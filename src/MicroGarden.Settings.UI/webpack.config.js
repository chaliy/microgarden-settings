var webpack = require('webpack');
var HtmlWebpackPlugin = require('html-webpack-plugin');
var config = require('microgarden-ui-sdk/webpack.config.factory')({
  entry: {
        vendor: [
            'react',
            'react-router',
            'react-dom',
            'babel-polyfill',
            'fetch-polyfill'
        ],
        main: './app/main'
    },
    output: {
        path: '../MicroGarden.Settings/wwwroot',
        publicPath: '/',
        filename: 'js/[name].js'
    },
    plugins: [
        new webpack.ProvidePlugin({
            'Router': 'react-router',
            'React': 'react',
            'ReactDOM': 'react-dom'
        }),
        new webpack.optimize.CommonsChunkPlugin(
            /* chunkName= */'vendor',
            /* filename= */'js/vendor.js'
        ),
        new webpack.NoErrorsPlugin(),
        new HtmlWebpackPlugin({  // Also generate a test.html
          template: 'templates/index.html'
       })

    ],
});

module.exports = config;
