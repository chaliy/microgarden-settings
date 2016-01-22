import React from 'react';
import SettingsForm from '../components/SettingsForm';

import { dispatch, subscribe } from '../utils/rlux';

import { updateSettingsItem, UPDATE_SETTINGS_ITEM } from '../actions';
import { loadSettingsItem, LOAD_SETTINGS_ITEM } from '../actions';

export default class SettingsEntity extends React.Component {

  constructor(props){
    super(props);

    this.state = {};
    this.name = props.params.name;

    this.subscription = subscribe(a => {

      switch(a.type) {
        case `${UPDATE_SETTINGS_ITEM}_SUCCESS`:
          this.setState({
            data: a.result
          });
          break;

        case `${LOAD_SETTINGS_ITEM}_SUCCESS`:
          this.setState(a.result);
          break;
      }

    });
  }

  componentWillMount() {
    dispatch(loadSettingsItem(this.name));
  }

  componentWillUnmount() {
    this.subscription.end();
  }

  handleSubmit(changes) {
    dispatch(updateSettingsItem(this.name, changes));
  }

  render() {
    var { schema, data } = this.state;

    if (!schema) {
      return (<div>Loading...</div>);
    }

    return (<SettingsForm
              schema={schema}
              data={data || {}}
              onSubmit={this.handleSubmit.bind(this)} />);
  }
}

SettingsEntity.propTypes = {
  params: React.PropTypes.object.isRequired
}
