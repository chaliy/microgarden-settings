import React from 'react';
import SettingsSection from './SettingsSection';

export default ({ schema, data, onSubmit }) => {

  var changes = {};

  var handleSubmit = e => {
    e.preventDefault();
    onSubmit(changes);
  }

  var updateChanges = (sectionName, fieldName, value) => {
    changes = Object.assign(changes, {
      [sectionName]: Object.assign(changes[sectionName] || {}, {
        [fieldName]: value
      })
    });
  }

  return (
    <form onSubmit={handleSubmit}>
      {
        ((schema || {}).sections || []).map(section => {
          var onSectionChange = e => {
            updateChanges(section.name, e.name, e.value);
          };
          return (
            <SettingsSection
                key={section.name}
                values={data[section.name] || {}}
                onChange={onSectionChange}
                {...section} />
          );
        })
      }
      <button type="submit" className="btn btn-primary">Submit</button>
    </form>
  );
}
