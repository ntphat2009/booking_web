import { BaseModel } from "./BaseModel";
export interface Property extends BaseModel {
    Name: string;
    PropertyUrl: string;
    CityID: number;
    Street: string;
    District: string;
    AvgPrice: number;
    Rule: string;
    Services: any;
    ImageProperties: any;
    Rooms: any;
    Id: string;
  }
  