using BookingSystem.APIService.Services;
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;


namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CitiesController> _logger;
        private readonly BaseApiResponse _response;

        public CitiesController(ICityService cityService, ILogger<CitiesController> logger)
        {
            _cityService = cityService;
            _logger = logger;
            _response = new BaseApiResponse();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCityAsync(string? keyWord, int page = 1, int pageSize = 10, string sortBy = "updateat")
        {
            var result = await _cityService.GetAllCityAsync(page, pageSize, sortBy, keyWord);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpGet("url={cityUrl}")]
        public async Task<IActionResult> GetCityByNameAsync(string cityUrl)
        {
            var result = await _cityService.GetCityByNameAsync(cityUrl);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpPost]
        public async Task<IActionResult> InsertCityAsync(CityDTO city)
        {
            try
            {
                await _cityService.AddCityAsync(city);
                _response.Result = "Add success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCityAsync(CityDTO city, string cityUrl)
        {
            try
            {
                await _cityService.UpdateCityAsync(city, cityUrl);
                _response.Result = "update success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletedCityAsync(string cityUrl, string deletedBy)
        {
            try
            {
                await _cityService.DeleteCityAsync(cityUrl, deletedBy);
                _response.Result = "deleted success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }
    }
}
