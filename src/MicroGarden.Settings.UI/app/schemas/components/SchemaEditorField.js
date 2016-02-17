import {Component, PropTypes} from 'react';

import SchemaEditor from './editor/SchemaEditor';

export default class SchemaEditorField extends Component {

  render() {
    var { name, displayName, help } = this.props;

    var _readValue = () => {      
      return this.context.data[name];
    };

    var _handleEditorOnChange = schema => {
      this.context.onChange({
        name: name,
        value: schema
      });
    };

    return (
        <div className="form-group">
          <label htmlFor={name}>{displayName}</label>

          <SchemaEditor
            schema={_readValue()}
            onChange={_handleEditorOnChange} />

          <p className="help-block">{help}</p>
        </div>
    );
  }
}

SchemaEditorField.contextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
