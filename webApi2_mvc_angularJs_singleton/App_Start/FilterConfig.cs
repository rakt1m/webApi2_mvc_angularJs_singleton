using System.Web;
using System.Web.Mvc;

namespace webApi2_mvc_angularJs_singleton
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
