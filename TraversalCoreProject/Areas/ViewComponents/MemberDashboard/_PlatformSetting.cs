using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.ViewComponents.MemberDashboard
{
    public class _PlatformSetting:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
