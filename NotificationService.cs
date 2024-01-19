using RuRuServer.Base;
using RuRuServer.Models;
using System.Reflection;

namespace RuRuServer
{
    public class NotificationService
    {
        private readonly Random random = new Random();

        public string CreateNotification(DataModel model)
        {
            var notification = new Notification
            {
                Id = model.SubscriptionId,
                Period = new Period
                {
                    From = new DateTime(2022, 01, 24, 16, 07, 02),
                    To = new DateTime(2022, 06, 28, 16, 06, 17)
                },
                State = 1,
                StateReason = model.SelectedStateReason,
                StateUpdated = DateTime.Now,
                ProlongationNumber = 1,
                PaymentNumber = 8,
                PaymentSucceeded = new DateTime(2023, 01, 24, 16, 07, 02),
                TotalPaymentAmount = 720.0000F,
                TransactionId = "505206097",
                TransactionError = "0",
                Signature = "yUPIpsAQusBdleRfMSho2Nnt9dsJV/kn6cn6rLpno9I="
            };
            notification.NextPayment = notification.PaymentSucceeded.AddDays(1);
            var parameterList = new ParameterList();
            var parameterItem = new ParameterItem
            {
                Name = "user_id",
                Value = 112236
            };
            parameterList.ParameterItems.Add(parameterItem);
            notification.UserIds = parameterList.ToXML();

            //Task.Run(() => Notify(notification, model.Url));
            return Notify(notification, model.Url);
        }

        private string Notify(Notification notification, string url)
        {
            //Task.Delay(150);
            WebClient wc = new WebClient(url);
            return wc.ProcessRequest(notification);
        }
    }
}
