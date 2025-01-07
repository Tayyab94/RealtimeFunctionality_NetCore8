namespace Realtime_SignalR_Net.Interfaces
{
    public interface INotificationsClient
    {
        Task ReceiveNotification(string content);
    }
}
