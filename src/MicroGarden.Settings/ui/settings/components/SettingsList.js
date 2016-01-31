import React from 'react';
import { Link } from 'react-router';

export default ({ items }) => {
  return (
    <div>
      {
        (items || []).map(item => {
          return (
            <div key={item.name}>
              <Link to={`/settings/${item.name}`}><h3>{item.displayName}</h3></Link>
              <p>{item.displayName}</p>
            </div>
          );
        })
      }
    </div>
  );
}
