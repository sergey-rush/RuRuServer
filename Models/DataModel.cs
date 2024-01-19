using Microsoft.AspNetCore.Mvc.Rendering;
using RuRuServer.Base;

namespace RuRuServer.Models
{
    public class DataModel
    {
        public string SubscriptionId { get; set; }
        public List<SelectListItem> StateReasons { get; set; } = StateReasonList.GetList();

        public int SelectedStateReason { get; set; }
        public string Url { get; set; } = "http://localhost:8020/WebHandlers/RuRu2/Notifications/SubscriptionNotificationHandler.ashx";

        public string Output { get; set; }
    }
}
