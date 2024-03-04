using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using RuRuServer.Models;
using System.Diagnostics;

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
            if (model.Input != null)
            {
                model.Notification = JsonConvert.DeserializeObject<Notification>(model.Input);

                if (model.Notification != null)
                {
                    var notificationService = new NotificationService();
                    model = notificationService.Send(model);
                }
            }

            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Payment()
        {
            var nvc = QueryHelpers.ParseQuery(Request.QueryString.Value).ToDictionary(m => m.Key, m => m.Value.ToString());
            string requestJson = JsonConvert.SerializeObject(nvc);
            InitModel initModel = JsonConvert.DeserializeObject<InitModel>(requestJson);
            DataModel dataModel = new DataModel();
            dataModel.InitModel = initModel;
            dataModel.CPAReqUrl = CreateCPAReqUrl(dataModel.InitModel);
            return View(dataModel);
        }

        [HttpPost]
        public IActionResult Payment(DataModel dataModel)
        {
            dataModel.CPAReqUrl = CreateCPAReqUrl(dataModel.InitModel);
            WebClient wc = new WebClient(dataModel.CPAReqUrl, "application/xml");
            dataModel.Output = wc.ProcessRequest(HttpMethod.Get, null);
            return View(dataModel);
        }

        private string CreateCPAReqUrl(InitModel model)
        {
            string url = "http://pay-dev.digitalspb.com:9304/Card/Gazprombank/[[Type]]/callback?merch_id=[[MerchantId]]&trx_id=[[TransactionId]]&o.order_id=[[InvoiceId]]&lang_code=[[LangCode]]&ts=[[TimeStamp]]";
            url = url.Replace("[[Type]]", "cpareq").Replace("[[InvoiceId]]", model.InvoiceId).Replace("[[MerchantId]]", model.MerchantId);
            string transactionId = Guid.NewGuid().ToString("N");
            string timeStamp = DateTimeOffset.Now.ToString("yyyyMMdd HH:mm:ss");
            url = url.Replace("[[TransactionId]]", transactionId).Replace("[[LangCode]]", model.LangCode).Replace("[[TimeStamp]]", timeStamp);
            return url;
        }

        public IActionResult Checkout()
        {
            var nvc = QueryHelpers.ParseQuery(Request.QueryString.Value).ToDictionary(m => m.Key, m => m.Value.ToString());
            string requestJson = JsonConvert.SerializeObject(nvc);
            InitModel model = JsonConvert.DeserializeObject<InitModel>(requestJson);
            return View(model);
        }

        public IActionResult Result(bool success)
        {
            DataModel model = new DataModel();
            model.Result = success;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}