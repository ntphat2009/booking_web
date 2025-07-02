using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class Tag : BaseEntity<string>
    {
        public string TagName { get; set; } = string.Empty;
        [StringLength(150)]
        public string PropertyUrl { get; set; } = string.Empty;
        public string PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
