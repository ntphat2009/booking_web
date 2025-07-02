using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.ApiService.Services.Interfaces
{
    public class BookingResult
    {
        public bool IsSuccess { get; set; }
        public Message MessagesCode { get; set; }
        public enum Message
        {
            RoomNotFound,
            RoomNotAvailable,
            RegisterSuccess
        }
    }
    public interface IBookingService
    {
        public Task<BookingResult> BookRoomAsync(BookingDTO bookingDTO);
    }
}
