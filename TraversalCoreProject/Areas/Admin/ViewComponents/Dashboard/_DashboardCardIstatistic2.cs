using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardCardIstatistic2:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.destinations = context.Destinations.Count();
            ViewBag.guests = context.Users.Count();
            return View();  
        }
    }
}
