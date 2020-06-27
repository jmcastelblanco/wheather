using WeatherA.Class;
using WeatherA.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WeatherA.Controllers
{
    public class GenericController : Controller
    {
        private WeatherAContext db = new WeatherAContext();
        // GET: Generic
        public JsonResult GetUser(string id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var user = db.Users.Where(c => c.DocumentNumber == id);
            if (user.Count()<1)
            {
                var errorModel = new { error = "Error" };
                return new JsonHttpStatusResult(errorModel, HttpStatusCode.InternalServerError);
            }
            return Json(user);
        }


        public JsonResult guardarlog(string Photo, int UserID)
        {
            var item = db.Session_logs.Where(x => x.UserID == UserID).OrderByDescending(x => x.Session_logID).FirstOrDefault();
            var entrar = true;
            if (item != null)
            {
                if (item.Entry)
                {
                    entrar = false;
                }
            }
            var dia = DateTime.Now.DayOfWeek.ToString();
            CultureInfo ci = CultureInfo.InvariantCulture;
            var hora = DateTime.Now.ToString("hh:mm", ci);
            
            var session = new Session_log
            {
                UserID = UserID,
                Date = DateTime.Now,
                Entry = entrar,
                Commentaries = hora,
            };
            var folder = "~/Content/photos";
            var fileName = string.Format("user{0}{1}.jpg", session.UserID,session.Date.ToString("yyyyMMdd_hhmmss"));
           
            

            if (FilesHelper.UploadImagePath(Photo, folder,
                fileName))
            {
                
                var pic = string.Format("{0}/{1}", folder, fileName);
                session.Photo = pic;
                db.Session_logs.Add(session);
                var respuesta = DbHelper.Save(db);
                if (respuesta.Succeeded == false)
                {
                    ModelState.AddModelError(string.Empty, respuesta.Message);
                    return Json(session);
                }
            }
            db.Configuration.ProxyCreationEnabled = false;
            var user = db.Users.Where(c => c.UserID == UserID);
            if (user.Count() < 1)
            {
                var errorModel = new { error = "Error" };
                return new JsonHttpStatusResult(errorModel, HttpStatusCode.InternalServerError);
            }
            return Json(user);
        }

        public class JsonHttpStatusResult : JsonResult
        {
            private readonly HttpStatusCode _httpStatus;

            public JsonHttpStatusResult(object data, HttpStatusCode httpStatus)
            {
                Data = data;
                _httpStatus = httpStatus;
            }

            public override void ExecuteResult(ControllerContext context)
            {
                context.RequestContext.HttpContext.Response.StatusCode = (int)_httpStatus;
                base.ExecuteResult(context);
            }
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