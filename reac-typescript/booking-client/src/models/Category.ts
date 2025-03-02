import { BaseModel } from './BaseModel';
export interface Category extends BaseModel  {
    id?: number;
    Name?: string;
    Image?: string;
    Icon?: string;
    Description?: string;
  }