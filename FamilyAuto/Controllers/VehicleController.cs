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
using System.Text.RegularExpressions;
using Microsoft.AspNet.Identity;

namespace FamilyAuto.Controllers
{
    public class VehicleController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: Showroom
        public ActionResult Showroom(string make, string model, string type, int? mileage, int? priceFrom, int? priceTo)
        {
            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature)
                .Include(v => v.VehicleHistory).Where(v => v.Sold == false)
                .Where(v => v.Make == make || make == null || make == "")
                .Where(v => v.Model == model || model == null || model == "")
                .Where(v => v.Type.ToString() == type || type == null || type == "")
                .Where(v => v.VehicleHistory.Mileage < mileage || mileage == null)
                .Where(v => v.Price > priceFrom && v.Price < priceTo || priceFrom == null || priceTo == null);



            ViewBag.Make = (from v in db.Vehicles.Where(x => x.Sold == false) select v.Make).Distinct();

            ViewBag.Model = (from v in db.Vehicles.Where(x => x.Sold == false) select v.Model).Distinct();

            ViewBag.Type = (from v in db.Vehicles.Where(x => x.Sold == false) select v.Type).Distinct();

            int[] mil = new int[5] { 10000, 50000, 100000, 200000, 300000 };

            ViewBag.Mileage = mil;

            if (TempData["VehicleNotFound"] != null) ViewBag.VehicleNotFound = TempData["VehicleNotFound"].ToString();

            return View("Showroom", vehicles.ToList());
        }

        [Authorize(Roles = "Admin, Content Manager")]
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.IdSortParm = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.MakeSortParm = sortOrder == "Make" ? "make_desc" : "Make";
            ViewBag.ModelSortParm = sortOrder == "Model" ? "model_desc" : "Model";
            ViewBag.VariantSortParm = sortOrder == "Variant" ? "variant_desc" : "Variant";
            ViewBag.ConditionSortParm = sortOrder == "Condition" ? "condition_desc" : "Condition";
            ViewBag.TypeSortParm = sortOrder == "Type" ? "type_desc" : "Type";
            ViewBag.SoldSortParm = sortOrder == "Sold" ? "sold_desc" : "Sold";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var vehicles = db.Vehicles.Include(v => v.VehicleEngine).Include(v => v.VehicleFeature).Include(v => v.VehicleHistory);

            if (!String.IsNullOrEmpty(searchString) && Regex.IsMatch(searchString, @"^\d+$"))
            {
                int searchInt = int.Parse(searchString);
                vehicles = vehicles.Where(v => v.Id.Equals(searchInt));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                vehicles = vehicles.Where(v => v.Make.Contains(searchString) || v.Model.Contains(searchString) || v.Variant.Contains(searchString)
                || v.Condition.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "id_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Id);
                    break;
                case "Model":
                    vehicles = vehicles.OrderBy(s => s.Model);
                    break;
                case "model_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Model);
                    break;
                case "Make":
                    vehicles = vehicles.OrderBy(s => s.Make);
                    break;
                case "make_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Make);
                    break;
                case "Variant":
                    vehicles = vehicles.OrderBy(s => s.Variant);
                    break;
                case "variant_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Variant);
                    break;
                case "Condition":
                    vehicles = vehicles.OrderBy(s => s.Condition);
                    break;
                case "condition_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Condition);
                    break;
                case "Type":
                    vehicles = vehicles.OrderBy(s => s.Type);
                    break;
                case "type_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Type);
                    break;
                case "Sold":
                    vehicles = vehicles.OrderBy(s => s.Sold);
                    break;
                case "sold_desc":
                    vehicles = vehicles.OrderByDescending(s => s.Sold);
                    break;
                case "Date":
                    vehicles = vehicles.OrderBy(s => s.DateUploaded);
                    break;
                case "date_desc":
                    vehicles = vehicles.OrderByDescending(s => s.DateUploaded);
                    break;
                default:
                    vehicles = vehicles.OrderBy(s => s.Id);
                    break;
            }

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
                //ViewBag.VehicleNotFound = "Vehicle does not exist in the database";
                TempData["VehicleNotFound"] = "Vehicle does not exist in the database";
                return RedirectToAction ("Showroom");
                //return HttpNotFound();
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
                    Guid imgIdentifier = Guid.NewGuid();
                    if (upload != null && upload.ContentLength > 0)
                    {
                        var vehiclePicture = new VehiclePicture()
                        {
                            Description = "",
                            ImageURL = "/Images/" + imgIdentifier + System.IO.Path.GetFileName(upload.FileName)
                        };

                        vehicle.VehiclePictures.Add(vehiclePicture);
                        //vehiclePictures.Add(vehiclePicture);
                        //var path = Path.Combine(Server.MapPath("~/Images/"), fileName + Guid.NewGuid());
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Images/"), imgIdentifier + upload.FileName));
                    }
                }

                if (form != null)
                {

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

                }
                try
                {
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType", vehicle.Id);
                    ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor", vehicle.Id);
                    ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose", vehicle.Id);
                    return View("Error", vehicle);
                }
            }

            ViewBag.Id = new SelectList(db.VehicleEngines, "Id", "FuelType", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleFeatures, "Id", "ExteriorColor", vehicle.Id);
            ViewBag.Id = new SelectList(db.VehicleHistories, "Id", "Purpose", vehicle.Id);
            return View("Error", vehicle);
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
        public ActionResult Edit([Bind(Include = "Id,Make,Model,Variant,Condition,Type,Description,Price,DateUploaded")] Vehicle vehicle)
        //, [Bind(Include = "ExteriorColor,InteriorColor,AirConditioning,InteriorFeatures,Security,Airbags,ParkingSensor,Sports,InteriorMaterial")] VehicleFeature vehicleFeature
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

        public JsonResult FillModel(string make)
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

        public ActionResult SaveFavorite(FavoriteVehicle fv)
        {
            if (User.Identity.IsAuthenticated)
            {
                string uID = User.Identity.GetUserId();
                if (ModelState.IsValid)
                {
                    fv.UserId = uID;
                    fv.VehicleId = Convert.ToInt32(fv.VehicleId);
                    db.FavoriteVehicle.Add(fv);
                    db.SaveChanges();
                    return Redirect(Request.UrlReferrer.PathAndQuery);
                }
            }
            else
            {
                return Redirect(Request.UrlReferrer.PathAndQuery);
            }
            return Redirect(Request.UrlReferrer.PathAndQuery);
        }

    }
}
