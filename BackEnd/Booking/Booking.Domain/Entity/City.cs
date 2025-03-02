using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public class City : BaseEntity<int>
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [StringLength(150)]
        public string CityUrl { get; set; } = string.Empty;
        public Category Category { get; set; }
        public int CategoryID { get; set; }
        public string Banner { get; set; } = string.Empty;
        public ICollection<Property> Properties { get; set; }
    }
}
