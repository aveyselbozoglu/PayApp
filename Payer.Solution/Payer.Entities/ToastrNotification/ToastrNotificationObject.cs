namespace Payer.Entities.ToastrNotification
{
    public class ToastrNotificationObject
    {
        public ToastrNotificationType ToastrNotificationType { get; set; }

        public string Title { get; set; }
        public string Message { get; set; }

        public ToastrNotificationObject()
        {
            ToastrNotificationType = ToastrNotificationType.Success;

            Message = "Başarılı İşlem";
        }
    }
}