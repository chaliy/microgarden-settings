import {Component, PropTypes} from 'react';

export default class TextField extends Component {

  render() {
    var props = this.props;
    return (
        <div key={props.name} className="form-group">
          <label htmlFor={props.name}>{props.displayName}</label>
          <input
            className="form-control"
            id={props.name}
            value={this.context.data[props.name]}
            onChange={this.context.onChange}
            {...props}
            />          
          <p className="help-block">{props.help}</p>
        </div>
    );
  }
}

TextField.contextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
