using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly UserManager<AppUser> _userManager;
        public DestinationController(IDestinationService destinationService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _userManager = userManager; 
        }

        public IActionResult Index()
        {
            var getDestinationList = _destinationService.TGetList();
            return View(getDestinationList);
        }

        [HttpGet]   
        public async Task<IActionResult> DestinationDetail(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name  );
            ViewBag.image=user.ImageUrl;
            ViewBag.i = id;
            ViewBag.i2 = id;
            ViewBag.userId = user.Id;
            var destination = _destinationService.TGetDestinationWithGuide(id);    
            return View(destination);  
        }
        [HttpPost]
      public IActionResult DestinationDetail(Destination d)
        {
            return View();
        }
    }
}
