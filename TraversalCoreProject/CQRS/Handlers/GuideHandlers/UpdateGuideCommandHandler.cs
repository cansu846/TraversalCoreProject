using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class UpdateGuideCommandHandler : IRequestHandler<UpdateGuideCommand>
    {
        private readonly Context _context;

        public UpdateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async  Task<Unit> Handle(UpdateGuideCommand request, CancellationToken cancellationToken)
        {
            var guide = _context.Guides.Find(request.GuideID);
     
            if (guide!=null)
            {
                guide.Name = request.Name;
                guide.Description = request.Description;
                _context.Guides.Update(guide);
                _context.SaveChanges();
            }
            return Unit.Value;
        }
    }
}
