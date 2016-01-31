import Sidebar from 'react-sidebar';
import { Link } from 'react-router';

import './App.css';

var sidebar = (
  <div>
    <h2>Settings</h2>
    <Link to="/settings">Settings</Link>
    <hr />
    <Link to="/schemas">Schemas</Link>
  </div>
);

export default ({children}) => {
  return (
    <Sidebar sidebar={sidebar} docked sidebarClassName="left-sidebar" >
      <div id="main" className="conatiner">
        {children}
      </div>
    </Sidebar>
  );
};
