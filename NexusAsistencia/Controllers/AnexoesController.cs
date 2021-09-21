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
    public class AnexoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Anexoes
        public ActionResult Index()
        {
            return View(db.Anexoes.ToList());
        }

        // GET: Anexoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anexo anexo = db.Anexoes.Find(id);
            if (anexo == null)
            {
                return HttpNotFound();
            }
            return View(anexo);
        }

        // GET: Anexoes/Create
        public ActionResult Create()
        {
            ViewBag.Ruc = new SelectList(db.Empresas, "Ruc", "RazSoc");
            return View();
        }

        // POST: Anexoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAnexo,Descri,DirAne,Latitu,Longit,Nota,Ruc,RanMet")] Anexo anexo)
        {
            anexo.Descri.ToUpper();
            if (ModelState.IsValid)
            {
                db.Anexoes.Add(anexo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anexo);
        }

        // GET: Anexoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Anexo anexo = db.Anexoes.Find(id);

            if (anexo == null)
            {
                return HttpNotFound();
            }
            ViewBag.Empresa = db.Empresas.Find(anexo.Ruc).RazSoc;
            return View(anexo);
        }

        // POST: Anexoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAnexo,Descri,DirAne,Latitu,Longit,Nota,Ruc,RanMet")] Anexo anexo)
        {
            anexo.Descri.ToUpper();
            if (ModelState.IsValid)
            {
                db.Entry(anexo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anexo);
        }

        // GET: Anexoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anexo anexo = db.Anexoes.Find(id);
            if (anexo == null)
            {
                return HttpNotFound();
            }
            return View(anexo);
        }

        // POST: Anexoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Anexo anexo = db.Anexoes.Find(id);
            db.Anexoes.Remove(anexo);
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
