using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FoodBankMelbourne_frez0003.Models;
using System.Text;

namespace FoodBankMelbourne_frez0003.Controllers
{
    public class RestaurantsController : Controller
    {
        private FoodBankMelbourne_Entities db = new FoodBankMelbourne_Entities();

        // GET: Restaurants
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(db.Restaurants.ToList());
        }

        [Authorize (Roles = "Administrator, Customer")]
        // GET: Restaurants/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // GET: Restaurants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Authorize(Roles = "Administrator")]

        public ActionResult Create([Bind(Include = "Id,R_Name,Descrip,RT_Service")] Restaurant restaurant)
        {
            StringBuilder sbDescription = new StringBuilder();
            sbDescription.Append(HttpUtility.HtmlEncode(restaurant.Descrip));

            sbDescription.Replace("&lt;b&gt;", "<b>");
            sbDescription.Replace("&lt;/b&gt;", "</b>");
            sbDescription.Replace("&lt;u&gt;", "<u>");
            sbDescription.Replace("&lt;/u&gt;", "</u>");

            restaurant.Descrip = sbDescription.ToString();



            StringBuilder sbRName = new StringBuilder();
            sbRName.Append(HttpUtility.HtmlEncode(restaurant.R_Name));

            sbRName.Replace("&lt;b&gt;", "<b>");
            sbRName.Replace("&lt;/b&gt;", "</b>");
            sbRName.Replace("&lt;u&gt;", "<u>");
            sbRName.Replace("&lt;/u&gt;", "</u>");

            restaurant.R_Name = sbDescription.ToString();

            StringBuilder sbRType = new StringBuilder();
            sbRType.Append(HttpUtility.HtmlEncode(restaurant.RT_Service));

            sbRType.Replace("&lt;b&gt;", "<b>");
            sbRType.Replace("&lt;/b&gt;", "</b>");
            sbRType.Replace("&lt;u&gt;", "<u>");
            sbRType.Replace("&lt;/u&gt;", "</u>");

            restaurant.RT_Service = sbDescription.ToString();


            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]

        public ActionResult Edit([Bind(Include = "Id,R_Name,Descrip,RT_Service")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurant restaurant = db.Restaurants.Find(id);
            if (restaurant == null)
            {
                return HttpNotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            db.Restaurants.Remove(restaurant);
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
