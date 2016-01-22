import React from 'react';
import SettingsForm from '../components/SettingsForm';

import { retrieve } from '../utils/server';

const glue = (key, setState) => {
  setState({});
  (async () => {
    var response = await retrieve(`api/settings/instances/${key}`);
    var data = await response.json();

    setState({
      entity: data
    });
  })();
}

export default class SettingsEntity extends React.Component {

  constructor(){
    super();
    this.state = {};
  }

  componentWillMount() {
    var { key } = this.props.params;
    glue(key, s => this.setState(s));
  }

  render() {
    var { entity } = this.state;

    if (!entity) {
      return (<div>Loading...</div>);
    }

    var data = entity.data || {};

    return (<SettingsForm schema={entity.schema} data={data} />);
  }
}

SettingsEntity.propTypes = {
  params: React.PropTypes.object.isRequired
}
