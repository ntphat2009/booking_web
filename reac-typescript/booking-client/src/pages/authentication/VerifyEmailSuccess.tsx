import React from 'react'
import { useNavigate } from 'react-router-dom';

const VerifyEmailSuccess = () => {
    const navigate = useNavigate();
    return (
        <div>
            <p style={{backgroundColor:"rgb(152 183 229)", fontSize: 20, textAlign: 'center', padding: "70px 0px 70px 0px",margin:"20px 80px 20px 80px", borderRadius:10, border: "2px solid #003b95"}}>Tài khoản của bạn đã được xác thực. Vui lòng đăng nhập lại để có thể thực hiện đặt chỗ</p>
        </div>
    )
}
export default VerifyEmailSuccess