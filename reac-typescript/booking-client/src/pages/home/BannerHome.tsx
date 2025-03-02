import SearchBox from '../../components/SearchBox'
import React from 'react'
const BannerHome: React.FC = () => {
    return (
        <div>
            <div className="banner-home">
                <div className="background-gradient"></div>
                <img className="img-banner" src='https://r-xx.bstatic.com/xdata/images/xphoto/2880x868/428203771.jpeg?k=abace62fa6ff7d143bc66e567ce3b821ee9a6046659f552fa9d4eb1ed03e9f7b&o=' alt="" />
                <div className="form-banner">
                    <div className="content-banner">
                        <h1 className="h1-content-banner">Tiết kiệm tới 35% với Ưu Đãi Black Friday</h1>
                        <p className="p-content-banner">Bàn kế hoạch du lịch thành hiện thực. Đặt trước 4/12/2024, thời gian lưu trú đến hết năm 2025</p>
                    </div>
                </div>
            </div>
            <SearchBox />
            <div className="wrapper">
                <div>
                    <h2>Tiếp tục tìm kiếm</h2>
                </div>
                <div className="list-search-history">
                    <ul>
                        <li>
                            <div className="container-history">
                                <div className="container-img">
                                    <img className="city-img" src="../../../assets/image/city/HCM.jpg" alt="" />
                                </div>
                                <div className="container-info info-search-history">
                                    <h4>TP.Ho Chi Minh</h4>
                                    <p>T4, 4 tháng 12-T7, 7 tháng 12</p>
                                    <p>2 người lớn</p>
                                </div>
                            </div>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    )
}
export default BannerHome;
