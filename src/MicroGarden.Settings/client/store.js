import Rx from 'rx';
import { retrieve } from './utils/server';

var entities = [];

var replaceEntities = newEntities => {
  entities = newEntities;
  changed.onNext({
    entities: newEntities
  });
}

export const changed = new Rx.Subject();
export async function initStore() {
  var response = await retrieve('/api/schemas');
  var entities = await response.json();

  replaceEntities(entities);
}

export function getEntities() {
  return entities;
}

export function getEntity(key) {
  return entities.find(x => x.Key === key);
}
