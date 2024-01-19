using System.Net;
using Microsoft.AspNetCore.Mvc;
using RuRuServer.Base;
using RuRuServer.Models;

namespace RuRuServer.Controllers
{
    //[Route("Subscribe")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private Random random = new Random();

        [HttpGet]
        [Route("subscriptions/new")]
        public SubscriptionCreateResponse CreateSubscription()
        {
            Console.WriteLine("CreateSubscription requested");
            var response = new SubscriptionCreateResponse
            {
                Id = random.Next(1000000).ToString(),
                AwaitedStateReason = 0
            };
            return response;
        }

        [HttpPost]
        [Route("subscriptions")]
        public SubscriptionCreateResponse CreateSubscription(SubscriptionCreateRequest model)
        {
            Console.WriteLine("CreateSubscription requested");
            var response = new SubscriptionCreateResponse
            {
                Id = random.Next(1000000).ToString(),
                AwaitedStateReason = 0
            };

            return response;
        }


        [HttpDelete]
        [Route("subscriptions")]
        public HttpStatusCode DeleteSubscription(int id)
        {
            Console.WriteLine("DeleteSubscription requested");
            return HttpStatusCode.NoContent;
        }
    }
}
