import React from 'react';

export default ({ displayName, fields, values, onChange }) => {
  var localOnChange = (e, field) => {
    onChange({
      name: field.name,
      value: e.target.value
    });
  }

  return (
    <div>
      <h2>{displayName}</h2>
      {
        (fields || []).map(field => {

          return (
            <div key={field.name} className="form-group">
              <label htmlFor={field.name}>{field.displayName}</label>
              <input
                className="form-control"
                id={field.name}
                type={field.type}
                defaultValue={values[field.name]}
                onChange={e => localOnChange(e, field)}
                />
            </div>
          );
        })
      }
    </div>
  );
}
