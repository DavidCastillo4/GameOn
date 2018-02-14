//  --------------------------------------------------------------------------------------
// GameOn.FilterConfig.cs
// 2018/02/14
//  --------------------------------------------------------------------------------------

using System.Web.Mvc;

namespace GameOn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}