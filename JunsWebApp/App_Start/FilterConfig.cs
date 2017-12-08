using System.Web;
using System.Web.Mvc;

namespace JunsWebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // this one will ensure use Error.cshtml when error occurs
            // whether show friendly error or stack trace is configured by customErrors in Web.config
            filters.Add(new HandleErrorAttribute());
        }
    }
}
