using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TraversalCoreProject.CQRS.Queries.GuideQueries;
using TraversalCoreProject.CQRS.Results.GuideResults;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler:IRequestHandler<GetGuideByIdQuery,GetGuideByIdQueryResult>
    {
        private readonly Context _context;

        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Guides.FindAsync(request.GuideID);
            if (value != null) {
                return new GetGuideByIdQueryResult
                {
                    GuideID = value.GuideID,
                    Name = value.Name,
                    Description = value.Description,    
                };
            }
          return null;  
        }
    }
}
