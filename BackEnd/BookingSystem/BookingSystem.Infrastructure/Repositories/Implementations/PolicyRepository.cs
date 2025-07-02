using Azure;
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
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BookingSystem.Infrastructure.Repositories.Implementations
{
    public class PolicyRepository : BaseRepository<Service>, IPolicyRepository
    {
        private readonly ILogger<PolicyRepository> _logger;
        private readonly ApplicationDbContext _context;

        public PolicyRepository(ApplicationDbContext context, ILogger<PolicyRepository> logger) : base(context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task AddPolicyAsync(PolicyDTO policy)
        {
            try
            {
                var newService = new Service()
                {
                    CreatedAt = DateTime.Now,
                    CreatedBy = policy.CreatedBy,
                    UpdatedAt = DateTime.Now,
                    IsDeleted = false,
                    Value = policy.Value,
                    PropertyUrl = policy.PropertyUrl,
                    PropertyId = policy.PropertyId,
                };
                await AddAsync(newService);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task DeletePolicyAsync(string deletedBy, int serviceId)
        {
            try
            {
                var item = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceId);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.IsDeleted = true;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = deletedBy;
                    await UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task UpdatePolicyAsync(PolicyDTO service, int serviceId)
        {
            try
            {
                var item = await _context.Services.FirstOrDefaultAsync(x => x.Id == serviceId);
                if (item == null)
                {
                    throw new Exception("id not found");
                }
                else
                {
                    item.IsDeleted = false;
                    item.PropertyUrl = service.PropertyUrl;
                    item.PropertyId = service.PropertyId;
                    item.Value = service.Value;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = service.UpdatedBy;
                    await UpdateAsync(item);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.InnerException);
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        protected override Expression<Func<Service, object>>? GetSortExpression(string sortBy)
        {
            return sortBy.ToLower() switch
            {
                "updateat" => s => s.UpdatedAt,
                "createdat" => s => s.CreatedAt,
                "name" => s => s.Value,
                _ => s => s.UpdatedAt
            };
        }

        public async Task<IEnumerable<Service>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            var sortExpresstion = GetSortExpression(sortBy);
            return await GetsAsync
                (
                    page: page,
                    pageSize: pageSize,
                    sortBy: sortExpresstion,
                    filter: s => !s.IsDeleted
                );
        }
    }
}
