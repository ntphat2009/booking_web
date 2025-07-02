using BookingSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.DTOs
{
    public class CityDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string CategoryUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string Banner { get; set; } = string.Empty;
    }
}
