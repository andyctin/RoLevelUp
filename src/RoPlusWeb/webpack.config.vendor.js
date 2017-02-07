var isDevBuild = process.argv.indexOf('--env.prod') < 0;
var path = require('path');
var webpack = require('webpack');
var ExtractTextPlugin = require('extract-text-webpack-plugin');
var extractCSS = new ExtractTextPlugin('vendor.css');

module.exports = {
    resolve: {
        extensions: ['', '.js']
    },
    module: {
        loaders: [
            { test: /bootstrap.+\.(jsx|js)$/, loader: 'imports-loader?jQuery=jquery,$=jquery,this=>window' },
            { test: /\.(png|woff|woff2|eot|ttf|svg)(\?|$)/, loader: 'url-loader?limit=100000' },
            { test: /\.css(\?|$)/, loader: extractCSS.extract(['css']) },
            { test: require.resolve("jquery"), loader: "expose?$!expose?jQuery" }
        ]
    },
    entry: {
        vendor: [
            '@angular/common',
            '@angular/compiler',
            '@angular/core',
            '@angular/http',
            '@angular/platform-browser',
            '@angular/platform-browser-dynamic',
            '@angular/router',
            '@angular/platform-server',
            'angular2-universal',
            'angular2-universal-polyfills',
            'jquery',
            'tether',
            'bootstrap',
            'bootstrap/dist/css/bootstrap.css',
            'bootstrap/dist/js/bootstrap.js',
            'font-awesome/css/font-awesome.css',
            'es6-shim',
            'es6-promise',
            'zone.js',
        ]
    },
    output: {
        path: path.join(__dirname, 'wwwroot', 'dist'),
        filename: '[name].js',
        library: '[name]_[hash]',
    },
    plugins: [
        extractCSS,
        new webpack.ProvidePlugin({
            $: 'jquery', jQuery: 'jquery', jquery: 'jquery', "windows.jQuery": "jquery",
            tether: 'tether', Tether: 'tether', 'window.Tether': 'tether',
        }), // Maps these identifiers to the jQuery package (because Bootstrap expects it to be a global variable)
        new webpack.optimize.OccurenceOrderPlugin(),
        new webpack.DllPlugin({
            path: path.join(__dirname, 'wwwroot', 'dist', '[name]-manifest.json'),
            name: '[name]_[hash]'
        })
    ].concat(isDevBuild ? [] : [
        new webpack.optimize.UglifyJsPlugin({ compress: { warnings: false } })
    ])
};
