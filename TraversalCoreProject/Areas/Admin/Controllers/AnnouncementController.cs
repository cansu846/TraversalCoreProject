using AutoMapper;
using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DTOLayer.DTOs.AnnouncementDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
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
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService,
            IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Announcement> Annlist = _announcementService.TGetList();

            //List<AnnouncemenListViewModel> AnnViewModelList = new List<AnnouncemenListViewModel>();

            //foreach (var item in Annlist)
            //{
            //    AnnouncemenListViewModel model = new AnnouncemenListViewModel();

            //    model.AnnouncementID = item.AnnouncementID;
            //    model.Title = item.Title;   
            //    model.Content = item.Content;
            //    AnnViewModelList.Add(model);    
            //}

            var values = _mapper.Map<List<AnnouncementListDto>>(Annlist);
            return View(values);
        }

        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddAnnouncement(AnnouncementAddDto a)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Title = a.Title,
                    Content = a.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
                });
                return RedirectToAction("Index");   
            }
            return View();
        }
        
        [HttpGet("/Admin/Announcement/DeleteAnnouncement/{id}")]  
        public IActionResult DeleteAnnouncement(int id)
        {
            var value = _announcementService.TGetById(id);  
            _announcementService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
