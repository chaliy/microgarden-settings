import { IndexRoute, Route } from 'react-router';

import Home from './containers/Home';
import Create from './containers/Create';
import Update from './containers/Update';

export default (
  <Route path="schemas">
    <IndexRoute component={Home} />
    <Route path="create" component={Create} />
    <Route path=":id" component={Update} />
  </Route>);
