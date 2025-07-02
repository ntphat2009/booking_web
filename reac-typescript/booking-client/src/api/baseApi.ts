import axios from 'axios';

// Tạo instance axios với baseURL chung
const baseApi = axios.create({
  baseURL: 'https://localhost:7214/api', // URL backend của bạn
  timeout: 5000,                     // Timeout nếu cần
  headers: {
    'Content-Type': 'application/json',
  },
});

// Có thể thêm interceptors nếu cần
baseApi.interceptors.request.use(
  config => {
    // Ví dụ: Thêm token vào header nếu có
    const token = localStorage.getItem('accessToken');
    if (token && config.headers) {
      config.headers.Authorization = `Bearer ${token}`;
    }
    return config;
  },
  error => Promise.reject(error)
);

export default baseApi;
