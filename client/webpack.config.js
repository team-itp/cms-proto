const path = require('path')

const commonConfig = {
    node: {
        __dirname: false
    },
    output: {
        path: path.resolve(__dirname, 'dist'),
        filename: '[name].js'
    },
    module: {
        rules: [
            {
                test: /\.ts?$/,
                enforce: 'pre',
                loader: 'tslint-loader',
                options: {
                    typeCheck: true,
                    emitErrors: true
                }
            },
            {
                test: /\.tsx?$/,
                loader: 'ts-loader'
            }
        ]
    },
    resolve: {
        extensions: ['.js', '.ts', '.tsx', '.jsx', '.json']
    }
}

const HtmlWebpackPlugin = require('html-webpack-plugin')

module.exports = [
    Object.assign(
        {
            target: 'electron-main',
            entry: { main: './src/main.ts' }
        },
        commonConfig),
    Object.assign(
        {
            target: 'electron-renderer',
            entry: { renderer: './src/renderer.tsx' },
            plugins: [new HtmlWebpackPlugin()]
        },
        commonConfig)
]
