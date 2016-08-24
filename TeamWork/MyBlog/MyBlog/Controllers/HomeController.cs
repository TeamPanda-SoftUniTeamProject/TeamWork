using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using System.Net;
using System.Data.Entity;
using MyBlog.Extensions;

namespace MyBlog.Controllers
{
    public class HomeController : BaseController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(6);
            return View(posts.ToList());
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult Users()
        {
            var users = db.Users.OrderBy(u => u.UserName);
            return View(users.ToList());
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult DeleteUser(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var user = db.Users.SingleOrDefault(u=>u.Id==id);
            return View(user);
        }
        [HttpPost, ActionName("DeleteUser")]
        [Authorize(Roles = "Administrators")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
           
                ApplicationUser user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                this.AddNotification("User deleted!", NotificationType.INFO);
                return RedirectToAction("Users");
          
            
        }
    }
}