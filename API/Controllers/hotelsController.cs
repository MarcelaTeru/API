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
    public class hotelsController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/hotels
        public IQueryable<hotel> Gethotel()
        {
            return db.hotel;
        }

        // GET: api/hotels/5
        [ResponseType(typeof(hotel))]
        public IHttpActionResult Gethotel(int id)
        {
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            return Ok(hotel);
        }

        // PUT: api/hotels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Puthotel(int id, hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hotel.precio)
            {
                return BadRequest();
            }

            db.Entry(hotel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!hotelExists(id))
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

        // POST: api/hotels
        [ResponseType(typeof(hotel))]
        public IHttpActionResult Posthotel(hotel hotel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.hotel.Add(hotel);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (hotelExists(hotel.precio))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hotel.precio }, hotel);
        }

        // DELETE: api/hotels/5
        [ResponseType(typeof(hotel))]
        public IHttpActionResult Deletehotel(int id)
        {
            hotel hotel = db.hotel.Find(id);
            if (hotel == null)
            {
                return NotFound();
            }

            db.hotel.Remove(hotel);
            db.SaveChanges();

            return Ok(hotel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool hotelExists(int id)
        {
            return db.hotel.Count(e => e.precio == id) > 0;
        }
    }
}