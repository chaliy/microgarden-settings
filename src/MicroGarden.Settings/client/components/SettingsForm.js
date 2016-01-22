import React from 'react';
import SettingsSection from './SettingsSection';

export default class SettingsForm extends React.Component {

  constructor(){
    super();
  }

  render() {
    var { schema, data } = this.props;

    var sections = schema.sections || [];

    return (
      <div>
        <h2>Settings</h2>
        <form onSubmit={e => {
          console.log(this.state);
        }}>
          {
            (sections).map(section => {
              var values = data[section.name] || {};
              var onChange = e => {
                this.setState({
                  [section.name + '.' + e.name]: e.value
                });
              };
              return (
                <SettingsSection key={section.name} {...section} values={values} onChange={onChange} />
              );
            })
          }
          <button type="submit" className="btn btn-primary">Submit</button>
        </form>
      </div>
    );
  }
}

SettingsForm.propTypes = {
  schema: React.PropTypes.object.isRequired,
  data: React.PropTypes.object.isRequired
}
