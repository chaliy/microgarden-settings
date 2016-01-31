import { listApi } from '../utils/dc/apis';

export const instancesApi = listApi({
  baseUrl: '/api/settings/instances'
});

export const dataApi = listApi({
  baseUrl: '/api/settings/data'
});
