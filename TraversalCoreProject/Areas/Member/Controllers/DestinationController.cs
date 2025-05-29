using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    [Route("Member/[controller]/[action]")]
    public class DestinationController : Controller
    {
        IDestinationService destinationService = new DestinationManager(new EfDestinationDal());
        public IActionResult Index(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in destinationService.TGetList() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }

            return View(values.ToList());
        }

        [HttpGet]
        public IActionResult LastDestinationList()
        {
            var values = destinationService.TGetList().Take(4).ToList();
            return View(values);
        }
        //bu method ilk basta test amacıyla yazılmıtı sonrasında Index e uygunadı. bu view hicbir yerde cagırılmadı
        [HttpGet]
         public IActionResult GetCitiesSearchByName(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values=from x in destinationService.TGetList() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0);
            }
           
            return View(values.ToList());
        }
    }
}
