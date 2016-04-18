using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;

namespace FamilyAuto.Controllers
{
    public class IMSController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: IMS
        public ActionResult Index()
        {
            return View("Index", db.Articles.ToList());
        }

        // GET: Statistics
        public ActionResult Statistics()
        {
            ViewBag.VehiclesSold = (from v in db.Vehicles where v.Sold == true select v).Count().ToString();
            ViewBag.VehiclesNotSold = (from v in db.Vehicles where v.Sold == false select v).Count().ToString();
            ViewBag.RegisteredCustomers = (from c in db.Customers where c.UserId != null select c).Count().ToString();
            ViewBag.NonRegisteredCustomers = (from c in db.Customers where c.UserId == null select c).Count().ToString();

            //ViewBag.SalesPerMonth = db.SoldVehicles.GroupBy(d => d.DateSold).Select(c => new { Month = c.FirstOrDefault().DateSold.Month, Quantity = c.Count().ToString() });

            var SalesPerMonth = from s in db.SoldVehicles
                                group s by s.DateSold into dateSold
                                select new DateSoldGroup()
                                {
                                    DateSold = dateSold.Key,
                                    SoldCount = dateSold.Count()
                                };

            return View("Statistics", SalesPerMonth);
        }

        // GET: IMS/Details/5
        public ActionResult Details(int? id)
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
            return View("Details", articles);
        }

        // GET: IMS/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: IMS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ArticleTitle,ArticleDescription,ArticleType,DateUploaded")] Articles articles)
        {
            //articles.DateUploaded = DateTime.Now;
            if (ModelState.IsValid)
            {
                
                db.Articles.Add(articles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(articles);
        }

        // GET: IMS/Edit/5
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

        // POST: IMS/Edit/5
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

        // GET: IMS/Delete/5
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

        // POST: IMS/Delete/5
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

        //public void SalesPerMonth()
        //{
        //    string[] monthNames = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.MonthGenitiveNames;
        //    ViewBag.Months = monthNames;

        //    DateTime[] spm = (from s in db.SoldVehicles select s.DateSold).ToArray();

        //    System.Collections.ArrayList som = new System.Collections.ArrayList();
        //    foreach (var i in spm)
        //    {
        //        som.Add(i.ToString("MMMM"));
        //    }

        //    ViewBag.SalesPerMonth = som;
        //}
    }
}
