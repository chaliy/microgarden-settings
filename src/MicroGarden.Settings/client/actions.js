import Rx from 'rx';

export const init = new Rx.Subject();
export const reload = new Rx.Subject();

export const UPDATE_SETTINGS = 'UPDATE_SETTINGS';

export const updateSettings = (sectionName, changes) => ({
  type: UPDATE_SETTINGS,
  API_CALL: {
    path: '/some/some',
    method: 'put',
    data: {
      sectionName,
      changes
    }
  }
});
