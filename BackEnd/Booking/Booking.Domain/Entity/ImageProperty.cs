using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Domain.Entity
{
    public class ImageProperty : BaseImage
    {
        public Guid PropertyID { get; set; }
        public Property Property { get; set; }
    }
}
