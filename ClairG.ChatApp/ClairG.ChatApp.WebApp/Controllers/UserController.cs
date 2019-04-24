using ClairG.ChatApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClairG.ChatApp.WebApp.Controllers
{
    public class UserController : Controller
    {
        private EFDbContext db = new EFDbContext();

        //User/UserProfile
        public ActionResult UserProfile()
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            //if user is looged in
            return View(db.Users.Find(userId));
        }
    }
}