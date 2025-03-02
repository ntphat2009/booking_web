using Booking.ApiService.Services;
using Booking.ApiService.Services.Interfaces;
using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Newtonsoft.Json;


namespace Booking.API.Controllers
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
        [HttpGet("GetAllCity")]
        public async Task<IActionResult> GetAllCityAsync(string? keyWord, int page = 1, int pageSize = 10, string sortBy = "desc")
        {
            var result = await _cityService.GetAllCityAsync(page, pageSize, sortBy, keyWord);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpGet("GetCityByUrl")]
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

        [HttpPost("InsertCity")]
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

        [HttpPut("UpdateCity")]
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

        [HttpPut("DeletedCity")]
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
