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
    public class FavouritesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Favourites
        public ActionResult Index()
        {
            DestFavViewModel model = new DestFavViewModel();
            List<Destination> destinations = new List<Destination>();
            String username = User.Identity.Name;
            List<Favourites> favs = db.Favourites.Where(m => m.userEmail.Equals(username)).ToList();
            foreach(Favourites f in favs)
            {
                destinations.Add(db.Destinations.Single(m=>m.id==f.Destination));
            }
            model.destinations = destinations;
            model.Favourites = new Favourites();
            return View(model);
        }

        // GET: Favourites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourites favourites = db.Favourites.Find(id);
            if (favourites == null)
            {
                return HttpNotFound();
            }
            return View(favourites);
        }

        // GET: Favourites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favourites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Destination")] Favourites favourites)
        {
            if (ModelState.IsValid)
            {
                favourites.userEmail = User.Identity.Name;
                db.Favourites.Add(favourites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favourites);
        }

        // GET: Favourites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourites favourites = db.Favourites.Find(id);
            if (favourites == null)
            {
                return HttpNotFound();
            }
            return View(favourites);
        }

        // POST: Favourites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Destination,userEmail")] Favourites favourites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favourites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favourites);
        }

        // GET: Favourites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Favourites favourites = db.Favourites.Find(id);
            if (favourites == null)
            {
                return HttpNotFound();
            }
            return View(favourites);
        }

        // POST: Favourites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Favourites favourites = db.Favourites.Find(id);
            db.Favourites.Remove(favourites);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Remove([Bind(Include = "Destination")] Favourites favourites)
        {
            if(ModelState.IsValid)
            {
            string username = User.Identity.Name;
            Favourites fav = db.Favourites.Where(m => m.Destination == favourites.Destination).Where(m => m.userEmail.Equals(username)).FirstOrDefault();
            db.Favourites.Remove(fav);
                db.SaveChanges();
            return RedirectToAction("Index");  }
            return View();

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
