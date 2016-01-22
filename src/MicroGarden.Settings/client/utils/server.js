export const apiCallMiddleware = dispatch => next => async action => {
  if (action && action['API_CALL']) {
    var apiCall = action['API_CALL'];
    var options = Object.assign({
         credentials: 'same-origin',
         headers: {
             'Accept': 'application/json',
             'Content-Type': 'application/json'
         },
         method: apiCall.method || 'post',
         body: JSON.stringify(apiCall.data)
       },
       apiCall.options || {});

    var response = await fetch(apiCall.path, options);
    if (response.ok) {
      var result = await response.json();
      dispatch({
        type: action.type + '_SUCCESS',
        result: result
      })
    } else {
      dispatch({
        type: action.type + '_FAILURE',
        error: response
      })
    }
  } else {
      next(action);
  }
};
