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
    public class Res_CommentsController : Controller
    {
        private FoodBankMelbourne_Entities db = new FoodBankMelbourne_Entities();

        // GET: Res_Comments
        public ActionResult Index()
        {
            var res_Comments = db.Res_Comments.Include(r => r.Restaurant);
            return View(res_Comments.ToList());
        }

        // GET: Res_Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Comments res_Comments = db.Res_Comments.Find(id);
            if (res_Comments == null)
            {
                return HttpNotFound();
            }
            return View(res_Comments);
        }

        // GET: Res_Comments/Create
        public ActionResult Create()
        {
            ViewBag.R_Id = new SelectList(db.Restaurants, "Id", "R_Name");
            return View();
        }

        // POST: Res_Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Cus_Init,Com_String,Com_Rate,R_Id")] Res_Comments res_Comments)
        {
            if (ModelState.IsValid)
            {
                db.Res_Comments.Add(res_Comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.R_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Comments.R_Id);
            return View(res_Comments);
        }

        // GET: Res_Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Comments res_Comments = db.Res_Comments.Find(id);
            if (res_Comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.R_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Comments.R_Id);
            return View(res_Comments);
        }

        // POST: Res_Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Cus_Init,Com_String,Com_Rate,R_Id")] Res_Comments res_Comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(res_Comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.R_Id = new SelectList(db.Restaurants, "Id", "R_Name", res_Comments.R_Id);
            return View(res_Comments);
        }

        // GET: Res_Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Res_Comments res_Comments = db.Res_Comments.Find(id);
            if (res_Comments == null)
            {
                return HttpNotFound();
            }
            return View(res_Comments);
        }

        // POST: Res_Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Res_Comments res_Comments = db.Res_Comments.Find(id);
            db.Res_Comments.Remove(res_Comments);
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
