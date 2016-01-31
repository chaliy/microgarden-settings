import {Component, PropTypes} from 'react';

export default class JsonTextField extends Component {

  render() {
    var props = this.props;

    var _readValue = () => {
      var val = this.context.data[props.name];
      if (val && typeof(val) === 'object') {
        return JSON.stringify(val);
      }
      return val;
    }

    return (
        <div key={props.name} className="form-group">
          <label htmlFor={props.name}>{props.displayName}</label>
          <textarea
            className="form-control"
            id={props.name}
            value={_readValue()}
            onChange={this.context.onChange}
            {...props}
            ></textarea>
          <p className="help-block">{props.help}</p>
        </div>
    );
  }
}

JsonTextField.contextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
