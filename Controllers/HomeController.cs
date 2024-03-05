using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using RuRuServer.Extensions;
using RuRuServer.Models;
using System.Diagnostics;
using System.Security.Cryptography.Xml;

namespace RuRuServer.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Random random = new Random();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataModel model = new DataModel();
            model.Phone = "9267026528";
            model.SelectedState = 1;
            model.SelectedReason = 2;
            model.SubscriptionId = "835956";
            model.Amount = random.Next(100, 400);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            if (!string.IsNullOrEmpty(model.SubscriptionId))
            {
                var notificationService = new NotificationService();
                model = notificationService.Notify(model);
                if (model.Amount > 0)
                {
                    model.Amount *= 2;
                }
                else
                {
                    model.Amount = random.Next(100, 400);
                }
            }


            return View(model);
        }

        [HttpPost]
        public IActionResult Process(DataModel model)
        {
            if (string.IsNullOrEmpty(model.Input))
            {
                Notification? notification = model.Input.FromJson<Notification>()!;

                if (notification != null)
                {
                    model.Notification = notification;
                    var notificationService = new NotificationService();
                    model = notificationService.Send(model);
                }
            }

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Payment()
        {
            DataModel dataModel = new DataModel();
            var nvc = QueryHelpers.ParseQuery(Request.QueryString.Value).ToDictionary(m => m.Key, m => m.Value.ToString());
            string requestJson = nvc.ToJson();
            InitModel? initModel = requestJson.FromJson<InitModel>();
            if (initModel != null)
            {
                dataModel.InitModel = initModel;
            }
            dataModel.Url = CreateCPAReqUrl(dataModel.InitModel);
            return View(dataModel);
        }

        [HttpPost]
        public IActionResult Payment(DataModel dataModel)
        {
            WebClient wc = new WebClient(dataModel.Url, "application/xml");
            dataModel.Output = wc.ProcessRequest(HttpMethod.Get, null);
            PaymentAvailResponse? response = dataModel.Output.FromXML<PaymentAvailResponse>();
            if (response != null)
            {
                dataModel.InitModel.Amount = response.Purchase.AccountAmount.Amount;
                dataModel.InitModel.PaymentId = response.PaymentId;
            }
            
            return View(dataModel);
        }

        /// <summary>
        /// Check payment available
        /// </summary>
        private string CreateCPAReqUrl(InitModel model)
        {
            string url = "http://pay-dev.digitalspb.com:9304/Card/Gazprombank/[[Type]]/callback?merch_id=[[MerchantId]]&trx_id=[[TransactionId]]&o.order_id=[[InvoiceId]]&lang_code=[[LangCode]]&ts=[[TimeStamp]]";
            url = url.Replace("[[Type]]", "cpareq").Replace("[[InvoiceId]]", model.InvoiceId).Replace("[[MerchantId]]", model.MerchantId);
            model.TransactionId = Guid.NewGuid().ToString("N");
            string timeStamp = DateTimeOffset.Now.ToString("yyyyMMdd HH:mm:ss");
            url = url.Replace("[[TransactionId]]", model.TransactionId).Replace("[[LangCode]]", model.LangCode).Replace("[[TimeStamp]]", timeStamp);
            return url;
        }

        public IActionResult Checkout()
        {
            var nvc = QueryHelpers.ParseQuery(Request.QueryString.Value).ToDictionary(m => m.Key, m => m.Value.ToString());
            string requestJson = nvc.ToJson();
            InitModel? initModel = requestJson.FromJson<InitModel>();
            return View(initModel);
        }

        public IActionResult Register()
        {
            DataModel dataModel = new DataModel();
            var nvc = QueryHelpers.ParseQuery(Request.QueryString.Value).ToDictionary(m => m.Key, m => m.Value.ToString());
            string requestJson = nvc.ToJson();
            InitModel? initModel = requestJson.FromJson<InitModel>();

            if (initModel != null)
            {
                dataModel.InitModel = initModel;
                dataModel.Url = CreateRPReqUrl(dataModel.InitModel);
            }
            
            return View(dataModel);
        }

        /// <summary>
        /// Register completed payment
        /// </summary>
        private string CreateRPReqUrl(InitModel model)
        {
            string url = "http://pay-dev.digitalspb.com:9304/Card/Gazprombank/[[Type]]/callback?trx_id=[[TransactionId]]&merch_id=[[MerchantId]]&merchant_trx=[[PaymentId]]&result_code=[[ResultCode]]&amount=[[Amount]]&o.order_id=[[InvoiceId]]&p.rrn=[[AcquiringId]]&p.authcode=AB2F23&p.maskedPan=545454xxxxxx5454&p.isFullyAuthenticated=Y&p.transmissionDateTime=[[TransmissionDateTime]]&ts=[[TimeStamp]]";
            url = url.Replace("[[Type]]", "rpreq");
            url = url.Replace("[[TransactionId]]", model.TransactionId);
            url = url.Replace("[[MerchantId]]", model.MerchantId);
            url = url.Replace("[[PaymentId]]", model.PaymentId);
            url = url.Replace("[[ResultCode]]", model.ResultCode);
            url = url.Replace("[[Amount]]", model.Amount.ToString());
            url = url.Replace("[[InvoiceId]]", model.InvoiceId);
            url = url.Replace("[[AcquiringId]]", model.TransactionId);
            url = url.Replace("[[TransmissionDateTime]]", DateTimeOffset.Now.AddSeconds(-5).ToString("yyyyMMdd HH:mm:ss"));
            url = url.Replace("[[TimeStamp]]", DateTimeOffset.Now.ToString("yyyyMMdd HH:mm:ss"));
            url = url.Replace("[[Signature]]", "Signature");
            string signedUrl = $"&signature={url.Sign()}";
            Console.WriteLine($"Signed Url: {signedUrl}");
            url += signedUrl;
            return url;
        }

        [HttpPost]
        public IActionResult Register(DataModel dataModel)
        {
            WebClient wc = new WebClient(dataModel.Url, "application/xml");
            dataModel.Output = wc.ProcessRequest(HttpMethod.Get, null);
            return View(dataModel);
        }

        public IActionResult Result(bool success)
        {
            DataModel model = new DataModel
            {
                Result = success
            };
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}