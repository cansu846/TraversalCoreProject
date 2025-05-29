using Microsoft.AspNetCore.Mvc;
namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class _MemberLayoutMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
