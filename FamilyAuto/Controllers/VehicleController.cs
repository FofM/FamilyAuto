using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;
using System.IO;

namespace FamilyAuto.Controllers
{
    public class VehicleController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: Showroom
        public ActionResult Showroom(string make, string model, string type, int? mileage, int? priceFrom, int? priceTo)
        {
            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature).Include(v => v.VehicleHistory).Where(v => v.Sold == false)
                .Where(v => v.Make == make || make == null || make == "")
                .Where(v => v.Model == model || model == null || model == "")
                .Where(v => v.Type.ToString() == type || type == null || type == "")
                .Where(v => v.VehicleHistory.Mileage < mileage || mileage == null)
                .Where(v => v.Price > priceFrom && v.Price < priceTo || priceFrom == null || priceTo == null);
                


            ViewBag.Make = (from v in db.Vehicles select v.Make).Distinct();

            ViewBag.Model = (from v in db.Vehicles select v.Model).Distinct();

            ViewBag.Type = (from v in db.Vehicles select v.Type).Distinct();

            int[] mil = new int[5] { 10000, 50000, 100000, 200000, 300000 };

            ViewBag.Mileage = mil;

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
            return View("Showroom", vehicles.ToList());
        }

        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature).Include(v => v.VehicleHistory);
            return View("Index", vehicles.ToList());
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

            return View("Details", vehicle);
        }

        // GET: Vehicle/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType");
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor");
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose");
            return View("Create");
        }

        // POST: Vehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Make,Model,Variant,Condition,Type,Description,Price,DateUploaded")] Vehicle vehicle, FormCollection form)
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

                //VehicleHistory vh = new VehicleHistory();
                //vh.Id = vehicle.Id;
                //vh.Mileage = int.Parse(form["VehicleHistory.Mileage"]);

                //bool war = StringToBool(form["VehicleHistory.Warranty"]);

                //List<VehiclePicture> vehiclePictures = new List<VehiclePicture>();
                vehicle.VehiclePictures = new List<VehiclePicture>();
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase upload = Request.Files[i];

                    if (upload != null && upload.ContentLength > 0)
                    {
                        var vehiclePicture = new VehiclePicture()
                        {
                            Description = "",
                            ImageURL = "/Images/" + System.IO.Path.GetFileName(upload.FileName)
                        };

                        vehicle.VehiclePictures.Add(vehiclePicture);
                        //vehiclePictures.Add(vehiclePicture);
                        //var path = Path.Combine(Server.MapPath("~/Images/"), fileName + Guid.NewGuid());
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), upload.FileName));
                    }
                }


                VehicleHistory vh = new VehicleHistory()
                {
                    Id = vehicle.Id,
                    Purpose = form["VehicleHistory.Purpose"].ToString(),
                    NoOfOwners = int.Parse(form["VehicleHistory.NoOfOwners"]),
                    HUValidUntil = DateTime.Parse(form["VehicleHistory.HUValidUntil"]),
                    Warranty = StringToBool(form["VehicleHistory.Warranty"]),
                    Mileage = int.Parse(form["VehicleHistory.Mileage"]),
                    FirstRegistration = DateTime.Parse(form["VehicleHistory.FirstRegistration"])
                };

                VehicleEngine ve = new VehicleEngine()
                {
                    FuelType = form["VehicleEngine.FuelType"].ToString(),
                    Transmission = form["VehicleEngine.Transmission"].ToString(),
                    CubicCapacity = int.Parse(form["VehicleEngine.CubicCapacity"]),
                    Power = int.Parse(form["VehicleEngine.Power"]),
                    FuelConsumption = form["VehicleEngine.FuelConsumption"].ToString(),
                    EmissionClass = form["VehicleEngine.EmissionClass"].ToString(),
                    EmissionSticker = form["VehicleEngine.EmissionSticker"].ToString()
                };

                VehicleFeature vf = new VehicleFeature()
                {
                    ExteriorColor = form["VehicleFeature.ExteriorColor"].ToString(),
                    InteriorColor = form["VehicleFeature.InteriorColor"].ToString(),
                    AirConditioning = StringToBool(form["VehicleFeature.AirConditioning"]),
                    InteriorFeatures = form["VehicleFeature.InteriorFeatures"].ToString(),
                    Security = form["VehicleFeature.Security"].ToString(),
                    Airbags = StringToBool(form["VehicleFeature.Airbags"]),
                    ParkingSensor = StringToBool(form["VehicleFeature.ParkingSensor"]),
                    Sports = StringToBool(form["VehicleFeature.Sports"]),
                    InteriorMaterial = form["VehicleFeature.InteriorMaterial"].ToString()
                };

                db.VehicleHistories.Add(vh);
                db.VehicleEngines.Add(ve);
                db.VehicleFeatures.Add(vf);
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
            return View("Edit", vehicle);
        }

        // POST: Vehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Variant,Condition,Type,Description,Price,DateUploaded")] Vehicle vehicle, [Bind(Include = "ExteriorColor,InteriorColor,AirConditioning,InteriorFeatures,Security,Airbags,ParkingSensor,Sports,InteriorMaterial")] VehicleFeature vehicleFeature)
        {
            if (ModelState.IsValid)
            {
             //   vehicle.VehicleFeature = vehicleFeature;
                vehicle.DateUploaded = DateTime.Now;
                db.Entry(vehicle).State = EntityState.Modified;
                //db.Entry(vehicle.VehicleFeature).State = EntityState.Modified;
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
            return View("Delete", vehicle);
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

        public ActionResult FillModel(string make)
        {
            var context = new FamilyAutoEntities();
            
                context.Configuration.ProxyCreationEnabled = false;
                var models = context.Vehicles.Where(v => v.Make == make);
                return Json(models, JsonRequestBehavior.AllowGet);
            
        }

        public bool StringToBool(string s)
        {
            if (s.ToLower().Equals("true,false"))
            {
                return true;
            }
            else return false;
        }
    }
}
