using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Views.ViewComponents.Destination
{
    public class _Navbar:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
