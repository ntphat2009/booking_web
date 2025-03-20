import React, { useEffect, useState } from 'react'
import MapComponent from './Map';
import RangeSlider from './RangeSlider';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';
import { Property } from '../../models/Property';
import { City } from '../../models/City';
import { CartProduct } from '../../components/CartProduct';
import SearchBox from '../../components/SearchBox';
import NavRoute from '../../components/NavRoute';
// import '../../assets'
const ListProperty: React.FC = () => {
    const { cityUrl } = useParams();
    const [city, setCity] = useState<City>()
    const [properties, setProperties] = useState<Property[]>([])
    useEffect(() => {
        const fetchCityByName = async () => {
            try {
                const response = await axios.get(`https://localhost:7214/api/Cities/GetCityByUrl?cityUrl=${cityUrl}`)
                const data: City = await response.data;
                const dataProperties: Property[] = data.Properties;
                setCity(data);
                setProperties(dataProperties);
            } catch (error) {
                console.error('Lỗi khi gọi API:', error);
            }
        }
        fetchCityByName();
        return () => {
        };
    }, [])
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
                            <h4>{city?.Name}: tìm thấy {properties.length} chỗ nghỉ</h4>
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
                        {city?.Properties && properties.length > 0 ?
                            (properties.map((property: Property) => (
                                <CartProduct property={property} cityUrl={city.CityUrl} />
                            ))
                            ) : ("")}

                    </div>
                </div>
            </div>
        </div>
    )
}
export default ListProperty;
