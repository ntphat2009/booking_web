using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class City : BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(150)]
        public string CityUrl { get; set; } = string.Empty;
        public Category Category { get; set; }
        [StringLength(150)]
        public string CategoryUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Banner { get; set; } = string.Empty;
        public ICollection<Property> Properties { get; set; }
    }
}
