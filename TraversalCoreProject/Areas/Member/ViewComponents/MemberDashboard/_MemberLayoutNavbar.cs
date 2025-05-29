using Microsoft.AspNetCore.Mvc;
namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class _MemberLayoutNavbar : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
