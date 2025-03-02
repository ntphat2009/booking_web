import React, { useEffect, useState } from 'react'
import MapComponent from './Map';
import RangeSlider from './RangeSlider';
import { useParams } from 'react-router-dom';
import axios from 'axios';
import { toast } from 'react-toastify';
import { Property } from '../../models/Property';
import { City } from '../../models/City';
import SearchBox from '../../components/SearchBox';
import NavRoute from '../../components/NavRoute';
// import '../../assets'
const ListProperty: React.FC = () => {
    const { cityUrl } = useParams();
    const [City, setCity] = useState<City>()
    const [properties, setProperties] = useState<Property[]>([])
    console.log("useParams", cityUrl)
    useEffect(() => {
        const fetchCityByName = async () => {
            try {
                const response = await axios.get(`https://localhost:7214/api/Cities/GetCityByUrl?cityUrl=${cityUrl}`)
                if (response == null) {
                    throw "fetchProperties null"
                }
                else {
                    const data: City = await response.data;
                    const dataProperties: Property[] = data.Properties;
                    setCity(data);
                    setProperties(dataProperties);
                }
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
                            <h4>{City?.Name}: tìm thấy {properties.length} chỗ nghỉ</h4>
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
                        {City?.Properties && properties.length > 0 ?
                            (properties.map((property: Property) => (
                                <div className="cart-product">
                                    <div className="row">
                                        <div className="col-4">
                                            <img className='product-img' src={property.ImageProperties} alt="" />
                                        </div>
                                        <div className="col-8 product-info">
                                            <div className="important-info">
                                                <div className="">
                                                    <h3>{property.Name}</h3>
                                                    <span className='tag-adress'>Bãi biển(chưa gán động)</span>
                                                </div>
                                                <div className="rate">
                                                    <div className="tag-adress">
                                                        <span>aa</span>
                                                    </div>
                                                    <div className="tag-adress">
                                                        <span>Bãi biển</span>
                                                    </div>
                                                </div>
                                            </div>
                                            <div className="d-flex mb-3">
                                                <span className='deals-product'>{property.Services}</span>
                                            </div>
                                            <div className="important-info">
                                                <div >
                                                    <div className="service-details">
                                                        <p className='type-room'>Phòng gia đình sang trọng nhìn ra biển</p>
                                                        <p className='favor'>Bao bữa sáng</p>
                                                        <div>
                                                            <span className='c-span favor'><i className="fas fa-check"></i></span>
                                                            <span className='favor'>Miễn phí hủy</span>
                                                        </div>
                                                        <div>
                                                            <span className='c-span favor'><i className="fas fa-check"></i></span>
                                                            <span className='favor'>Không cần thanh toán trước</span>
                                                        </div>
                                                    </div>

                                                </div>
                                                <div className="flex-right">
                                                    <div className='d-grid'>
                                                        <p>4 người, 2 giường</p>
                                                        <h5>VND 4.560.000</h5>
                                                        <p>Đã bao gồm thuế và phí</p>
                                                    </div>
                                                    <div>
                                                        <button type="submit" className="view-room">Xem chỗ trông</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            ))
                            ) : ("")}

                    </div>
                </div>
            </div>
        </div>
    )
}
export default ListProperty;
