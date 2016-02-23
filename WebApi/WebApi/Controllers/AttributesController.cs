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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AttributesController : ApiController
    {
        private TestBaseEntities db = new TestBaseEntities();

        // GET api/Attributes
        public IQueryable<Attributes> GetAttributes()
        {
            return db.Attributes;
        }

        // GET api/Attributes/5
        [ResponseType(typeof(Attributes))]
        public IHttpActionResult GetAttributes(int id)
        {
            Attributes attributes = db.Attributes.Find(id);
            if (attributes == null)
            {
                return NotFound();
            }

            return Ok(attributes);
        }

        // PUT api/Attributes/5
        public IHttpActionResult PutAttributes(string id, Attributes attributes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != attributes.id)
            {
                return BadRequest();
            }

            db.Entry(attributes).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AttributesExists(id))
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

        // POST api/Attributes
        [ResponseType(typeof(Attributes))]
        public IHttpActionResult PostAttributes(Attributes attributes)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Attributes.Add(attributes);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = attributes.id }, attributes);
        }

        // DELETE api/Attributes/5
        [ResponseType(typeof(Attributes))]
        public IHttpActionResult DeleteAttributes(int id)
        {
            Attributes attributes = db.Attributes.Find(id);
            if (attributes == null)
            {
                return NotFound();
            }

            db.Attributes.Remove(attributes);
            db.SaveChanges();

            return Ok(attributes);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AttributesExists(string id)
        {
            return db.Attributes.Count(e => e.id == id) > 0;
        }
    }
}