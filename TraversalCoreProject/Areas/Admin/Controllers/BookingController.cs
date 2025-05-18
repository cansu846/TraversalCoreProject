using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Authorization;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using TraversalCoreProject.Areas.Admin.Models;
using System.Collections.Generic;
using Newtonsoft.Json;
using DocumentFormat.OpenXml.Drawing.Charts;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class BookingController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/hotels/searchHotels?dest_id=-2092174&search_type=CITY&arrival_date=2025-05-18&departure_date=2025-05-24&adults=1&children_age=0%2C17&room_qty=1&page_number=1&units=metric&temperature_unit=c&languagecode=en-us&currency_code=AED&location=US"),
                Headers =
    {
        { "x-rapidapi-key", "fa09fade7bmsh1f6123b3f0a9cd9p190af2jsn5a13973b6c52" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var values = JsonConvert.DeserializeObject<BookingViewModel>(body);
                return View(values.data);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDestinationById()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetDestinationById(string p)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://booking-com15.p.rapidapi.com/api/v1/hotels/searchDestination?query={p}"),
                Headers =
    {
        { "x-rapidapi-key", "fa09fade7bmsh1f6123b3f0a9cd9p190af2jsn5a13973b6c52" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var values = JsonConvert.DeserializeObject(body);
                return View();
            }
        }
    }
}
