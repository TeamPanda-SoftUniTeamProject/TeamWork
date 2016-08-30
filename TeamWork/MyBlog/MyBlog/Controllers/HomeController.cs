using System;
using System.Collections;
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
        private const int UserPerPage = 10;

        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author).OrderByDescending(p => p.Date).Take(6);
            return View(posts.ToList());
        }
        [Authorize(Roles = "Administrators")]
        public ActionResult Users(int? id)
        {
            int pageNumber = id ?? 0;
            IEnumerable<ApplicationUser> users = (from user in db.Users.OrderBy(u => u.UserName) select user)
                .Skip(pageNumber * UserPerPage).Take(UserPerPage + 1);
            ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            ViewBag.IsNextLinkVisible = users.Count() > UserPerPage;
            ViewBag.PageNumber = pageNumber;
            //var userse = db.Users.OrderBy(u => u.UserName);
            return View(users.Take(UserPerPage).ToList());
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