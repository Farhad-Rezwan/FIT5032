using System.Web;
using System.Web.Mvc;

namespace frez0003_FoodBank_Melb
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
