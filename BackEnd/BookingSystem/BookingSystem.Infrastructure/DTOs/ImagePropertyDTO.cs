using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.DTOs
{

    public class ImagePropertyDTO : BaseImageDTO
    {
        public string ImageUrl { get; set; } = string.Empty;
        public string ImageName { get; set; } = string.Empty;
        public string PropertyUrl { get; set; } = string.Empty;
        public string PropertyId { get; set; }
        public MyImageType ImageType { get; set; }
    }
}
