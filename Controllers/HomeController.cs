using Microsoft.AspNetCore.Mvc;
using RuRuServer.Base;
using RuRuServer.Models;
using System;
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
            model.SubscriptionId = "188143";
            model.Amount = random.Next(1000);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            if (!string.IsNullOrEmpty(model.SubscriptionId))
            {
                var notificationService = new NotificationService();
                model = notificationService.Notify(model);
            }
            return View(model);
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