using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class CityUsingAjaxController : Controller
    {
        private IDestinationService _destinationService;

        public CityUsingAjaxController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CityList() {
            var values = _destinationService.TGetList().TakeLast(5);
            var jsonCity = JsonConvert.SerializeObject(values);
            //Json() metodu otomatik olarak cities listesini JSON'a çevirir. 
            return Json(jsonCity);
        }

        [HttpGet("/Admin/CityUsingAjax/GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var values = _destinationService.TGetById(id);
            var jsonCity = JsonConvert.SerializeObject(values);
            //Json() metodu otomatik olarak cities listesini JSON'a çevirir. 
            return Json(jsonCity);
        }

        [HttpGet("/Admin/CityUsingAjax/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var value = _destinationService.TGetById(id);
            _destinationService.TDelete(value);
           
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destination.Status = true;
            _destinationService.TAdd(destination);
            return RedirectToAction("Index");
        }

        //List<CityViewModel> cities = new List<CityViewModel>
        //{
        //    new CityViewModel
        //    {
        //        CityId=1,
        //        CityName="Paris",
        //        CityCountry="France"
        //    },
        //    new CityViewModel
        //    {
        //        CityId=2,
        //        CityName="Paris",
        //        CityCountry="France"
        //    },
        //    new CityViewModel
        //    {
        //        CityId=3,
        //        CityName="Paris",
        //        CityCountry="France"
        //    },
        //    new CityViewModel
        //    {
        //        CityId=4,
        //        CityName="Paris",
        //        CityCountry="France"
        //    }
        //};
    }
}
