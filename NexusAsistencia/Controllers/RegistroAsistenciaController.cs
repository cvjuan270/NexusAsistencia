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

namespace NexusAsistencia.Controllers
{
    public class RegistroAsistenciaController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        #region scaffold

        // GET: RegistroAsistencia
        [Authorize]
        public ActionResult Index()
        {
            var fecha = DateTime.Now.Date;
            var asistencias = db.Asistencias.Where(c => c.Fecha == fecha && c.UserName == HttpContext.User.Identity.Name);

            asistencias.Include(a => a.anexo).Include(a => a.empresa);

            var lst = asistencias.ToList();
            if (lst.Count==0)
            {
                Asistencia ass = new Asistencia();
                lst.Add(ass);
            }

            return View(lst);
        }

        // GET: RegistroAsistencia/Details/5
        [Authorize]
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

        // GET: RegistroAsistencia/Create
        [Authorize]
        public ActionResult Create()
        {
            Asistencia ast = new Asistencia();
            ast.UserName = HttpContext.User.Identity.Name;
            ast.HorEnt = TimeSpan.Parse(DateTime.Now.ToShortTimeString());

            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri");
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc");
            return View(ast);
        }

        [Authorize]
        public ActionResult Refrigerio(int? id) 
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
            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }

        [HttpPost]
        public ActionResult Refrigerio([Bind(Include = "IdAsistencia,Breake")] Asistencia asistencia) 
        {
            Asistencia asis = db.Asistencias.Find(asistencia.IdAsistencia);
            if (asistencia.Breake == false)
            {
                asis.BreIni = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
                asis.Breake = true;
            }
            else
            {
                asis.BreFin = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            }

            if (ModelState.IsValid)
            {
                db.Entry(asis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asistencia);
        }

        [HttpGet]
        public ActionResult Salida(int? id) 
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
            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }
        [HttpPost]
        public ActionResult Salida([Bind(Include = "IdAsistencia")] Asistencia asistencia) 
        {
            Asistencia asis = db.Asistencias.Find(asistencia.IdAsistencia);
            asis.HorSal = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            if (ModelState.IsValid)
            {
                db.Entry(asis).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asistencia);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAsistencia,Ruc,IdAnexo,UserName,HorEnt,Breake,BreTie,BreIni,BreFin,HorSal")] Asistencia asistencia)
        {
            asistencia.HorEnt = TimeSpan.Parse(DateTime.Now.ToShortTimeString());
            asistencia.Fecha = DateTime.Now.Date;
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

        // GET: RegistroAsistencia/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.IdAnexo = new SelectList(db.Anexoes, "IdAnexo", "Descri", asistencia.IdAnexo);
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc", asistencia.Ruc);
            return View(asistencia);
        }

        // POST: RegistroAsistencia/Edit/5
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

        // GET: RegistroAsistencia/Delete/5
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

        // POST: RegistroAsistencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asistencia asistencia = db.Asistencias.Find(id);
            db.Asistencias.Remove(asistencia);
            db.SaveChanges();
            return RedirectToAction("Index");
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
            if (ane.IdAnexo != 0)
            {
                anexo = db.Anexoes.Find(ane.IdAnexo);

            }
            return Json(anexo, JsonRequestBehavior.AllowGet);
        }
        #endregion
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    #region Models
    public class lstAnexos
    {
        public int IdAnexo { get; set; }
        public string Nombre { get; set; }
    }

    public class Ruc { public string oruc { get; set; } }
    public class Ane { public int IdAnexo { get; set; } }

    public class LatLon
    {
        public string Lat { get; set; }
        public string Lon { get; set; }

    }
    #endregion
}
