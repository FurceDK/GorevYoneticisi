using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GorevYoneticisi.Models;
using GorevYoneticisi.Attributes;
using System.Diagnostics;

namespace GorevYoneticisi.Controllers
{
    public class GorevController : Controller
    {
        private GorevContext db = new GorevContext();

        [AllowAnonymous]
        public ActionResult Index(string durum, DateTime? startDate, DateTime? endDate)
        {
            var gorevler = from g in db.Gorevler
                           where !g.Arsivle
                           select g;

            if (!String.IsNullOrEmpty(durum))
            {
                var durumEnum = (Durum)Enum.Parse(typeof(Durum), durum);
                gorevler = gorevler.Where(g => g.Durum == durumEnum);
            }

            if (startDate.HasValue)
            {
                gorevler = gorevler.Where(g => g.DueDate >= startDate);
            }

            if (endDate.HasValue)
            {
                gorevler = gorevler.Where(g => g.DueDate <= endDate);
            }

            return View(gorevler.ToList());
        }



        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorevler.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        [CustomAuthorize("Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [CustomAuthorize("Admin")]
        public ActionResult Create(Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                db.Gorevler.Add(gorev);
                db.SaveChanges();

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Görev başarıyla eklendi." });
                }
                else
                {
                    return RedirectToAction("Index");                 
                }
            }

            if (Request.IsAjaxRequest())
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors });
            }
            else
            {
                return View(gorev);
            }
        }

        [CustomAuthorize("Admin", "Calisan")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorevler.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        [HttpPost]
        [CustomAuthorize("Admin", "Calisan")]
        public ActionResult Edit(Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gorev).State = EntityState.Modified;
                db.SaveChanges();

                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, message = "Görev başarıyla güncellendi." });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            if (Request.IsAjaxRequest())
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                return Json(new { success = false, errors });
            }
            else
            {
                return View(gorev);
            }
        }
        [CustomAuthorize("Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorevler.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gorev gorev = db.Gorevler.Find(id);
            db.Gorevler.Remove(gorev);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [CustomAuthorize("Admin")]
        public ActionResult Archive(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorevler.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }

            gorev.Arsivle = true;
            gorev.ArsivlenmeTarihi = DateTime.Now;
            db.Entry(gorev).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        [AllowAnonymous]
        public ActionResult Arsiv()
        {
            var arsivlenmisGorevler = db.Gorevler.Where(g => g.Arsivle).ToList();
            return View(arsivlenmisGorevler);
        }
        [CustomAuthorize("Admin")]
        public ActionResult ArsivdenSil(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorevler.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }

            db.Gorevler.Remove(gorev);
            db.SaveChanges();

            return RedirectToAction("Arsiv");
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
