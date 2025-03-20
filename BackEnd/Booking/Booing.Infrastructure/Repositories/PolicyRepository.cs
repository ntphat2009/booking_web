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

namespace Booking.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly ILogger<PolicyRepository> _logger;
        private readonly ApplicationDbContext _context;

        public PolicyRepository(ILogger<PolicyRepository> logger, ApplicationDbContext context)
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
                    PropertyId = policy.PropertyId
                };
                await _context.Services.AddAsync(newService);
                await _context.SaveChangesAsync();
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
                    await _context.SaveChangesAsync();
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
                    item.PropertyId = service.PropertyId;
                    item.Value = service.Value;
                    item.UpdatedAt = DateTime.Now;
                    item.UpdatedBy = service.UpdatedBy;
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
