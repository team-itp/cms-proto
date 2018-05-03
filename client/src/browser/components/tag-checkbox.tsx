import * as React from 'react'
import Checkbox from 'material-ui/Checkbox'
import { FormControl, FormLabel, FormControlLabel, FormGroup } from 'material-ui/Form'
import ExpansionPanel, { ExpansionPanelSummary, ExpansionPanelDetails } from 'material-ui/ExpansionPanel'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import Typography from 'material-ui/Typography'
import { Tag } from '../../common/wp-api'

interface TagCheckboxProps {
  displayName: string
  selection: Tag[]
  defaultChecked: Tag[]
  required?: boolean
}

interface TagCheckboxState {
  selectedList: Tag[]
}

class TagCheckbox extends React.Component<TagCheckboxProps, TagCheckboxState> {
  constructor(props: TagCheckboxProps) {
    super(props)
    this.state = {
      selectedList: []
    }
  }

  handleCheckChanged(event: any, value: Tag): void {
    if (event.target.checked) {
      if (this.state.selectedList.filter(v => v.slug === value.slug).length === 0) {
        const selectedList = this.state.selectedList.slice()
        selectedList.push(value)
        this.setState({
          selectedList: selectedList.sort((a, b) => a.name.localeCompare(b.name))
        })
      }
    } else {
      const delList = this.state.selectedList.filter(v => v.slug === value.slug)
      if (delList) {
        const selectedList = this.state.selectedList.slice()
        delList.forEach(v => {
          selectedList.splice(selectedList.indexOf(v), 1)
        })
        this.setState({
          selectedList: selectedList.sort((a, b) => a.name.localeCompare(b.name))
        })
      }
    }
  }

  render() {
    return (
      <ExpansionPanel defaultExpanded>
        <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
          <FormLabel component='label'>{this.props.displayName}</FormLabel>
          <Typography style={{ lineHeight: 1, fontSize: '1rem', position: 'absolute', left: '7em' }}>{this.state.selectedList ? this.state.selectedList.map(v => v.name).join(', ') : ''}</Typography>
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <FormControl component='fieldset' required={this.props.required} style={{ width: '100%', margin: 0 }}>
            <FormGroup>
              {this.props.selection.map(v => {
                return <FormControlLabel value={v.slug} control={<Checkbox onChange={(e) => this.handleCheckChanged(e, v)} />} label={v.name} />
              })}
            </FormGroup>
          </FormControl>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    )
  }
}

export default TagCheckbox
