import * as React from 'react'
import GridList, { GridListTile, GridListTileBar } from 'material-ui/GridList'
import IconButton from 'material-ui/IconButton'
import InfoIcon from '@material-ui/icons/Info'
import PdfImage from './pdf-image'

const tileData = [
  {
    img: 'https://github.com/mozilla/pdf.js/raw/master/examples/helloworld/helloworld.pdf',
    title: 'Image',
    author: 'author'
  },
  {
    img: '../assets/sample1.pdf',
    title: 'Image',
    author: 'author'
  },
  {
    img: '../assets/sample2.pdf',
    title: 'Image',
    author: 'author'
  }
]

interface PdfListProps {
  style?: React.CSSProperties
}

class PdfList extends React.Component<PdfListProps> {
  constructor(props: PdfListProps) {
    super(props)
  }

  render() {
    return (
      <div style={this.props.style}>
        <GridList cellHeight={300}>
          {tileData.map(tile => (
            <GridListTile key={tile.img}>
              <PdfImage src={tile.img} alt={tile.title} />
              <GridListTileBar
                title={tile.title}
                subtitle={<span>by: {tile.author}</span>}
                actionIcon={
                  <IconButton>
                    <InfoIcon />
                  </IconButton>
                }
              />
            </GridListTile>
          ))}
        </GridList>
      </div>
    )
  }
}

export default PdfList
