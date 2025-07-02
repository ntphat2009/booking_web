using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.DTOs
{
    public class RoomDTO : BaseDTO
    {
        public string PropertyUrl { get; set; }
        public string PropertyId { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public required string RoomId { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int MaxPeople { get; set; }
        public bool IsAvailable { get; set; }
    }
}
