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
    public class BancosController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/Bancos
        public IQueryable<Banco> GetBanco()
        {
            return db.Banco;
        }

        // GET: api/Bancos/5
        [ResponseType(typeof(Banco))]
        public IHttpActionResult GetBanco(int id)
        {
            Banco banco = db.Banco.Find(id);
            if (banco == null)
            {
                return NotFound();
            }

            return Ok(banco);
        }

        // PUT: api/Bancos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBanco(int id, Banco banco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != banco.idDatos)
            {
                return BadRequest();
            }

            db.Entry(banco).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BancoExists(id))
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

        // POST: api/Bancos
        [ResponseType(typeof(Banco))]
        public IHttpActionResult PostBanco(Banco banco)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Banco.Add(banco);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = banco.idDatos }, banco);
        }

        // DELETE: api/Bancos/5
        [ResponseType(typeof(Banco))]
        public IHttpActionResult DeleteBanco(int id)
        {
            Banco banco = db.Banco.Find(id);
            if (banco == null)
            {
                return NotFound();
            }

            db.Banco.Remove(banco);
            db.SaveChanges();

            return Ok(banco);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BancoExists(int id)
        {
            return db.Banco.Count(e => e.idDatos == id) > 0;
        }
    }
}