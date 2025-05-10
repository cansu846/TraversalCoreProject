﻿namespace TraversalCoreProject.CQRS.Results.DestinationResults
{
    public class GetAllDestinationQueryResult
    {
        //Uye olmayan kullanıcıların gordugu kısım
        public int DestinationID { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
        public string DayNight { get; set; }
    }
}
