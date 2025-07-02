import React, { useEffect, useState } from 'react'
import MapComponent from './Map';
import RangeSlider from './RangeSlider';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { Property } from '../../models/Property';
import { CartProduct } from '../../components/CartProduct';
import SearchBox from '../../components/SearchBox';
import NavRoute from '../../components/NavRoute';
// import '../../assets'
const ListProperty: React.FC = () => {
    const { cityUrl } = useParams();
    const [properties, setProperties] = useState<Property[]>([])
    useEffect(() => {
        const fetchCityByName = async () => {
            try {
                const response = await axios.get(`https://localhost:7214/api/Properties/city-url=${cityUrl}?page=1&pageSize=10&sortBy=updateat`)
                const dataProperties: Property[] = await response.data;
                setProperties(dataProperties);
            } catch (error) {
                console.error('Lỗi khi gọi API:', error);
            }
        }
        fetchCityByName();
        return () => {
        };
    }, [cityUrl])
    console.log(properties)
    return (
        <div>
            <SearchBox></SearchBox>
            <NavRoute></NavRoute>
            <div className="wrapper">
                <div className="row">
                    <div className="col-3">
                        <div className="ggmap">
                            <MapComponent />
                        </div>
                        <div className="filter">
                            <div className="filter-key-word">
                                <h2>Chọn lọc theo :</h2>
                            </div>
                            <div className="filter-range">
                                <div className="filter-field">
                                    <fieldset >
                                        <legend>Ngân sách của bạn (mỗi đêm)</legend>
                                        <RangeSlider />
                                    </fieldset>
                                </div>
                            </div>
                            <div className="filter-range">
                                <div className="filter-field">
                                    <fieldset >
                                        <legend>Bữa ăn</legend>
                                        <label className="cb-field">
                                            <input type="checkbox" className="cb-button" name="" id="" />
                                            <span>tự nấu</span>
                                        </label>
                                        <label className="cb-field">
                                            <input type="checkbox" className="cb-button" name="" id="" />
                                            <span>Bao gồm bữa sáng</span>
                                        </label>
                                    </fieldset>
                                </div>
                            </div>
                            <div className="filter-range">
                                <div className="filter-field">
                                    <fieldset >
                                        <legend>Bữa ăn</legend>
                                        <label className="cb-field">
                                            <input type="checkbox" className="cb-button" name="" id="" />
                                            <span>tự nấu</span>
                                        </label>
                                        <label className="cb-field">
                                            <input type="checkbox" className="cb-button" name="" id="" />
                                            <span>Bao gồm bữa sáng</span>
                                        </label>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-9">
                        <div className="search-key">
                            <h4>{properties[0]?.CityName}: tìm thấy {properties.length} chỗ nghỉ</h4>
                        </div>
                        <div className="tags-list">
                            <div className="search-tag">
                                <span>Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                            <div className="search-tag">
                                <span>Bãi biển Bãi biển Bãi biển Bãi biển Bãi biển Bãi biển Bãi biển Bãi biển Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                            <div className="search-tag">
                                <span>Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                            <div className="search-tag">
                                <span>Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                            <div className="search-tag">
                                <span>Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                            <div className="search-tag">
                                <span>Bãi biển</span>
                                <span className='x-span'><i className="fas fa-times"></i></span>
                            </div>
                        </div>
                        {properties.length > 0 ?
                            (properties.map((property: Property) => (
                                <CartProduct {...property}/>
                            ))
                            ) : <p>Không có sản phẩm nào.</p>}
                    </div>
                </div>
            </div>
        </div>
    )
}
export default ListProperty;
