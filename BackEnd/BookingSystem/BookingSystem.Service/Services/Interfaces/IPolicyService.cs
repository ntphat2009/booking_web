using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services.Interfaces
{
    public interface IPolicyService
    {
        public Task<IEnumerable<Service>> GetAllAsync(int page, int pageSize, string sortBy);
        public Task AddPolicyAsync(PolicyDTO policy);
        public Task UpdatePolicyAsync(PolicyDTO policy, int policyId);
        public Task DeletePolicyAsync(string deletedBy, int policyId);
    }
}
