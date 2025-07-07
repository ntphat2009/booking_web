using BookingSystem.APIService.Services;
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _service;
        private readonly ILogger<RoomsController> _logger;
        private readonly BaseApiResponse _response;

        public RoomsController(IRoomService service, ILogger<RoomsController> logger)
        {
            _service = service;
            _logger = logger;
            _response = new BaseApiResponse();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRoomAsync(int page = 1, int pageSize = 10, string sortBy = "updateat")
        {
            var result = await _service.GetAllAsync(page, pageSize, sortBy);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpGet("url={roomyUrl}")]
        public async Task<IActionResult> GetRoomByNameAsync(string roomNumber, string propertyUrl)
        {
            var result = await _service.GetRoomAsync(roomNumber, propertyUrl);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }
        [HttpGet("room-list")]
        public async Task<IActionResult> GetRoomListAsync()
        {
            var result = await _service.GetRoomListAsync();
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            return Ok(jsonConvert);
        }

        [HttpPost]
        public async Task<IActionResult> InsertRoomAsync(RoomDTO roomy)
        {
            try
            {
                await _service.AddRoomAsync(roomy);
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
        public async Task<IActionResult> UpdateRoomAsync(RoomDTO roomy, string roomyUrl)
        {
            try
            {
                await _service.UpdateRoomAsync(roomy, roomyUrl);
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
        public async Task<IActionResult> DeletedRoomAsync(string roomyUrl, string deletedBy)
        {
            try
            {
                await _service.DeleteRoomAsync(roomyUrl, deletedBy);
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
