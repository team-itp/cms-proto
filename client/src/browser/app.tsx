import * as React from 'react'
import PdfList from './components/pdf-list'
import NavigationBar from './components/navigation-bar'

class App extends React.Component<any> {
  constructor(props: any) {
    super(props)
  }
  render() {
    return (
      <div>
        <NavigationBar title='application' />
        <PdfList />
      </div>
    )
  }
}

export default App
