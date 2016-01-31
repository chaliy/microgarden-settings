import React from 'react';
import { render } from 'react-dom';
import { hashHistory, Router, Route } from 'react-router';

import App from './components/App';
import SettingsRoutes from './settings/routes';
import SchemasRoutes from './schemas/routes';

render((
  <Router history={hashHistory}>
    <Route path="/" component={App}>
      {SettingsRoutes}
      {SchemasRoutes}
    </Route>
  </Router>
), document.getElementById('app'));
