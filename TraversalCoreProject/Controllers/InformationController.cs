using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Controllers
{
    [Route("[controller]/[action]")]
    public class InformationController : Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}
