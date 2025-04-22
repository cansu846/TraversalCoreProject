using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class CityUsingAjaxController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CityList() {
            //Json() metodu otomatik olarak cities listesini JSON'a çevirir. 
            return Json(cities);
        }

        List<CityViewModel> cities = new List<CityViewModel>
        {
            new CityViewModel
            {
                CityId=1,
                CityName="Paris",
                CityCountry="France"
            },
            new CityViewModel
            {
                CityId=2,
                CityName="Paris",
                CityCountry="France"
            },
            new CityViewModel
            {
                CityId=3,
                CityName="Paris",
                CityCountry="France"
            },
            new CityViewModel
            {
                CityId=4,
                CityName="Paris",
                CityCountry="France"
            }
        };
    }
}
