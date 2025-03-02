import React, { useState } from 'react'
import { Link, useNavigate } from "react-router-dom";
import { SignUpModel } from './../../models/SignUpModel';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import axios from 'axios';

const SignUp = () => {
    const [FirstName, fNamechange] = useState<string>("");
    const [LastName, namechange] = useState<string>("");
    const [UserName, usernamechange] = useState<string>("");
    const [Password, passwordchange] = useState<string>("");
    const [confirmpassword, confirmpasswordchange] = useState<string>("");
    const [Email, emailchange] = useState<string>("");
    const navigate = useNavigate();
    const IsValidate = () => {
        let isproceed = true;
        let errormessage = 'Vui lòng nhập ';
        let errors: string[] = [];
        const passwordPolicy = /^(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{7,}$/;
        if (!FirstName) {
            isproceed = false;
            errors.push('Họ');
        }
        if (!LastName) {
            isproceed = false;
            errors.push('Tên');
        }
        if (!UserName) {
            isproceed = false;
            errors.push('Tên');
        }
        if (!Password) {
            isproceed = false;
            errors.push('Mật khẩu');
        } else if (!passwordPolicy.test(Password)) {
            isproceed = false;
            errors.push('Mật khẩu chưa đúng định dạng (Ít nhất 7 ký tự gồm ít nhất 1 kí tự đặc biệt,1 chữ số, 1 kí tự in hoa)');
        }
        if (!Email) {
            isproceed = false;
            errors.push('Email');
        }
        if (Password !== confirmpassword) {
            isproceed = false;
            errors.push('Kiểm tra xác nhận mật khẩu, mật khẩu chưa khớp');
        }
        if (errors.length > 0) {
            errormessage += errors.join(', ');
            toast.warning(errormessage);
        } else {
            if (/^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[A-Za-z]{2,}$/.test(Email)) {
                return isproceed;
            } else {
                isproceed = false;
                toast.warning('Vui lòng nhập email chính xác');
            }
        }
        return isproceed;
    }
    const handlesubmit = async (e:any) => {
        e.preventDefault();
        let regobj: SignUpModel = { FirstName, LastName, Password, Email, UserName };
        if (IsValidate()) {
            try {
                const response = await axios.post(
                    "https://localhost:7214/api/Authentications/SignUp",
                    regobj
                );
                console.log("Response:", response.data);
                toast.success("Đăng ký thành công")
                navigate("/sign-in");
            } catch (error) {
                if (axios.isAxiosError(error)) {
                    const errorData = error.response?.data; // Lấy thông tin chi tiết từ API
                    console.error("Error from API:", errorData);
                    toast.error(errorData);
                } else {
                    console.error("Unknown error:", error);
                    toast.error("Lỗi không xác định, vui lòng thử lại.");
                }
            }
        } else {
            console.error("Validation failed!");
        }
    };
    return (
        <div>
            <>
                <section className="section-content padding-y">
                    {/* ============================ COMPONENT REGISTER   ================================= */}
                    <div className="card mx-auto" style={{ maxWidth: "520px", marginTop: "40px" }}>
                    <ToastContainer />
                        <article className="card-body">
                            <header className="mb-4"><h4 className="card-title">Đăng Ký</h4></header>
                            <form onSubmit={handlesubmit}>
                                <div className="form-row">
                                    <div className="col form-group">
                                        <label>Họ</label>
                                        <input type="text" className="form-control" placeholder="" value={FirstName} onChange={e => fNamechange(e.target.value)} />
                                    </div> {/* form-group end.// */}
                                    <div className="col form-group">
                                        <label>Tên</label>
                                        <input type="text" name="lastName" className="form-control" placeholder="" value={LastName} onChange={e => namechange(e.target.value)} />
                                    </div> {/* form-group end.// */}
                                </div> {/* form-row end.// */}
                                <div className="form-group">
                                    <label>Tên đăng nhập</label>
                                    <input type="text" className="form-control" placeholder="" value={UserName} onChange={e => usernamechange(e.target.value)} />
                                    <small className="form-text text-muted">Chúng tôi sẽ không chia sẻ Email của bạn cho bất kỳ ai khác</small>
                                </div> {/* form-group end.// */}
                                <div className="form-group">
                                    <label>Email</label>
                                    <input type="email" className="form-control" placeholder="" value={Email} onChange={e => emailchange(e.target.value)} />
                                    <small className="form-text text-muted">Chúng tôi sẽ không chia sẻ Email của bạn cho bất kỳ ai khác</small>
                                </div> {/* form-group end.// */}
                                <div className="form-row">
                                    <div className="form-group col-md-6">
                                        <label>Nhập mật khẩu</label>
                                        <input className="form-control" type="password" value={Password} onChange={e => passwordchange(e.target.value)} />
                                    </div>
                                    <div className="form-group col-md-6">
                                        <label>Nhập mật khẩu</label>
                                        <input className="form-control" type="password" value={confirmpassword} onChange={e => confirmpasswordchange(e.target.value)} />
                                    </div>
                                </div>
                                <div className="form-group">
                                    <button type="submit" className="btn btn-info btn-block"> Đăng Ký  </button>
                                </div> {/* form-group// */}

                            </form>
                        </article>{/* card-body.// */}
                    </div> {/* card .// */}
                    <p className="text-center mt-4">Bạn đã có tài khoản? <a href="/sign-in">Đăng nhập</a></p>
                    <br></br>
                    {/* ============================ COMPONENT REGISTER  END.// ================================= */}


                </section>
            </>
        </div>
    )
}

export default SignUp
