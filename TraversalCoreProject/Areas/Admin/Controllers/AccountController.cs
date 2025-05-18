using BusinessLayer.Abstract.AbstractUnitOfWork;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult UpdateAccount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UpdateAccount(AccountViewModel accountViewModel)
        {
            var SenderValue = _accountService.TGetById(accountViewModel.SenderId);
            var RecieverValue = _accountService.TGetById(accountViewModel.RecieverId);

            SenderValue.Balance -= accountViewModel.Amount;
            RecieverValue.Balance += accountViewModel.Amount;

            List<Account> accounts = new List<Account> { 
                SenderValue,
                RecieverValue   
            };

            _accountService.TMultiUpdate(accounts);
            TempData["message"] = "Transfer completed successfully";

            // Sayfa yenilensin (POST-REDIRECT-GET pattern)
            return RedirectToAction("UpdateAccount");
        }
    }
}
