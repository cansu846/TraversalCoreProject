﻿namespace TraversalCoreProject.CQRS.Results.GuideResults
{
    public class GetAllGuidesQueryResult
    {
        public int GuideID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
