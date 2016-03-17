using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;

namespace FamilyAuto.Controllers
{
    public class HomeController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        public ActionResult Index()
        {
            var topNews = from n in db.Articles
                          where n.ArticleType == 0
                          select n;
            topNews.Take(3).ToList();
            return View(topNews);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Family Auto contact page.";

            return View();
        }
    }
}