import { Component } from 'react';
import SchemaSectionEditor from './SchemaSectionEditor';

export default class SchemaEditor extends Component {

  constructor(props){
    super(props);

    this.state = props.schema || {};
  }

  _invokeOnChange = () => {
    var { onChange } = this.props;
    if (onChange){
      onChange(this.state);
    }
  };

  _handleAddSection = e => {
    e.preventDefault();

    var sections = this.state.sections || [];

    this.setState({
      sections: sections.concat({
        id: `section${sections.length}`,
        displayName: `Section #${sections.length}`
      })
    }, () => this._invokeOnChange());
  };

  _handleSectionOnChange = section => {
    var sections = this.state.sections || [];

    for(var s of sections) {
      if (s.id == section.id) {
        s.displayName = section.displayName;
        s.fields = section.fields;
      }
    }

    this.setState({
      sections: sections
    }, () => this._invokeOnChange());
  };

  componentWillReceiveProps = nextProps => {
    this.setState(nextProps.schema || {});
  };

  render = () => {
    var { sections } = this.state;

    return (
      <div>
        {(sections || []).map(section => {
          return <SchemaSectionEditor
                    key={section.id}
                    section={section}
                    onChange={this._handleSectionOnChange} />;
        })}
        <button className="btn btn-default" onClick={this._handleAddSection}>Add Section</button>
      </div>
    );
  };
}
