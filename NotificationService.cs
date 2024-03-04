using Newtonsoft.Json;
using RuRuServer.Base;
using RuRuServer.Models;
using System.Reflection;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Transactions;

namespace RuRuServer
{
    public class NotificationService
    {
        private readonly Random random = new Random();

        private readonly string clientSecret = "tllv7WMoguA03a0zi8JE";

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
                
            };
            model.Notification.NextPayment = DateTime.Now.AddDays(1).ToString("s");

            model.Notification.UserIds = new List<KeyValueItem>();

            KeyValueItem kvi1 = new KeyValueItem();
            kvi1.Key = "user_id";

            var parameterList1 = new ParameterList();
            var parameterItem1 = new ParameterItem
            {
                Name = "user_id",
                Value = 112236
            };
            parameterList1.ParameterItems.Add(parameterItem1);
            kvi1.Value = parameterList1.ToXML();
            model.Notification.UserIds.Add(kvi1);

            KeyValueItem kvi2 = new KeyValueItem();
            kvi2.Key = "account_id";

            var parameterList2 = new ParameterList();
            var parameterItem2 = new ParameterItem
            {
                Name = "account_id",
                Value = 447292
            };
            parameterList2.ParameterItems.Add(parameterItem2);
            kvi2.Value = parameterList2.ToXML();
            model.Notification.UserIds.Add(kvi2);

            HandleReasonState(model);
            model.SelectedState = model.Notification.State;
            //Task.Run(() => Notify(notification, model.Url));
            model.Notification.Signature = GetSignature(model.Notification);
        }

        private DataModel HandleReasonState(DataModel model)
        {
            StateReason reason = (StateReason)model.SelectedReason;

            switch (reason)
            {
                case StateReason.FundsNotWithdrawn:
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = "22";
                    model.Notification.UserIds = null;
                    break;
                case StateReason.NumAttemptExceeded:
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = "7";
                    model.Notification.State = 0;
                    break;
                case StateReason.SubscriptionExpired:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.NextPayment = null;
                    model.Notification.UserIds = null;
                    model.Notification.TransactionError = "0";
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
                    model.Notification.TransactionError = "7";
                    model.Notification.TotalPaymentAmount = 0;
                    break;
                case StateReason.FatalPaymentError:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 0;
                    model.Notification.PaymentNumber = 1;
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.NextPayment = null;
                    model.Notification.TransactionError = "2";
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
                    model.Notification.TransactionError = "7";
                    break;
                case StateReason.FirstPaymentFailedNoFunds:
                    model.Notification.State = 0;
                    model.Notification.ProlongationNumber = 1;
                    model.Notification.PaymentNumber = 0;
                    model.Notification.TotalPaymentAmount = 0;
                    model.Notification.PaymentSucceeded = null;
                    model.Notification.PaymentFailed = DateTime.Now.ToString("s");
                    model.Notification.TransactionError = "2";
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
                WebClient wc = new WebClient(model.Url, "application/json");
                model.Output = wc.ProcessRequest(HttpMethod.Post, model.Input);
                return model;
            }
        }

        public DataModel Send(DataModel model)
        {
            WebClient wc = new WebClient(model.Url, "application/json");
            model.Output = wc.ProcessRequest(HttpMethod.Post, model.Input);
            return model;
        }

        private string GetSignature(Notification notification)
        {
            string signature = Sign(GetBytes(clientSecret), GetBytes(GetSignatureMessage(notification)));
            return signature;
        }

        private byte[] GetBytes(string input)
        {
            return Encoding.UTF8.GetBytes(input);
        }

        private string GetSignatureMessage(Notification notification)
        {
            return $"{notification.Id}{notification.TransactionId}{notification.TotalPaymentAmount}";
        }

        private string Sign(byte[] key, byte[] data)
        {
            using (var signer = new System.Security.Cryptography.HMACSHA1(key))
            {
                return Convert.ToBase64String(signer.ComputeHash(data));
            }
        }
    }
}
