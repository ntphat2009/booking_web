import React from 'react'
const Deal: React.FC = () => {
    return (
        <div className="wrapper">
            <div>
                <h2>Ưu đãi</h2>
                <p>Khuyến mãi, giảm giá và ưu đãi đặc biệt dành riêng cho bạn</p>
            </div>
            <div className="deals">
                <div className="container-history">
                    <div className="container-info ">
                        <h4>Vui là chính, không cần dài</h4>
                        <p>Kết năm với kỳ nghỉ ngắn. Tiết kiệm từ 15% trở lên khi đặt và lưu trú đến hết 7/1/2025. </p>
                        <button type="submit">Tìm ưu đãi cuối năm</button>
                    </div>
                    <div className="container-img">
                        <img className="dead-img" src="../../../assets/image/city/HCM.jpg" alt="" />
                    </div>
                </div>
            </div>
        </div>
    )
}
export default Deal;
