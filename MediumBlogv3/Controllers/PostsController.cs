using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediumBlogv3.Models;

namespace MediumBlogv3.Controllers
{
    public class PostsController : Controller
    {
        private PostDbContext db = new PostDbContext();

        // GET: Posts
        public ActionResult Index(string tag, string blog)
        {
            var posts = db.Posts.Include(p => p.Author).Include(p => p.Blog);
            var tags = posts.OrderBy(p => p.Tag).Select(p => p.Tag).Distinct();
            var blogs = posts.OrderBy(a => a.Blog.Name).Select(a => a.Blog.Name).Distinct();
            if (!String.IsNullOrEmpty(tag))
            {
                posts = posts.Where(p => p.Tag.ToString() == tag);
            }
            if (!String.IsNullOrEmpty(blog))
            {
                posts = posts.Where(a => a.Blog.Name.ToString() == blog);
            }
            ViewBag.Tag = new SelectList(tags);
            ViewBag.Blog = new SelectList(blogs);
            return View(posts.ToList());
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
        [Authorize]
        // GET: Posts/Create
        public ActionResult Create()
        {
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName");
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "Name");
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Tag,FeaturedImageURL,Title,AuthorID,BlogID,Content,Date")] Post post)
        {

            Post matchingPost = db.Posts.Where(cm => string.Compare(cm.Title, post.Title, true) == 0).FirstOrDefault();

            if (matchingPost != null)
            {
                ModelState.AddModelError("", "A post with that title has already been created!");
                return View(post);
            }
            if (ModelState.IsValid)
            {
                post.Date = DateTime.Now.ToString("MM-dd-yyyy");
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", post.AuthorID);
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "Name", post.BlogID);
            return View(post);
        }
        [Authorize(Roles = "Admin")]
        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", post.AuthorID);
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "Name", post.BlogID);
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,Tag,FeaturedImageURL,Title,AuthorID,BlogID,Content,Date")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorID = new SelectList(db.Authors, "AuthorID", "FirstName", post.AuthorID);
            ViewBag.BlogID = new SelectList(db.Blogs, "BlogID", "Name", post.BlogID);
            return View(post);
        }
        [Authorize(Roles = "Admin")]
        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
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
        [Authorize(Roles = "Admin")]
        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
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
