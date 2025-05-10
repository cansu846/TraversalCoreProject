namespace TraversalCoreProject.CQRS.Results.DestinationResults
{
    public class GetDestinationByIdQueryResult
    {
        //Uye olmayan kullanıcıların gordugu kısım
        public int DestinationID { get; set; }
        public string City { get; set; }
        public string DayNight { get; set; }
        public int Capacity { get; set; }
        public double Price { get; set; }
    }
}
