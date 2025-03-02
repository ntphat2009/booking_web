export interface BaseModel {
    IsDeleted: boolean;
    CreatedAt: string; // Dùng `Date` nếu muốn xử lý datetime
    UpdatedAt: string; // Tương tự
    CreatedBy: string;
    UpdatedBy: string;
  }
  