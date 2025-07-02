using BookingSystem.APIService.Services.Interfaces;
using BookingSystem.Domain.Entity;
using BookingSystem.Infrastructure.DTOs;
using BookingSystem.Infrastructure.Repositories;
using BookingSystem.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystem.APIService.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationRepository _authenticationRepository;

        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public Task<string> ConfirmEmail(string token, string email)
        {
            return _authenticationRepository.ConfirmEmail(token, email);
        }

        public Task<ApplicationUser> GetUserByUserName(string userName)
        {
            return _authenticationRepository.GetUserByUserName(userName);
        }

        public Task<string> ReSendEmailConfirm(string userName)
        {
            return _authenticationRepository.ReSendEmailConfirm(userName);
        }

        public Task<string> SignInAsync(SignInDTO signIn)
        {
            return _authenticationRepository.SignInAsync(signIn);
        }

        public Task<IdentityResult> SignUpAsync(UserDTO user)
        {
            return _authenticationRepository.SignUpAsync(user);
        }
    }
}
