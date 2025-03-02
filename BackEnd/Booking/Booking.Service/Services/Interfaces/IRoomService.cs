using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<Room>> GetAllAsync(int page, int pageSize, string sortBy);
        public Task<Room> GetByUrlAsync(string roomNumber);
        public Task AddRoomAsync(RoomDTO room);
        public Task UpdateRoomAsync(RoomDTO room, string roomNumber);
        public Task DeleteRoomAsync(string deletedBy, string roomNumber);
    }
}
