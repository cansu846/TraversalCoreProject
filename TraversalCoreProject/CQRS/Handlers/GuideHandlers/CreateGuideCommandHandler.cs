using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Commands.GuideCommands;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class CreateGuideCommandHandler : IRequestHandler<CreateGuideCommand>
    {
        private readonly Context _context;

        public CreateGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new Guide { 
                Name = request.Name,    
                Description = request.Description,
                Status = true
            });
            _context.SaveChanges();
            //MediatR kütüphanesi kullanıldığında karşımıza çıkar. Bu, C# dilinde void karşılığı olarak kullanılan bir yapıdır
            return Unit.Value;  
        }
    }
}
