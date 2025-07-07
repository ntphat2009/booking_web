import { BaseModel } from "./BaseModel";
export enum MyImageType {
  Larger = 0,
  Small = 1,
  Smaller = 2
}
export interface ImageProperties extends BaseModel {
  PropertyId: string;
  ImageUrl: string;
  ImageName: string;
  ImageType: MyImageType;
}