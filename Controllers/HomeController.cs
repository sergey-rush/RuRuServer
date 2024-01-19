using Microsoft.AspNetCore.Mvc;
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
            model.SubscriptionId = random.Next(1000000).ToString();
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(DataModel model)
        {
            var notificationService = new NotificationService();
            string output = notificationService.CreateNotification(model);
            model.Output = output;
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