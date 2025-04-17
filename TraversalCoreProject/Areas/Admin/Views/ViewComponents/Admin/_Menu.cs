using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Views.ViewComponents.Admin
{
    public class _Menu:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
