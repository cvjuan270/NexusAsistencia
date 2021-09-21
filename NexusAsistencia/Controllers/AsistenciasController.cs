using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IdentitySample.Models;
using NexusAsistencia.Models;
using NexusAsistencia.Models.ViewModels;

namespace NexusAsistencia.Controllers
{
    public class AsistenciasController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        #region SCAFFOLD

        // GET: Asistencias
        public ActionResult Index()
        {
            var asistencias = db.Asistencias.Include(a => a.anexo).Include(a => a.empresa);
            return View(asistencias.ToList());
        }

        // GET: Asistencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // GET: Asistencias/Create
        public ActionResult Create()
        {
            var asistencia = new Asistencia();


            var lstAnexo = new List<SelectListItem>();
            lstAnexo.Add(new SelectListItem() { Text = "Seleccione", Value = "0" });
            ViewBag.IdAnexo = new SelectList(lstAnexo,"Value","Text");
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc");
            return View(asistencia);
        }

        // POST: Asistencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsistencia,Ruc,IdAnexo,UserName,HorEnt")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Asistencias.Add(asistencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }

        // GET: Asistencias/Edit/5
        public ActionResult Edit(int? id)
        {
            bool MarcarBreake = true;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }

            //if (asistencia.BreIni==null)
            //{
            //    ViewBag.MarcarBreake = MarcarBreake;
            //    asistencia.BreIni = DateTime.Now;
            //    asistencia.BreFin = null;
            //}
            //else
            //{
            //    if (asistencia.BreFin==null)
            //    {
            //        ViewBag.MarcarBreake = MarcarBreake;
            //        asistencia.BreFin = DateTime.Now;
            //    }
            //}
            //if (asistencia.BreFin!=null&&asistencia.BreIni!=null)
            //{
            //    MarcarBreake = false;
            //    ViewBag.MarcarBreake = MarcarBreake;
            //    asistencia.HorSal = DateTime.Now;
            //}

            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }

        // POST: Asistencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAsistencia,Ruc,IdAnexo,UserName,HorEnt,Breake,BreTie,BreIni,BreFin,HorSal")] Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asistencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }

        // GET: Asistencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asistencia asistencia = db.Asistencias.Find(id);
            if (asistencia == null)
            {
                return HttpNotFound();
            }
            return View(asistencia);
        }

        // POST: Asistencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            db.Asistencias.Remove(asistencia);
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
        #endregion

        #region Breake

        public ActionResult Breake(int id) 
        {
            BreakeVM breakeVM = new BreakeVM();

            return View(breakeVM);
        }
        #endregion

        #region AJAX

        [HttpPost]
        public ActionResult GetAnexos(Ruc ruc)
        {
            List<lstAnexos> lsta = new List<lstAnexos>();

            var lst = (from an in db.Anexoes
                       where an.Ruc == ruc.oruc
                       select new { an.IdAnexo, an.Descri }).ToList();

            foreach (var item in lst)
            {
                lstAnexos ane = new lstAnexos();
                ane.IdAnexo = item.IdAnexo;
                ane.Nombre = item.Descri;
                lsta.Add(ane);
            }

            return Json(lst, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult getAnexo(Ane ane) 
        {
            Anexo anexo = new Anexo();
            if (ane.IdAnexo!=0)
            {
               anexo = db.Anexoes.Find(ane.IdAnexo);
                
            }
            return  Json(anexo, JsonRequestBehavior.AllowGet);
        }

        public ActionResult RegEntrada() 
        {
            return RedirectToAction("Index");
        }

        #endregion

        #region Models
        public class lstAnexos 
        {
            public int IdAnexo { get; set; }
            public string Nombre { get; set; }
        }

        public class Ruc { public string oruc { get; set; }}
        public class Ane { public int IdAnexo { get; set; } }

        public class LatLon 
        {
            public string Lat { get; set; }
            public string Lon { get; set; }

        }
        #endregion
    }
}
