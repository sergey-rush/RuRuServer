namespace RuRuServer.Models
{
    public class DataModel
    {
        public int StateReason { get; set; }
        public string Url { get; set; } = "http://localhost:8020/WebHandlers/RuRu2/Notifications/SubscriptionNotificationHandler.ashx";

        public string Output { get; set; }
    }
}
