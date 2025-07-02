using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Domain.Entity
{
    public enum DiscountType
    {
        Percentage,
        FixedAmount
    }
    public class Discount : BaseEntity<string>
    {
        [StringLength(50)]
        public string DiscountCode { get; set; } = string.Empty;
        [StringLength(50)]
        public string DiscountName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public DiscountType DiscountType { get; set; }
        public DateTime Expiry { get; set; }
    }
}
