using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoMiniTienda.DAL;
using ProyectoMiniTienda.Models;

namespace ProyectoMiniTienda.Controllers
{
    public class CompraVentasController : Controller
    {
        private AppDBContext db = new AppDBContext();

        // GET: CompraVentas
        public ActionResult Index()
        {
            double ingresos, gastos, neto;
            ingresos = db.compraventa.Where(m => m.EsCompra == true).Select(p => p.valor).Sum();
            gastos = db.compraventa.Where(m => m.EsCompra == false).Select(p => p.valor).Sum();
            neto = ingresos - gastos;
            ViewBag.ingresos = ingresos;
            ViewBag.gastos = gastos;
            ViewBag.neto = neto;
            return View(db.compraventa.ToList());
        }

        // GET: CompraVentas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.compraventa.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            return View(compraVenta);
        }

        // GET: CompraVentas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompraVentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descripcion,EsCompra,valor,Cantidad,Fecha")] CompraVenta compraVenta)
        {
            if (ModelState.IsValid)
            {
                db.compraventa.Add(compraVenta);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compraVenta);
        }

        // GET: CompraVentas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.compraventa.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            return View(compraVenta);
        }

        // POST: CompraVentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descripcion,EsCompra,valor,Cantidad,Fecha")] CompraVenta compraVenta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compraVenta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compraVenta);
        }

        // GET: CompraVentas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompraVenta compraVenta = db.compraventa.Find(id);
            if (compraVenta == null)
            {
                return HttpNotFound();
            }
            return View(compraVenta);
        }

        // POST: CompraVentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompraVenta compraVenta = db.compraventa.Find(id);
            db.compraventa.Remove(compraVenta);
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
