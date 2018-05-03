import * as React from 'react'
import { FormControl, FormLabel } from 'material-ui/Form'
import ExpansionPanel, { ExpansionPanelSummary, ExpansionPanelDetails } from 'material-ui/ExpansionPanel'
import ExpandMoreIcon from '@material-ui/icons/ExpandMore'
import Typography from 'material-ui/Typography'
import TextField from 'material-ui/TextField'
import { Tag } from '../../common/wp-api'

interface TagInputProps {
  displayName: string
}

interface TagInputState {
  selectedList: Tag[]
}

class TagInput extends React.Component<TagInputProps, TagInputState> {
  constructor(props: TagInputProps) {
    super(props)
    this.state = {
      selectedList: []
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
          <FormControl component='fieldset'>
            <TextField type='text' label='タグ名' />
          </FormControl>
        </ExpansionPanelDetails>
      </ExpansionPanel>
    )
  }
}

export default TagInput
