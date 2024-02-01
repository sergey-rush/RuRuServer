using Microsoft.AspNetCore.Mvc;
using RuRuServer.Base;
using RuRuServer.Models;
using System;
using System.Diagnostics;
using Newtonsoft.Json;

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
                    notificationService.Send(model);
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}