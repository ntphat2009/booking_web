using Booking.ApiService.Services;
using Booking.ApiService.Services.Interfaces;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Booking.API.Controllers
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
        [HttpGet("GetAllRoom")]
        public async Task<IActionResult> GetAllRoomAsync(int page = 1, int pageSize = 10, string sortBy = "desc")
        {
            var result = await _service.GetAllAsync(page, pageSize, sortBy);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            _response.Result = jsonConvert;
            return Ok(_response);
        }

        [HttpGet("GetRoomByUrl")]
        public async Task<IActionResult> GetRoomByNameAsync(string roomyUrl)
        {
            var result = await _service.GetByUrlAsync(roomyUrl);
            var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                Formatting = Formatting.Indented
            });
            _response.Result = jsonConvert;
            return Ok(_response);
        }

        [HttpPost("InsertRoom")]
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

        [HttpPut("UpdateRoom")]
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

        [HttpPut("DeletedRoom")]
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
