
using System;
using System.Collections.Generic;

namespace DefaultWebApi.Domain.Interfaces.Tools.Notifications
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

        void AddNotifications(Dictionary<string, Object> notifications);

    }
}