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
    public class PromocionesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Promociones
        public IQueryable<Promocion> GetPromocion()
        {
            return db.Promocion;
        }

        // GET: api/Promociones/5
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult GetPromocion(int id)
        {
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return NotFound();
            }

            return Ok(promocion);
        }

        // PUT: api/Promociones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPromocion(int id, Promocion promocion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != promocion.id_promocion)
            {
                return BadRequest();
            }

            db.Entry(promocion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PromocionExists(id))
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

        // POST: api/Promociones
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult PostPromocion(Promocion promocion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Promocion.Add(promocion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (PromocionExists(promocion.id_promocion))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = promocion.id_promocion }, promocion);
        }

        // DELETE: api/Promociones/5
        [ResponseType(typeof(Promocion))]
        public IHttpActionResult DeletePromocion(int id)
        {
            Promocion promocion = db.Promocion.Find(id);
            if (promocion == null)
            {
                return NotFound();
            }

            db.Promocion.Remove(promocion);
            db.SaveChanges();

            return Ok(promocion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PromocionExists(int id)
        {
            return db.Promocion.Count(e => e.id_promocion == id) > 0;
        }
    }
}