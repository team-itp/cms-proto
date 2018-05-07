import * as React from 'react'
import Typography from 'material-ui/Typography'
import { Tag } from '../../common/wp-api'

interface TagLabelProps {
  tags: Tag[]
}

class TagLabel extends React.Component<TagLabelProps> {
  constructor(props: TagLabelProps) {
    super(props)
  }

  getLabel(tags: Tag[]) {
    if (tags && tags.length) {
      if (tags.length === 1) {
        return {
          label: tags[0].name,
          caption: undefined
        }
      } else if (tags.length === 2) {
        return {
          label: tags[0].name + '、' + tags[1].name,
          caption: undefined
        }
      } else {
        return {
          label: tags[0].name + `、... 他 ${tags.length} 件`,
          caption: tags.map(v => v.name).join('、')
        }
      }
    } else {
      return {
        label: undefined,
        caption: undefined
      }
    }
  }

  render() {
    const { label, caption } = this.getLabel(this.props.tags)
    return (
      <Typography style={{ lineHeight: 1, fontSize: '1rem', position: 'absolute', left: '7em' }} title={caption}>{label}</Typography>
    )
  }
}

export default TagLabel
