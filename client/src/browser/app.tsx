import * as React from 'react'
import CssBaseline from 'material-ui/CssBaseline'
import PdfList from './components/pdf-list'
import NavigationBar from './components/navigation-bar'
import MediaUploader from './components/media-uploader'

const styles = {
  root: {
    flexGrow: 1,
    zIndex: 1,
    overflow: 'hidden',
    display: 'flex',
    position: 'relative',
    padding: 8,
    paddingTop: 72
  },
  navigationBar: {
    zIndex: 2,
    height: 64
  },
  mediaUploader: {
    position: 'fixed',
    width: 400
  },
  content: {
    position: 'fixed',
    top: 64,
    bottom: 0,
    left: 408,
    right: 0,
    padding: 8,
    overflowY: 'auto'
  }
}

class App extends React.Component<any> {
  constructor(props: any) {
    super(props)
  }
  render() {
    return (
      <CssBaseline>
        <div style={styles.root as React.CSSProperties}>
          <NavigationBar title='application' style={styles.navigationBar as React.CSSProperties} />
          <MediaUploader style={styles.mediaUploader as React.CSSProperties} />
          <main style={styles.content as React.CSSProperties}>
            <PdfList />
          </main>
        </div>
      </CssBaseline>
    )
  }
}

export default App
