import * as React from 'react'
import GridList, { GridListTile, GridListTileBar } from 'material-ui/GridList'
import Subheader from 'material-ui/List/ListSubheader'
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
}

class PdfList extends React.Component<PdfListProps> {
  constructor(props: PdfListProps) {
    super(props)
  }

  render() {
    return (
      <div>
        <GridList cellHeight={300}>
          <GridListTile key='Subheader' cols={2} style={{ height: 'auto' }}>
            <Subheader component='div'>December</Subheader>
          </GridListTile>
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
