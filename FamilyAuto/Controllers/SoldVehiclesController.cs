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
    public class SoldVehiclesController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: SoldVehicles
        public ActionResult Index()
        {
            var soldVehicles = db.SoldVehicles.Include(s => s.Customers).Include(s => s.Vehicle);
            return View(soldVehicles.ToList());
        }

        // GET: SoldVehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoldVehicles soldVehicles = db.SoldVehicles.Find(id);
            if (soldVehicles == null)
            {
                return HttpNotFound();
            }
            return View(soldVehicles);
        }

        // GET: SoldVehicles/Create
        public ActionResult Create()
        {
            //ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id");

            ViewBag.CustomerId = new SelectList((from c in db.Customers.ToList()
                                                 select new
                                                 {
                                                     Id = c.Id,
                                                     customerName = c.Id + " - " + c.FirstName + " " + c.LastName
                                                 }),
    "Id", "customerName", null);

            ViewBag.StaffId = new SelectList((from s in db.Staff.ToList()
                                                 select new
                                                 {
                                                     Id = s.Id,
                                                     StaffId = s.Id + " - " + s.FirstName + " " + s.LastName
                                                 }),
"Id", "StaffId", null);

            //ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Id");

            //The SelectList values are defined by concatenating database values in order
            //to provide a more readable Create view in SoldVehicles
            ViewBag.VehicleId = new SelectList((from v in db.Vehicles.ToList()
                                                select new
                                                {
                                                    Id = v.Id,
                                                    vehicleName = v.Id + " - " + v.Make
                                                }),
                "Id", "vehicleName", null);
            //ViewBag.VehicleList = db.Vehicles;
            return View();
        }

        // POST: SoldVehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,VehicleId,CustomerId,DateSold,DateCreated,FinalPrice")] SoldVehicles soldVehicles)
        {
            //Vehicle v = new Vehicle();

            if (ModelState.IsValid)
            {
                soldVehicles.FinalPrice = AddVAT(soldVehicles.FinalPrice);
                soldVehicles.DateCreated = DateTime.Now;
                SellVehicle(soldVehicles.VehicleId);
                db.SoldVehicles.Add(soldVehicles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Id", soldVehicles.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Id", soldVehicles.VehicleId);
            ViewBag.VehicleList = db.Vehicles;
            return View(soldVehicles);
        }

        // GET: SoldVehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoldVehicles soldVehicles = db.SoldVehicles.Find(id);
            if (soldVehicles == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", soldVehicles.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", soldVehicles.VehicleId);
            return View(soldVehicles);
        }

        // POST: SoldVehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,VehicleId,CustomerId,DateSold,DateCreated,FinalPrice")] SoldVehicles soldVehicles)
        {

            if (ModelState.IsValid)
            {
                db.Entry(soldVehicles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", soldVehicles.CustomerId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "Make", soldVehicles.VehicleId);
            return View(soldVehicles);
        }

        // GET: SoldVehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SoldVehicles soldVehicles = db.SoldVehicles.Find(id);
            if (soldVehicles == null)
            {
                return HttpNotFound();
            }
            return View(soldVehicles);
        }

        // POST: SoldVehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SoldVehicles soldVehicles = db.SoldVehicles.Find(id);
            SellVehicleCancel(soldVehicles.VehicleId);
            db.SoldVehicles.Remove(soldVehicles);
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

        public void SellVehicle(int id)
        {
            Vehicle v = db.Vehicles.Find(id);
            v.Sold = true;
            db.SaveChanges();
        }

        public void SellVehicleCancel(int id)
        {
            Vehicle v = db.Vehicles.Find(id);
            v.Sold = false;
            db.SaveChanges();
        }

        public int AddVAT(int price)
        {
            return price * 20 / 100 + price;
        }
    }
}
