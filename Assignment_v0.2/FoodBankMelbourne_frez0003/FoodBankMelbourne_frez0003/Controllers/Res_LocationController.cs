using System;
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
    public class Res_LocationController : Controller
    {
        private FoodBankMelbourne_Entities db = new FoodBankMelbourne_Entities();

        // GET: Res_Location
        public ActionResult Index()
        {
            var res_Location = db.Res_Location.Include(r => r.Restaurant);
            return View(res_Location.ToList());
        }

        // GET: Res_Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Location res_Location = db.Res_Location.Find(id);
            if (res_Location == null)
            {
                return HttpNotFound();
            }
            return View(res_Location);
        }

        // GET: Res_Location/Create
        public ActionResult Create()
        {
            ViewBag.Res_Id = new SelectList(db.Restaurants, "Id", "R_Name");
            return View();
        }

        // POST: Res_Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,L_Name,S_Address,Latitude,Longitude,Res_Id")] Res_Location res_Location)
        {
            if (ModelState.IsValid)
            {
                db.Res_Location.Add(res_Location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Res_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Location.Res_Id);
            return View(res_Location);
        }

        // GET: Res_Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Location res_Location = db.Res_Location.Find(id);
            if (res_Location == null)
            {
                return HttpNotFound();
            }
            ViewBag.Res_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Location.Res_Id);
            return View(res_Location);
        }

        // POST: Res_Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,L_Name,S_Address,Latitude,Longitude,Res_Id")] Res_Location res_Location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(res_Location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Res_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Location.Res_Id);
            return View(res_Location);
        }

        // GET: Res_Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Location res_Location = db.Res_Location.Find(id);
            if (res_Location == null)
            {
                return HttpNotFound();
            }
            return View(res_Location);
        }

        // POST: Res_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Res_Location res_Location = db.Res_Location.Find(id);
            db.Res_Location.Remove(res_Location);
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
