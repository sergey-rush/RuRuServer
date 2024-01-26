using Microsoft.AspNetCore.Mvc.Rendering;

namespace RuRuServer.Base;
public static class StateList
{
    private static List<SelectListItem> items = new List<SelectListItem>();

    static StateList()
    {
        if (items.Count == 0)
        {
            items.Add(new SelectListItem("0. Inactive", "0"));
            items.Add(new SelectListItem("1. Active", "1"));
        }
    }

    public static List<SelectListItem> GetList()
    {
        return items;
    }
}