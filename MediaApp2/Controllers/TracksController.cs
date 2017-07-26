using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MediaApp2.Models;

namespace MediaApp2.Controllers
{
    public class TracksController : Controller
    {
        private MediaApp2Context db = new MediaApp2Context();

        // GET: Tracks
        public ActionResult Index()
        {
            var tracks = db.Tracks.Include(t => t.Albums);
            return View(tracks.ToList());
        }

        // GET: Tracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // GET: Tracks/Create
        public ActionResult Create()
        {
            ViewBag.AlbumsID = new SelectList(db.Albums, "ID", "AlbumName");
            return View();
        }

        // POST: Tracks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TrackNum,TrackName,AlbumsID")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Tracks.Add(tracks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumsID = new SelectList(db.Albums, "ID", "AlbumName", tracks.AlbumsID);
            return View(tracks);
        }

        // GET: Tracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumsID = new SelectList(db.Albums, "ID", "AlbumName", tracks.AlbumsID);
            return View(tracks);
        }

        // POST: Tracks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrackNum,TrackName,AlbumsID")] Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tracks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumsID = new SelectList(db.Albums, "ID", "AlbumName", tracks.AlbumsID);
            return View(tracks);
        }

        // GET: Tracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tracks tracks = db.Tracks.Find(id);
            if (tracks == null)
            {
                return HttpNotFound();
            }
            return View(tracks);
        }

        // POST: Tracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tracks tracks = db.Tracks.Find(id);
            db.Tracks.Remove(tracks);
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
