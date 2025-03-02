using Booking.Domain.Entity;
using Booking.Infrastructure.DTOs;
using Microsoft.AspNetCore.Identity;

namespace Booking.Infrastructure.Repositories.InterfaceRepository
{
    public interface IAuthenticationRepository
    {
        Task<string> ConfirmEmail(string token, string email);
        //void SendVerificationEmail(Messages message);
        Task<IdentityResult> SignUpAsync(UserDTO user);
        Task<string> ReSendEmailConfirm(string userName);
        Task<string> SignInAsync(SignInDTO signIn);
        Task<ApplicationUser> GetUserByUserName(string userName);
    }
}
