using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public enum MyImageType
    {
        Larger,
        Small,
        Smaller
    }
    public class BaseImage : BaseEntity<string>
    {
        public string ImageUrl { get; set; } = string.Empty;
        [StringLength(100)]
        public string ImageName { get; set; } = string.Empty;
        public MyImageType ImageType { get; set; }
    }
}
