using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyBlog.Models;
using MyBlog.Extensions;

namespace MyBlog.Controllers
{
    [ValidateInput(false)]
    public class PostsController : BaseController
    {
       
        private ApplicationDbContext db = new ApplicationDbContext();
        private const int PostPerPage = 10;
        // GET: Posts
        public ActionResult Index(int? id)
        {
            int pageNumber = id ?? 0;
            IEnumerable<Post> posts =
                (from post in db.Posts.Include(p => p.Author) where post.Date < DateTime.Now orderby post.Date descending select post)
                .Skip(pageNumber * PostPerPage).Take(PostPerPage+1);
            ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            ViewBag.IsNextLinkVisible = posts.Count() > PostPerPage;
            ViewBag.PageNumber = pageNumber;
            return View(posts.Take(PostPerPage).ToList());
        }
        public ActionResult MyPosts(int? id)
        {
            
            int pageNumber = id ?? 0;
            IEnumerable<Post> posts =
                (from post in db.Posts.Include(p => p.Author).Where(p => p.Author.UserName == User.Identity.Name)
                 where post.Date < DateTime.Now orderby post.Date descending select post)
                .Skip(pageNumber * PostPerPage).Take(PostPerPage + 1);
            ViewBag.IsPreviousLinkVisible = pageNumber > 0;
            ViewBag.IsNextLinkVisible = posts.Count() > PostPerPage;
            ViewBag.PageNumber = pageNumber;
            if (posts.Count() != 0)
            {
                return View(posts.Take(PostPerPage).ToList());
            }
            else
            {
                this.AddNotification("You don't have any posts!", NotificationType.ERROR);
                return RedirectToAction("Create");
            }
                
            
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Body")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Author = db.Users
                    .FirstOrDefault(u => u.UserName == User.Identity.Name);
                post.Date = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                this.AddNotification("Post created!", NotificationType.INFO);
                return RedirectToAction("Index");
            }
            else
            {
                this.AddNotification("Error!Cannot create post!",NotificationType.ERROR);
                return View(post);
            }

           
        }

        // GET: Posts/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(p => p.Author).SingleOrDefault(p=>p.Id==id);
            if (post == null || ((post.Author==null || post.Author.UserName!=User.Identity.Name) && (!User.IsInRole("Administrators"))))
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Body")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                this.AddNotification("Post edited!",NotificationType.INFO);
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Include(p => p.Author).SingleOrDefault(p => p.Id == id);
            if (post == null || ((post.Author == null || post.Author.UserName != User.Identity.Name) && (!User.IsInRole("Administrators"))))
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            this.AddNotification("Post deleted!",NotificationType.INFO);
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
