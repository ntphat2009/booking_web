using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class ImageRoom : BaseImage
    {
        [StringLength(150)]
        public string RoomUrl { get; set; } = string.Empty;
        public string RoomId { get; set; }
        public Room Room { get; set; }
    }
}
