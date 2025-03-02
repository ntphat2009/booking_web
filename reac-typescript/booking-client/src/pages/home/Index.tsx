import React, { PureComponent } from 'react'
import BannerHome from './BannerHome';
import Deal from './Deal';
import ListCity from './ListCity';
import Trending from './Trending';
import TopLocation from './TopLocation';
import MoreFill from './MoreFill';


export default class index extends PureComponent {
  render() {
    return (
      <div>
        <BannerHome></BannerHome>
        <Deal></Deal>
        <ListCity></ListCity>
        <Trending></Trending>
        <TopLocation></TopLocation>
        <MoreFill></MoreFill>
      </div>
    )
  }
}
