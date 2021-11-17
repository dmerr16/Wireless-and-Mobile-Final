using System.Web;
using System.Web.Mvc;

namespace Wireless_and_Mobile_Final
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
