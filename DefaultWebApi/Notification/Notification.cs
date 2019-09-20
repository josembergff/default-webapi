using System.Linq;
using DefaultWebApi.Model;
using DefaultWebApi.Interfaces;

namespace DefaultWebApi.Notifications
{
    public class Notification : INotification
    {
        private NotificationModel[] listNotifiable;

        public Notification()
        {
            listNotifiable = new NotificationModel[]{ };
        }

        public bool IsValid()
        {
            return listNotifiable == null || !listNotifiable.Any();
        }

        public void AddNotification(string message)
        {
            var newNotification = new NotificationModel { Message = message };
        }

        public void AddNotification(string title, string message)
        {
            var newNotification = new NotificationModel { Title = title, Message = message };
        }

        public void AddNotification(string title, string message, object objectValue)
        {
            var newNotification = new NotificationModel { Title = title, Message = message, Object = objectValue };
        }

        public string NotificationsMessage()
        {
            var retorno = string.Empty;
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = string.Join(";", listNotifiable.Select(s => s.Message).ToArray());
            }
            return retorno;
        }

        public string NotificationsTitle()
        {
            var retorno = string.Empty;
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = string.Join(";", listNotifiable.Select(s => s.Title).ToArray());
            }
            return retorno;
        }

        public string[] ListNotificationsTitle()
        {
            var retorno = new string[] { };
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = listNotifiable.Select(s => s.Title).ToArray();
            }
            return retorno;
        }

        public string[] ListNotifications()
        {
            var retorno = new string[] { };
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = listNotifiable.Select(s => string.Join(":", s.Title, s.Message)).ToArray();
            }
            return retorno;
        }

        public void ClearNotifications()
        {
            listNotifiable = new NotificationModel[] { };
        }

        public void AddNotifications(NotificationModel[] notifications)
        {
            if (listNotifiable != null && listNotifiable.Any())
            {
                listNotifiable.Concat(notifications);
            }
        }

        public NotificationModel[] Notifications()
        {
            return listNotifiable;
        }
    }
}