using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Views.ViewComponents.Dashboard
{
    public class DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
