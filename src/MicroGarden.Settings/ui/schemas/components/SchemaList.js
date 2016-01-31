import React from 'react';
import { Link } from 'react-router';

export default ({ items }) => {
  return (
    <div>
      <div className="btn-toolbar" role="toolbar" aria-label="Operations on shemas list">
        <Link to="/schemas/create" className="btn btn-default">Create</Link>
      </div>
      {
        (items || []).map(item => {
          return (
            <div key={item.id}>
              <Link to={`/schemas/${item.id}`}><h3>{item.displayName}</h3></Link>
              <p>{item.displayName}</p>
            </div>
          );
        })
      }
    </div>
  );
}
