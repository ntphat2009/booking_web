using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace BookingSystem.API.Hubs
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            var userId = connection.User?.FindFirst(ClaimTypes.Email)?.Value;
            return userId;
        }
    }
}
