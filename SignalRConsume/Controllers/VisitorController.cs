using Microsoft.AspNetCore.Mvc;

namespace SignalRConsume.Controllers
{
    public class VisitorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
