import React from 'react'
import Slider from "react-slick";
import "slick-carousel/slick/slick.css"; 
import "slick-carousel/slick/slick-theme.css";

const MoreFill: React.FC = () => {

    const settings = {
        dots: false,          // Hiển thị chấm điều hướng
        infinite: false,      // Vòng lặp vô hạn
        speed: 500,          // Tốc độ chuyển (ms)
        slidesToShow: 4,     // Số slide hiển thị cùng lúc
        slidesToScroll: 1,   // Số slide cuộn mỗi lần
        autoplay: true,      // Tự động chạy
        autoplaySpeed: 10000, // Tốc độ tự động chạy (ms)
      };
    return (
        <div className="wrapper">
        <div>
            <h2>Ưu đãi cho cuối tuần</h2>
            <p>Tiết kiệm cho chỗ nghỉ từ ngày 13 tháng 12 - ngày 15 tháng 12</p>
        </div>
        <div className="list-city">
                    <Slider {...settings} className="slick-slidee">
                        <div className="slick-item card">
                                <img className="card-img" src="../../../assets/image/location/615107862.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Milestone SaiGon</h4>
                                    <p>TP. Hồ Chí Minh, Việt Nam</p>
                                    <p>Rất tôt - 20 đánh giá</p>
                                    <h5><span>Bắt đầu từ</span>12.026.000 VND</h5>
                                </div>
                        </div>
                        <div className="slick-item card">
                                <img className="card-img" src="../../../assets/image/location/615107862.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Milestone SaiGon</h4>
                                    <p>TP. Hồ Chí Minh, Việt Nam</p>
                                    <p>Rất tôt - 20 đánh giá</p>
                                    <h5><span>Bắt đầu từ</span>12.026.000 VND</h5>
                                </div>
                        </div>
                        <div className="slick-item card">
                                <img className="card-img" src="../../../assets/image/location/615107862.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Milestone SaiGon</h4>
                                    <p>TP. Hồ Chí Minh, Việt Nam</p>
                                    <p>Rất tôt - 20 đánh giá</p>
                                    <h5><span>Bắt đầu từ</span>12.026.000 VND</h5>
                                </div>
                        </div>
                        <div className="slick-item card">
                                <img className="card-img" src="../../../assets/image/location/615107862.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Milestone SaiGon</h4>
                                    <p>TP. Hồ Chí Minh, Việt Nam</p>
                                    <p>Rất tôt - 20 đánh giá</p>
                                    <h5><span>Bắt đầu từ</span>12.026.000 VND</h5>
                                </div>
                        </div>
                        
                    </Slider>
        </div>
    </div>
    )
  }
export default MoreFill;
