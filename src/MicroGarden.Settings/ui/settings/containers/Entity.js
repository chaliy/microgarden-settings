import React from 'react';

import { wireUpdate } from '../../utils/dc/wires';

import { instancesApi, dataApi } from '../api';
import SettingsForm from '../components/settings/SettingsForm';

var Entity = props => (
    <div>
      <h2>Settings: {props.displayName}</h2>
      <SettingsForm {...props} />
    </div>
);

export default wireUpdate({
  load: instancesApi.load,
  update: dataApi.update,
  success: ({response, instance}) => {
    instance.setState({
      data: response
    });
  }
})(Entity);
