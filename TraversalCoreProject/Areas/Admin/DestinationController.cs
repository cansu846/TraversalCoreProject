using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin
{
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService destinationService = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationService.TGetList();
            return View(values);
        }
    }
}
