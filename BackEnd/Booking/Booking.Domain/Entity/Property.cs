using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public class Property : BaseEntity<string>
    {
        [StringLength(250)]
        public string Name { get; set; } = string.Empty;
        [StringLength(300)]
        public string PropertyUrl { get; set; } = string.Empty;
        public int CityId { get; set; }
        [StringLength(250)]
        public string Street { get; set; } = string.Empty;
        [StringLength(250)]
        public string District { get; set; } = string.Empty;
        public decimal AvgPrice { get; set; }
        public string Rule { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string UserId { get; set; }= string.Empty;
        public ApplicationUser User { get; set; }
        public City City { get; set; }
        public ICollection<Service> Services { get; set; }
        public ICollection<ImageProperty> ImageProperties { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
