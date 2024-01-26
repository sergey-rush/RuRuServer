using Newtonsoft.Json;
using RuRuServer.Base;
using RuRuServer.Models;
using System.Reflection;
using System.Transactions;

namespace RuRuServer
{
    public class NotificationService
    {
        private readonly Random random = new Random();

        private void CreateNotification(DataModel model)
        {
            model.Notification = new Notification
            {
                Id = model.SubscriptionId,
                Phone = model.Phone,
                Period = new Period
                {
                    From = new DateTime(2024, 01, 03, 16, 07, 02).ToString("O"),
                    To = new DateTime(2024, 06, 28, 11, 06, 17).ToString("O")
                },
                State = 1,
                StateReason = model.SelectedReason,
                StateUpdated = DateTime.Now.ToString("s"),
                ProlongationNumber = 1,
                PaymentNumber = 8,
                PaymentSucceeded = DateTime.Now.ToString("s"),
                TotalPaymentAmount = Convert.ToSingle(model.Amount),
                TransactionId = random.Next(1000000).ToString(),
                TransactionError = "0",
                Signature = "yUPIpsAQusBdleRfMSho2Nnt9dsJV/kn6cn6rLpno9I="
            };
            model.Notification.NextPayment = DateTime.Now.AddDays(1).ToString("s");
            var parameterList = new ParameterList();
            var parameterItem = new ParameterItem
            {
                Name = "user_id",
                Value = 112236
            };
            parameterList.ParameterItems.Add(parameterItem);
            model.Notification.UserIds = parameterList.ToXML();

            HandleReasonState(model);
            model.SelectedState = model.Notification.State;
            //Task.Run(() => Notify(notification, model.Url));

        }

        private DataModel HandleReasonState(DataModel model)
        {
            StateReason reason = (StateReason)model.SelectedReason;

            switch (reason)
            {
                case StateReason.FundsNotWithdrawn:
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = random.Next(20).ToString();
                    model.Notification.UserIds = null;
                    break;
                case StateReason.NumAttemptExceeded:
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = random.Next(20).ToString();
                    model.Notification.State = 0;
                    break;
                case StateReason.SubscriptionExpired:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.NextPayment = null;
                    model.Notification.UserIds = null;
                    break;
                case StateReason.CanceledByPartner:
                case StateReason.CanceledByAdmin:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.TransactionId = null;
                    model.Notification.UserIds = null;
                    break;
                case StateReason.UserOperatorChanged:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.TransactionId = null;
                    break;
                case StateReason.FirstPaymentFailed:
                    model.Notification.State = 0;
                    model.Notification.PaymentNumber = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionId = null;
                    model.Notification.TotalPaymentAmount = 0;
                    break;
                case StateReason.FatalPaymentError:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.NextPayment = null;
                    model.Notification.TransactionError = random.Next(20).ToString();
                    break;
                case StateReason.SubscriptionExtended:
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.PaymentNumber = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.TransactionId = null;
                    model.Notification.TotalPaymentAmount = 0;
                    model.Notification.TransactionError = null;
                    model.Notification.UserIds = null;
                    break;
                case StateReason.ExpiredAndExtended:
                    model.Notification.State = 0;
                    model.Notification.NextPayment = null;
                    break;
                case StateReason.BindingRejected:
                case StateReason.CanceledAfterPeriod:
                case StateReason.CanceledByUserUSSD:
                case StateReason.CanceledByUserSMS:
                    model.Notification.State = 0;
                    model.Notification.PaymentNumber = 1;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.TransactionId = null;
                    break;
                case StateReason.CreatedConfirmationAwait:
                    model.Notification.PaymentNumber = 0;
                    model.Notification.TotalPaymentAmount = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.TransactionId = null;
                    model.Notification.UserIds = null;
                    break;
                case StateReason.SubscriptionUnconfirmed:
                    model.Notification.State = 0;
                    model.Notification.PaymentNumber = 0;
                    model.Notification.TotalPaymentAmount = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.TransactionId = null;
                    model.Notification.UserIds = null;
                    break;
                case StateReason.NumAttemptPayoutExceeded:
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.ProlongationNumber = 1;
                    model.Notification.PaymentNumber = 1;
                    model.Notification.TransactionError = random.Next(20).ToString();
                    break;
                case StateReason.FirstPaymentFailedNoFunds:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 1;
                    model.Notification.PaymentNumber = 0;
                    model.Notification.TotalPaymentAmount = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = random.Next(20).ToString();
                    break;
            }

            return model;
        }

        public DataModel Notify(DataModel model)
        {
            CreateNotification(model);

            model.Input = JsonConvert.SerializeObject(model.Notification, Formatting.Indented);
            if (model.TestMode == "on")
            {
                return model;
            }
            else
            {
                WebClient wc = new WebClient(model.Url);
                return wc.ProcessRequest(model);
            }
        }
    }
}
