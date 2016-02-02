import { Component } from 'react';

export default class SchemaSectionEditor extends Component {

  constructor(props){
    super(props);

    this.state = props.section || {};
  }

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

  componentWillReceiveProps = nextProps => {
    this.setState(nextProps.section || {});
  };

  render = () => {
    var { id, displayName, fields } = this.state;

    console.log(fields);

    return (
      <div className="panel panel-default">
        <div className="panel-heading">{displayName || id}</div>
        <div className="panel-body">
          {(fields || []).map(field => {
              return (
                <div key={field.name}>
                  <div>{field.displayName}</div>
                </div>
              );
          })}
          <button className="btn btn-default" onClick={this._handleAddField}>Add Field</button>
        </div>
      </div>
    );
  };
}
