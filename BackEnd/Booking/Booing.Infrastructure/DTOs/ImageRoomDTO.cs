using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
   
    public class ImageRoomDTO : BaseImageDTO
    {
        public string ImageURL { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string RoomId { get; set; }
        public MyImageType ImageType { get; set; }
    }
}
