import { app, BrowserWindow, ipcMain as ipc, IpcMessageEvent } from 'electron'
import api from './main/api'
import { PostMediaOptions } from './common'

declare var __dirname: string
let mainWindow: Electron.BrowserWindow

app.once('ready', () => {
  mainWindow = new BrowserWindow({
    width: 800,
    height: 600
  })

  const fileName = `file://${__dirname}/index.html`
  mainWindow.loadURL(fileName)
  mainWindow.on('close', () => app.quit())

  ipc.on('post-media:request', (event: IpcMessageEvent, args: PostMediaOptions) => {
    api.uploadMedia(args.contentType, args.filepath, (err: any) => {
      if (err) {
        event.sender.send('post-media:failed', err)
      } else {
        event.sender.send('post-media:completed')
      }
    })
  })

})

app.on('window-all-closed', () => app.quit())
