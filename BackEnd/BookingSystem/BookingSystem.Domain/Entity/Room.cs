using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class Room : BaseEntity<string>
    {
        [StringLength(150)]
        public string PropertyUrl { get; set; } = string.Empty;
        public string PropertyId { get; set; }
        [StringLength(50)]
        public string RoomNumber { get; set; } = string.Empty;
        [StringLength(50)]
        public string RoomType { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public int MaxPeople { get; set; }
        public bool IsAvailable { get; set; }
        public Property Property { get; set; }
        public ICollection<ImageRoom> ImageRooms { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
