using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BillManager.Models;

namespace BillManager.Controllers
{
    public class BillModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BillModels
        public ActionResult Index()
        {
            return View(db.Bills.ToList());
        }

        // GET: BillModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillModel billModel = db.Bills.Find(id);
            if (billModel == null)
            {
                return HttpNotFound();
            }
            return View(billModel);
        }

        // GET: BillModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BillModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BillId,BillName,BillCompany,BillPrice,BillDueDate,BillStatus")] BillModel billModel)
        {
            if (ModelState.IsValid)
            {
                db.Bills.Add(billModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(billModel);
        }

        // GET: BillModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillModel billModel = db.Bills.Find(id);
            if (billModel == null)
            {
                return HttpNotFound();
            }
            return View(billModel);
        }

        // POST: BillModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BillId,BillName,BillCompany,BillPrice,BillDueDate,BillStatus")] BillModel billModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(billModel);
        }

        // GET: BillModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BillModel billModel = db.Bills.Find(id);
            if (billModel == null)
            {
                return HttpNotFound();
            }
            return View(billModel);
        }

        // POST: BillModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BillModel billModel = db.Bills.Find(id);
            db.Bills.Remove(billModel);
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
