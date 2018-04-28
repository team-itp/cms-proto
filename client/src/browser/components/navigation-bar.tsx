import * as React from 'react'
import AppBar from 'material-ui/AppBar'
import Toolbar from 'material-ui/Toolbar'
import Typography from 'material-ui/Typography'

interface NavigationBarProps {
  title: string
}

class NavigationBar extends React.Component<NavigationBarProps> {
  constructor(props: NavigationBarProps) {
    super(props)
  }

  render() {
    return (
      <AppBar>
        <Toolbar>
          <Typography variant='title' color='inherit'>
            {this.props.title}
          </Typography>
        </Toolbar>
      </AppBar>
    )
  }
}

export default NavigationBar
