using Microsoft.AspNetCore.SignalR;

namespace Booking.API.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user , string message)
        {
            await Clients.All.SendAsync("receiveMessenger",user, message);
        }
    }
}
