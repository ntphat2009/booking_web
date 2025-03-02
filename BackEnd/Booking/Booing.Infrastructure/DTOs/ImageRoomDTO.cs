using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class ImageRoomDTO : BaseDTO
    {
        public string ImageURL { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public Guid RoomID { get; set; }
    }
}
