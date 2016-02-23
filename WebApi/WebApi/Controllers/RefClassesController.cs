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
    public class RefClassesController : ApiController
    {
        private TestBaseEntities db = new TestBaseEntities();

        // GET api/RefClasses
        public IQueryable<RefClasses> GetRefClasses()
        {
            return db.RefClasses;
        }

        // GET api/RefClasses/5
        [ResponseType(typeof(RefClasses))]
        public IHttpActionResult GetRefClasses(int id)
        {
            RefClasses refclasses = db.RefClasses.Find(id);
            if (refclasses == null)
            {
                return NotFound();
            }

            return Ok(refclasses);
        }

        // PUT api/RefClasses/5
        public IHttpActionResult PutRefClasses(string id, RefClasses refclasses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != refclasses.id)
            {
                return BadRequest();
            }

            db.Entry(refclasses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefClassesExists(id))
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

        // POST api/RefClasses
        [ResponseType(typeof(RefClasses))]
        public IHttpActionResult PostRefClasses(RefClasses refclasses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RefClasses.Add(refclasses);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = refclasses.id }, refclasses);
        }

        // DELETE api/RefClasses/5
        [ResponseType(typeof(RefClasses))]
        public IHttpActionResult DeleteRefClasses(int id)
        {
            RefClasses refclasses = db.RefClasses.Find(id);
            if (refclasses == null)
            {
                return NotFound();
            }

            db.RefClasses.Remove(refclasses);
            db.SaveChanges();

            return Ok(refclasses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefClassesExists(string id)
        {
            return db.RefClasses.Count(e => e.id == id) > 0;
        }
    }
}