using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List<Announcement> Annlist = _announcementService.TGetList();

            List<AnnouncemenListViewModel> AnnViewModelList = new List<AnnouncemenListViewModel>();

            foreach (var item in Annlist)
            {
                AnnouncemenListViewModel model = new AnnouncemenListViewModel();

                model.AnnouncementID = item.AnnouncementID;
                model.Title = item.Title;   
                model.Content = item.Content;
                AnnViewModelList.Add(model);    
            }
            return View(AnnViewModelList);
        }
    }
}
