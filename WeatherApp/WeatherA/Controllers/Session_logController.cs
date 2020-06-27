using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherA.Models;

namespace WeatherA.Controllers
{
    public class Session_logController : Controller
    {
        private WeatherAContext db = new WeatherAContext();

        // GET: Session_log
        public ActionResult Index()
        {
            var session_log = db.Session_logs.Include(s => s.User);
            return View(session_log.ToList());
        }

        // GET: Session_log/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_log session_log = db.Session_logs.Find(id);
            if (session_log == null)
            {
                return HttpNotFound();
            }
            return View(session_log);
        }

        // GET: Session_log/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "DocumentNumber");
            return View();
        }

        // POST: Session_log/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Session_log session_log)
        {
            if (ModelState.IsValid)
            {
                db.Session_logs.Add(session_log);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "DocumentNumber", session_log.UserID);
            return View(session_log);
        }

        // GET: Session_log/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_log session_log = db.Session_logs.Find(id);
            if (session_log == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "DocumentNumber", session_log.UserID);
            return View(session_log);
        }

        // POST: Session_log/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Session_logID,UserID,Fecha,Photo")] Session_log session_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session_log).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "DocumentNumber", session_log.UserID);
            return View(session_log);
        }

        // GET: Session_log/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session_log session_log = db.Session_logs.Find(id);
            if (session_log == null)
            {
                return HttpNotFound();
            }
            return View(session_log);
        }

        // POST: Session_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session_log session_log = db.Session_logs.Find(id);
            db.Session_logs.Remove(session_log);
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
