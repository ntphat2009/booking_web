using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace BookingSystem.API.Controllers
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
        [HttpGet]
        public async Task<IActionResult> GetAllPolicyAsync(int page = 1, int pageSize = 10, string sortBy = "updateat")
        {
            try
            {
                var result = await _service.GetAllAsync(page, pageSize, sortBy);
                var jsonConvert = JsonConvert.SerializeObject(result, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    Formatting = Formatting.Indented
                });
                return Ok(jsonConvert);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                _response.ErrorMessages.Add(ex.Message);
                _response.StatusCode = HttpStatusCode.InternalServerError;
                return NotFound(_response);
            }
        }
        [HttpPost]
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

        [HttpPut]
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

        [HttpDelete]
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
