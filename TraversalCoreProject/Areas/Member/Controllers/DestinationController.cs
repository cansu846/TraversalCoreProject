using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        IDestinationService destinationService = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationService.TGetList();
            return View(values);
        }
    }
}
