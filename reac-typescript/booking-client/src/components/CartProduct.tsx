import { Property } from '../models/Property'
import { Link } from 'react-router-dom'
import VNDFormat from '../Utils/VNDFormat'
export const CartProduct = ( property :Property) => {
    const imageproperty = property.ImageProperty ?? "";
    return (
        <div className="cart-product">
            <div className="row">
                <div className="col-4">
                    <img className='img-cart-product' alt="" loading={'lazy'} src={imageproperty} />
                </div>
                <div className="col-8 product-info">
                    <div className="important-info">
                        <div className="">
                            <h3>
                                <Link to={`/search-result/${property.CityUrl}/${property.PropertyUrl}`} >
                                    {property.Name}
                                </Link>
                            </h3>
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
                                <h5>{VNDFormat(property.AvgPrice)}</h5>
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
    )
}
