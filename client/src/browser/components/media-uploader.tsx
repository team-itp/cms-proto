import * as React from 'react'
import { Tag } from '../../common/wp-api'
import TagRadio from './tag-radio'

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
      <TagRadio name='documentType' displayName='文書種類' selection={
        [
          { slug: 'slug1', name: '見積書' },
          { slug: 'slug2', name: '注文書' },
          { slug: 'slug3', name: '請求書' },
          { slug: 'slug4', name: '図面' }
        ]
      } />
      <TagRadio name='personInCharge' displayName='担当者' selection={
        [
          { slug: 'slug1', name: '田中　太郎' },
          { slug: 'slug2', name: '田中　次郎' },
          { slug: 'slug3', name: '田中　三郎' },
          { slug: 'slug4', name: '田中　史郎' },
          { slug: 'slug5', name: '田中　五郎' }
        ]
      } />
      <TagRadio name='division' displayName='部門' selection={
        [
          { slug: 'slug1', name: '建築' },
          { slug: 'slug2', name: 'リフォーム' }
        ]
      } />
      <TagRadio name='term' displayName='工事期間' selection={
        [
          { slug: 'slug1', name: '2017年度' },
          { slug: 'slug2', name: '2018年度' },
          { slug: 'slug3', name: '2019年度' }
        ]
      } />
    </div>
  }
}

export default MediaUploader
