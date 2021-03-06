﻿using System;
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
    public class VehicleController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: Vehicle
        public ActionResult Showroom()
        {
            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature).Include(v => v.VehicleHistory);

            //var vehicles = from v in db.Vehicles
            //               from ve in db.VehicleEngines
            //               from vh in db.VehicleHistories
            //               from vf in db.VehicleFeatures
            //               where v.Id == ve.Id
            //               where v.Id == vh.Id
            //               where v.Id == vf.Id
            //               select new
            //               {
            //                   v,
            //                   ve,
            //                   vh,
            //                   vf

            //               };

            //IEnumerable<string> make = new IEnumerable<string>();
            
            //ViewBag.VehicleMake = from v in db.Vehicles select v.Make;

            //if (!User.Identity.IsAuthenticated)
            //{
            //    return View("Showroom", vehicles.ToList());
            //}
            return View(vehicles.ToList());
        }

        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature).Include(v => v.VehicleHistory);
            return View(vehicles.ToList());
        }

        // GET: Vehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }

            //var pictureData = new FamilyAutoEntities();
            //pictureData.VehiclePictures = pictureData.VehiclePictures.Where(i => i.VehicleID == id);
            ViewBag.VehicleID = id.Value;

            return View(vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType");
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor");
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose");
            return View();
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Variant,Condition,Type,Description,DateUploaded")] Vehicle vehicle, FormCollection form )
        {
            if (ModelState.IsValid)
            {
                vehicle.DateUploaded = DateTime.Now;
                //Convert.ToString(vehicle.Type);
                db.Vehicles.Add(vehicle);
                //vh = new VehicleHistory
                //{
                //    vh.Id = FK;
                //vh.Mileage =
                //}
                //vh.Id = vehicle.Id;
                //db.VehicleHistories.Add(vh);
                VehicleHistory vh = new VehicleHistory();
                vh.Id = vehicle.Id;
                vh.Mileage = int.Parse(form["VehicleHistory.Mileage"]);
                db.VehicleHistories.Add(vh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose", vehicle.Id);
            return View(vehicle);
        }

        // GET: Vehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose", vehicle.Id);
            return View(vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Variant,Condition,Type,Description,Price,DateUploaded")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                vehicle.DateUploaded = DateTime.Now;
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose", vehicle.Id);
            return View(vehicle);
        }

        // GET: Vehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
