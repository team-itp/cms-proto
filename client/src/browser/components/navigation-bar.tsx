import * as React from 'react'
import AppBar from 'material-ui/AppBar'
import Toolbar from 'material-ui/Toolbar'
import Typography from 'material-ui/Typography'

interface NavigationBarProps {
  title: string
  style?: React.CSSProperties
}

class NavigationBar extends React.Component<NavigationBarProps> {
  constructor(props: NavigationBarProps) {
    super(props)
  }

  render() {
    return (
      <div style={this.props.style}>
        <AppBar position='fixed'>
          <Toolbar>
            <Typography variant='title' color='inherit' noWrap>
              {this.props.title}
            </Typography>
          </Toolbar>
        </AppBar>
      </div>
    )
  }
}

export default NavigationBar
