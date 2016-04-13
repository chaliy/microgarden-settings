import { listApi } from '../utils/dc/apis';

export const instancesApi = listApi({
  baseUrl: '/settings/api/instances'
});

export const dataApi = listApi({
  baseUrl: '/settings/api/data'
});
