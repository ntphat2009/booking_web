using BookingSystem.APIService.Services;
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagePropertiesController : ControllerBase
    {
        private readonly ILogger<ImagePropertiesController> _logger;
        private readonly IImagePropertyService _service;
        private readonly BaseApiResponse _response;

        public ImagePropertiesController(ILogger<ImagePropertiesController> logger, IImagePropertyService service)
        {
            _logger = logger;
            _service = service;
            _response = new BaseApiResponse();
        }
        [HttpPost]
        public async Task<IActionResult> InsertImagePropertyAsync(ImagePropertyDTO image)
        {
            try
            {
                await _service.AddImage(image);
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
        public async Task<IActionResult> UpdateImagePropertyAsync(ImagePropertyDTO image, string imageID)
        {
            try
            {
                await _service.UpdateImage(image, imageID);
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
        public async Task<IActionResult> DeletedImagePropertyAsync(string deletedBy, string imageID)
        {
            try
            {
                await _service.DeleteImage(deletedBy, imageID);
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
