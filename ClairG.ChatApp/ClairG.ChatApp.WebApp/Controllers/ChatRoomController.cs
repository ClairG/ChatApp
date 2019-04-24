using ClairG.ChatApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace ClairG.ChatApp.WebApp.Controllers
{
    public class ChatRoomController : Controller
    {
        private EFDbContext db = new EFDbContext();
        // GET: ChatRoom
        public ActionResult Index()
        {
            var comments = db.Comments.Include(x => x.Replies).ToList();
            return View(comments);
        }
    }
}