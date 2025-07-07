import React, { useEffect, useRef, useState, ReactEventHandler } from 'react'
import $ from "jquery"; // Import jQuery
import "jquery-ui-bundle"; // Import jQuery UI CSS và JS
import "jquery-ui-bundle/jquery-ui.css";
const RangeSlider: React.FC = () => {
    const sliderRef = useRef<HTMLDivElement>(null); // Ref để tham chiếu đến DOM slider
    const [range, setRange] = useState<[number, number]>([100, 1000]); // State để lưu giá trị slider
    useEffect(() => {
        // Khởi tạo slider sau khi DOM đã được render
        const current = sliderRef.current;
        if (current) {
            $(current).slideToggle({
                range: true,
                min: 0,
                max: 10000,
                values: range,
                slide: (_event: ReactEventHandler, ui: { values: [number, number] }) => {
                    setRange(ui.values as [number, number]); // Cập nhật giá trị khi trượt slider
                },
            });
        }
        return () => {
            // Hủy slider khi component bị unmount

            if (current) {
                $(current).slideToggle("destroy");
            }
        };
    }, [range]);
    return (
        <div>
            <div>
                <div>
                    <label htmlFor="amount">
                        <input className="show-range-amount" type="text" id="amount" readOnly value={`${range[0]} VND - ${range[1]} VND`} />
                    </label>
                </div>
                <div id="slider-range" ref={sliderRef}></div>
            </div>
        </div>
    )
}
export default RangeSlider;

