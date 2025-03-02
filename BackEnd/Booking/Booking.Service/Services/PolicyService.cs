using Booking.ApiService.Services.Interfaces;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services
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

        public async Task UpdatePolicyAsync(PolicyDTO policy, int policyId)
        {
            await _repository.UpdatePolicyAsync(policy, policyId);
        }
    }
}
