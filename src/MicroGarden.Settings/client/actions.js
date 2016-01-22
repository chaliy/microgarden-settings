export const LOAD_SETTINGS = 'LOAD_SETTINGS';
export const LOAD_SETTINGS_ITEM = 'LOAD_SETTINGS_ITEM';
export const UPDATE_SETTINGS_ITEM = 'UPDATE_SETTINGS_ITEM';

export const loadSettings = () => ({
  type: LOAD_SETTINGS,
  API_CALL: {
    path: '/api/settings/instances',
    method: 'get'
  }
});

export const loadSettingsItem = (name) => ({
  type: LOAD_SETTINGS_ITEM,
  API_CALL: {
    path: `/api/settings/instances/${name}`,
    method: 'get'
  }
});

export const updateSettingsItem = (name, changes) => ({
  type: UPDATE_SETTINGS_ITEM,
  API_CALL: {
    path: `/api/settings/data/${name}`,
    method: 'put',
    data: changes
  }
});
