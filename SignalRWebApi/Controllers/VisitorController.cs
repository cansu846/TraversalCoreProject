﻿using Microsoft.AspNetCore.Mvc;
using SignalRWebApi.DAL;
using SignalRWebApi.Models;
using System;
using System.Linq;

namespace SignalRWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorService _visitorService;

        public VisitorController(VisitorService visitorService)
        {
            _visitorService = visitorService;
        }

        [HttpGet]   
        public IActionResult CreateVisitor()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x =>
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100, 200),
                        VisitDate = DateTime.Now.AddDays(x)
                    };
                    _visitorService.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Added visitors successfully");
        }
    }
}
