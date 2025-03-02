using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class ImagePropertyDTO : BaseDTO
    {
        public string ImageURL { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public Guid PropertyID { get; set; }
    }
}
