using OurMoviesBlog.DAL;
using OurMoviesBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OurMoviesBlog.Controllers
{
    public class CommentsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Comments
        public ActionResult Index(string searchTitle, string searchAuthorName)
        {
            var results = db.Comments.AsQueryable();
            if (!string.IsNullOrEmpty(searchTitle))
            {
                results = results.Where(s => s.Title.Contains(searchTitle));
            }
            if (!string.IsNullOrEmpty(searchAuthorName))
            {
                results = results.Where(s => s.AuthorName.Contains(searchAuthorName));
            }
            
            return View(results.ToList());



            var comments = db.Comments.Include(c => c.Post);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        [Authorize(Users = "Admin")]
        public ActionResult Details(int? commentID)
        {
            if (commentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(commentID);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Add(int PostID)
        {
            //ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title");
            var newComment = new Comment();
            newComment.PostID = PostID; // this will be sent from the ArticleDetails View, hold on :).

            return PartialView(newComment);
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "CommentID,PostID,Title,AuthorName,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return Json(new { succeeded = true, commentData = comment });
                //return Json(comment, JsonRequestBehavior.AllowGet);
                //return PartialView(comment);

            }

            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", comment.PostID);
            return Json(new { succeeded = false });
            //return PartialView(comment);

        }


        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,PostID,Title,AuthorName,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        [Authorize(Users = "Admin")]
        public ActionResult Edit(int? commentID)
        {
            if (commentID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(commentID);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Edit([Bind(Include = "CommentID,PostID,Title,AuthorName,Content")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PostID = new SelectList(db.Posts, "PostID", "Title", comment.PostID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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

        // GET: Comments
        public ActionResult Filter(string commentTitle, string authorName)
        {
            var results = db.Comments.AsQueryable();
           
            if (!string.IsNullOrEmpty(authorName))
            {
                results = results.Where(c => c.AuthorName.Contains(authorName));
            }           
            if (!string.IsNullOrEmpty(commentTitle))
            {
                results = results.Where(c => c.Title.Contains(commentTitle));
            }

            return View("Filter", results.ToList());
        }
    }
}