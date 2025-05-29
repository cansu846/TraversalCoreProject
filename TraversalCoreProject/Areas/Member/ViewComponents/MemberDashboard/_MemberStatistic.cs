using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class _MemberStatistic:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
