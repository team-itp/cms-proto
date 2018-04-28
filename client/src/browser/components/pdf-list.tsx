import * as React from 'react'
import GridList, { GridListTile, GridListTileBar } from 'material-ui/GridList'
import Subheader from 'material-ui/List/ListSubheader'
import IconButton from 'material-ui/IconButton'
import InfoIcon from '@material-ui/icons/Info'

const tileData = [
  {
    img: 'https://imagejournal.org/wp-content/uploads/bb-plugin/cache/23466317216_b99485ba14_o-panorama.jpg',
    title: 'Image',
    author: 'author'
  },
  {
    img: 'https://imagejournal.org/wp-content/uploads/bb-plugin/cache/23466317216_b99485ba14_o-panorama.jpg',
    title: 'Image',
    author: 'author'
  },
  {
    img: 'https://imagejournal.org/wp-content/uploads/bb-plugin/cache/23466317216_b99485ba14_o-panorama.jpg',
    title: 'Image',
    author: 'author'
  }
]

class PdfList extends React.Component<any> {

  constructor(props: any) {
    super(props)
  }

  render() {
    return (
      <div>
        <GridList cellHeight={180}>
          <GridListTile key='Subheader' cols={2} style={{ height: 'auto' }}>
            <Subheader component='div'>December</Subheader>
          </GridListTile>
          {tileData.map(tile => (
            <GridListTile key={tile.img}>
              <img src={tile.img} alt={tile.title} />
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
