using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.ViewComponents.Destination
{
    public class _GuideCardDestinationDetail:ViewComponent
    {
        private readonly IGuideService _guideService;
        Random rnd;
        public _GuideCardDestinationDetail(IGuideService guideService)
        {
            _guideService = guideService;
            rnd = new Random();
        }

        public IViewComponentResult Invoke(int guideId)
        {
            //var randomNumber = rnd.Next(1, _guideService.TGetList().Count);
            var value = _guideService.TGetById(guideId);
            return View(value);
        }
    }
}
