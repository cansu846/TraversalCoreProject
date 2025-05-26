using DocumentFormat.OpenXml.Office2016.Drawing.Command;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/[controller]/[action]")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
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
                Name=createRoleViewModel.RoleName
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
    }
}
