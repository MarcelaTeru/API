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
    public class BanquetesController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Banquetes
        public IQueryable<Banquete> GetBanquete()
        {
            return db.Banquete;
        }

        // GET: api/Banquetes/5
        [ResponseType(typeof(Banquete))]
        public IHttpActionResult GetBanquete(int id)
        {
            Banquete banquete = db.Banquete.Find(id);
            if (banquete == null)
            {
                return NotFound();
            }

            return Ok(banquete);
        }

        // PUT: api/Banquetes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBanquete(int id, Banquete banquete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banquete.idBanquete)
            {
                return BadRequest();
            }

            db.Entry(banquete).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BanqueteExists(id))
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

        // POST: api/Banquetes
        [ResponseType(typeof(Banquete))]
        public IHttpActionResult PostBanquete(Banquete banquete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Banquete.Add(banquete);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BanqueteExists(banquete.idBanquete))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = banquete.idBanquete }, banquete);
        }

        // DELETE: api/Banquetes/5
        [ResponseType(typeof(Banquete))]
        public IHttpActionResult DeleteBanquete(int id)
        {
            Banquete banquete = db.Banquete.Find(id);
            if (banquete == null)
            {
                return NotFound();
            }

            db.Banquete.Remove(banquete);
            db.SaveChanges();

            return Ok(banquete);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BanqueteExists(int id)
        {
            return db.Banquete.Count(e => e.idBanquete == id) > 0;
        }
    }
}