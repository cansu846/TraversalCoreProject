using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using TraversalCoreProject.CQRS.Commands.DestinationCommands;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;

        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand c)
        {
            var value = _context.Destinations.Find(c.Id);
            if (value != null) {
                _context.Remove(value);
                _context.SaveChanges();
            }
        }
    }
}
