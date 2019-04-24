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
        [HttpPost]
        public ActionResult PostReply(ReplyVM obj)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Reply r = new Reply();
                r.CommentId = obj.CommendId;
                r.Text = obj.Reply;
                r.UserId = userId;
                r.CreatedDateTime = DateTime.Now;

                db.Replies.Add(r);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }

        //PostComment
        [HttpPost]
        public ActionResult PostComment(string CommentText)
        {
            var userId = Convert.ToInt32(Session["UserId"]);
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Comment c = new Comment();
                c.Text = CommentText;
                c.UserId = userId;
                c.CreatedDateTime = DateTime.Now;

                db.Comments.Add(c);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}