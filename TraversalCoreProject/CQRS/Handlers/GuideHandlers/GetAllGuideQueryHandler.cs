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
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuidesQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuidesQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuidesQueryResult
            {
                GuideID = x.GuideID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image 
            }).AsNoTracking().ToListAsync();
        }
    }
}
