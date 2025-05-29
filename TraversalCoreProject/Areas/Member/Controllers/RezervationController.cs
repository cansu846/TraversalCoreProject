using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class RezervationController : Controller
    {
        private readonly IDestinationService _destinationService = new DestinationManager(new EfDestinationDal());
        private readonly IReservationService _reservationService = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager;

        public RezervationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> MyCurrentReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetListWithReservationByAccepted(user.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MyOldReservation()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetListWithReservationByPrevious(user.Id);
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> MyApprovalReservation()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.GetListWithReservationByApproval(user.Id);    
            return View(values);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            //SelectListItem listesi oluşturuluyor. Bu tip liste, dropdown (açılır liste) oluştururken kullanılır.
            List<SelectListItem> values = (from x in _destinationService.TGetList()
                                     select new SelectListItem{ 
                                         Text=x.City,
                                         Value= x.DestinationID.ToString()
                                     }).ToList();
            ViewBag.destinationList = values;
            return View();  
        }

        [HttpPost]
        public IActionResult NewReservation(Reservation reservation)
        {
            reservation.AppUserId = 8;
            reservation.Status = "Onay bekliyor...";
            _reservationService.TAdd(reservation);
            return RedirectToAction("CurrentReservation");
        }

    }
}
