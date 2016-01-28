import React from 'react';

import TextField from './fields/TextField';
import FallbackField from './fields/FallbackField';

export default ({ displayName, fields, values, onChange }) => {

  return (
    <div>
      <h2>{displayName}</h2>
      {
        (fields || []).map(field => {
          var defaultValue = values[field.name];

          if (field.type === 'text') {
            return <TextField key={field.name} field={field} defaultValue={defaultValue} onChange={onChange} />
          }
          console.warn(`SettingsSection does not support ${field.type}`);
          return <FallbackField key={field.name} field={field} defaultValue={defaultValue} onChange={onChange} />
        })
      }
    </div>
  );
}
