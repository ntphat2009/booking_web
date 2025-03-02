using Booking.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services.Interfaces
{
    public interface IPolicyService
    {
        public Task AddPolicyAsync(PolicyDTO policy);
        public Task UpdatePolicyAsync(PolicyDTO policy, int policyId);
        public Task DeletePolicyAsync(string deletedBy, int policyId);
    }
}
