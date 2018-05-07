import * as React from 'react'
import { FormControl, FormLabel, FormControlLabel } from 'material-ui/Form'
import Radio, { RadioGroup } from 'material-ui/Radio'
import ExpansionPanel, { ExpansionPanelSummary, ExpansionPanelDetails } from 'material-ui/ExpansionPanel'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import { Tag } from '../../common/wp-api'
import TagLabel from './tag-label'

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
    return (
      <ExpansionPanel defaultExpanded>
        <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
          <FormLabel component='label'>{this.props.displayName}</FormLabel>
          <TagLabel tags={this.state.selected ? [this.state.selected] : []} />
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <FormControl component='fieldset' required={this.props.required}>
            <RadioGroup
              name={this.props.name}
              value={this.state.value}
              onClick={this.handleChange}
            >
              {this.props.selection.map(v => {
                return <FormControlLabel value={v.slug} control={<Radio />} label={v.name} />
              })}
            </RadioGroup>
          </FormControl>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    )
  }
}

export default TagRadio
