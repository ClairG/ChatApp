using ClairG.ChatApp.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using ClairG.ChatApp.WebApp.Models;
using ClairG.ChatApp.Domain.Entities;

namespace ClairG.ChatApp.WebApp.Controllers
{
    public class ChatRoomController : Controller
    {
        private EFDbContext db = new EFDbContext();

        //ChatRoom/Index
        public ActionResult Index()
        {
            var comments = db.Comments.Include(x => x.Replies).ToList();
            return View(comments);
        }

        //PostReply
        public ActionResult PostReply(ReplyVM obj)
        {
            Reply r = new Reply();
            r.CommentId = obj.CommendId;
            r.Text = obj.Reply;

            db.Replies.Add(r);
            db.SaveChanges();

            return View("Index");
        }
    }
}