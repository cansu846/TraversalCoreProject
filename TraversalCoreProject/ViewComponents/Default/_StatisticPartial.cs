using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _StatisticPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var context = new Context();
            ViewBag.destinationCount = context.Destinations.Count();
            ViewBag.guideCount = context.Guides.Count();
            ViewBag.customerCount = "285";
            ViewBag.awardCount = "990";
            return View();
        }
    }
}
