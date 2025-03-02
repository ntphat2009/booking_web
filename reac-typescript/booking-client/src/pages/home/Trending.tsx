import React, { useEffect, useState } from 'react'
import axios from 'axios';
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Category } from '../../models/Category';
import SpinnerLoad from '../../components/SpinnerLoad';
const Trending: React.FC = () => {
    const [categories, setCategories] = useState<Category[]>([])
    useEffect(() => {

        const fetchApi = async () => {
            try {
                const response = await axios.get("https://localhost:7214/Categories/GetAllCategory?page=1&pageSize=10&sortBy=date_desc");
                if (response == null) {
                    throw "response was null"
                }
                else {
                    setCategories(response.data)
                }
            } catch (error) {
                console.log(error)
            }
        }
        fetchApi();
        return () => {

        };
    }, []);
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
                <h2>Điểm đến thịnh hành</h2>
                <p>Các lựa chọn phổ biến nhất cho du khách từ Việt Nam</p>
            </div>
            <div className="trendding">
                <div className="container">
                    <div className="row mt-2">

                        <div className="col-6 trendding-card">
                            <a href="#">
                                <div className="city-name">
                                    <h3>
                                        TP. Hồ Chí Minh
                                    </h3>
                                </div>
                                <div className="trendding-img">
                                    <img src="https://cf.bstatic.com/xdata/images/city/600x600/688893.jpg?k=d32ef7ff94e5d02b90908214fb2476185b62339549a1bd7544612bdac51fda31&o=" alt="" />
                                </div>
                            </a>
                        </div>
                        <div className="col-6 trendding-card">
                            <a href="#">
                                <div className="city-name">
                                    <h3>
                                        Đà Nẵng
                                    </h3>
                                </div>
                                <div className="trendding-img">
                                    <img src="https://cf.bstatic.com/xdata/images/city/600x600/688844.jpg?k=02892d4252c5e4272ca29db5faf12104004f81d13ff9db724371de0c526e1e15&o=" alt="" />
                                </div>
                            </a>
                        </div>
                    </div>
                    <div className="row mt-2">
                        <div className="col-4 trendding-card">
                            <a href="#">
                                <div className="city-name">
                                    <h3>
                                        Vũng Tàu
                                    </h3>
                                </div>
                                <div className="trendding-img">
                                    <img src="https://cf.bstatic.com/xdata/images/city/600x600/688956.jpg?k=fc88c6ab5434042ebe73d94991e011866b18ee486476e475a9ac596c79dce818&o=" alt="" />
                                </div>
                            </a>
                        </div>
                        <div className="col-4 trendding-card">
                            <a href="#">
                                <div className="city-name">
                                    <h3>
                                        Hà Nội
                                    </h3>
                                </div>
                                <div className="trendding-img">
                                    <img src="https://cf.bstatic.com/xdata/images/city/600x600/981517.jpg?k=2268f51ad34ab94115ea9e42155bc593aa8d48ffaa6fc58432a8760467dc4ea6&o=" alt="" />
                                </div>
                            </a>
                        </div>
                        <div className="col-4 trendding-card">
                            <a href="#">
                                <div className="city-name">
                                    <h3>
                                        Đà Lạt
                                    </h3>
                                </div>
                                <div className="trendding-img">
                                    <img src="https://cf.bstatic.com/xdata/images/city/600x600/688831.jpg?k=7b999c7babe3487598fc4dd89365db2c4778827eac8cb2a47d48505c97959a78&o=" alt="" />
                                </div>
                            </a>
                        </div>
                    </div>
                </div>
            </div>
            <div className="list-city">
                <Slider {...settings} className="slick-slidee">
                    {
                        categories && categories.length > 0 ? (
                            categories.map((category) => (
                                <div className="slick-item">
                                    <img className="list-city-img" src={category.Image} alt="Slide 1" />
                                    <div className="info">
                                        <h4>{category.Name}</h4>
                                    </div>
                                </div>
                            ))
                        ) : (
                            <SpinnerLoad />
                        )
                    }
                </Slider>
            </div>
        </div>
    )
}
export default Trending;
