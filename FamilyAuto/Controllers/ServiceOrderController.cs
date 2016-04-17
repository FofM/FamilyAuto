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
    public class ServiceOrderController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: ServiceOrder
        public ActionResult Index()
        {
            var serviceOrder = db.ServiceOrder.Include(s => s.Articles).Include(s => s.Customers);
            return View(serviceOrder.ToList());
        }

        // GET: ServiceOrder/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrder serviceOrder = db.ServiceOrder.Find(id);
            if (serviceOrder == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrder);
        }

        // GET: ServiceOrder/Create
        public ActionResult Create()
        {
            //ViewBag.ServiceId = new SelectList(db.Articles, "Id", "ArticleTitle");

            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName");
            var services = from s in db.Articles
                           where s.ArticleType == ArticleEnum.Service select s;

            ViewBag.ServiceId = new SelectList((from s in services.ToList()
                                                select new
                                                {
                                                    Id = s.Id,
                                                    ArticleTitle = s.ArticleTitle
                                                }), "Id", "ArticleTitle", null);
            
            //ViewBag.ServiceId = new SelectList(services, "Id", "ArticleTitle");


            ViewBag.CustomerId = new SelectList((from c in db.Customers.ToList()
                                                 select new
                                                 {
                                                     Id = c.Id,
                                                     customerName = c.Id + " - " + c.FirstName + " " + c.LastName
                                                 }),
                                                "Id", "customerName", null);
            return View();
        }

        // POST: ServiceOrder/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Price,Paid,OrderedOnDate,DueDate,DeliveredDate,ServiceId,CustomerId")] ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                db.ServiceOrder.Add(serviceOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServiceId = new SelectList(db.Articles, "Id", "ArticleTitle", serviceOrder.ServiceId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", serviceOrder.CustomerId);
            return View(serviceOrder);
        }

        // GET: ServiceOrder/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrder serviceOrder = db.ServiceOrder.Find(id);
            if (serviceOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServiceId = new SelectList(db.Articles, "Id", "ArticleTitle", serviceOrder.ServiceId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", serviceOrder.CustomerId);
            return View(serviceOrder);
        }

        // POST: ServiceOrder/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Price,Paid,OrderedOnDate,DueDate,DeliveredDate,ServiceId,CustomerId")] ServiceOrder serviceOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serviceOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServiceId = new SelectList(db.Articles, "Id", "ArticleTitle", serviceOrder.ServiceId);
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", serviceOrder.CustomerId);
            return View(serviceOrder);
        }

        // GET: ServiceOrder/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServiceOrder serviceOrder = db.ServiceOrder.Find(id);
            if (serviceOrder == null)
            {
                return HttpNotFound();
            }
            return View(serviceOrder);
        }

        // POST: ServiceOrder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServiceOrder serviceOrder = db.ServiceOrder.Find(id);
            db.ServiceOrder.Remove(serviceOrder);
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
