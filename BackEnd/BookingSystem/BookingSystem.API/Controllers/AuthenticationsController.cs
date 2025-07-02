using Azure;
using BookingSystem.APIService.Services;
using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Infrastructure.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BookingSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationsController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        [HttpGet("ConfirmEmail")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string token, string email)
        {
            var statusCode = await _authenticationService.ConfirmEmail(token, email);
            if (statusCode == "200")
            {
                return Redirect("http://localhost:5173/isverify");
            }
            return NotFound(statusCode);
        }
        [HttpPost]
        [Route("SignUp")]
        [AllowAnonymous]
        public async Task<IActionResult> SignUpAsync(UserDTO userDTO)
        {
            try
            {
                var result = await _authenticationService.SignUpAsync(userDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignInAsync(SignInDTO signInDTO)
        {
            try
            {
                var result = await _authenticationService.SignInAsync(signInDTO);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpPost]
        [Route("ReSendEmailConfirm")]
        public async Task<IActionResult> ReSendEmailConfirm(string userName)
        {
            try
            {
                var result = await _authenticationService.ReSendEmailConfirm(userName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
        [HttpGet]
        [Route("FindUser")]
        public async Task<IActionResult> GetUserByUserName(string userName)
        {
            try
            {
                var result = await _authenticationService.GetUserByUserName(userName);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
