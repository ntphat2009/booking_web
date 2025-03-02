import React, { Component } from 'react'
import PropTypes from 'prop-types'

export default class NavRoute extends Component {
    static propTypes = {
        prop: PropTypes
    }
    render() {
        return (
            <nav className="nav-history">
                <ul className="nav-list">
                    <li className="nav-item">
                        <span>
                            <a href="#">
                                Trang chủ
                            </a>
                        </span>
                    </li>
                    <li className="nav-item">
                        <span className="" aria-hidden="true"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="50px" data-rtl-flip="true"><path d="M8.913 19.236a.9.9 0 0 0 .642-.266l6.057-6.057a1.3 1.3 0 0 0 .388-.945c.008-.35-.123-.69-.364-.945L9.58 4.966a.91.91 0 0 0-1.284 0 .896.896 0 0 0 0 1.284l5.694 5.718-5.718 5.718a.896.896 0 0 0 0 1.284.88.88 0 0 0 .642.266"></path></svg></span>
                        <span>
                            <a href="#">
                                Việt Nam
                            </a>
                        </span>
                    </li>
                    <li className="nav-item">
                        <span className="" aria-hidden="true"><svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" width="50px" data-rtl-flip="true"><path d="M8.913 19.236a.9.9 0 0 0 .642-.266l6.057-6.057a1.3 1.3 0 0 0 .388-.945c.008-.35-.123-.69-.364-.945L9.58 4.966a.91.91 0 0 0-1.284 0 .896.896 0 0 0 0 1.284l5.694 5.718-5.718 5.718a.896.896 0 0 0 0 1.284.88.88 0 0 0 .642.266"></path></svg></span>
                        <span>
                            <a href="#">
                                Kết quả tìm kiếm
                            </a>
                        </span>
                    </li>
                </ul>
            </nav>
        )
    }
}
