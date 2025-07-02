import { BaseModel } from "./BaseModel";
export interface Property extends BaseModel {
  Id: string;
  Name: string;
  PropertyUrl: string;
  CityUrl: string;
  CityId: string | null;
  CityName: string;
  Street: string;
  District: string;
  AvgPrice: number;
  Rule: string;
  Description: string;
  UserId: string;
  UserMail: string;
  Services: string[] | null;
  ImageProperty: string | null;
  Rooms: string[] | null;
  Tags: string[] | null;
}