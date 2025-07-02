using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.Infrastructure.Repositories.InterfaceRepository
{
    public interface IRoomRepository
    {
        public Task<Room> GetRoomByIdAsync(string id);
        public Task<IEnumerable<Room>> GetRoomsAsync(int page, int pageSize, string sortBy);
        public Task<Room> GetRoomAsync(string roomNumber, string propertyUrl);
        public Task AddRoomAsync(RoomDTO room);
        public Task UpdateRoomAsync(RoomDTO room, string roomNumber);
        public Task DeleteRoomAsync(string deletedBy, string roomNumber);
    }
}
