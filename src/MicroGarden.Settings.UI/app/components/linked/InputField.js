import { Component, PropTypes } from 'react';
import { Input } from 'react-bootstrap';

export default class InputField extends Component {

  render() {
    var { link } = this.props;
    var props = Object.assign({
      type: 'text'
    }, this.props);

    return <Input
              value={link.value()}
              onChange={link.change}
              {...props} />
  }
}
