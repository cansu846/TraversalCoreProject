using MediatR;
using System.Collections.Generic;
using TraversalCoreProject.CQRS.Results.GuideResults;

namespace TraversalCoreProject.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery:IRequest<GetGuideByIdQueryResult>
    {
        public int GuideID { get; set; }

        public GetGuideByIdQuery(int guideID)
        {
            GuideID = guideID;
        }
    }
}
