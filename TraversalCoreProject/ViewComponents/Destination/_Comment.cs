using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Destination
{
    public class _Comment:ViewComponent
    {
        ICommentService commentService = new CommentManager(new EfCommentDal());
        public IViewComponentResult Invoke(int id)
        {
            
            var values = commentService.TGetCommentByDestinationId(id);
            return View(values);  
        }
    }
}
