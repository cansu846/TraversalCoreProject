using AutoMapper.Internal;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System.Security.Policy;
using System.Threading.Tasks;
using TraversalCoreProject.Models;
using static System.Net.WebRequestMethods;

namespace TraversalCoreProject.Controllers
{

    public class PasswordChangeController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public PasswordChangeController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel forgetPasswordViewModel)
        {
            var user = await _userManager.FindByEmailAsync(forgetPasswordViewModel.Mail);
            //Identity’nin sunduğu güvenli bir parola sıfırlama token'ı üretir.
            //passwordResetToken: Tek seferlik, zaman sınırlı, doğrulama kodudur.
            string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            //Url.Action(...): Belirli bir controller / action'a giden tam URL oluşturur.

            //"ResetPassword": Şifre sıfırlama formunun gösterileceği action.

            //"PasswordChange": Yukarıdaki action’ın yer aldığı controller.

            //new { userId = user.Id, token = passwordResetToken }: Bu parametreler URL’ye eklenecek query string değerleri.

            //HttpContext.Request.Scheme: http veya https – bağlantının güvenli protokolle çalışması sağlanır.
            var passwordResetTokenLink = Url.Action("ResetPassword", "PasswordChange", new
            {
                userId = user.Id,
                token = passwordResetToken,
            }, HttpContext.Request.Scheme);

            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddress = new MailboxAddress("Admin", "cansukocaoglu55@gmail.com");
            mimeMessage.From.Add(mailboxAddress);

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", forgetPasswordViewModel.Mail);
            mimeMessage.To.Add(mailboxAddressTo);

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = passwordResetTokenLink;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            mimeMessage.Subject = "Request Password Change";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("cansukocaoglu55@gmail.com", "bsqq orbw oedc xinv\r\n");
            client.Send(mimeMessage);
            client.Disconnect(true);

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string userId, string token)
        {
            TempData["userid"] = userId;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            var userid = TempData["userid"];
            var token = TempData["token"];
            if (userid == null || token == null)
            {
                //hata mesajı
            }
            var user = await _userManager.FindByIdAsync(userid.ToString());
            var result = await _userManager.ResetPasswordAsync(user, token.ToString(), resetPasswordViewModel.Password);
            if (result.Succeeded) { return RedirectToAction("SignIn", "Login"); }
            return View();
        }
    }
}
