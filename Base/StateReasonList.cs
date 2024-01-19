using Microsoft.AspNetCore.Mvc.Rendering;

namespace RuRuServer.Base;
public static class StateReasonList
{
    private static List<SelectListItem> items = new List<SelectListItem>();

    static StateReasonList()
    {
        if (items.Count == 0)
        {
            items.Add(new SelectListItem("SubscriptionCreated", "0"));
            items.Add(new SelectListItem("PaymentInProgress", "1"));
            items.Add(new SelectListItem("PaymentCompleted", "2"));
            items.Add(new SelectListItem("FundsNotWithdrawn", "3"));
            items.Add(new SelectListItem("NumAttemptExceeded", "4"));
            items.Add(new SelectListItem("SubscriptionExpired", "5"));
            items.Add(new SelectListItem("CanceledByPartner", "6"));
            items.Add(new SelectListItem("CanceledByAdmin", "7"));
            items.Add(new SelectListItem("UserOperatorChanged", "8"));
            items.Add(new SelectListItem("FirstPaymentFailed", "9"));
            items.Add(new SelectListItem("FatalPaymentError", "10"));

            items.Add(new SelectListItem("SubscriptionExtended", "11"));
            items.Add(new SelectListItem("ExpiredAndExtended", "12"));
            items.Add(new SelectListItem("BindingRejected", "13"));
            items.Add(new SelectListItem("CanceledByUserUSSD", "14"));
            items.Add(new SelectListItem("CanceledByUserSMS", "15"));
            items.Add(new SelectListItem("CreatedConfirmationAwait", "16"));
            items.Add(new SelectListItem("SubscriptionUnconfirmed", "17"));
            items.Add(new SelectListItem("NumAttemptPayoutExceeded", "18"));
            items.Add(new SelectListItem("FirstPaymentFailedNoFunds", "19"));
            items.Add(new SelectListItem("CanceledAfterPeriod", "20"));
        }
    }

    public static List<SelectListItem> GetList()
    {
        return items;
    }

    public static string GetDefault()
    {
        return items[0].Text;
    }
}