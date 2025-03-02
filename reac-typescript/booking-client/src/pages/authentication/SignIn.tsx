import React, { useState } from 'react'
import { Link, useNavigate } from 'react-router-dom';
import { toast, ToastContainer } from 'react-toastify';
const SignIn = () => {
    const [userName, setUserName] = useState<string>('');
    const [password, setPassword] = useState<string>('');
    const navigate = useNavigate();
    const handleLogin = async (e:any) => {
        e.preventDefault();
        try {
            const response = await fetch('https://localhost:7214/api/Authentications/SignIn', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ userName, password })
            });
            if (!response.ok) {
                throw new Error('Đăng nhập thất bại, vui lòng kiểm tra lại email và mật khẩu.');
            }
            const token = await response.text(); // Lấy chuỗi JWT thô
            sessionStorage.setItem('token', token); // Lưu vào sessionStorage
            console.log("token in signIn page",sessionStorage.getItem('token'));
            // navigate('/');
            window.location.href="/";
        } catch (error) {
            console.error('Lỗi:', error);
            toast.error("Đăng nhập thất bại, vui lòng kiểm tra lại email và mật khẩu.")
        }
    };
    return (
        <div>
            <>
            <ToastContainer></ToastContainer>
                <section className="section-conten padding-y" style={{ minHeight: "84vh" }}>
                    {/* ============================ COMPONENT LOGIN   ================================= */}
                    <div className="card mx-auto" style={{ maxWidth: "380px", marginTop: "100px" }}>
                        <div className="card-body">
                            <h4 className="card-title mb-4">Đăng nhập</h4>
                            <form onSubmit={handleLogin}>

                                <div className="form-group">
                                    <input className="form-control" placeholder="Tên đăng nhập..." type="text" value={userName} onChange={(e) => setUserName(e.target.value)} />
                                </div>
                                <div className="form-group">
                                    <input className="form-control" placeholder="Mật khẩu..." type="password" value={password} onChange={(e) => setPassword(e.target.value)} />
                                </div>
                                <div className="form-group">
                                    <a href="/forgotpassword" className="float-right">Quên mật khẩu?</a>
                                    <label className="float-left custom-control custom-checkbox"> <input type="checkbox" className="custom-control-input" /> <div className="custom-control-label"> Nhớ tài khoản </div> </label>
                                </div>
                                <div className="form-group">
                                    <button type="submit" className="btn btn-info btn-block"> Đăng nhập  </button>
                                </div>
                            </form>
                        </div>
                    </div>

                    <p className="text-center mt-4">Bạn chưa có tài khoản?
                        <a href="/sign-up">Đăng ký</a>
                    </p>
                    <br></br>
                    {/* ============================ COMPONENT LOGIN  END.// ================================= */}


                </section>
            </>
        </div>
    )
}

export default SignIn
