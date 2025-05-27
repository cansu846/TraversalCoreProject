using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace TraversalCoreProject.Areas.Member.ViewComponents.MemberDashboard
{
    public class _DestinationList:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _DestinationList(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList().TakeLast(4).ToList();
            return View(values);
        }
    }
}
