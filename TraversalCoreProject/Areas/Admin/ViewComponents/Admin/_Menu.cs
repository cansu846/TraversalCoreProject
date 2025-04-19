using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.ViewComponents.Admin
{
    public class _Menu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
