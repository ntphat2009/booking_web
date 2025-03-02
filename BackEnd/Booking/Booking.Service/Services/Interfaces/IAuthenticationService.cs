﻿using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking.ApiService.Services.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> ConfirmEmail(string token, string email);
        Task<IdentityResult> SignUpAsync(UserDTO user);
        Task<string> SignInAsync(SignInDTO signIn);
        Task<ApplicationUser> GetUserByUserName(string userName);
        Task<string> ReSendEmailConfirm(string userName);
    }
}
