
using Booking.ApiService.Services.Interfaces;
using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }
        public async Task AddRoomAsync(RoomDTO room)
        {
            await _roomRepository.AddRoomAsync(room);
        }

        public async Task DeleteRoomAsync(string deletedBy, string roomNumber)
        {
            await _roomRepository.DeleteRoomAsync(deletedBy, roomNumber);
        }

        public async Task<IEnumerable<Room>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            return await _roomRepository.GetAllAsync(page, pageSize, sortBy);
        }

        public async Task<Room> GetByUrlAsync(string roomNumber)
        {
            return await _roomRepository.GetByUrlAsync(roomNumber);
        }

        public async Task UpdateRoomAsync(RoomDTO room, string roomNumber)
        {
            await UpdateRoomAsync(room, roomNumber);
        }
    }
}
