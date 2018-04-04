module.exports = [
    Object.assign(
        {
            target: 'electron-main',
            entry: { main: './src/main.ts' }
        },
        require('./config/webpack/webpack.main.config.js')),
    Object.assign(
        {
            target: 'electron-renderer',
            entry: { renderer: './src/renderer.ts' },
        },
        require('./config/webpack/webpack.renderer.config.js'))
]