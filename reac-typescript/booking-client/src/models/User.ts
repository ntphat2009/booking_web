import { BaseModel } from "./BaseModel";
export interface User {
    FirstName: string;
    LastName: string;
    FullName: string;
    Avatar: string;
    Id: string;
    UserName: string;
    Email: string;
    EmailConfirm: boolean;
    PhoneNumber: string;
}
