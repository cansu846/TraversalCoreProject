using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    public class ApiExchangeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/cars/searchCarRentals?pick_up_latitude=40.6397018432617&pick_up_longitude=-73.7791976928711&drop_off_latitude=40.6397018432617&drop_off_longitude=-73.7791976928711&pick_up_time=10%3A00&drop_off_time=10%3A00&driver_age=30&currency_code=USD&location=US"),
                Headers =
    {
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BookingViewModel>>(body);
                Console.WriteLine(body);
                return View(values);

            }
        }
    }
}
