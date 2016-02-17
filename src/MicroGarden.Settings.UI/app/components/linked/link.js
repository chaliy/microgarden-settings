export class ValueLink {
  constructor(options){
      this.value = options.value;
      this.change = options.change;
  }
}

export function linkState(component, path){
  return new ValueLink({
    value: () => {
      var state = component.state;
      var tokens = path.split('.');
      for(var token of tokens) {
        state = state[token];
        if (state == undefined) {
          break;
        }
      }
      return state;
    },
    change: e => {

      var state = component.state;
      var tokens = path.split('.');
      var changeRoot;
      var change;
      while(tokens.length > 0){
        var token = tokens.shift();
        if (!changeRoot){
          change = changeRoot = {
            [token]: state[token] || {}
          }
        }
        if (tokens.length == 0) {
          change[token] = e.target.value;
        } else {
          change = change[token] = change[token] || {};
        }
      }
      component.setState(changeRoot);
    }
  })
}
