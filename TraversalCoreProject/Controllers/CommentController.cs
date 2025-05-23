using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<PartialViewResult> _AddCommentPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _AddCommentPartial(Comment c)
        {
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.CommentState = true;
            _commentService.TAdd(c);
            return RedirectToAction("Index","Destination");
        }
    }
}
