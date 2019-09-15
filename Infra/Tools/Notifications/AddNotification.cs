using System;
using System.Linq.Expressions;

namespace DefaultWebApi.Intra.Tools.Notifications
{
    public static partial class AddNotification
    {
        public static void AddValidation<TEntity>(this TEntity objectTarget, Expression<Func<TEntity, bool>> validations, string message = "") where TEntity : Notifiable
        {
            var data = validations.Compile().Invoke(objectTarget);

            if (data)
            {
                objectTarget.AddNotification(message, objectTarget);
            }
        }
    }
}