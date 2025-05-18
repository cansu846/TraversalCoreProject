using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;
using TraversalCoreProject.CQRS.Handlers.DestinationHandlers;
using TraversalCoreProject.CQRS.Queries.DestinationQueries;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]

    public class DestinationCQRSController : Controller
    {
       private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
       private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, 
            GetDestinationByIdQueryHandler getDestinationByIdQueryHandler,
            CreateDestinationCommandHandler createDestinationCommandHandler,
            RemoveDestinationCommandHandler removeDestinationCommandHandler,
            UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet("{id}")]
        //Destination nesnesinde guncellenecek degerlerin karşılıgnı getirmek için kullanılıcak
        public IActionResult GetDestinationById(int id)
        {
            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        //Destination nesnesinde guncellenecek degerlerin karşılıgnı getirmek için kullanılıcak
        public IActionResult UpdateDestination(UpdateDestinationCommand command)
        {
            //UpdateDestinationCommand command = new UpdateDestinationCommand();
            //command.DestinationID = d.DestinationID;
            //command.City = d.City;
            //command.DayNight = d.DayNight;
            //command.City = d.City;
            //command.Price = command.Price;
            //command.Capacity = d.Capacity;
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index", "DestinationCQRS");
        }


        [HttpGet("{id}")]
        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
