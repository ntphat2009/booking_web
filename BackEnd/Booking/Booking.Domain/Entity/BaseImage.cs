using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public class BaseImage:BaseEntity<Guid>
    {
        public string ImageURL { get; set; } = string.Empty;
        [StringLength(100)]
        public string ImageName { get; set; } = string.Empty;
    }
}
