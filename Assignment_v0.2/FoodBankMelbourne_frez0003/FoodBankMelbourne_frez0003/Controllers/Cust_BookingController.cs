﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodBankMelbourne_frez0003.Models;

namespace FoodBankMelbourne_frez0003.Controllers
{
    [Authorize(Roles = "Customer, Administrator")]
    public class Cust_BookingController : Controller
    {
        private FoodBankMelbourne_Entities db = new FoodBankMelbourne_Entities();

        // GET: Cust_Booking
        [Authorize(Roles = "Customer, Administrator")]
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            var cust_Booking = db.Cust_Booking.Include(c => c.AspNetUser).Where(c=> c.AspNetUser.Email == user).Include(c => c.Restaurant);
            return View(cust_Booking.ToList());
        }

        // GET: Cust_Booking/Details/5
        [Authorize(Roles = "Customer, Administrator")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Booking cust_Booking = db.Cust_Booking.Find(id);
            if (cust_Booking == null)
            {
                return HttpNotFound();
            }
            return View(cust_Booking);
        }

        // GET: Cust_Booking/Create
        [Authorize(Roles = "Customer")]
        public ActionResult Create()
        {
            ViewBag.Customer_id = new SelectList(db.AspNetUsers, "Id", "Email");
            ViewBag.Resturent_id = new SelectList(db.Restaurants, "Id", "R_Name");
            return View();
        }

        // POST: Cust_Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult Create([Bind(Include = "Id,Resturent_id,Customer_id,Booking_Date_time")] Cust_Booking cust_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Cust_Booking.Add(cust_Booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Customer_id = new SelectList(db.AspNetUsers, "Id", "Email", cust_Booking.Customer_id);
            ViewBag.Resturent_id = new SelectList(db.Restaurants, "Id", "R_Name", cust_Booking.Resturent_id);
            return View(cust_Booking);
        }

        // GET: Cust_Booking/Edit/5
        [Authorize(Roles = "Customer")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Booking cust_Booking = db.Cust_Booking.Find(id);
            if (cust_Booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.Customer_id = new SelectList(db.AspNetUsers, "Id", "Email", cust_Booking.Customer_id);
            ViewBag.Resturent_id = new SelectList(db.Restaurants, "Id", "R_Name", cust_Booking.Resturent_id);
            return View(cust_Booking);
        }

        // POST: Cust_Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]

        public ActionResult Edit([Bind(Include = "Id,Resturent_id,Customer_id,Booking_Date_time")] Cust_Booking cust_Booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cust_Booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Customer_id = new SelectList(db.AspNetUsers, "Id", "Email", cust_Booking.Customer_id);
            ViewBag.Resturent_id = new SelectList(db.Restaurants, "Id", "R_Name", cust_Booking.Resturent_id);
            return View(cust_Booking);
        }

        // GET: Cust_Booking/Delete/5
        [Authorize(Roles = "Customer")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cust_Booking cust_Booking = db.Cust_Booking.Find(id);
            if (cust_Booking == null)
            {
                return HttpNotFound();
            }
            return View(cust_Booking);
        }

        // POST: Cust_Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Customer")]
        public ActionResult DeleteConfirmed(int id)
        {
            Cust_Booking cust_Booking = db.Cust_Booking.Find(id);
            db.Cust_Booking.Remove(cust_Booking);
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
