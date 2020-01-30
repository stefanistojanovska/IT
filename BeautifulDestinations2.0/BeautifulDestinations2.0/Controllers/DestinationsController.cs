using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BeautifulDestinations2._0.Models;

namespace BeautifulDestinations2._0.Controllers
{
    public class DestinationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Destinations
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            List<Favourites> favs = db.Favourites.Where(m => m.userEmail.Equals(username)).ToList();
            ViewBag.favs = favs;
            DestFavViewModel df = new DestFavViewModel();
            df.destinations = db.Destinations.ToList();
            df.Favourites = new Favourites();
            return View(df);
        }

        // GET: Destinations/Details/5
        public ActionResult Details(int? id)
        {
            long[] indexes=new long[db.Destinations.Count()];
            int counter = 0;
            List<Destination> destinations = db.Destinations.ToList();
            foreach(Destination d in destinations)
            {
                indexes[counter] = d.id;
                counter++;

            }
            Review review = new Review();
            DestRevViewModel dr = new DestRevViewModel();
            ViewBag.Ids = indexes;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            List<Review> revs = db.Reviews.Where(r => r.Destination==id).ToList();
            dr.destination = destination;
            dr.review = review;
            dr.reviews = revs;
            return View(dr);
        }
        [Authorize(Roles = "Admin")]
        // GET: Destinations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Name,Description,ImgUrl")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Destinations.Add(destination);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destination);
        }
        [Authorize(Roles = "Admin")]
        // GET: Destinations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }
        [Authorize(Roles = "Admin")]
        // POST: Destinations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name,Description,ImgUrl")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destination).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destination);
        }

        // GET: Destinations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Destination destination = db.Destinations.Find(id);
            if (destination == null)
            {
                return HttpNotFound();
            }
            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Destination destination = db.Destinations.Find(id);
            db.Destinations.Remove(destination);
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
