using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using API.Models;

namespace API.Controllers
{
    public class ReporteVentasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/ReporteVentas
        public IQueryable<ReporteVenta> GetReporteVenta()
        {
            return db.ReporteVenta;
        }

        // GET: api/ReporteVentas/5
        [ResponseType(typeof(ReporteVenta))]
        public IHttpActionResult GetReporteVenta(string id)
        {
            ReporteVenta reporteVenta = db.ReporteVenta.Find(id);
            if (reporteVenta == null)
            {
                return NotFound();
            }

            return Ok(reporteVenta);
        }

        // PUT: api/ReporteVentas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutReporteVenta(string id, ReporteVenta reporteVenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reporteVenta.id_producto)
            {
                return BadRequest();
            }

            db.Entry(reporteVenta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReporteVentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ReporteVentas
        [ResponseType(typeof(ReporteVenta))]
        public IHttpActionResult PostReporteVenta(ReporteVenta reporteVenta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReporteVenta.Add(reporteVenta);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ReporteVentaExists(reporteVenta.id_producto))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = reporteVenta.id_producto }, reporteVenta);
        }

        // DELETE: api/ReporteVentas/5
        [ResponseType(typeof(ReporteVenta))]
        public IHttpActionResult DeleteReporteVenta(string id)
        {
            ReporteVenta reporteVenta = db.ReporteVenta.Find(id);
            if (reporteVenta == null)
            {
                return NotFound();
            }

            db.ReporteVenta.Remove(reporteVenta);
            db.SaveChanges();

            return Ok(reporteVenta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReporteVentaExists(string id)
        {
            return db.ReporteVenta.Count(e => e.id_producto == id) > 0;
        }
    }
}