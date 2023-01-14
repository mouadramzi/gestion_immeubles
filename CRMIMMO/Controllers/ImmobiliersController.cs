using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRMIMMO.Models;

namespace CRMIMMO.Controllers
{
    public class ImmobiliersController : Controller
    {
        private CRMContext22 db = new CRMContext22();

        // GET: Immobiliers
        public ActionResult Index()
        {
            return View(db.Immobiliers.ToList());
        }
        public ActionResult searchimmo(string type, string local, string Description)
        {
            var search = from d in db.Immobiliers
                         where d.typeImmobilierr == type
                         || d.localimmobilier == local
                         || d.description == Description
                         select d;

            return View("searchimmo", search.ToList());

        }

        // GET: Immobiliers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immobilier immobilier = db.Immobiliers.Find(id);
            if (immobilier == null)
            {
                return HttpNotFound();
            }
            return View(immobilier);
        }

        // GET: Immobiliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Immobiliers/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ImmobilierId,typeImmobilierr,localimmobilier,surfaceimmobilier,prix,description")] Immobilier immobilier)
        {
            if (ModelState.IsValid)
            {
                db.Immobiliers.Add(immobilier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(immobilier);
        }

        // GET: Immobiliers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immobilier immobilier = db.Immobiliers.Find(id);
            if (immobilier == null)
            {
                return HttpNotFound();
            }
            return View(immobilier);
        }

        // POST: Immobiliers/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ImmobilierId,typeImmobilierr,localimmobilier,surfaceimmobilier,prix,description")] Immobilier immobilier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(immobilier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(immobilier);
        }

        // GET: Immobiliers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Immobilier immobilier = db.Immobiliers.Find(id);
            if (immobilier == null)
            {
                return HttpNotFound();
            }
            return View(immobilier);
        }

        // POST: Immobiliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Immobilier immobilier = db.Immobiliers.Find(id);
            db.Immobiliers.Remove(immobilier);
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
