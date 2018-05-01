import * as React from 'react'
import { FormControl, FormLabel, FormControlLabel } from 'material-ui/Form'
import Radio, { RadioGroup } from 'material-ui/Radio'
import ExpansionPanel, { ExpansionPanelSummary, ExpansionPanelDetails } from 'material-ui/ExpansionPanel'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import Typography from 'material-ui/Typography'
import { Tag } from '../../common/wp-api'

interface TagRadioProps {
  name: string
  displayName: string
  selection: Tag[]
  required?: boolean
}

interface TagRadioState {
  value?: string
  selected?: Tag
}

class TagRadio extends React.Component<TagRadioProps, TagRadioState> {
  constructor(props: TagRadioProps) {
    super(props)
    if (props.selection) {
      this.state = {
        value: props.selection[0].slug,
        selected: props.selection[0]
      }
    }
  }

  handleChange = (event: any) => {
    const value = (event.target as HTMLInputElement).value
    const selectedTags = this.props.selection.filter(e => e.slug === value)
    if (selectedTags) {
      this.setState({
        value: value,
        selected: selectedTags[0]
      })
    }
  }

  render() {
    return <div>
      <FormControl component='fieldset' required={this.props.required} style={{ width: '100%' }}>
        <ExpansionPanel defaultExpanded>
          <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
            <FormLabel component='legend'>{this.props.displayName}</FormLabel>
            <Typography style={{ lineHeight: 1, fontSize: '1rem', position: 'absolute', left: '7em' }}>{this.state.selected ? this.state.selected.name : ''}</Typography>
          </ExpansionPanelSummary>
          <ExpansionPanelDetails>
            <RadioGroup
              name={this.props.name}
              value={this.state.value}
              onClick={this.handleChange}
            >
              {this.props.selection.map(v => {
                return <FormControlLabel value={v.slug} control={<Radio />} label={v.name} />
              })}
            </RadioGroup>
          </ExpansionPanelDetails>
        </ExpansionPanel>
      </FormControl>
    </div>
  }
}

export default TagRadio
