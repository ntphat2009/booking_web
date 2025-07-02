using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Avatar { get; set; } = string.Empty;
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(100)]
        public string FullName => FirstName + " " + LastName;
        [StringLength(150)]
        public string NameUrl { get; set; } = string.Empty;
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Property> Properties { get; set; }
    }
}