using OurMoviesBlog.DAL;
using OurMoviesBlog.Models;
using SVMTextClassifier;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OurMoviesBlog.Controllers
{
    public class PostsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.ToList());
        }

        // GET: Posts/Details/5
        public ActionResult Details(int? id, int? movie)
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
        public ActionResult Create()
        {
            var allMovies = db.Movies;
            this.ViewData["moviesSelectable"] = (IEnumerable<OurMoviesBlog.Models.Movie>)allMovies;
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,Title,AuthorName,MovieID,Content")] Post post, string category)
        {
            post.Date = DateTime.Now;
            if (ModelState.IsValid)
            {
                Category newCategory;
                if (string.IsNullOrEmpty(category))
                {
                    Program.Main();
                    Enum.TryParse(Program.Predict(post.Content), out newCategory);

                    ViewBag.Category = newCategory;

                    db.Posts.Add(post);
                    db.SaveChanges();

                    return View("Suggestion", post);
                }
                else
                {
                    Enum.TryParse(category, out newCategory);
                    post.Category = newCategory;
                    db.Posts.Add(post);
                    db.SaveChanges();

                    int prediction;
                    int.TryParse(category, out prediction);
                    Program.AddPrediction(post.Title, prediction + 1);

                    return RedirectToAction("Index");
                }
            }

            var allMovies = db.Movies;
            this.ViewData["moviesSelectable"] = (IEnumerable<OurMoviesBlog.Models.Movie>)allMovies;
            return View(post);
        }

        public ActionResult Approve(int? id, Category category)
        {
            Post post = db.Posts.Find(id);
            db.Entry(post).State = EntityState.Modified;
            post.Category = category;
            db.SaveChanges();

            int prediction;
            int.TryParse(category.GetHashCode().ToString(), out prediction);
            Program.AddPrediction(post.Title, prediction + 1);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Suggestion([Bind(Include = "PostID")] int? PostID, string category)
        {
            Category newCategory;

            if (!string.IsNullOrEmpty(category) && Enum.TryParse(category, out newCategory))
            {
                Approve(PostID, newCategory);
            }

            return RedirectToAction("Index");
        }

        // GET: Posts/Edit/5
        [Authorize(Users = "Admin")]
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

            var allMovies = db.Movies;
            this.ViewData["moviesSelectable"] = (IEnumerable<OurMoviesBlog.Models.Movie>)allMovies;
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Edit([Bind(Include = "PostID,Title,AuthorName,MovieID,Movie,Date,Content")] Post post, string category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                Category newCategory;
                Enum.TryParse(category, out newCategory);
                post.Category = newCategory;
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");         
            }
            var allMovies = db.Movies;
            this.ViewData["movieSelectable"] = (IEnumerable<OurMoviesBlog.Models.Movie>)allMovies;
            return View(post);
        }

        // GET: Posts/Delete/5
        [Authorize(Users = "Admin")]
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

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Posts
        public ActionResult Filter(string movieGenre, string authorName, string movieName, string postCategory)
        {
            var results = db.Posts.AsQueryable();
            Genre genre;
            Category category;
            if (!string.IsNullOrEmpty(movieName))
            {
                results = from post in db.Posts
                          join movie in db.Movies on post.MovieId equals movie.MovieID
                          where movie.Name == movieName
                          select post;
            }
            if (!string.IsNullOrEmpty(authorName))
            {
                results = results.Where(p => p.AuthorName.Contains(authorName));
            }
            if (!string.IsNullOrEmpty(postCategory) && Enum.TryParse(postCategory, out category))
            {
                results = results.Where(m => m.Category == category);
            }
            return View("Filter", results.ToList());
        }

        public ActionResult GroupByMovie()
        {
            // Group by and join
            var PostsAmount = from post in db.Posts
                              group post by post.MovieId into g
                              join movie in db.Movies on g.Key equals movie.MovieID
                              select new SelectByMovie() { MovieName = movie.Name, PostsAmount = g.Sum(m => 1) };

            return View(PostsAmount.ToList());
        }

        [HttpGet]
        public ActionResult GroupByMovieData()
        {
            // Group by and join
            var PostsAmount = from post in db.Posts
                              group post by post.MovieId into g
                              join movie in db.Movies on g.Key equals movie.MovieID
                              select new SelectByMovie() { MovieName = movie.Name, PostsAmount = g.Sum(m => 1) };

            return Json(PostsAmount.ToList(), JsonRequestBehavior.AllowGet);
        }

        // Get Posts/WantMore
        [HttpPost]
        public ActionResult WantMore(string movieId, string currentPostId)
        {
            try
            {
                int postId = Int32.Parse(currentPostId);
                int movId = Int32.Parse(movieId);
                var alikePost = (from post in db.Posts
                                 where post.PostID != postId && post.MovieId == movId
                                 select post.PostID).SingleOrDefault();
                if (alikePost != 0)
                {
                    return Json(new Dictionary<string, object> { { "url", "/Posts/Details/" + alikePost + "?movie=" + movieId } });
                }
                else
                {
                    return Json(new Dictionary<string, object> { { "error", "didnt found any" } });
                }
            }
            catch (Exception ex)
            {
                return Json(new Dictionary<string, object> { { "error", ex.Message } });
            }


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