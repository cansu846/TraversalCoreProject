using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    [AllowAnonymous]
    public class CommentController:Controller
    {
        private ICommentService _commentService = new CommentManager(new EfCommentDal());
        public IActionResult Index()
        {
            var values = _commentService.TGetCommentListWithDestination();
            return View(values);  
        }

        public IActionResult DeleteComment(int id)
        {
            var comment = _commentService.TGetById(id); 
            _commentService.TDelete(comment);
            return RedirectToAction("Index");
        }
    }
}
