import React from 'react';
//import { dispatch, subscribe } from 'rlux';
import { dispatch, subscribe } from '../utils/rlux';

import SettingsList from '../components/SettingsList';

import { loadSettings, LOAD_SETTINGS } from '../actions';

export default class Settings extends React.Component {

  constructor(){
    super();
    this.state = {};

    this.unsubscribe = subscribe(a => {

      switch(a.type) {
        case `${LOAD_SETTINGS}_SUCCESS`:
          this.setState({
            items: a.result
          });
          break;
      }

    });
  }

  componentWillMount() {
    dispatch(loadSettings());
  }

  componentWillUnmount() {
    this.unsubscribe();
  }

  render() {
    var { items } = this.state;
    return (
      <div>
        <h2>Settings</h2>
        <SettingsList items={items} />
      </div>
    );
  }
}
