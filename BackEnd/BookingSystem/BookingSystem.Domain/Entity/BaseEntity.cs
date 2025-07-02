using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public class BaseEntity<T>
    {
        public virtual T Id { get; set; }
        public bool IsDeleted { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        [StringLength(50)]
        public string CreatedBy { get; set; } = string.Empty;
        [StringLength(50)]
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
