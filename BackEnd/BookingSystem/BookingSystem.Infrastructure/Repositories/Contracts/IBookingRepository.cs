using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.Contracts
{
    public interface IBookingRepository 
    {
        Task<Booking> GetBookingByIdAsync(string id);
        Task AddBooking(BookingDTO bookingDTO);
        Task DeleteBooking(string bookingId);
    }
}
