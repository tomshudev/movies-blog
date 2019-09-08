using OurMoviesBlog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OurMoviesBlog.Controllers
{
    public class AdminController : Controller
    {
        private ProjectContext db = new ProjectContext();

   
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var users = db.Users;

            var user = users.Find(username);

            if (user != null)
            {
                if (user.Password == password)
                {
                    FormsAuthentication.SetAuthCookie("Admin", true);
                    return Json(new { succeeded = true });
                }
            }

            return Json(new { error = "User name or password are incorrect." });
        }

        public ActionResult Logout()
        {
            //System.Web.HttpContext.Current.Session["isLoggedIn"] = null;
            FormsAuthentication.SignOut();
            return Redirect("/Movies");
        }
    }
}