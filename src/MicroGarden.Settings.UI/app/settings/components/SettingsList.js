import React from 'react';
import { Link } from 'react-router';

export default ({ items }) => {
  return (
    <div>
      {
        (items || []).map(item => {
          return (
            <div key={item.id}>
              <Link to={`/settings/${item.id}`}><h3>{item.displayName}</h3></Link>
              <p>{item.displayName}</p>
            </div>
          );
        })
      }
    </div>
  );
}
