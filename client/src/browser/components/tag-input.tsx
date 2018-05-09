import * as React from 'react'
import Chip from 'material-ui/Chip'
import { FormControl, FormLabel } from 'material-ui/Form'
import ExpansionPanel, { ExpansionPanelSummary, ExpansionPanelDetails } from 'material-ui/ExpansionPanel'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import { Tag } from '../../common/wp-api'
import TagInputField from './tag-input-field'
import TagLabel from './tag-label'

interface TagInputProps {
  displayName: string
  required?: boolean
}

interface TagInputState {
  selectedTags: Tag[]
}

class TagInput extends React.Component<TagInputProps, TagInputState> {
  constructor(props: TagInputProps) {
    super(props)
    this.state = {
      selectedTags: []
    }
    this.handleTagSelect = this.handleTagSelect.bind(this)
  }

  handleTagDelete(value: Tag): () => void {
    return () => {
      let selectedTags = this.state.selectedTags.filter(v => v.slug !== value.slug)
      this.setState({
        selectedTags: selectedTags
      })
    }
  }

  handleTagSelect(value: Tag): void {
    if (this.state.selectedTags.filter(v => v.slug === value.slug).length === 0) {
      const selectedTags = this.state.selectedTags.slice()
      selectedTags.push(value)
      this.setState({
        selectedTags: selectedTags.sort((a, b) => a.name.localeCompare(b.name))
      })
    }
  }

  renderTags(renderTags: Tag[]) {
    return (
      renderTags.map(v => {
        return (
          <Chip label={v.name} onDelete={this.handleTagDelete(v)} style={{ margin: 8, marginLeft: 0 }} />
        )
      })
    )
  }

  render() {
    const { selectedTags } = this.state
    return (
      <ExpansionPanel defaultExpanded>
        <ExpansionPanelSummary expandIcon={<ExpandMoreIcon />}>
          <FormLabel component='label'>{this.props.displayName}</FormLabel>
          <TagLabel tags={selectedTags} />
        </ExpansionPanelSummary>
        <ExpansionPanelDetails>
          <div>
            <FormControl component='fieldset' required={this.props.required} style={{ width: '100%', margin: 0 }}>
              <TagInputField label='タグ' onTagSelect={this.handleTagSelect} />
            </FormControl>
            <div style={{
              display: 'flex',
              justifyContent: 'left',
              flexWrap: 'wrap'
            }}>
              {this.renderTags(selectedTags)}
            </div>
          </div>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    )
  }
}

export default TagInput
