﻿using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services.Interfaces
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAllCityAsync(int page, int pageSize, string sortBy, string keyWord);
        public Task<City> GetCityByNameAsync(string cityUrl);
        public Task AddCityAsync(CityDTO cityDTO);
        public Task UpdateCityAsync(CityDTO city, string cityUrl);
        public Task DeleteCityAsync(string cityUrl, string deletedBy);
    }
}
