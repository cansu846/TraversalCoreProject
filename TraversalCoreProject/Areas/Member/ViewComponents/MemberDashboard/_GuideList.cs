using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        private readonly IGuideService _guideManager = new GuideManager(new EfGuideDal());
        public IViewComponentResult Invoke()
        {
            var guides = _guideManager.TGetList();
            return View(guides);  
        }
    }
}
