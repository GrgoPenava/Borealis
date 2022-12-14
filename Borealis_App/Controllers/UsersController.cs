using Microsoft.AspNetCore.Mvc;
using Borealis_App.Data;
using Borealis_App.Models;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;

namespace Borealis_App.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _db;
        public static bool PostojiPoruka { get; set; } = false;
        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
			ViewBag.message = PostojiPoruka;
            IEnumerable<Users> UsersList = _db.users;
            UsersList = UsersList.OrderByDescending(x => x.Username);
            return View(UsersList);
        }

        //GET
        public IActionResult Prijava()
        {
			if (HttpContext.Session.GetString("Username") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Upravitelj", "Zapisi");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Prijava(Users user)
        {    
            if (HttpContext.Session.GetString("Username") == null)
            {
                if (ModelState.IsValid)
                {
                    var obj = _db.users.Where(a => a.Username.Equals(user.Username) && a.lozinka.Equals(user.lozinka)).FirstOrDefault();
                    if (obj != null)
                    {
                        HttpContext.Session.SetString("Username", obj.Username.ToString());
                        var poruka = HttpContext.Session.GetString("Username");
                        if (poruka != null) {
                            PostojiPoruka = true;
                        } 
                        return RedirectToAction("Upravitelj","Zapisi");
                    }
                }
                else
                {
                    return RedirectToAction("Prijava");
                }
            }
            return View();
        }
        
    }
}
