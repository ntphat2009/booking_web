using Booking.ApiService.Services.Interfaces;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoliciesController : ControllerBase
    {
        private readonly ILogger<PoliciesController> _logger;
        private readonly IPolicyService _service;
        private readonly BaseApiResponse _response;

        public PoliciesController(ILogger<PoliciesController> logger, IPolicyService service)
        {
            _logger = logger;
            _service = service;
            _response = new BaseApiResponse();
        }
        [HttpPost("InsertPolicy")]
        public async Task<IActionResult> InsertPolicyAsync(PolicyDTO policy)
        {
            try
            {
                await _service.AddPolicyAsync(policy);
                _response.Result = "Add success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }

        [HttpPut("UpdatePolicy")]
        public async Task<IActionResult> UpdatePolicyAsync(PolicyDTO policy, int policyID)
        {
            try
            {
                await _service.UpdatePolicyAsync(policy, policyID);
                _response.Result = "update success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }

        [HttpPut("DeletedPolicy")]
        public async Task<IActionResult> DeletedPolicyAsync(string deletedBy, int policyID)
        {
            try
            {
                await _service.DeletePolicyAsync(deletedBy, policyID);
                _response.Result = "deleted success";
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }
    }
}
