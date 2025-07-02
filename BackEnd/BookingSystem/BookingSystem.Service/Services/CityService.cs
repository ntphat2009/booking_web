using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.APIService.ViewModel;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetAllCityAsync(int page, int pageSize, string sortBy, string keyWord)
        {
            return await _cityRepository.GetAllCityAsync(page, pageSize, sortBy, keyWord);
        }

        public async Task<City> GetCityByNameAsync(string cityUrl)
        {
            return await _cityRepository.GetCityByNameAsync(cityUrl);
        }

        public async Task AddCityAsync(CityDTO cityDTO)
        {
            await _cityRepository.AddCityAsync(cityDTO);
        }

        public async Task UpdateCityAsync(CityDTO city, string cityUrl)
        {
            await _cityRepository.UpdateCityAsync(city, cityUrl);
        }

        public async Task DeleteCityAsync(string cityUrl, string deletedBy)
        {
            await _cityRepository.DeleteCityAsync(cityUrl, deletedBy);
        }
    }
}
