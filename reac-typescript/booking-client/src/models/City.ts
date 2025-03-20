import { BaseModel } from "./BaseModel";
export interface City extends BaseModel {
  Id?: number;
  CategoryId?: number;
  Name?: string;
  Banner?: string;
  Category: any;
  CityUrl: string;
  Properties: any;
}