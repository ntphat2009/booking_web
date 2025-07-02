using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.Data;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.GenericRepository;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        private readonly ILogger<RoomRepository> _logger;
        private readonly ApplicationDbContext _context;

        public RoomRepository(ILogger<RoomRepository> logger, ApplicationDbContext dbContext) : base(dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<IEnumerable<Room>> GetRoomsAsync(int page, int pageSize, string sortBy)
        {
            var sortExpression = GetSortExpression(sortBy);
            return await GetsAsync(
                page: page,
                pageSize: pageSize,
                sortBy: sortExpression,
                filter: r => !r.IsDeleted,
                includes: [r => r.Property, r => r.ImageRooms]
                ) ?? [];
        }

        public async Task<Room> GetRoomAsync(string roomNumber, string propertyUrl)
        {
            var result = await _context.Rooms.AsNoTracking().Where(r => !r.IsDeleted)
                .Include(r => r.Property)
                .Include(r => r.ImageRooms)
                .FirstOrDefaultAsync(r => r.RoomNumber == roomNumber && r.PropertyUrl == propertyUrl);
            return result ?? new Room();
        }

        public async Task UpdateRoomAsync(RoomDTO room, string roomNumber)
        {
            try
            {
                var item = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == roomNumber);
                if (item == null)
                {
                    throw new Exception($"{roomNumber} not found");
                }
                else
                {
                    item.PropertyUrl = room.PropertyUrl;
                    item.PropertyId = room.PropertyId;
                    item.RoomNumber = roomNumber;
                    item.IsDeleted = false;
                    item.UpdatedAt = DateTime.Now;
                    item.CreatedBy = room.CreatedBy;
                    item.CreatedAt = room.CreatedAt;
                    item.PricePerNight = room.PricePerNight;
                    item.IsAvailable = true;
                    item.MaxPeople = room.MaxPeople;
                    await UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task AddRoomAsync(RoomDTO room)
        {
            try
            {
                var newRoom = new Room()
                {
                    Id = Guid.NewGuid().ToString(),
                    PropertyId = room.PropertyId,
                    RoomNumber = room.RoomNumber,
                    PropertyUrl = room.PropertyUrl,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = room.CreatedBy,
                    IsAvailable = true,
                    MaxPeople = room.MaxPeople,
                    IsDeleted = false,
                    PricePerNight = room.PricePerNight,
                    RoomType = room.RoomType,
                };
                await AddAsync(newRoom);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task DeleteRoomAsync(string deletedBy, string roomNumber)
        {
            try
            {
                var item = await _context.Rooms.FirstOrDefaultAsync(x => x.RoomNumber == roomNumber);
                if (item == null)
                {
                    throw new Exception($"{roomNumber} not found");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = deletedBy;
                    await DeleteAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override Expression<Func<Room, object>>? GetSortExpression(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "updateat" => r => r.UpdatedAt,
                "name" => r => r.RoomNumber,
                _ => r => r.UpdatedAt
            };
        }

        public async Task<Room> GetRoomByIdAsync(string id)
        {
            //return await GetByIdAsync(includes: [r => r.Bookings ],filter:r=>!r.IsDeleted, predicate: r => r.Id == id);
            var room = await _context.Rooms.AsNoTracking().Include(r => r.Bookings.Where(b => b.CheckInDate >= DateTime.Now.AddMonths(-3))).Where(x => !x.IsDeleted).FirstOrDefaultAsync(r => r.Id == id);
            return room;
        }


    }
}
