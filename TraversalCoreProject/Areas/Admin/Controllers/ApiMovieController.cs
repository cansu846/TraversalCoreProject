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
    public class ApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<ApiMovieViewModel> ApiMovieViewModelList = new List<ApiMovieViewModel>();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-1000-movies-series.p.rapidapi.com/list/1"),
                Headers =
    {
        { "x-rapidapi-key", "fa09fade7bmsh1f6123b3f0a9cd9p190af2jsn5a13973b6c52" },
        { "x-rapidapi-host", "imdb-top-1000-movies-series.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
                var values = JsonConvert.DeserializeObject<ApiMovieViewModel>(body);
                return View(values.result);

            }
        }
    }
}
