using BookingSystem.APIService.Services;
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly ILogger<PropertyRepository> _logger;
        private readonly IPropertyService _propertyService;
        private readonly BaseApiResponse _response;

        public PropertiesController(ILogger<PropertyRepository> logger, IPropertyService propertyService)
        {
            _logger = logger;
            _propertyService = propertyService;
            _response = new BaseApiResponse();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPropertyAsync(int page = 1, int pageSize = 10, string sortBy = "updateat")
        {
            var result = await _propertyService.GetAllAsync(page, pageSize, sortBy);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }
        [HttpGet("city-url={cityUrl}")]
        public async Task<IActionResult> GetByCityUrlAsync(string cityUrl, int page = 1, int pageSize = 10, string sortBy = "updateat")
        {
            var result = await _propertyService.GetByCityUrlAsync(cityUrl, page, pageSize, sortBy);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }
        [HttpGet("url={propertyUrl}")]
        public async Task<IActionResult> GetPropertyByNameAsync(string propertyUrl)
        {

            var result = await _propertyService.GetByUrlAsync(propertyUrl);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpPost]
        public async Task<IActionResult> InsertPropertyAsync(PropertyDTO property)
        {
            try
            {
                await _propertyService.AddPropertyAsync(property);
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

        [HttpPut("UpdateProperty")]
        public async Task<IActionResult> UpdatePropertyAsync(PropertyDTO property, string propertyUrl)
        {
            try
            {
                await _propertyService.UpdatePropertyAsync(property, propertyUrl);
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
        public async Task<IActionResult> DeletedPropertyAsync(string propertyUrl, string deletedBy)
        {
            try
            {
                await _propertyService.DeletePropertyAsync(propertyUrl, deletedBy);
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
