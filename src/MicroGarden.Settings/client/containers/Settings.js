import React from 'react';
import { reload } from '../actions';
import { getEntities } from '../store';
import { updateSettings } from '../actions';
//import { dispatch, subscribe } from 'rlux';
import { dispatch, subscribe } from '../utils/rlux';

import SettingsList from '../components/SettingsList';

export default class Settings extends React.Component {

  constructor(){
    super();
    var self = this;

    self.state = {
      entities: getEntities()
    };
    reload.forEach(e => {
      self.setState({
        entities: e.entities
      });
    });

    var a = subscribe(e => {
      console.log('e', e);
    });
    console.log(a);

    dispatch(updateSettings('test', {}));

    a.dispose();
  }

  render() {
    var { entities } = this.state;
    return (
      <div>
        <h2>Settings</h2>
        <SettingsList entities={entities} />
      </div>
    );
  }
}
