import { BaseModel } from "./BaseModel";
import { ImageProperties } from "./ImageProperty";
import { User } from './User';
export interface PropertyDes extends BaseModel {
  Name: string;
  PropertyUrl: string;
  CityID: number;
  CityName: string;
  Street: string;
  District: string;
  AvgPrice: number;
  Rule: string;
  // Services: any;
  ImageProperties: ImageProperties[];
  // Rooms: any;
  Id: string;
  Description:string;
  UserId:string;
  User : User
}
