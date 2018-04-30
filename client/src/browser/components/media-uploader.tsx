import * as React from 'react'
import Paper from 'material-ui/Paper'

interface MediaUploaderProps {
  style?: React.CSSProperties
}

class MediaUploader extends React.Component<MediaUploaderProps> {
  constructor(props: MediaUploaderProps) {
    super(props)
  }

  render() {
    return <div style={this.props.style}>
      <Paper>
        {'test'}
      </Paper>
    </div>
  }
}

export default MediaUploader
