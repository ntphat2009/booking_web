using BookingSystem.ApiService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.Contracts;
using BookingSystem.Infrastructure.Repositories.Implementations;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.ApiService.Services
{
    public class BookingService : IBookingService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository, IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }
        public async Task<BookingResult> BookRoomAsync(BookingDTO bookingDTO)
        {
            try
            {
                var room = await _roomRepository.GetRoomByIdAsync(bookingDTO.RoomId);
                if (room == null)
                {
                    return new BookingResult() { IsSuccess = false, MessagesCode = BookingResult.Message.RoomNotFound };
                }
                else
                {
                    var isbooking = room.Bookings.Count != 0;
                    DateTime threeMonthsAgo = DateTime.Now.AddMonths(-3);
                    var bookings = room.Bookings.OrderByDescending(b=>b.CheckInDate).ToList();
                    foreach (var b in bookings)
                    {
                        bool isRoomNotAvailable = bookingDTO.CheckInDate < b.CheckOutDate && bookingDTO.CheckOutDate > b.CheckInDate;

                        if (isRoomNotAvailable)
                        {
                            return new BookingResult() { IsSuccess = false, MessagesCode = BookingResult.Message.RoomNotAvailable };
                        }
                    }
                    await _bookingRepository.AddBooking(bookingDTO);
                    return new BookingResult() { IsSuccess = true, MessagesCode = BookingResult.Message.RegisterSuccess };
                }
            }
            catch (Exception ex)
            {
                throw new Exception("BookingService", ex);
            }
        }
    }
}
