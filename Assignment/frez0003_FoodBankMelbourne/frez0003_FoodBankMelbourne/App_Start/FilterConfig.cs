using System.Web;
using System.Web.Mvc;

namespace frez0003_FoodBankMelbourne
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
