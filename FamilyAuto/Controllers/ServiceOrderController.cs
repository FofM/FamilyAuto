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
        public ActionResult Index(string sortOrder)
        {
            var serviceOrder = db.ServiceOrder.Include(s => s.Articles).Include(s => s.Customers);

            ViewBag.ServiceName = sortOrder == "ServiceName" ? "service_desc" : "ServiceName";
            ViewBag.CustomerId = sortOrder == "CustomerIdName" ? "cid_desc" : "CustomerIdName";
            ViewBag.FinalPrice = sortOrder == "FinalPrice" ? "price_desc" : "FinalPrice";
            ViewBag.DateOrdered = sortOrder == "DateOrdered" ? "dateo_desc" : "DateOrdered";
            ViewBag.DateDue = sortOrder == "DateDue" ? "dated_desc" : "DateDue";
            ViewBag.DateDelivered = sortOrder == "DateDelivered" ? "datede_desc" : "DateDelivered";
            ViewBag.Paid = sortOrder == "Paid" ? "paid_desc" : "Paid";

            switch (sortOrder)
            {
                case "ServiceName":
                    serviceOrder = serviceOrder.OrderBy(s => s.ServiceId);
                    break;
                case "service_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.ServiceId);
                    break;
                case "CustomerIdName":
                    serviceOrder = serviceOrder.OrderBy(s => s.CustomerId);
                    break;
                case "cid_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.CustomerId);
                    break;
                case "FinalPrice":
                    serviceOrder = serviceOrder.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.Price);
                    break;
                case "DateOrdered":
                    serviceOrder = serviceOrder.OrderBy(s => s.OrderedOnDate);
                    break;
                case "dateo_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.OrderedOnDate);
                    break;
                case "DateDue":
                    serviceOrder = serviceOrder.OrderBy(s => s.DueDate);
                    break;
                case "dated_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.DueDate);
                    break;
                case "DateDelivered":
                    serviceOrder = serviceOrder.OrderBy(s => s.DeliveredDate);
                    break;
                case "datede_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.DeliveredDate);
                    break;
                case "Paid":
                    serviceOrder = serviceOrder.OrderBy(s => s.Paid);
                    break;
                case "paid_desc":
                    serviceOrder = serviceOrder.OrderByDescending(s => s.Paid);
                    break;
                default:
                    serviceOrder = serviceOrder.OrderBy(s => s.Id);
                    break;
            }

            return View("Index", serviceOrder.ToList());
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
            return View("Details", serviceOrder);
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
            return View("Create");
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
            return View("Edit", serviceOrder);
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
            return View("Delete", serviceOrder);
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
