using BookingSystem.APIService.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;
namespace BookingSystem.API.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessageFromAdmin", user, message);
        }
        public async Task SendMessageToUser(string to, string message)
        {
            var from = Context.User?.FindFirst(ClaimTypes.Email)?.Value;
            if (from != null)
            {
                await Clients.Users(to,from).SendAsync("ReceiveMessageFromUser", from, message);
            }
        }
    }
}
