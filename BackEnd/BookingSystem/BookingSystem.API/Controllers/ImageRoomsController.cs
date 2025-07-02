using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageRoomsController : ControllerBase
    {
        private readonly ILogger<ImageRoomsController> _logger;
        private readonly IImageRoomService _service;
        private readonly BaseApiResponse _response;

        public ImageRoomsController(ILogger<ImageRoomsController> logger, IImageRoomService service)
        {
            _logger = logger;
            _service = service;
            _response = new BaseApiResponse();
        }
        [HttpPost]
        public async Task<IActionResult> InsertImageRoomAsync(ImageRoomDTO image)
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
        public async Task<IActionResult> UpdateImageRoomAsync(ImageRoomDTO image, string imageID)
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
        public async Task<IActionResult> DeletedImageRoomAsync(string deletedBy, string imageID)
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
