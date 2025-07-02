using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
namespace BookingSystem.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Category,CategoryDTO>();
            CreateMap<CategoryDTO,Category>();

            CreateMap<City,CityDTO>();
            CreateMap<CityDTO,City>();

            CreateMap<Property,PropertyDTO>();
            CreateMap<PropertyDTO,Property>();

            CreateMap<Room,RoomDTO>();
            CreateMap<RoomDTO,Room>();
        }
    }
}
