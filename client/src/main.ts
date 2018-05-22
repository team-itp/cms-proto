import { app, BrowserWindow, ipcMain, IpcMessageEvent } from 'electron'

declare var __dirname: string
let mainWindow: Electron.BrowserWindow

function onReady() {
  mainWindow = new BrowserWindow({
    width: 800,
    height: 600
  })

  const fileName = `file://${__dirname}/index.html`
  mainWindow.loadURL(fileName)
  mainWindow.on('close', () => app.quit())
}

app.on('ready', () => onReady())
app.on('window-all-closed', () => app.quit())
console.log(`Electron Version ${app.getVersion()}`)

ipcMain.on('send', (event: IpcMessageEvent) => {
  event.sender.send('send_complete')
})
