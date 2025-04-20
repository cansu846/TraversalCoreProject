using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("/Admin/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _reservationService;
        private readonly ICommentService _commnetService;

        public UserController(IAppUserService appUserService,
            IReservationService reservationService,
            ICommentService commentService)
        {
            _appUserService = appUserService;
            _reservationService = reservationService;
            _commnetService = commentService;
        }
        public IActionResult Index()
        {
            var values = _appUserService.TGetList();
            return View(values);
        }
        public IActionResult DeleteUser(int id)
        {
            var value = _appUserService.TGetById(id);
            _appUserService.TDelete(value);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateUser(int id )
        {
            var value = _commnetService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateUser(AppUser user)
        {

            //Aşagdaki kod kullanılmazsa "expected to affect 1 row(s) but actually affected 0 row(s)" hatasına neden oluyor.
            //Çünkü EF, güncellemeye çalıştığı veri üzerinde bir RowVersion(veya başka bir concurrency token) kontrolü yapmaya çalışıyor ama karşısında zaten takip ettiği bir nesne yok.
            var existingUser = _appUserService.TGetById(user.Id);
            if (existingUser != null) { 
                existingUser.Name = user.Name;
                existingUser.Surname = user.Surname;
                existingUser.UserName = user.UserName;
                existingUser.Gender = user.Gender;
                existingUser.Email = user.Email;    
                existingUser.PhoneNumber = user.PhoneNumber;    
            }
            _appUserService.TUpdate(existingUser);
            return RedirectToAction("Index");
        }

        [HttpGet("/Admin/User/CommentList/{userId}")]
        public IActionResult CommentList(int userId)
        {
            var values = _commnetService.TGetCommentByUserId(userId);
            return View(values);
        }

        [HttpGet("/Admin/User/ReservationList/{userId}")]
        public IActionResult ReservationList(int userId)
        {
            var values = _reservationService.GetReservationListByUserId(userId);
            return View(values);
        }
    }
}
