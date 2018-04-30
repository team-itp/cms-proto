import * as React from 'react'
import { FormControl, FormLabel, FormControlLabel } from 'material-ui/Form'
import Radio, { RadioGroup } from 'material-ui/Radio'
import { Tag } from '../../common/wp-api'

interface TagRadioProps {
  style?: React.CSSProperties
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
    this.state = {
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
    return <div style={this.props.style}>
      <FormControl component='fieldset' required={this.props.required}>
        <FormLabel component='legend'>{this.props.displayName}</FormLabel>
        <RadioGroup
          name={this.props.name}
          value={this.state.value}
          onChange={this.handleChange}
        >
          {this.props.selection.map(v => {
            return <FormControlLabel value={v.slug} control={<Radio />} label={v.name} />
          })}
        </RadioGroup>
      </FormControl>
    </div>
  }
}

export default TagRadio
