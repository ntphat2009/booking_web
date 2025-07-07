using BookingSystem.ApiService.ViewModel.Room;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services.Interfaces
{
    public interface IRoomService
    {
        public Task<IEnumerable<RoomListVM>> GetRoomListAsync();
        public Task<IEnumerable<Room>> GetAllAsync(int page, int pageSize, string sortBy);
        public Task<Room> GetRoomAsync(string roomNumber, string propertyUrl);
        public Task AddRoomAsync(RoomDTO room);
        public Task UpdateRoomAsync(RoomDTO room, string roomNumber);
        public Task DeleteRoomAsync(string deletedBy, string roomNumber);
    }
}
