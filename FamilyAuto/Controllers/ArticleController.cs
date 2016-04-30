using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;
using System.Text.RegularExpressions;

namespace FamilyAuto.Controllers
{
    public class ArticleController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: Article
        [Authorize(Roles = "Admin, Content Manager")]
        public ActionResult Index(string sortOrder, string searchString)
        {
            IQueryable<Articles> articles = db.Articles;

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.TitleSortParm = sortOrder == "ArticleTitle" ? "title_desc" : "ArticleTitle";
            ViewBag.DescriptionSortParm = sortOrder == "ArticleDescription" ? "description_desc" : "ArticleDescription";
            ViewBag.TypeSortParm = sortOrder == "ArticleType" ? "type_desc" : "ArticleType";
            ViewBag.DateSortParm = sortOrder == "DateUploaded" ? "date_desc" : "DateUploaded";

            switch (sortOrder)
            {
                case "id_desc":
                    articles = articles.OrderByDescending(s => s.Id);
                    break;
                case "ArticleTitle":
                    articles = articles.OrderBy(s => s.ArticleTitle);
                    break;
                case "title_desc":
                    articles = articles.OrderByDescending(s => s.ArticleTitle);
                    break;
                case "ArticleDescription":
                    articles = articles.OrderBy(s => s.ArticleDescription);
                    break;
                case "description_desc":
                    articles = articles.OrderByDescending(s => s.ArticleDescription);
                    break;
                case "ArticleType":
                    articles = articles.OrderBy(s => s.ArticleType);
                    break;
                case "type_desc":
                    articles = articles.OrderByDescending(s => s.ArticleType);
                    break;
                case "DateUploaded":
                    articles = articles.OrderBy(s => s.DateUploaded);
                    break;
                case "date_desc":
                    articles = articles.OrderByDescending(s => s.DateUploaded);
                    break;
                default:
                    articles = articles.OrderBy(s => s.Id);
                    break;
            }

            

            if (!String.IsNullOrEmpty(searchString) && Regex.IsMatch(searchString, @"^\d+$"))
            {
                int searchInt = int.Parse(searchString);
                articles = articles.Where(a => a.Id.Equals(searchInt));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(a => a.ArticleTitle.Contains(searchString) || a.ArticleDescription.Contains(searchString));
            }

            return View("Index", articles.ToList());
        }

        // GET: Article/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                TempData["ArticleNotFound"] = "Article does not exist in the database";
                return RedirectToAction("Services", "Home");

                //return HttpNotFound();
            }
            return View("Details", articles);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Article/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArticleTitle,ArticleDescription,ArticleType,DateUploaded")] Articles articles)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    articles.DateUploaded = DateTime.Now;
                    db.Articles.Add(articles);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                return View(articles);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "Article", "Create"));
            }
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View("Edit", articles);
        }

        // POST: Article/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ArticleTitle,ArticleDescription,ArticleType,DateUploaded")] Articles articles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(articles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(articles);
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Articles articles = db.Articles.Find(id);
            if (articles == null)
            {
                return HttpNotFound();
            }
            return View("Delete", articles);
        }

        // POST: Article/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Articles articles = db.Articles.Find(id);
            db.Articles.Remove(articles);
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
