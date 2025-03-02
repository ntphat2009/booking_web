import React from 'react'
const Map: React.FC = () => {
  return (
    <div
      className="eec927a9a4"
      style={{
        backgroundImage: `url("https://maps.googleapis.com/maps/api/staticmap?size=264x150&center=16.209980653583,108.086399195987&channel=sr-www&zoom=13&key=AIzaSyBdKFC4KGfYWho2c1M3BbSKcrMDjh_mPEQ&signature=pU_05w9BTV5iWjAPUO1wOWkvaXY=")`,
      }}
    >
      <div className="c944867a8c b8d2d0000b">
        <button
          data-map-trigger-button="1"
          type="button"
          className="a83ed08757 c21c56c305 a4c1805887 ab98298258 c082d89982 c6da63b617"
        >
          <span className="eedba9e88a a29f44e7c4">
            <span
              className="fcd9eec8fb bf9a32efa5 a84c4cb7ce"
              aria-hidden="true"
            >
              <svg
                xmlns="http://www.w3.org/2000/svg"
                viewBox="0 0 24 24"
                width="50px"
              >
                <path d="M12 0a8.01 8.01 0 0 0-8 8c0 3.51 5 12.025 7.148 15.524A1 1 0 0 0 12 24a.99.99 0 0 0 .852-.477C15 20.026 20 11.514 20 8a8.01 8.01 0 0 0-8-8m0 11.5A3.5 3.5 0 1 1 15.5 8a3.5 3.5 0 0 1-3.5 3.5"></path>
              </svg>
            </span>
          </span>
          <span className="e4adce92df">Hiển thị trên bản đồ</span>
        </button>
      </div>
    </div>
  )
}
export default Map;

