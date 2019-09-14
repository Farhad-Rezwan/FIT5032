using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assignment_frez0003.Models;

namespace FIT5032_Assignment_frez0003.Controllers
{
    [Authorize]
    public class Reg_CustomerController : Controller
    {
        private FIT5032_Assignment_DatabaseFirstEntities db = new FIT5032_Assignment_DatabaseFirstEntities();

        // GET: Reg_Customer
        public ActionResult Index()
        {
            return View(db.Reg_Customer.ToList());
        }

        // GET: Reg_Customer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg_Customer reg_Customer = db.Reg_Customer.Find(id);
            if (reg_Customer == null)
            {
                return HttpNotFound();
            }
            return View(reg_Customer);
        }

        // GET: Reg_Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reg_Customer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,C_Email,C_Password,CF_Name,CL_Name,C_Phone")] Reg_Customer reg_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Reg_Customer.Add(reg_Customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reg_Customer);
        }

        // GET: Reg_Customer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg_Customer reg_Customer = db.Reg_Customer.Find(id);
            if (reg_Customer == null)
            {
                return HttpNotFound();
            }
            return View(reg_Customer);
        }

        // POST: Reg_Customer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,C_Email,C_Password,CF_Name,CL_Name,C_Phone")] Reg_Customer reg_Customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reg_Customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reg_Customer);
        }

        // GET: Reg_Customer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reg_Customer reg_Customer = db.Reg_Customer.Find(id);
            if (reg_Customer == null)
            {
                return HttpNotFound();
            }
            return View(reg_Customer);
        }

        // POST: Reg_Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reg_Customer reg_Customer = db.Reg_Customer.Find(id);
            db.Reg_Customer.Remove(reg_Customer);
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
