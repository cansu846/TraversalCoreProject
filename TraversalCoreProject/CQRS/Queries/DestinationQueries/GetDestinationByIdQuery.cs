namespace TraversalCoreProject.CQRS.Queries.DestinationQueries
{

    public class GetDestinationByIdQuery
    {
        //parametremiz
        public int id { get; set; }

        public GetDestinationByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
