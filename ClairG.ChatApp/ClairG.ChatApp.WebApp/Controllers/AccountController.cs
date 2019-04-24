using ClairG.ChatApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClairG.ChatApp.WebApp.Models;
using ClairG.ChatApp.Domain.Entities;

namespace ClairG.ChatApp.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private EFDbContext db = new EFDbContext();

        //Get: Account/Register
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        //Get: Account/Register
        [HttpPost]
        public ActionResult Register(RegisterVM obj)
        {
            bool UserExist = db.Users.Any(x => x.Username == obj.Username);
            if (UserExist) //if username is already in use
            {
                ViewBag.UsernameMessage = "This username is already in use, try another";
                return View();
            }
            bool EmailExist = db.Users.Any(y => y.Email == obj.Email);
            if (EmailExist) //if Email is already in use
            {
                ViewBag.EmailMessage = "This Email is already in use, try another";
                return View();
            }
            //if username and email is unique, then we save the user
            User u = new User();
            u.Username = obj.Username;
            u.Password = obj.Password;
            u.Email = obj.Email;
            u.ImageUrl = "";
            u.CreatedDateTime = DateTime.Now;

            db.Users.Add(u);
            db.SaveChanges();

            return RedirectToAction("Index", "ChatRoom");
        }

    }
}