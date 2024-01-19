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
                AccountId = "8346346383610234",
                Phone = model.Phone,
                Period = new Period
                {
                    From = new DateTime(2024, 01, 03, 16, 07, 02).ToString("O"),
                    To = new DateTime(2024, 06, 28, 11, 06, 17).ToString("O")
                },
                State = 1,
                StateReason = model.SelectedStateReason,
                StateUpdated = DateTime.Now,
                ProlongationNumber = 1,
                PaymentNumber = 8,
                PaymentSucceeded = DateTime.Now,
                TotalPaymentAmount = random.Next(1000),
                TransactionId = random.Next(1000000).ToString(),
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
