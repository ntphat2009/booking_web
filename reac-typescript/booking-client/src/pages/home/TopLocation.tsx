import React, { useState } from 'react'
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
const TopLocation: React.FC = () => {

    const settings = {
        dots: false,          // Hiển thị chấm điều hướng
        infinite: false,      // Vòng lặp vô hạn
        speed: 500,          // Tốc độ chuyển (ms)
        slidesToShow: 6,     // Số slide hiển thị cùng lúc
        slidesToScroll: 1,   // Số slide cuộn mỗi lần
        autoplay: true,      // Tự động chạy
        autoplaySpeed: 10000, // Tốc độ tự động chạy (ms)
    };
    const [activeContent, setActiveContent] = useState('content1'); // Lưu trạng thái của mục nội dung đang hiển thị

    const handleButtonClick = (targetId:string) => {
        setActiveContent(targetId); // Cập nhật mục đang hiển thị
    };
    return (
        <div className="wrapper">
            <div style={{ marginBottom: 10 }}>
                <h2>Lên kế hoạch dễ dàng và nhanh chóng</h2>
                <p>Khám phá các điểm đến hàng đầu theo cách bạn thích ở Việt Nam</p>
            </div>
            <div className="button-group">
                <button
                    className={`toggle-btn location-button ${activeContent === "content1" ? "active" : ""}`}
                    onClick={() => handleButtonClick("content1")}
                >
                    Bãi biển
                </button>

                <button
                    className={`toggle-btn location-button ${activeContent === "content2" ? "active" : ""}`}
                    onClick={() => handleButtonClick("content2")}
                >
                    Thiên nhiên
                </button>
                <button
                    className={`toggle-btn location-button ${activeContent === "content3" ? "active" : ""}`}
                    onClick={() => handleButtonClick("content3")}
                >
                    Thành phố
                </button>
            </div>
            <div className="content-group">
                <div id="content1" className={`content-item ${activeContent === "content1" ? "active" : "hidden"}`}>
                    <div className="list-city">
                        <Slider {...settings} className="slick-slidee">
                            <div className="slick-item">
                                <img className="list-city-img" src="../../../assets/image/city/HCM.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Đà Nẵng</h4>
                                    <p>cách đây 20km</p>
                                </div>
                            </div>

                        </Slider>
                    </div>
                </div>
                <div id="content2" className={`content-item ${activeContent === "content2" ? "active" : "hidden"}`}>
                    <div className="list-city">
                        <Slider {...settings} className="slick-slidee">
                            <div className="slick-item">
                                <img className="list-city-img" src="../../../assets/image/city/HCM.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Đà Nẵng</h4>
                                    <p>cách đây 20km</p>
                                </div>
                            </div>

                        </Slider>
                    </div>
                </div>
                <div id="content3" className={`content-item ${activeContent === "content3" ? "active" : "hidden"}`}>
                    <div className="list-city">
                        <Slider {...settings} className="slick-slidee">
                            <div className="slick-item">
                                <img className="list-city-img" src="../../../assets/image/city/HCM.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Đà Nẵng</h4>
                                    <p>cách đây 20km</p>
                                </div>
                            </div>
                            <div className="slick-item">
                                <img className="list-city-img" src="../../../assets/image/city/HCM.jpg" alt="Slide 1" />
                                <div className="info">
                                    <h4>Đà Nẵng</h4>
                                    <p>cách đây 20km</p>
                                </div>
                            </div>
                        </Slider>
                    </div>
                </div>
            </div>
        </div>
    )
}
export default TopLocation;
