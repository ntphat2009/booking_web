import { BaseModel } from "./BaseModel";
export enum MyImageType {
  Larger = 0,
  Small = 1,
  Smaller = 2
}
export interface ImageProperties extends BaseModel {
  PropertyID: string;
  ImageURL: string;
  ImageName: string;
  ImageType: MyImageType;
}