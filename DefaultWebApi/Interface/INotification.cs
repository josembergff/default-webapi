
using DefaultWebApi.Model;

namespace DefaultWebApi.Interfaces
{
    public interface INotification
    {
        bool IsValid();

        void AddNotification(string message);

        void AddNotification(string title, string message);

        void AddNotification(string title, string message, object objectValue);

        string NotificationsMessage();

        string NotificationsTitle();

        string[] ListNotificationsTitle();

        string[] ListNotifications();

        void ClearNotifications();

        void AddNotifications(NotificationModel[] notifications);

        NotificationModel[] Notifications();

    }
}