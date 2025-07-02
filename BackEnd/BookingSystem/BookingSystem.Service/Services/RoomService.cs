
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
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
            return await _roomRepository.GetRoomsAsync(page, pageSize, sortBy);
        }

        public async Task<Room> GetRoomAsync(string roomNumber, string propertyUrl)
        {
            return await _roomRepository.GetRoomAsync(roomNumber, propertyUrl);
        }



        public async Task UpdateRoomAsync(RoomDTO room, string roomNumber)
        {
            await UpdateRoomAsync(room, roomNumber);
        }
    }
}
