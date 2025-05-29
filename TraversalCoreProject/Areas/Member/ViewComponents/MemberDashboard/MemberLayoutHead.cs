using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class MemberLayoutHead:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
