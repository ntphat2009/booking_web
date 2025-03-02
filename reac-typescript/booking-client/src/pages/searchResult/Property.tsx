import React from 'react'
import NavRoute from '../../components/NavRoute'
import SearchBox from '../../components/SearchBox'
import Map from './Map'
import { Link } from 'react-router-dom'
import Slider from "react-slick";
import "slick-carousel/slick/slick.css";
import "slick-carousel/slick/slick-theme.css";
import ListCity from './../home/ListCity';
const Property = () => {
    const settings = {
        dots: false,          // Hiển thị chấm điều hướng
        slidesToShow: 3,     // Số slide hiển thị cùng lúc
        slidesToScroll: 1,   // Số slide cuộn mỗi lần
        autoplay: false,      // Tự động chạy
    };
    return (
        <div>
            <SearchBox />
            <NavRoute />
            <div className="wrapper">
                <div className="row">
                    <div className="col-10">
                        <h3>The IMPERIAL Vung Tau Hotel</h3>
                    </div>
                    <div className="col-2">
                        <div className='more-option'>
                            <div className="bt-famous">
                                <i className="far fa-heart fas-icon"></i>
                            </div>
                            <div className="bt-share">
                                <i className="fas fa-share-alt fas-icon"></i>
                            </div>
                            <div className="bt-book">
                                <span className='search-submit'>Đặt ngay</span>
                            </div>
                        </div>

                    </div>
                </div>
                <div>
                    <span className='tag-adress'>159 Thuy Van Street, Vũng Tàu, Việt Nam</span>
                    <div className="PriceMatch">
                        <i className="fas fa-tag fas-icon"></i>
                        <span className='mx-2'>Chúng tôi luôn khớp giá</span>
                    </div>
                </div>
                <div className="row mt-4">
                    <div className="col-9 buid-image">
                        <div className="image-gallery">
                            <div className="image large">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max1024x768/647441996.jpg?k=5bbf963250650a643eadefff092f73298fded715e9f7ac66e05fb071af04d91d&o=" alt="Large Image" />
                            </div>
                            <div className="image small">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 1" />
                            </div>
                            <div className="image small">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 1" />
                            </div>
                        </div>
                        <div className="image-more">
                            <div className="image small more">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 4" />
                            </div>
                            <div className="image small more">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 4" />
                            </div>
                            <div className="image small more">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 4" />
                            </div>
                            <div className="image small more">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 4" />
                            </div>
                            <div className="image small more">
                                <img src="https://cf.bstatic.com/xdata/images/hotel/max500/647446205.jpg?k=dd59427e6a4b4eb6d25f917836afde32fc318fee8bb5148b73cead4cf3525d59&o=" alt="Small Image 4" />
                                <div className="overlay">+37 ảnh</div>
                            </div>
                        </div>
                    </div>
                    <div className="col-3">
                        <div>
                            <div className='filter'>
                                <div className="most-rate">
                                    <div className="text-content">
                                        <strong>Rất tốt</strong>
                                        <span>1.163 đánh giá</span>
                                    </div>
                                    <div className="average-point">8,5</div>
                                </div>
                                <hr />
                                <div>
                                    <div className="random-review">
                                        “The hotel is one of the best we have stayed in.
                                        The staff were amazing, always there to help, from housekeeping,bar staff, doorman,receptionist and...”
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div className='mt-4'>
                            <Map />

                        </div>
                    </div>
                </div>
                <div className="row mt-4">
                    <div className="col-9">
                        <div className="des">
                            You might be eligible for a Genius discount at The IMPERIAL Vung Tau Hotel. To check if a Genius discount is available for your selected dates sign in.
                            Genius discounts at this property are subject to book dates, stay dates and other available deals.
                            <p className='font-weight-bolder'>
                                Get the celebrity treatment with world-class service at The IMPERIAL Vung Tau Hotel
                            </p>
                            Boasting a private beach area, The IMPERIAL Vung Tau Hotel offers accommodation with Victorian décor in Back Beach area. The hotel has an outdoor swimming pool and 2 on-site dining options. Guests can enjoy free WiFi access in all areas.
                            Overlooking the ocean, pool or city, all ample guestrooms come air-conditioned and fitted with a wardrobe and personal safe. Featuring large windows, each well-appointed unit features a seating area, desk and cable flat-screen TV. En suite bathroom is equipped with a bathtub and shower facility. You will find a hairdryer, slippers, bathrobes and toiletries for your comfort.
                            Recreation facilities include a beach club, luxurious spa and fitness centre. Operating 24-hour front desk, The IMPERIAL Vung Tau Hotel provides various services, including luggage storage and free parking.
                            The Dining Restaurant serves Vietnamese, Asian and European dishes. Guests can enjoy fresh seafood at La Sirena seafood restaurant. Guests can also enjoy many choices of drinks and beverages at Lobby Lounge.
                            Vung Tau Light House and Christ of Vung Tau are within 2.2 km from the hotel, while Nghinh Phong Cape is 2.9 km away. The nearest airport is Tan Son Nhat Airport, 100 km away.
                            Couples particularly like the location — they rated it 9.0 for a two-person trip.
                        </div>
                    </div>
                    <div className="col-3"></div>
                </div>
                <div className="mt-4">
                    <table className='table table-bordered'>
                        <thead >
                            <th>
                                Loại chỗ nghỉ
                            </th>
                            <th>
                                Số lượng khách
                            </th>
                            <th>
                            </th>
                        </thead>
                        <tbody>
                            <td>
                                <Link to={""}> Ưu Đãi Đặc Biệt - Phòng Heritage Deluxe Giường Đôi Có Ban Công
                                </Link>
                            </td>
                            <td>Tối đa 4 khách(2 người lớn)</td>
                            <td><span className='btn btn-info-nothover'>Hiển thị giá</span></td>
                        </tbody>
                    </table>
                </div>
                {/* review */}
                <div className="mt-4">
                    <div className="d-flex justify-content-between">
                        <div className='fw-bold fs-4'>Đánh giá của khách</div>
                        <span className='btn btn-info-nothover'>Xem phòng trống</span>
                    </div>
                    <div className="list-city">
                        <Slider {...settings} className="slick-slidee">
                            <Link to={``}  >
                                <div className="slick-item border p-3">
                                    <div className="d-flex ">
                                        <img className="img-account-review" src={""} alt="avatar" />
                                        <span>Name User</span>
                                    </div>
                                    <div className="random-review">
                                        “The hotel is one of the best we have stayed in.
                                        The staff were amazing, always there to help, from housekeeping,bar staff, doorman,receptionist and...”
                                    </div>
                                </div>
                            </Link>
                            <Link to={``}  >
                                <div className="slick-item border p-3">
                                    <div className="d-flex ">
                                        <img className="img-account-review" src={""} alt="avatar" />
                                        <span>Name User</span>
                                    </div>
                                    <div className="random-review">
                                        “The hotel is one of the best we have stayed in.
                                        The staff were amazing, always there to help, from housekeeping,bar staff, doorman,receptionist and...”
                                    </div>
                                </div>
                            </Link>
                            <Link to={``}  >
                                <div className="slick-item border p-3">
                                    <div className="d-flex ">
                                        <img className="img-account-review" src={""} alt="avatar" />
                                        <span>Name User</span>
                                    </div>
                                    <div className="random-review">
                                        “The hotel is one of the best we have stayed in.
                                        The staff were amazing, always there to help, from housekeeping,bar staff, doorman,receptionist and...”
                                    </div>
                                </div>
                            </Link>
                        </Slider>
                    </div>
                </div>
                {/* rule */}
                <div className="mt-4">
                    <div className="d-flex justify-content-between">
                        <div className='fw-bold fs-4'>Quy tắc chung</div>
                        <span className='btn btn-info-nothover'>Xem phòng trống</span>
                    </div>
                    <div className="rule border mt-4">
                        You might be eligible for a Genius discount at The IMPERIAL Vung Tau Hotel. To check if a Genius discount is available for your selected dates sign in.
                        Genius discounts at this property are subject to book dates, stay dates and other available deals.
                        Boasting a private beach area, The IMPERIAL Vung Tau Hotel offers accommodation with Victorian décor in Back Beach area. The hotel has an outdoor swimming pool and 2 on-site dining options. Guests can enjoy free WiFi access in all areas.
                        Overlooking the ocean, pool or city, all ample guestrooms come air-conditioned and fitted with a wardrobe and personal safe. Featuring large windows, each well-appointed unit features a seating area, desk and cable flat-screen TV. En suite bathroom is equipped with a bathtub and shower facility. You will find a hairdryer, slippers, bathrobes and toiletries for your comfort.
                        Recreation facilities include a beach club, luxurious spa and fitness centre. Operating 24-hour front desk, The IMPERIAL Vung Tau Hotel provides various services, including luggage storage and free parking.
                        The Dining Restaurant serves Vietnamese, Asian and European dishes. Guests can enjoy fresh seafood at La Sirena seafood restaurant. Guests can also enjoy many choices of drinks and beverages at Lobby Lounge.
                        Vung Tau Light House and Christ of Vung Tau are within 2.2 km from the hotel, while Nghinh Phong Cape is 2.9 km away. The nearest airport is Tan Son Nhat Airport, 100 km away.
                        Couples particularly like the location — they rated it 9.0 for a two-person trip.
                    </div>
                </div>
            </div>
        </div>
    )
}

export default Property
