
namespace default_webapi_nuget.Interfaces
{
    public interface INotifiable
    {
        void ClearNotifications();

        string[] FullNotifications();

        string[] Notifications();

        string FullNotificationsMessage();

        string NotificationsMessage();

        void AddNotification<T>(string message, T objectValue);

        bool IsValid();

    }
}