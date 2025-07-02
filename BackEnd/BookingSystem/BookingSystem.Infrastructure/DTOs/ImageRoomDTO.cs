using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.DTOs
{

    public class ImageRoomDTO : BaseImageDTO
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string RoomUrl { get; set; } = string.Empty;
        public required string RoomId { get; set; }
        public MyImageType ImageType { get; set; }
    }
}
