using System.Web;
using System.Web.Mvc;

namespace HostelSuggestionSystem_WE
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
