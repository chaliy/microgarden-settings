import { Component, createElement } from 'react';

export const wire = ({ mount, unmount }) => component => {

  class Wrapper extends Component {

    componentWillMount = () => {
      if (mount) {
        mount(this);
      }
    };

    componentWillUnmount = () => {
      if (unmount) {
        unmount(this);
      }
    };

    render = () => {
      return createElement(component, this.state);
    };
  }

  return Wrapper;
};


export const wireList = ({ loadItems }) => {

  return wire({
    mount: async instance => {
      var response = await loadItems();
      instance.setState({
        items: response
      });
    }
  });

};

export const wireUpdate = ({ load, update, success }) => {

  return wire({
    mount: async instance => {
      var id = instance.props.params.id;
      instance.setState({
        data: await load(id),
        onSubmit: async data => {
          var response = await update(id, data);
          if (success) {
            success({
              response,
              instance
            });
          }
        }
      });
    }
  });
};

export const wireCreate = ({ create, success }) => {

  return wire({
    mount: async instance => {
      var state = {
        onSubmit: async data => {
          var response = await create(data);
          if (success) {
            success({
              response,
              instance
            });
          }
        }
      };
      instance.setState(state);
    }
  });
};
