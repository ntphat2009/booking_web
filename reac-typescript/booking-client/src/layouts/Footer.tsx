import React, { PureComponent } from 'react'

export default class Footer extends PureComponent {
    render() {
        return (
            <footer>
                <div className="container">
                    <div className="row">
                        <div className="col footer">
                            <span>Hỗ trợ</span>
                            <ul >
                                <li>
                                    <a href='#'>Câu hỏi thường gặp về virut corona(COVID-19)</a>
                                </li>
                                <li>
                                    <a href='#'>Quản lí các chuyến đi của bạn</a>
                                </li>
                                <li>
                                    <a href='#'>Liên hệ dịch vụ khách hàng</a>
                                </li>
                                <li>
                                    <a href='#'>Trung tâm thông tin bảo mật</a>
                                </li>
                            </ul>
                        </div>
                        <div className="col footer">
                            <span>Khám phá thêm</span>
                            <ul>
                                <li>
                                    <a href='#'>Chương trình khách hàng thân thiết Genius</a>
                                </li>
                                <li>
                                    <a href='#'>Ưu đãi theo mùa và dịp lễ</a>
                                </li>
                                <li>
                                    <a href='#'>Bài viết về du lịch</a>
                                </li>
                                <li>
                                    <a href='#'>Booking.com dành cho Doanh Nghiệp</a>
                                </li>
                                <li>
                                    <a href='#'>Traveller Review Awards</a>
                                </li>
                            </ul>
                        </div>
                        <div className="col footer">
                            <span>Điều khoản và cài đặt</span>
                            <ul>
                                <li>
                                    <a href='#'>Bảo mật & Cookie</a>
                                </li>
                                <li>
                                    <a href='#'>Điều khoản và điều kiện</a>
                                </li>
                                <li>
                                    <a href='#'>Tranh chấp đối tác</a>
                                </li>
                                <li>
                                    <a href='#'>Chính sách chống Nô lệ Hiện đại</a>
                                </li>
                                <li>
                                    <a href='#'>Chính sách về Quyền con người</a>
                                </li>
                            </ul>
                        </div>
                        <div className="col footer">
                            <span>Dành cho đối tác</span>
                            <ul>
                                <li>
                                    <a href='#'>Đăng nhập vào trang Extranet</a>
                                </li>
                                <li>
                                    <a href='#'>Trợ giúp đối tác</a>
                                </li>
                                <li>
                                    <a href='#'>Đăng chỗ nghỉ của Quý vị</a>
                                </li>
                                <li>
                                    <a href='#'>Trở thành đối tác phân phối</a>
                                </li>
                            </ul>
                        </div>
                        <div className="col footer">
                            <span>Về chúng tôi</span>
                            <ul>
                                <li>
                                    <a href='#'>Về Booking.com</a>
                                </li>
                                <li>
                                    <a href='#'>Chúng tôi hoạt động như thế nào</a>
                                </li>
                                <li>
                                    <a href='#'>Du lịch bền vững</a>
                                </li>
                                <li>
                                    <a href='#'>Truyền thông</a>
                                </li>
                            </ul>
                        </div>


                    </div>
                    <hr></hr>
                    <div className="copyright">
                        <p>Booking.com là một phần của Booking Holdings Inc., tập đoàn đứng đầu thế giới về du lịch trực tuyến và các dịch vụ liên quan.</p>
                        <p>Bản quyền © 1996 - 2024 Booking.com™. Bảo lưu mọi quyền.</p>
                    </div>
                </div>
            </footer>
        )
    }
}
