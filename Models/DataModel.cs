using Microsoft.AspNetCore.Mvc.Rendering;
using RuRuServer.Base;

namespace RuRuServer.Models
{
    public class DataModel
    {
        public int Amount { get; set; }
        public string SubscriptionId { get; set; }
        public List<SelectListItem> Reasons { get; set; } = ReasonList.GetList();
        public int SelectedReason { get; set; }
        public List<SelectListItem> States { get; set; } = StateList.GetList();
        public int SelectedState { get; set; }
        public string Url { get; set; } = "http://localhost:8020/WebHandlers/RuRu2/Notifications/SubscriptionNotificationHandler.ashx";
        public string Phone { get; set; }
        public string Input { get; set; }
        public string Output { get; set; }
        public string TestMode { get; set; }
        public Notification Notification { get; set; }
        public bool Result { get; set; }
        public InitModel InitModel { get; set; }
    }
}
