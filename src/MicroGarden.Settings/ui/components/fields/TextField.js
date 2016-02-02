import { Component, PropTypes } from 'react';

export default class TextField extends Component {

  render() {
    var { name, displayName, help } = this.props;

    return (
        <div className="form-group">
          <label htmlFor={name}>{displayName}</label>
          <input
            className="form-control"
            id={name}
            value={this.context.data[name]}
            onChange={this.context.onChange}
            {...this.props}
            />
          <p className="help-block">{help}</p>
        </div>
    );
  }
}

TextField.contextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
