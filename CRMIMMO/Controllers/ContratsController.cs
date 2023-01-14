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
    public class ContratsController : Controller
    {
        private CRMContext22 db = new CRMContext22();

        // GET: Contrats
        public ActionResult Index()
        {
            var contrats = db.contrats.Include(c => c.Client);
            return View(contrats.ToList());
        }
        public ActionResult Searchcontrat(string ctt, string cin)
        {


            var searchcontrat = from d in db.contrats
                                where d.idcontrat == ctt
                                || d.ClientID == cin
                                select d;

            return View("Searchcontrat", searchcontrat.ToList());



        }
        // GET: Contrats/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // GET: Contrats/Create
        public ActionResult Create()
        {
            ViewBag.ClientID = new SelectList(db.clients, "ClientID", "cin");
            return View();
        }

        // POST: Contrats/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idcontrat,idImmobilier,clientcin,datecontrat,ClientID")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.contrats.Add(contrat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientID = new SelectList(db.clients, "ClientID", "cin", contrat.ClientID);
            return View(contrat);
        }

        // GET: Contrats/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientID = new SelectList(db.clients, "ClientID", "cin", contrat.ClientID);
            return View(contrat);
        }

        // POST: Contrats/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idcontrat,idImmobilier,clientcin,datecontrat,ClientID")] Contrat contrat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientID = new SelectList(db.clients, "ClientID", "cin", contrat.ClientID);
            return View(contrat);
        }

        // GET: Contrats/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrat contrat = db.contrats.Find(id);
            if (contrat == null)
            {
                return HttpNotFound();
            }
            return View(contrat);
        }

        // POST: Contrats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Contrat contrat = db.contrats.Find(id);
            db.contrats.Remove(contrat);
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
