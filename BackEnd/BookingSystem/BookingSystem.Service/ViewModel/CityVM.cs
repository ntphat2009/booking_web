using BookingSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.ViewModel
{
    public class CityVM:BaseVM<int>
    {
        public string Name { get; set; } = string.Empty;
        [StringLength(150)]
        public string CityUrl { get; set; } = string.Empty;
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string Banner { get; set; } = string.Empty;
        public List<PropertyVM> Properties { get; set; }
        public string ImageProperty { get; set; }

    }
}
