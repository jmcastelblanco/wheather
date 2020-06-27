using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WeatherA.Models;
using WeatherA.Class;
using System.Data.Entity;

namespace WeatherA.Controllers
{
    public class UsersController : Controller
    {
        private WeatherAContext db = new WeatherAContext();

        // GET: Users
        public ActionResult Index()
        {

            var users = db.Users;
            return View(users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            var users = db.Users;
            ViewBag.RolID = new SelectList(CombosHelper.GetRoles(), "RolID", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                var respuesta = DbHelper.Save(db);
                if (respuesta.Succeeded)
                {
                    //UsuariosHelper.CreateUserAsp(user.UserName, user.Rol.Name);
                    if (user.PhotoFile != null)
                    {
                        var folder = "~/Content/photos";
                        var fileName = string.Format("user{0}.jpg", user.UserName);

                        if (FilesHelper.UploadImage(user.PhotoFile, folder,
                            fileName))
                        {
                            var pic = string.Format("{0}/{1}", folder, fileName);
                            user.Photo = pic;
                            db.Entry(user).State = EntityState.Modified;
                            respuesta = DbHelper.Save(db);
                            if (respuesta.Succeeded == false)
                            {
                                ModelState.AddModelError(string.Empty, respuesta.Message);
                                ViewBag.RolID = new SelectList(CombosHelper.GetRoles(), "RolID", "Name", user.RolID);

                                return View(user);
                            }
                        }
                    }
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError(string.Empty, respuesta.Message);
            }
            ViewBag.RolID = new SelectList(CombosHelper.GetRoles(), "RolID", "Name", user.RolID);
            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
             ViewBag.RolID = new SelectList(CombosHelper.GetRoles(), "RolID", "Name", user.RolID);
            return View(user);
        }

        // POST: Users/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RolID = new SelectList(CombosHelper.GetRoles(), "RolID", "Name", user.RolID);
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
            