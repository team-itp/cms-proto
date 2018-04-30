import * as React from 'react'
import { PDFJSStatic } from 'pdfjs-dist'

let PDFJS: PDFJSStatic = require('pdfjs-dist')

interface PdfImageProps {
  src: string
  alt: string
  width?: number
  height?: number
}

interface PdfImageState {
  page: number
  isPortrait?: boolean
}

class PdfImage extends React.Component<PdfImageProps, PdfImageState> {
  constructor(props: PdfImageProps) {
    super(props)
    this.state = {
      page: 1
    }
  }

  componentDidMount() {
    this.renderPdf()
  }

  renderPdf() {
    PDFJS.getDocument(this.props.src).then(pdfDoc => {
      pdfDoc.getPage(this.state.page).then(page => {
        const container = this.refs.container as HTMLElement
        const canvas = this.refs.canvas as HTMLCanvasElement
        const context = canvas.getContext('2d')!
        let viewport = page.getViewport(1)
        const isPortrait = Math.max(viewport.height, viewport.width) === viewport.height
        let ratio = isPortrait
          ? (container.clientHeight / viewport.height)
          : (container.clientWidth / viewport.width)
        viewport = page.getViewport(ratio)
        canvas.height = viewport.height
        canvas.width = viewport.width
        if (page.pageNumber !== this.state.page ||
          isPortrait !== this.state.isPortrait) {
          this.setState({
            page: this.state.page,
            isPortrait: isPortrait
          })
        }
        page.render({
          canvasContext: context,
          viewport: viewport
        })
      })
    })
  }

  render() {
    return <div ref='container' style={{ height: '100%' }}>
      <canvas ref='canvas' title={this.props.alt} width={this.props.width} height={this.props.height} style={ this.state.isPortrait ? undefined : { width: '100%' }} />
    </div>
  }
}

export default PdfImage
