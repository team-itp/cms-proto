import * as React from 'react'
import Popover from 'material-ui/Popover'
import Grow from 'material-ui/transitions/Grow'
import Paper from 'material-ui/Paper'
import { MenuItem } from 'material-ui/Menu'
import TextField from 'material-ui/TextField'
import { Tag } from '../../common'

const suggestions = [
  { name: 'どこかの現場1', slug: 'docoka1' },
  { name: 'どこかの現場2', slug: 'docoka2' }
]

interface TagInputProps {
  label: string
  onTagSelect: (tag: Tag) => void
}

interface TagInputState {
  capture: boolean
  open: boolean
  value?: string
  suggestion?: Tag[]
}

class TagInput extends React.Component<TagInputProps, TagInputState> {
  private inputEl?: HTMLInputElement

  constructor(props: TagInputProps) {
    super(props)
    this.state = {
      open: false,
      capture: false
    }
    this.handleClose = this.handleClose.bind(this)
    this.handleChange = this.handleChange.bind(this)
    this.handleBlur = this.handleBlur.bind(this)
    this.handleSelect = this.handleSelect.bind(this)
  }

  handleClose() {
    this.setState({ open: false })
  }

  handleChange(event: any) {
    const value = event.target.value
    this.setState({
      value: value
    })
    if (value) {
      setTimeout(() => {
        if (this.state.value === value) {
          const suggestion = suggestions.filter(v => RegExp(value).test(v.name))
          if (suggestion.length) {
            this.setState({ open: true, suggestion: suggestion })
          } else {
            this.setState({ open: false, suggestion: suggestion })
          }
        }
      }, 300)
    } else {
      this.setState({ open: false, suggestion: [] })
    }
  }

  handleBlur() {
    this.setState({ open: false })
  }

  handleSelect(value: Tag): () => void {
    return () => {
      if (this.inputEl) {
        this.inputEl.value = ''
      }
      this.setState({ open: false, value: '' })
      this.props.onTagSelect.call(this, value)
    }
  }

  render() {
    const { label } = this.props
    const { open, value, suggestion } = this.state

    return (
      <div>
        <TextField inputRef={node => this.inputEl = node} label={label} value={value} onChange={this.handleChange} />
        <Popover open={open} anchorEl={this.inputEl} anchorOrigin={{ horizontal: 'left', vertical: 'bottom' }} disableAutoFocus style={{ top: 8 }}>
          <Grow in={open}>
            <Paper>
              {open && suggestion!.map(v => {
                return <MenuItem onClick={this.handleSelect(v)}>{v.name}</MenuItem>
              })}
            </Paper>
          </Grow>
        </Popover>
      </div>
    )
  }
}

export default TagInput
