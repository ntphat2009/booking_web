using Booking.Domain.Entity;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Booking.Common.Utilities.FormatUtilities;
namespace Booking.Infrastructure.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ILogger<RoomRepository> _logger;
        private readonly ApplicationDbContext _context;

        public RoomRepository(ILogger<RoomRepository> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public async Task<IEnumerable<Room>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            IQueryable<Room> queryable = _context.Rooms
                .AsNoTracking()
                .Include(x => x.Property)
                .Include(y => y.ImageRooms);
            switch (sortBy.ToLower())
            {
                case "desc":
                    queryable.OrderByDescending(x => x.RoomNumber);
                    break;
                case "asc":
                    queryable.OrderBy(x => x.RoomNumber);
                    break;
                case "date_desc":
                    queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
                case "date_asc":
                    queryable.OrderBy(x => x.UpdatedAt);
                    break;
                default:
                    queryable.OrderByDescending(x => x.UpdatedAt);
                    break;
            }
            var listRoom = await queryable
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
            return listRoom ?? [];
        }

        public async Task<Room> GetByUrlAsync(string roomNumber)
        {
            var item = await _context.Rooms
                .AsNoTracking()
                .Include(x => x.Property)
                .Include(y => y.ImageRooms)
                .Where(x => x.IsDeleted)
                .FirstOrDefaultAsync(x => x.RoomNumber == roomNumber);
            return item ?? new Room();
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
                    item.PropertyID = room.PropertyID;
                    item.RoomNumber = roomNumber;
                    item.IsDeleted = false;
                    item.UpdatedAt = DateTime.Now;
                    item.CreatedBy = room.CreatedBy;
                    item.CreatedAt = room.CreatedAt;
                    item.PricePerNight = room.PricePerNight;
                    item.IsAvailable = true;
                    item.MaxPeople = room.MaxPeople;
                    item.RoomUrl = room.RoomUrl;
                    await _context.SaveChangesAsync();
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
                    RoomNumber = room.RoomNumber,
                    PropertyID = room.PropertyID,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                    CreatedBy = room.CreatedBy,
                    IsAvailable = true,
                    MaxPeople = room.MaxPeople,
                    IsDeleted = false,
                    RoomUrl = ToUrl(room.RoomUrl),
                    PricePerNight = room.PricePerNight,
                    RoomType = room.RoomType,
                };
                await _context.Rooms.AddAsync(newRoom);
                await _context.SaveChangesAsync();
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
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
    }
}
