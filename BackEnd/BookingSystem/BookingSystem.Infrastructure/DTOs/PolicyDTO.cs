using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.DTOs
{
    public class PolicyDTO : BaseDTO
    {
        public string Value { get; set; } = string.Empty;
        public string PropertyUrl { get; set; } = string.Empty;
        public string PropertyId { get; set; }
    }
}
