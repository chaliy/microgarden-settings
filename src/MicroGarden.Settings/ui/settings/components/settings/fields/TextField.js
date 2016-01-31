import React from 'react';

export default ({ field, defaultValue, onChange }) => {
  var localOnChange = e => {
    onChange({
      name: field.name,
      value: e.target.value
    });
  }
  return (
          <div key={field.name} className="form-group">
            <label htmlFor={field.name}>{field.displayName}</label>
            <input
              {...field}
              className="form-control"
              id={field.name}
              defaultValue={defaultValue}
              onChange={localOnChange}
              />
          </div>
        );
}
