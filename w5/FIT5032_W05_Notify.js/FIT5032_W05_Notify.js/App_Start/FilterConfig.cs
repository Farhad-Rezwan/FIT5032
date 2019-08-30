using System.Web;
using System.Web.Mvc;

namespace FIT5032_W05_Notify.js
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
