using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class RoomDTO:BaseDTO
    {
        public Guid PropertyID { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public string RoomUrl { get; set; } = string.Empty;
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int MaxPeople { get; set; }
        public bool IsAvailable { get; set; }
    }
}
