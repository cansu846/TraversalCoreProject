using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.DTOs.ContactDto;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    [AllowAnonymous]
    public class ContactController : Controller
    {
        private readonly IContactSideUserMessageService _contactSideUserMessageService;
        private readonly IMapper _mapper;

        public ContactController(IContactSideUserMessageService contactSideUserMessageService, IMapper mapper)
        {
            _contactSideUserMessageService = contactSideUserMessageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(SendMessageDto message)
        {
            if (ModelState.IsValid)
            {
                message.MessageStatus = true;
                message.MessageDate = DateTime.Now;
                var value = _mapper.Map<ContactSideUserMessage>(message);
                _contactSideUserMessageService.TAdd(value);
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("","Something went wrong..");
            }

            return View(message);
        }
    }
}
