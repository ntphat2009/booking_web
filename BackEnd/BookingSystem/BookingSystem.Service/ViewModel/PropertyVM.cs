using BookingSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.ViewModel
{
    public class PropertyVM:BaseVM<string>
    {
        public string Name { get; set; } = string.Empty;
        public string PropertyUrl { get; set; } = string.Empty;
        public string CityUrl { get; set; }
        public string CityId { get; set; }
        public string CityName { get; set; }
        public string Street { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public decimal AvgPrice { get; set; }
        public string Rule { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ICollection<Service> Services { get; set; }
        public string ImageProperty { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
