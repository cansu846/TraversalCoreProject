using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    public class DestinationController : Controller
    {
        private IDestinationService destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var getDestinationList = destinationManager.TGetList();
            return View(getDestinationList);
        }

        [HttpGet]   
        public IActionResult DestinationDetail(int id)
        {
            ViewBag.i = id;
            var destination = destinationManager.TGetById(id);    
            return View(destination);  
        }
        [HttpPost]
      public IActionResult DestinationDetail(Destination d)
        {
            return View();
        }
    }
}
