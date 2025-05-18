using MediatR;

namespace TraversalCoreProject.CQRS.Commands.GuideCommands
{
    public class DeleteGuideCommand:IRequest
    {
        public int GuideId { get; set; }
    }
}
