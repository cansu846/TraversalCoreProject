using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination() { 
            return View();  
        }

        [HttpPost]
        public IActionResult AddDestination(Destination d)
        {
            d.Status = true;
            _destinationService.TAdd(d);
            return RedirectToAction("Index","Destination","Admin");
        }

        [HttpGet]
        public IActionResult DeleteDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            _destinationService.TDelete(value);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var value = _destinationService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination d)
        {
            _destinationService.TUpdate(d);
            return RedirectToAction("Index", "Destination", new { area = "Admin" });
        }
    }
}
