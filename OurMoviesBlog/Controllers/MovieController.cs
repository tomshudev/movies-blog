using OurMoviesBlog.DAL;
using OurMoviesBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OurMoviesBlog.Controllers
{
    public class MoviesController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Movies
        public ActionResult Index(string searchName, string searchGenre, string searchReleaseDate, string searchLanguage, double? searchRate)
        {
            var results = db.Movies.AsQueryable();
            int releaseDate;
            Genre genre;
            Language language;
            if (!string.IsNullOrEmpty(searchName))
            {
                results = results.Where(s => s.Name.Contains(searchName));
            }
            if (!string.IsNullOrEmpty(searchGenre) && Enum.TryParse(searchGenre, out genre))
            {
                results = results.Where(s => s.Genre == genre);
            }
            if (!string.IsNullOrEmpty(searchLanguage) && Enum.TryParse(searchLanguage, out language))
            {
                results = results.Where(s => s.Language == language);
            }
            if (!string.IsNullOrEmpty(searchReleaseDate) && int.TryParse(searchReleaseDate, out releaseDate))
            {
                results = results.Where(s => s.ReleaseDate.Year >= releaseDate);
            }
            return View(results.ToList());
        }

        // GET: Movies
        [HttpGet]
        public ActionResult IndexData(string searchName, string searchGenre, string searchReleaseDate, string searchLanguage, double? searchRate)
        {
            var movies = db.Movies.ToList();

            return Json(movies, JsonRequestBehavior.AllowGet);
        }

        // GET: Movies/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Users = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Create(HttpPostedFileBase postedFile, [Bind(Include = "movieID,Name,Genre,ReleaseDate,Producer, RunningTime, Location, ImageName, Language")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    movie.ImageName = Path.GetFileName(postedFile.FileName);


                    string path = Server.MapPath("~/Media/movies");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    postedFile.SaveAs(path + "\\" + Path.GetFileName(postedFile.FileName));
                    ViewBag.Message = "File uploaded successfully.";
                }

                db.Movies.Add(movie);

                Map map = new Map
                {
                    MapID = movie.MovieID,
                    Name = movie.Name,
                    Location = movie.Location
                };

                db.Maps.Add(map);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Users = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Edit(HttpPostedFileBase postedFile, [Bind(Include = "movieID,Name,Genre,ReleaseDate,Producer,Location,RunningTime,Language,ImageName")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();

                if (postedFile != null)
                {
                    movie.ImageName = Path.GetFileName(postedFile.FileName);

                    string path = Server.MapPath("~/Media/movies");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    postedFile.SaveAs(path + "\\" + Path.GetFileName(postedFile.FileName));
                    ViewBag.Message = "File uploaded successfully.";
                    movie.ImageName = Path.GetFileName(postedFile.FileName);

                }

                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Users = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Users = "Admin")]
        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.Find(id);
            var posts = db.Posts.Where(p => p.MovieId == id);
            foreach (var post in posts)
            {
                db.Posts.Remove(post);
            }
                db.SaveChanges();

            db.Movies.Remove(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Trailer
        public ActionResult Trailer(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }

            return View("Trailer", movie);
        }

        // GET: Posts
        public ActionResult PieChart()
        {
            return View("Pie");
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