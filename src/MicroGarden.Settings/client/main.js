import React from 'react';
import { render } from 'react-dom'
import { browserHistory, Router, Route, IndexRoute } from 'react-router'

import Settings from './containers/Settings';
import SettingsEntity from './containers/SettingsEntity';

import { reload } from './actions';
import { changed, initStore } from './store';
import { apiCallMiddleware } from './utils/server';
import { use, loggingMiddleware } from './utils/rlux';
//import { use, loggingMiddleware } from 'rlux';


use(loggingMiddleware);
use(apiCallMiddleware);

changed.forEach(e => {
  reload.onNext(e);
})

initStore();

class App extends React.Component {
  render() {
    return (
      <div>
        {this.props.children}
      </div>
    );
  }
}
render((
  <Router history={browserHistory}>
    <Route path="/" component={App}>
      <IndexRoute component={Settings} />
      <Route path="settings/:key" component={SettingsEntity} />
    </Route>
  </Router>
), document.getElementById('app'))
