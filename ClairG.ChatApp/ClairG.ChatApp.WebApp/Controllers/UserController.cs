using ClairG.ChatApp.Domain.Concrete;
using ClairG.ChatApp.Domain.Entities;
using ClairG.ChatApp.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

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

        //public class UserLog: IRequiresSessionState
        //{
        //    public bool Check(HttpContext context)
        //    {
        //        if (Convert.ToInt32(context.Session["UserId"]) == 0)
        //        {
        //            return false;
        //        }
        //        return true;
        //    }

        //}

        //Update Picture
        [HttpPost]
        public ActionResult UpdatePicture(PictureVM obj)
        {
            int userId = Convert.ToInt32(Session["UserId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }

            var file = obj.Picture;
            User u = db.Users.Find(userId);
            if( file != null)
            {
                //update the img
                var extension = Path.GetExtension(file.FileName);
                string id_and_extension = userId + extension;
                string imgUrl = "~/Profile_Images/" + id_and_extension;
                u.ImageUrl = imgUrl;
                db.Entry(u).State = EntityState.Modified; //*
                db.SaveChanges();

                var path = Server.MapPath("~/Profile_Images/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path + id_and_extension);
                }
                //when update new img, delete old img
                if ((System.IO.File.Exists(path + id_and_extension))) //imgUrl
                {
                    System.IO.File.Delete(path + id_and_extension);
                }
                file.SaveAs((path + id_and_extension));
            }
            return RedirectToAction("UserProfile");
        }
    }
}