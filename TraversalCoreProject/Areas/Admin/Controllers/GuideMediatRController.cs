using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Commands.GuideCommands;
using TraversalCoreProject.CQRS.Queries.GuideQueries;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGuide(UpdateGuideCommand updateGuideCommand)
        {
            var values = await _mediator.Send(updateGuideCommand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateGuide(CreateGuideCommand createGuideCommand)
        {
            await _mediator.Send(createGuideCommand);
            return RedirectToAction("Index");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteGuide(int id)
        {

            await _mediator.Send(new DeleteGuideCommand
            {
                GuideId = id
            });
            return RedirectToAction("Index");
        }
    }
}
