import React from 'react';
import { Link } from 'react-router';

export default function SettingsList ({entities}) {
  return (
    <div>
      {
        (entities || []).map(entity => {
          return (
            <div key={entity.name}>
              <Link to={`/settings/${entity.name}`}><h3>{entity.displayName}</h3></Link>
              <p>{entity.displayName}</p>
            </div>
          );
        })
      }
    </div>
  );
}
