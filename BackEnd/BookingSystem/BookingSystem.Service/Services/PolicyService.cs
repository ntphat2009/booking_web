using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _repository;

        public PolicyService(IPolicyRepository repository)
        {
            _repository = repository;
        }

        public async Task AddPolicyAsync(PolicyDTO policy)
        {
            await _repository.AddPolicyAsync(policy);
        }

        public async Task DeletePolicyAsync(string deletedBy, int policyId)
        {
            await _repository.DeletePolicyAsync(deletedBy, policyId);
        }

        public Task<IEnumerable<Service>> GetAllAsync(int page, int pageSize, string sortBy)
        {
            return _repository.GetAllAsync(page, pageSize, sortBy);
        }

        public async Task UpdatePolicyAsync(PolicyDTO policy, int policyId)
        {
            await _repository.UpdatePolicyAsync(policy, policyId);
        }
    }
}
