using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Destination
{
    public class _DestinationBreadCrumb:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
