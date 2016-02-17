import { IndexRoute, Route } from 'react-router';

import Home from './containers/Home';
import Entity from './containers/Entity';

export default (
  <Route path="settings">
    <IndexRoute component={Home} />
    <Route path=":id" component={Entity} />
  </Route>);
