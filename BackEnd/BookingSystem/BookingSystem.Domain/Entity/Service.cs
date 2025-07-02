using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class Service : BaseEntity<int>
    {
        public string Value { get; set; } = string.Empty;
        public Property Property { get; set; }
        public string PropertyUrl { get; set; } = string.Empty;
        public string PropertyId { get; set; }
    }
}
