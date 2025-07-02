using BookingSystem.ApiService.Services;
using BookingSystem.ApiService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly ILogger<BookingsController> _logger;
        private readonly BaseApiResponse _response;

        public BookingsController(IBookingService bookingService, ILogger<BookingsController> logger)
        {
            _bookingService = bookingService;
            _logger = logger;
            _response = new BaseApiResponse();
        }
        [HttpPost]
        public async Task<IActionResult> InsertCategoryAsync(BookingDTO bookingDto)
        {
            try
            {
                var result = await _bookingService.BookRoomAsync(bookingDto);
                if (result.IsSuccess)
                {
                    _response.Message = result.MessagesCode.ToString();
                    return Ok(_response);
                }
                _response.Message = result.MessagesCode.ToString();
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Insert Error");
                _response.Message = ex.Message;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return BadRequest(_response);
            }
        }
    }
}
