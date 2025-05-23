using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Destination
{
    [AllowAnonymous]
    public class _Comment:ViewComponent
    {
        private readonly ICommentService _commentService;

        public _Comment(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int destinationId)
        {
            
            var values = _commentService.TCommentListWithDestinationAndAppUser(destinationId);
            return View(values);  
        }
    }
}
