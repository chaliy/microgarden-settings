var webpack = require('webpack');
var path = require('path');

module.exports = {
    entry: {
        vendor: [
            'react',
            'react-router',
            'react-dom',
            'babel-polyfill',
            'fetch-polyfill'
        ],
        main: './client/main'
    },
    output: {
        path: path.resolve(__dirname, 'wwwroot/js'),
        publicPath: 'js/',
        filename: '[name].js'
    },
    module: {
        loaders: [
            { test: /\.scss$/, loader: 'style!css!autoprefixer!sass' },
            { test: /\.css$/, loader: 'style!css' },
            {
                test: /\.jsx?$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'babel',
                query: {
                    cacheDirectory: true,
                    presets: ['react', 'es2015'],
                    plugins: ['syntax-async-functions', 'transform-regenerator']
                }
            },
            {
                test: /\.(jpeg|gif|png).*/,
                exclude: /(node_modules|bower_components)/,
                loader: 'url?limit=1000&name=[name].[hash].[ext]'
            },
            { test: /\.(woff|woff2).*/, loader: 'url?limit=10000&mimetype=application/font-woff&name=[name].[hash].[ext]' },
            { test: /\.ttf.*/, loader: 'url?limit=10000&mimetype=application/octet-stream&name=[name].[hash].[ext]' },
            { test: /\.eot.*/, loader: 'file' },
            { test: /\.svg.*/, loader: 'url?limit=10000&mimetype=image/svg+xml&name=[name].[hash].[ext]' }
        ]
    },
    resolve: {
        extensions: ['', '.js', '.jsx']
    },
    plugins: [
        new webpack.ProvidePlugin({
            'Router': 'react-router',
            'React': 'react',
            'ReactDOM': 'react-dom'
        }),
        new webpack.optimize.CommonsChunkPlugin(
            /* chunkName= */'vendor',
            /* filename= */'vendor.js'
        ),
        new webpack.NoErrorsPlugin()
    ]
};
