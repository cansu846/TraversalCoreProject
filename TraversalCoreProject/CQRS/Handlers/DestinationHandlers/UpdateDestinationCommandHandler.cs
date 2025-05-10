using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using TraversalCoreProject.CQRS.Commands;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.DestinationID);
            value.City = command.City;
            value.DayNight = command.DayNight;
            value.Price = command.Price;
            value.Capacity = command.Capacity;  

            _context.Destinations.Update(value);
            _context.SaveChanges();
        }
    }
}
