using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public class ImageRoom : BaseImage
    {
        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
