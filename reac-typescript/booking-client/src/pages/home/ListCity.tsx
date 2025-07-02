import React, { useState, useEffect } from 'react'
import axios from 'axios';
import Slider from "react-slick";
import { City } from '../../models/City';
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import { Link } from 'react-router-dom';
import SpinnerLoad from '../../components/SpinnerLoad';
const ListCity: React.FC = () => {
    const [cities, setCities] = useState<City[]>([])
    useEffect(() => {
        const fetchCities = async () => {
            try {
                const response = await axios.get(`https://localhost:7214/api/Cities?page=1&pageSize=10&sortBy=updateat`);
                if (response == null) {
                    throw "response null";
                }
                else {
                    const data: City[] = await response.data;
                    setCities(data);
                }
            } catch (error) {
                console.error('Lỗi khi gọi API:', error);
            }
        };
        fetchCities();
        return () => {
        };
    }, []);
    const settings = {
        dots: false,          // Hiển thị chấm điều hướng
        infinite: true,      // Vòng lặp vô hạn
        speed: 500,          // Tốc độ chuyển (ms)
        slidesToShow: 6,     // Số slide hiển thị cùng lúc
        slidesToScroll: 1,   // Số slide cuộn mỗi lần
        autoplay: true,      // Tự động chạy
        autoplaySpeed: 4000, // Tốc độ tự động chạy (ms)
    };
    return (
        <div className="wrapper">
            <div>
                <h2>Khám phá Việt Nam</h2>
                <p>Các điểm đến phổ biến này có nhiều điều chờ đón bạn</p>
            </div>
            <div className="list-city">
                <Slider {...settings} className="slick-slidee">
                    {cities && cities.length > 0 ? (
                        cities.map((city:City) => (
                            <Link to={`/search-result/${city.CityUrl}`} key={city.Id} >
                                <div className="slick-item">
                                    <img className="list-city-img" src={city.Banner} alt="Slide 1" />
                                    <div className="info">
                                        <h4>{city.Name}</h4>
                                        <p>2.100 chỗ nghỉ</p>
                                    </div>
                                </div>
                            </Link>
                        ))
                    ) : (
                        <SpinnerLoad></SpinnerLoad>
                    )}

                </Slider>
            </div>
        </div>
    )
}
export default ListCity;

