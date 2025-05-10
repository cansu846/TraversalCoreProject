using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class VisitorApiController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VisitorApiController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44335/api/Visitor");
            Console.WriteLine(responseMessage);
            Console.WriteLine("cansu");

            if (responseMessage.IsSuccessStatusCode)
            {
                // Gelen cevabın JSON içerik kısmı okunur.
                //ReadAsStringAsync() metodu JSON'u string formatında alır.
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //VisitorViewModel türünde bir listeye deserialize edilir.
                var values = JsonConvert.DeserializeObject<List<VisitorViewModel>>(jsonData);
                return View(values);
            }
            return View(new List<VisitorViewModel>());
        }

        [HttpGet]
        public IActionResult CreateVisitor()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> CreateVisitor(CreateVisitorViewModel p)
        {
            var client =  _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:44335/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();  
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:44335/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine(responseMessage.IsSuccessStatusCode);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateVisitor(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:44335/api/Visitor/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateVisitorViewModel>(jsonData);
                return View(values);
                
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateVisitor(UpdateVisitorViewModel p)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(p);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:44335/api/Visitor/",content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
