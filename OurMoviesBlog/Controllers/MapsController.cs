using OurMoviesBlog.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OurMoviesBlog.Controllers
{
    public class MapsController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: Maps
        public ActionResult Index()
        {
            return View(db.Maps.ToList());
        }
    }
}