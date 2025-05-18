using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class DeleteGuideCommandHandler:IRequestHandler<DeleteGuideCommand>
    {
        private readonly Context _context;

        public DeleteGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteGuideCommand request, CancellationToken cancellationToken)
        {
            var value = _context.Guides.Find(request.GuideId);
            if (value != null)
            {
                _context.Remove(value);
                _context.SaveChanges();
            }
            return Unit.Value;
        }
    }
}
