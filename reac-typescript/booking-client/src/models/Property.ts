import { BaseModel } from "./BaseModel";
import { User } from './User';
export enum MyImageType {
  Larger = 0,
  Small = 1,
  Smaller = 2
}
interface ImageProperties extends BaseModel {
  PropertyID: string;
  ImageURL: string;
  ImageName: string;
  ImageType: MyImageType;
}
// import {ImageProperties} from "./ImageProperties"
export interface Property extends BaseModel {
  Name: string;
  PropertyUrl: string;
  CityID: number;
  City: any;
  Street: string;
  District: string;
  AvgPrice: number;
  Rule: string;
  Services: any;
  ImageProperties: ImageProperties[];
  Rooms: any;
  Id: string;
  Description:string;
  UserId:string;
  User : User
}
