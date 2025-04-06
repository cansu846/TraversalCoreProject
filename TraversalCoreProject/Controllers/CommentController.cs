using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TraversalCoreProject.Controllers
{
    public class CommentController : Controller
    {
        ICommentService commentService = new CommentManager(new EfCommentDal());

        [HttpGet]
        public PartialViewResult _AddCommentPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult _AddCommentPartial(Comment c)
        {
            c.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            c.CommentState = true;
            commentService.TAdd(c);
            return RedirectToAction("Index","Destination");
        }
    }
}
