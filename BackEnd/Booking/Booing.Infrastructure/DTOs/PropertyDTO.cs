using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class PropertyDTO : BaseDTO
    {
        public string Name { get; set; } = string.Empty;
        public string PropertyUrl { get; set; } = string.Empty;
        public int CityID { get; set; }
        public string Street { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public decimal AvgPrice { get; set; }
        public string Rule { get; set; } = string.Empty;
    }
}
