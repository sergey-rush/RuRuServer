using Microsoft.AspNetCore.Mvc.Rendering;

namespace RuRuServer.Base;
public static class ReasonList
{
    private static List<SelectListItem> items = new List<SelectListItem>();

    static ReasonList()
    {
        if (items.Count == 0)
        {
            items.Add(new SelectListItem("0. SubscriptionCreated", "0"));
            items.Add(new SelectListItem("1. PaymentInProgress", "1"));
            items.Add(new SelectListItem("2. PaymentCompleted", "2"));
            items.Add(new SelectListItem("3. FundsNotWithdrawn", "3"));
            items.Add(new SelectListItem("4. NumAttemptExceeded", "4"));
            items.Add(new SelectListItem("5. SubscriptionExpired", "5"));
            items.Add(new SelectListItem("6. CanceledByPartner", "6"));
            items.Add(new SelectListItem("7. CanceledByAdmin", "7"));
            items.Add(new SelectListItem("8. UserOperatorChanged", "8"));
            items.Add(new SelectListItem("9. FirstPaymentFailed", "9"));
            items.Add(new SelectListItem("10. FatalPaymentError", "10"));
            items.Add(new SelectListItem("11. SubscriptionExtended", "11"));
            items.Add(new SelectListItem("12. ExpiredAndExtended", "12"));
            items.Add(new SelectListItem("13. BindingRejected", "13"));
            items.Add(new SelectListItem("14. CanceledByUserUSSD", "14"));
            items.Add(new SelectListItem("15. CanceledByUserSMS", "15"));
            items.Add(new SelectListItem("16. CreatedConfirmationAwait", "16"));
            items.Add(new SelectListItem("17. SubscriptionUnconfirmed", "17"));
            items.Add(new SelectListItem("18. NumAttemptPayoutExceeded", "18"));
            items.Add(new SelectListItem("19. FirstPaymentFailedNoFunds", "19"));
            items.Add(new SelectListItem("20. CanceledAfterPeriod", "20"));
        }
    }

    public static List<SelectListItem> GetList()
    {
        return items;
    }
}