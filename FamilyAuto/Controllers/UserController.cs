using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FamilyAuto.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;

namespace FamilyAuto.Controllers
{
    public class UserController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: User
        public ActionResult Index(string searchString)
        {
            var customers = db.Customers.Include(c => c.AspNetUsers);

            if (!String.IsNullOrEmpty(searchString) && Regex.IsMatch(searchString, @"^\d+$"))
            {
                int searchInt = int.Parse(searchString);
                customers = customers.Where(a => a.Id.Equals(searchInt));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                customers = customers.Where(c => c.FirstName.Contains(searchString) || c.LastName.Contains(searchString) || c.Address.Contains(searchString) || c.Email.Contains(searchString)
                || c.Phone.Contains(searchString) || c.UserId.Contains(searchString));
            }

            return View("Index", customers.ToList());
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View("Details", customers);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            if (User.Identity.IsAuthenticated)
            {
                string uID = User.Identity.GetUserId();
                var loggedUser = db.Customers.Where(x => x.UserId == uID).FirstOrDefault();
                if (loggedUser != null)
                {
                    string idCompare = loggedUser.UserId;
                    int pKey = loggedUser.Id;
                    if (uID.Equals(idCompare))
                    {
                        return RedirectToAction("Edit", new { id = pKey });
                    }
                }

            }
            //ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View("Create");
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone,Email,Address,UserId")] Customers customers)
        {
            if (User.Identity.IsAuthenticated)
            {
                string uID = User.Identity.GetUserId();
                customers.UserId = uID;
            }
            try
            {
                if (ModelState.IsValid)
                {
                    db.Customers.Add(customers);
                    db.SaveChanges();
                    if (User.IsInRole("Admin") || User.IsInRole("Content Manager"))
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", customers.UserId);
                return View(customers);
            }
            catch (Exception ex)
            {
                return View("Error", new HandleErrorInfo(ex, "User", "Create"));
            }

        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", customers.UserId);
            return View("Edit", customers);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,Email,Address,UserId")] Customers customers)
        {
            if (ModelState.IsValid)
            {
                //FamilyAutoEntities context = new FamilyAutoEntities();
                //using (context)
                //{
                //    if (customers.UserId == null)
                //    {
                //        string id = db.Customers.Where(x => x.Id == customers.Id).FirstOrDefault().ToString();
                //        customers.UserId = id;
                //    }
                //}
                db.Entry(customers).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Admin") || User.IsInRole("Content Manager"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", customers.UserId);
            return View(customers);
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return HttpNotFound();
            }
            return View("Delete", customers);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers customers = db.Customers.Find(id);
            db.Customers.Remove(customers);
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
