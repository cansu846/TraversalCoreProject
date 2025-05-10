using DataAccessLayer.Concrete;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TraversalCoreProject.CQRS.Results.DestinationResults;

namespace TraversalCoreProject.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x=>
                new GetAllDestinationQueryResult
                {
                    DestinationID = x.DestinationID,
                    City = x.City,  
                    Price = x.Price,
                    Capacity = x.Capacity,  
                    DayNight = x.DayNight,  
                }
            //.AsNoTracking(): EF Core'un performans için verileri izlememesini sağlar (değiştirilmeyecekse önerilir).
            ).AsNoTracking().ToList();

            return values;
        }
    }
}
