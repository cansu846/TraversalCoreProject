using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.Dashboard
{
    public class _DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
