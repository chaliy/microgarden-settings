function _fetch(path, options) {
  options = options || {};
  var fetchOptions = Object.assign({
       credentials: 'same-origin',
       headers: {
           'Accept': 'application/json',
           'Content-Type': 'application/json'
       },
       method: options.method || 'get'
     }, options);

   return new Promise(async (resolve, reject) => {
     var response = await fetch(path, fetchOptions);
     if (response.ok) {
       var result = await response.json();
       resolve(result);
     } else {
       reject(response);
     }
   });
}

export const listApi = ({ baseUrl, loadUrl, updateUrl, createUrl }) => {

  return {

    loadItems: () => _fetch(`${baseUrl}`),

    load: id => _fetch(`${loadUrl || baseUrl}/${id}`),

    update: (id, data) => _fetch(`${updateUrl || baseUrl}/${id}`, {
      method: 'put',
      body: JSON.stringify(data)
    }),

    create: data => _fetch(`${createUrl || baseUrl}`, {
      method: 'post',
      body: JSON.stringify(data)
    })

  };
};
