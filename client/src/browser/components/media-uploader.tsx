import * as React from 'react'
import Button from 'material-ui/Button'
import { Tag } from '../../common/wp-api'
import TagRadio from './tag-radio'
import TagCheckbox from './tag-checkbox'
import TagInput from './tag-input'
import Paper from 'material-ui/Paper'

interface MediaUploaderProps {
  style?: React.CSSProperties
}

interface MediaUploaderState {
  documentType?: Tag
  personInCharge?: Tag
  division?: Tag
  term?: Tag
  tags?: Tag[]
}

class MediaUploader extends React.Component<MediaUploaderProps, MediaUploaderState> {
  constructor(props: MediaUploaderProps) {
    super(props)
  }

  render() {
    return <div style={this.props.style}>
      <TagRadio name='documentType' displayName='文書種類' selection={[
        { slug: 'slug1', name: '見積書' },
        { slug: 'slug2', name: '注文書' },
        { slug: 'slug3', name: '請求書' },
        { slug: 'slug4', name: '図面' }
      ]} />
      <TagRadio name='personInCharge' displayName='担当者' selection={[
        { slug: 'slug1', name: '田中　太郎' },
        { slug: 'slug2', name: '田中　次郎' },
        { slug: 'slug3', name: '田中　三郎' },
        { slug: 'slug4', name: '田中　史郎' },
        { slug: 'slug5', name: '田中　五郎' }
      ]} />
      <TagRadio name='division' displayName='部門' selection={[
        { slug: 'slug1', name: '建築' },
        { slug: 'slug2', name: 'リフォーム' }
      ]} />
      <TagCheckbox displayName='工事期間' defaultChecked={[
        { slug: 'slug1', name: '2017年度' }
      ]} selection={[
        { slug: 'slug1', name: '2017年度' },
        { slug: 'slug2', name: '2018年度' },
        { slug: 'slug3', name: '2019年度' }
      ]} />
      <TagInput displayName='その他' />
      <Paper style={{ position: 'relative', padding: 8, textAlign: 'right' }}>
        <Button variant='raised' color='primary'>
          送信
        </Button>
      </Paper>
    </div>
  }
}

export default MediaUploader
