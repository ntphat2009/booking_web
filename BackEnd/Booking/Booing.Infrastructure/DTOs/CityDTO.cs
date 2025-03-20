using Booking.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class CityDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Banner { get; set; } = string.Empty;
    }
}
