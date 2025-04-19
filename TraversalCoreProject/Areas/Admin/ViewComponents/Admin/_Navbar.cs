using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.Admin
{
    public class _Navbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
