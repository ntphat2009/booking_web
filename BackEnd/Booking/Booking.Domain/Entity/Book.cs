using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public enum Status
    {
        Waiting,
        Complete,
        Cancel
    }
    public class Book:BaseEntity<string>
    {
        public string UserId { get; set; }
        public string RoomId{ get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set;}
        public decimal TotalPrice { get; set; }
        public Status BookingStatus { get; set; }
        public Room Room { get; set; }
        public ApplicationUser User { get; set; }
    }
}
