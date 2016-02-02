import {Component, PropTypes} from 'react';

export default class JsonTextField extends Component {

  render() {    
    var { name, displayName, help } = this.props;

    var _readValue = () => {
      var val = this.context.data[name];
      if (val && typeof(val) === 'object') {
        return JSON.stringify(val);
      }
      return val;
    }

    return (
        <div className="form-group">
          <label htmlFor={name}>{displayName}</label>
          <textarea
            className="form-control"
            id={name}
            value={_readValue()}
            onChange={this.context.onChange}
            {...this.props}
            ></textarea>
          <p className="help-block">{help}</p>
        </div>
    );
  }
}

JsonTextField.contextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
