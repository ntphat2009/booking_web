using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.Infrastructure.DTOs
{
    public class PolicyDTO : BaseDTO
    {
        public string Value { get; set; } = string.Empty;
        public string PropertyId { get; set; }
    }
}
