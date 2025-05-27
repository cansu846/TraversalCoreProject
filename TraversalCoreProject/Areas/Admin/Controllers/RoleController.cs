using DocumentFormat.OpenXml.Office2010.ExcelAc;
using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager    )
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            AppRole appRole = new AppRole
            {
                Name=createRoleViewModel.RoleName.ToUpper()
            };
            var result = await _roleManager.CreateAsync(appRole);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(createRoleViewModel);
            }
        }

      [HttpGet("{id}")]
      public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(role);
            return RedirectToAction("Index");   
        }

        [HttpGet]
        public IActionResult UpdateRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(_ => _.Id == id);
            UpdateRoleViewModel model = new UpdateRoleViewModel
            {
                RoleName = role.Name,
                RoleId = role.Id
            };
            return View(model);  
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(UpdateRoleViewModel updateRoleViewModel)
        {
            var exisistRole = _roleManager.Roles.FirstOrDefault(x=>x.Id == updateRoleViewModel.RoleId);
            exisistRole.Name = updateRoleViewModel.RoleName;
            await _roleManager.UpdateAsync(exisistRole);    
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UserList()
        {
            var users = _userManager.Users.ToList();
            return View(users); 
        }

        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            TempData["userid"]= user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRole = await _userManager.GetRolesAsync(user);
            List<RoleAssignViewModel> roleAssignViewModel = new List<RoleAssignViewModel>();
            foreach(var item in roles)
            {
                RoleAssignViewModel model = new RoleAssignViewModel();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExisist = userRole.Contains(item.Name);
                roleAssignViewModel.Add(model);
            }
            return View(roleAssignViewModel);   
        }

        [HttpPost]  
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> roleAssignViewModels)
        {
            var userId = (int)TempData["userid"];
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userId);
            foreach (var item in roleAssignViewModels) {

                if (item.RoleExisist)
                {
                    await _userManager.AddToRoleAsync(user,item.RoleName);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, item.RoleName);
                }
            }
            return RedirectToAction("UserList");  
        }
    }
}
