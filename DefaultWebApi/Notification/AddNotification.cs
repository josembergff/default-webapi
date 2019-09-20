using System;
using System.Linq.Expressions;

namespace DefaultWebApi.Notifications
{
    public static partial class AddNotification
    {
        public static void AddValidation<TEntity>(this TEntity objectTarget, Expression<Func<TEntity, bool>> validations, string message = "") where TEntity : Notification
        {
            var data = validations.Compile().Invoke(objectTarget);

            if (data)
            {
                objectTarget.AddNotification(typeof(TEntity).Name, message, objectTarget);
            }
        }
    }
}