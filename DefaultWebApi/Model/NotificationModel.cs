
namespace DefaultWebApi.Model
{
    public class NotificationModel
    {
        public int SequenceLevel { get; set; }
        public string NameLevel { get; set; }
        public string Message { get; set; }
        public string Title { get; set; }
        public object Object { get; set; }
    }
}
