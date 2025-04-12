using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class RezervationController : Controller
    {
        private readonly IDestinationService _destinationService = new DestinationManager(new EfDestinationDal());
        private readonly IReservationService _reservationService = new ReservationManager(new EfReservationDal());

        [HttpGet]
        public IActionResult CurrentReservation()
        {
            var valeus = _reservationService.TGetList();
            return View(valeus);
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
