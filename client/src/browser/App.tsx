import * as React from 'react'
import { withStyles } from 'material-ui/styles'
import AppBar from 'material-ui/AppBar'
import Toolbar from 'material-ui/Toolbar'
import Typography from 'material-ui/Typography'
import TitlebarGridList from './components/TitlebarGridList'

const styles = (theme: any) => ({
  root: {
    flexGrow: 1
  },
  control: {
    padding: theme.spacing.unit * 2
  }
})

class App extends React.Component<any> {
  constructor(props: any) {
    super(props)
  }
  render() {
    return (
      <div>
        <AppBar>
          <Toolbar>
            <Typography variant='title' color='inherit'>
              Title
          </Typography>
          </Toolbar>
        </AppBar>
        <TitlebarGridList />
      </div>
    )
  }
}

export default withStyles(styles)(App)
