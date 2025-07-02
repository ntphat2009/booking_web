using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.Contracts;
using BookingSystem.Infrastructure.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        private readonly ILogger<Booking> _logger;
        private readonly ApplicationDbContext _context;
        public BookingRepository(ApplicationDbContext context, ILogger<Booking> logger) : base(context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task AddBooking(BookingDTO bookingDTO)
        {
            try
            {
                var newBooking = new Domain.Entity.Booking
                {
                    UserId = bookingDTO.UserId,
                    BookingStatus = bookingDTO.BookingStatus,
                    CheckInDate = bookingDTO.CheckInDate,
                    CheckOutDate = bookingDTO.CheckOutDate,
                    Id = Guid.NewGuid().ToString(),
                    IsDeleted = false,
                    RoomId = bookingDTO.RoomId,
                    TotalPrice = bookingDTO.TotalPrice,
                    UpdatedAt = DateTime.Now,
                    UpdatedBy = bookingDTO.UpdatedBy,
                    CreatedAt = DateTime.Now,
                    CreatedBy = bookingDTO.CreatedBy,
                };
                await AddAsync(newBooking);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("ADD BOOKING EX", ex);
                throw new Exception("ADD BOOKING EX", ex);
            }
        }

        public async Task DeleteBooking(string bookingId)
        {
            try
            {
                var booking = await _context.Bookings.FirstOrDefaultAsync(x => x.Id == bookingId);
                if (booking == null)
                {
                    _logger.LogWarning("booking history not found");
                    return;
                }
                booking.IsDeleted = true;
                booking.UpdatedAt = DateTime.Now;
                booking.UpdatedBy = booking.CreatedBy;
                await DeleteAsync(booking);
            }
            catch (Exception ex)
            {
                _logger.LogWarning("DELETED BOOKING EX", ex);
                throw new Exception("DELETED BOOKING EX", ex);
            }
        }

        public async Task<Booking> GetBookingByIdAsync(string id)
        {
            return await GetByIdAsync(filter: b => (b.CheckInDate >= DateTime.Now.AddMonths(-3)), predicate: r => r.Id == id);
        }

        protected override Expression<Func<Booking, object>>? GetSortExpression(string sortBy)
        {
            throw new NotImplementedException();
        }
    }
}
