using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Netcafe.Models;

namespace Netcafe.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class ManageBookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ManageBookings
        public ActionResult Index()
        {
            return View(db.Bookings.ToList());
        }

        // GET: ManageBookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: ManageBookings/Create
        public ActionResult Create()
        {
            return View(new CreateBookingViewModel());
        }

        // POST: ManageBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateBookingViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.TotalPrice = 50;
                db.Bookings.Add(new Booking() { StartTime = model.StartTime, EndTime = model.EndTime, TotalPrice = model.TotalPrice, UserId = model.UserId, ComputerId = model.ComputerId });
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        /* private decimal DetermineTotalPrice(CreateBookingViewModel model)
         {
             double period = (model.EndTime - model.StartTime).TotalHours;
             decimal totalPrice = (decimal)(10 * period);

             if (model. != null)
             {
                 switch (model.Computer.Performance)
                 {
                     case Performance.Low:
                         totalPrice = (decimal)(10 * period);
                         break;
                     case Performance.Medium:
                         totalPrice = (decimal)(15 * period);
                         break;
                     case Performance.High:
                         totalPrice = (decimal)(20 * period);
                         break;
                 }
             }
             return totalPrice;
         }*/

        // GET: ManageBookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: ManageBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime,TotalPrice")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: ManageBookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: ManageBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
