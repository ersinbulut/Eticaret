using Eticaret.Entity;
using Eticaret.Identity;
using Eticaret.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Eticaret.Controllers
{
    public class UserController : Controller
    {
        DataContext db = new DataContext();
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<ApplicationRole> _roleManager;
        private IdentityDataContext identityDb = new IdentityDataContext();
        public UserController()
        {
            var userStore = new UserStore<ApplicationUser>(identityDb);
            _userManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(identityDb);
            _roleManager = new RoleManager<ApplicationRole>(roleStore);
        }


        // GET: User
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        public ActionResult Index()
        {
            //var users = identityDb.Users.Include(u => u.Roles).ToList();
            var users = identityDb.Users.ToList();

            return View(users);
        }
        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        [HttpGet]
        public ActionResult RolAta(string kullaniciId)
        {
            var bulunankullanici = _userManager.FindByIdAsync(kullaniciId).Result;
            if (bulunankullanici != null)
            {
                TempData["kullaniciId"] = bulunankullanici.Id;
                var roller = _roleManager.Roles.ToList();
                var kullaniciRoller = _userManager.GetRolesAsync(bulunankullanici.Id).Result.ToList();//
                List<RolAtaViewModel> models = new List<RolAtaViewModel>();
                foreach (var rol in roller)
                {
                    RolAtaViewModel model = new RolAtaViewModel();
                    model.RoleId = rol.Id;
                    model.RoleAd = rol.Name;
                    model.VarMi = kullaniciRoller.Contains(rol.Name);
                    models.Add(model);
                }
                return View(models);
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "admin")]//sadece rolu admin olanlar bu sayfaya gidebilir
        [HttpPost]
        public async Task<ActionResult> RolAta(List<RolAtaViewModel> model)
        {
            string kullaniciId = TempData["kullaniciId"].ToString();
            var kullanici = _userManager.FindByIdAsync(kullaniciId).Result;
            foreach (var item in model)
            {
                if (item.VarMi)
                {
                   await _userManager.AddToRoleAsync(kullanici.Id, item.RoleAd);
                }
                else
                {
                  await _userManager.RemoveFromRoleAsync(kullanici.Id, item.RoleAd);
                }
            }
            return RedirectToAction("Index");
        }
    }
}