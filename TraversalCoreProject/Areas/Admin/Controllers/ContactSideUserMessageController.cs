using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class ContactSideUserMessageController : Controller
    {
        private readonly IContactSideUserMessageService _contactSideUserMessageService;

        public ContactSideUserMessageController(IContactSideUserMessageService contactSideUserMessageService)
        {
            _contactSideUserMessageService = contactSideUserMessageService;
        }

        public IActionResult MessageList()
        {
            var values = _contactSideUserMessageService.TGetListByStatusTrue();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult AddGuide()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult AddGuide(Guide guide)
        //{
        //    _guideService.TAdd(guide);
        //    return RedirectToAction("Index", "Guide", new { area = "Admin" });
        //}

        //[Route("ChangeToPassive/{id}")]
        //public IActionResult ChangeToPassive(int id)
        //{
        //    _guideService.TChangeToPassive(id);
        //    return RedirectToAction("Index", "Guide",new {area="Admin"});
        //}

        //[HttpGet("/Admin/Guide/ChangeToActive/{id}")]
        //public IActionResult ChangeToActive(int id)
        //{
        //    _guideService.TChangeToActive(id);
        //     return RedirectToAction("Index", "Guide",new {area="Admin"});
        //}

        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //   var value =  _guideService.TGetById(id);
        //    _guideService.TDelete(value);
        //    return RedirectToAction("Index", "Guide", new { area = "Admin" });
        //}
        
        //[HttpGet]
        //public IActionResult UpdateGuide(int id)
        //{
        //    var value = _guideService.TGetById(id);
        //    return View(value);
        //}

        //[HttpPost]
        //public IActionResult UpdateGuide(Guide guide)
        //{
        //   _guideService.TUpdate(guide);
        //    return RedirectToAction("Index", "Guide", new { area = "Admin" });
        //}
    }
}
