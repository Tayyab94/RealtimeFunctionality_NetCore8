using Microsoft.AspNetCore.SignalR;

namespace Realtime_SignalR_Net.Models.SignalRClass
{
    public sealed class NotificationsHub :Hub
    {
        public async Task SendNotification(string content)
        {
            await Clients.All.SendAsync("ReceiveNotification", content);
        }


        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Console.WriteLine($"client Connect with Connection ID : {connectionId}");
            return base.OnConnectedAsync();
        }
    }
}
