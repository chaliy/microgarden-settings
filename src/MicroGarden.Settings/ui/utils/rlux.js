var _subscribers = [];
var _push = e => {
  for(var subscriber of _subscribers) {
    subscriber(e);
  }
}
var _dispatch = _push;

export function dispatch(e) {
  _dispatch(e);
}

export function use(m) {
  _dispatch = m(dispatch)(_dispatch);
}

export function subscribe(next) {
  _subscribers.push(next);
  return {
    end: () => {
      var index = _subscribers.indexOf(next);
      if (index >= 0) {
        _subscribers.slice(index, 1);
      }
    }
  }
}

export const loggingMiddleware = () => next => action => {
  console.log('Action: ', action);
  next(action);
};

// export const sampleMiddleware = dispatch => next => action => {
//   console.log(dispatch, next, action);
//   next(action);
// };
