using System;
using System.Collections.Generic;
using System.Linq;
using DefaultWebApi.Domain.Interfaces.Tools.Notifications;
using Newtonsoft.Json;

namespace DefaultWebApi.Intra.Tools.Notifications
{
    public class Notifiable : INotifiable
    {
        private readonly Dictionary<string, Object> listNotifiable;

        public Notifiable()
        {
            listNotifiable = new Dictionary<string, Object>();
        }

        public bool IsValid()
        {
            return listNotifiable == null || !listNotifiable.Any();
        }

        public void AddNotification<T>(string message, T objectValue)
        {
            if (!listNotifiable.Any(a => a.Key == message))
            {
                listNotifiable.Add(message, objectValue);
            }
        }

        public string NotificationsMessage()
        {
            var retorno = string.Empty;
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = string.Join(";", listNotifiable.Select(s => s.Key).ToArray());
            }
            return retorno;
        }

        public string FullNotificationsMessage()
        {
            var retorno = string.Empty;
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = string.Join(";", listNotifiable.Select(s => string.Join("|", s.Key, JsonConvert.SerializeObject(s.Value))).ToArray());
            }
            return retorno;
        }

        public string[] Notifications()
        {
            var retorno = new string[] { };
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = listNotifiable.Select(s => s.Key).ToArray();
            }
            return retorno;
        }

        public string[] FullNotifications()
        {
            var retorno = new string[] { };
            if (listNotifiable != null && listNotifiable.Any())
            {
                retorno = listNotifiable.Select(s => string.Join("|", s.Key, JsonConvert.SerializeObject(s.Value))).ToArray();
            }
            return retorno;
        }

        public void ClearNotifications()
        {
            if (listNotifiable != null && listNotifiable.Any())
            {
                var listKeys = listNotifiable.Select(s => s.Key);

                foreach (var key in listKeys)
                {
                    listNotifiable.Remove(key);
                }
            }
        }

        public void AddNotifications(Dictionary<string, object> notifications)
        {
            if (listNotifiable != null && listNotifiable.Any())
            {
                foreach (var line in listNotifiable)
                {
                    listNotifiable.Add(line.Key, line.Value);
                }
            }
        }
    }
}