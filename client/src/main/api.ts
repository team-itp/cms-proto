import * as request from 'request'
import * as fs from 'fs'

const endPoints = {
  media: 'http://localhost/wp-json/wp/v2/media'
}

const uploadMedia = (title: string, filepath: string, callback: (err: any) => void) => {
  fs.exists(filepath, exists => {
    if (!exists) {
      callback('ファイルが存在しません。')
    }

    const headers = {
      'Content-Type': 'multipart/form-data',
      'Authorization': 'Bearer ' + 'Bearer ' + Buffer.from('admin:admin').toString('base64')
    }

    const formData = {
      title: title,
      content: 'Post body',
      'media[0]': fs.createReadStream(filepath),
      'media_attrs[0][caption]': title
    }

    const requestOptions = {
      url: endPoints.media,
      headers: headers,
      formData: formData
    }

    request.post(requestOptions, (error, response, body) => {
      console.log(error)
      console.log(body)

      if (response.statusCode === 401) {
        callback('認証に失敗しました。')
        return
      }

      if (response.statusCode !== 200) {
        callback('リクエストに失敗しました。(ステータスコード:' + response.statusCode + ')')
        return
      }

      callback(null)
    })
  })
}

const api = {
  uploadMedia
}

export default api
