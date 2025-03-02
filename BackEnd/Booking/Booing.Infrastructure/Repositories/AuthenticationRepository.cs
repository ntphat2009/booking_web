using Booking.Common.Model;
using Booking.Common.Service;
using Booking.Common.Service.Interfaces;
using Booking.Domain.Entity;
using Booking.Infrastructure.Data;
using Booking.Infrastructure.DTOs;
using Booking.Infrastructure.Repositories.InterfaceRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static Booking.Common.Utilities.FormatUtilities;
namespace Booking.Infrastructure.Repositories
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _user;
        private readonly SignInManager<ApplicationUser> _signIn;
        private readonly IConfiguration _configuration;
        private readonly IEmailSenderService _emailSenderService;

        public AuthenticationRepository(ApplicationDbContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> user, SignInManager<ApplicationUser> signIn, IConfiguration configuration, IEmailSenderService emailSenderService)
        {
            _context = context;
            _roleManager = roleManager;
            _user = user;
            _signIn = signIn;
            _configuration = configuration;
            _emailSenderService = emailSenderService;
        }
        public async Task<string> ConfirmEmail(string token, string email)
        {
            var user = await _user.FindByEmailAsync(email);
            if (user != null)
            {
                var result = await _user.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    return "200";
                }
            }
            return "404";
        }

        public async Task<ApplicationUser> GetUserByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);
            return user ?? new ApplicationUser();
        }

        private async Task<bool> SendEmailConfirmAsync(ApplicationUser applicationUser)
        {
            try
            {
                var token = await _user.GenerateEmailConfirmationTokenAsync(applicationUser);
                var encodeToken = HttpUtility.UrlEncode(token);
                //var confirmationLink = $"https://localhost:7214/api/Authentications/ConfirmEmail?token={encodeToken}&email={applicationUser.Email}";
                var confirmationLink = $"https://localhost:7214/api/Authentications/ConfirmEmail?token={encodeToken}&email={applicationUser.Email}";

                var htmlContent = $@"<html>
                                    <head>
                                        <meta charset='utf-8' />
                                        <title>Xác nhận Email</title>
                                    </head>
                                    <body style='font-family: Arial, sans-serif;'>
                                        <h2>Xác nhận Email</h2>
                                        <p>Vui lòng bấm vào nút bên dưới để xác nhận email của bạn:</p>
                                        <a href='{confirmationLink}' style='display: inline-block; padding: 10px 20px; color: #fff; background-color: #28a745; text-decoration: none; border-radius: 5px;'>Xác nhận Email</a>
                                        <br/><br/>
                                        <p>Nếu bạn không muốn xác nhận, vui lòng bỏ qua email này.</p>
                                    </body>
                                    </html>";
                var message = new Messages([applicationUser.Email], "Liên kết xác thực email", htmlContent);
                SendVerificationEmail(message);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private void SendVerificationEmail(Messages message)
        {
            var isSendMail = _emailSenderService.SendEmail(message);
            if (!isSendMail)
            {
                throw new Exception("Gửi Mail xác thực không thành công");
            }
        }
        public async Task<string> SignInAsync(SignInDTO signIn)
        {
            var account = await _user.FindByNameAsync(signIn.UserName);
            if (account == null)
            {
                throw new Exception("Account was't found");
            }
            else
            {
                var result = await _signIn.PasswordSignInAsync(signIn.UserName, signIn.Password, false, false);
                if (!result.Succeeded)
                {
                    throw new Exception("SignIn Failed");
                }
                else
                {
                    var authClaims = new List<Claim>
                    {
                        new("UserName",signIn.UserName),
                        new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new("EmailConfirmed",account.EmailConfirmed.ToString())
                    };
                    var userRoles = await _user.GetRolesAsync(account);
                    foreach (var role in userRoles)
                    {
                        authClaims.Add(new Claim("Role", role));
                    }
                    var authKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                    var token = new JwtSecurityToken
                   (
                       claims: authClaims,
                       issuer: _configuration["JWT:ValidIssuer"],
                       audience: _configuration["JWT:ValidAudience"],
                       expires: DateTime.UtcNow.AddHours(1),
                       signingCredentials: new SigningCredentials(authKey, SecurityAlgorithms.HmacSha256Signature)
                   );
                    return new JwtSecurityTokenHandler().WriteToken(token);
                }
            }
        }

        public async Task<IdentityResult> SignUpAsync(UserDTO user)
        {
            try
            {
                var applicationUser = new ApplicationUser
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                    NameUrl = ToUrl((user.FirstName + " " + user.LastName)),
                };
                var userExistted = await _context.Users.Where(x => x.UserName == user.UserName || x.Email == user.Email).ToListAsync();
                var errorMessage = new List<string>();
                if (userExistted.Any(x => x.UserName == user.UserName))
                {
                    throw new Exception("Tên người dùng đã tồn tại");
                }
                if (userExistted.Any(x => x.Email == user.Email))
                {
                    throw new Exception("Email đã tồn tại");

                }
                string Role = "User";
                var result = await _user.CreateAsync(applicationUser, user.Password);
                if (!result.Succeeded)
                {
                    throw new Exception("Quá trình khởi tạo tài khoản không thành công");
                }
                if (await _roleManager.RoleExistsAsync(Role))
                {
                    await _user.AddToRoleAsync(applicationUser, Role);
                }
                var sendMailToConfirm = await SendEmailConfirmAsync(applicationUser);
                if (!sendMailToConfirm)
                {
                    throw new Exception("Quá trình gửi email xác thực không thành công");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> ReSendEmailConfirm(string userName)
        {
            try
            {
                var applicationUser = await _user.FindByNameAsync(userName);
                var isSendMail = await SendEmailConfirmAsync(applicationUser);
                if (!isSendMail)
                {
                    throw new Exception("Gửi mail thất bại");
                }
                return "200";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
