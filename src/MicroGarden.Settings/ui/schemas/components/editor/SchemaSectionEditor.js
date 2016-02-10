import { Component } from 'react';
import { Modal, Button } from 'react-bootstrap';
import InputField from '../../../components/linked/InputField';
import { linkState } from '../../../components/linked/link';

export default class SchemaSectionEditor extends Component {

  constructor(props){
    super(props);

    this.state = props.section || {};
  }

  componentWillReceiveProps = nextProps => {
    this.setState(nextProps.section || {});
  };

  _invokeOnChange = () => {
    var { onChange } = this.props;
    if (onChange){
      onChange(this.state);
    }
  };

  _handleAddField = e => {
    e.preventDefault();
    var fields = this.state.fields || [];
    this.setState({
      fields: fields.concat({
        name: `field${fields.length}`,
        displayName: `Field #${fields.length}`
      })
    }, () => this._invokeOnChange());
  };

  _fieldEditHandler = field => {
    return e => {
      this.setState({
        currentField: Object.assign({}, field),
        showFieldEdit: true
      });
    }
  };

  _handleFieldEditClose = () => {
    this.setState({
      showFieldEdit: false
    });
  };

  _handleFieldEditSave = () => {
    var fields = this.state.fields || [];
    var currentField = this.state.currentField;
    fields.forEach(field => {
      if (field.name == currentField.name) {
        Object.assign(field, currentField);
      }
    });
    this.setState({
      fields: fields,
      showFieldEdit: false
    }, () => this._invokeOnChange());
  };

  render = () => {
    var { id, displayName, fields } = this.state;
    return (
      <div className="panel panel-default">
        <div className="panel-heading">{displayName || id}</div>
        <div className="panel-body">
          {(fields || []).map(field => {
              return (
                <div key={field.name}>
                  <div onClick={this._fieldEditHandler(field)}>{field.displayName}</div>
                </div>
              );
          })}
          <button className="btn btn-default" onClick={this._handleAddField}>Add Field</button>
        </div>
        <Modal show={this.state.showFieldEdit} onHide={this._handleFieldEditClose}>
          <Modal.Header closeButton>
            <Modal.Title>Edit field: {(this.state.currentField || {}).name}</Modal.Title>
          </Modal.Header>
          <Modal.Body>
            <InputField name="displayName" label="Display Name" link={linkState(this, 'currentField.displayName')} />
            <InputField name="description" label="Description"
              help="Short description of the field"
              link={linkState(this, 'currentField.description')} />
            <InputField name="help" label="Help" type="textarea"
              help="Help that will be displayed inline with field"
              link={linkState(this, 'currentField.help')} />
          </Modal.Body>
          <Modal.Footer>
            <Button onClick={this._handleFieldEditSave}>Save</Button>
            <Button onClick={this._handleFieldEditClose}>Close</Button>
          </Modal.Footer>
        </Modal>
      </div>
    );
  };
}
