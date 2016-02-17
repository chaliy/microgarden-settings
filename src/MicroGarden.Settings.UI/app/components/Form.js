import { Component, PropTypes } from 'react';

export default class Form extends Component {

  getData = () => {
    return Object.assign({}, this.props.data || {}, this.state);
  };

  getChildContext = () => {
    return {
      onChange: e => {
        var name = e.target ? e.target.name : e.name;
        var value = e.target ? e.target.value : e.value;

        this.handleChanges({
          [name]: value
        });
      },
      data: this.getData()
    };
  };

  handleChanges = changes => {
    this.setState(changes);
  };

  handleSubmit = e => {
    e.preventDefault();
    var { onSubmit } = this.props;
    if (onSubmit) {
      onSubmit(this.getData());
    }
  };

  render = () => {
    var { children } = this.props;
    return (
      <form onSubmit={this.handleSubmit}>
        {children}
        <button type="submit" className="btn btn-primary">Submit</button>
      </form>
    );
  };
}

Form.propTypes = {
  onSubmit: PropTypes.func,
  children: PropTypes.any,
  data: PropTypes.any
};

Form.childContextTypes = {
  onChange: PropTypes.func,
  data: PropTypes.any
};
