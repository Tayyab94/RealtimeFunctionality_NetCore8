using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Realtime_SignalR_Net.Interfaces;

namespace Realtime_SignalR_Net.Models.SignalRClass
{

    [Authorize]
    public sealed class NotificationsHub :Hub<INotificationsClient>
    {
        public async Task SendNotification(string content)
        {

            await Clients.All.ReceiveNotification(content);
            
            //await Clients.All.SendAsync("ReceiveNotification", content); Note: We can lose the SendAsync Method, but only can access ReceiveNotifacation Method, available in an interface

        }


        public override Task OnConnectedAsync()
        {
            var connectionId = Context.ConnectionId;
            Console.WriteLine($"client Connect with Connection ID : {connectionId}");
            return base.OnConnectedAsync();
        }
    }
}
