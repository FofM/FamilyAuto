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
    public class StaffController : Controller
    {
        private FamilyAutoEntities db = new FamilyAutoEntities();

        // GET: Staff
        public ActionResult Index(string searchString)
        {
            var staff = db.Staff.Include(s => s.AspNetUsers);

            if (!String.IsNullOrEmpty(searchString) && Regex.IsMatch(searchString, @"^\d+$"))
            {
                int searchInt = int.Parse(searchString);
                staff = staff.Where(s => s.Id.Equals(searchInt));
            }

            else if (!String.IsNullOrEmpty(searchString))
            {
                staff = staff.Where(s => s.FirstName.Contains(searchString) || s.LastName.Contains(searchString) || s.Address.Contains(searchString) || s.Position.Contains(searchString)
                || s.Phone.Contains(searchString) || s.Email.Contains(searchString));
            }

            return View("Index", staff.ToList());
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View("Details", staff);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email");
            return View("Create");
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone,Email,Address,Position,BirthDate,HiredDate,UserId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Staff.Add(staff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", staff.UserId);
            return View(staff);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", staff.UserId);
            return View("Edit", staff);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,Email,Address,Position,BirthDate,HiredDate,UserId")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(staff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.AspNetUsers, "Id", "Email", staff.UserId);
            return View(staff);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Staff staff = db.Staff.Find(id);
            if (staff == null)
            {
                return HttpNotFound();
            }
            return View("Delete", staff);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Staff staff = db.Staff.Find(id);
            db.Staff.Remove(staff);
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
