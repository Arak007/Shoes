using System.Web;
using System.Web.Mvc;

namespace Assignment_1_Shoes_200364251
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
