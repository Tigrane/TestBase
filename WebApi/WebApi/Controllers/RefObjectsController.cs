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
    public class RefObjectsController : ApiController
    {
        //private TestBaseEntities db = new TestBaseEntities();
        public TestBaseEntities db = new TestBaseEntities();

        // GET api/RefObjects
        public IQueryable<RefObjects> GetRefObjects()
        {
            return db.RefObjects;
        }

        // GET api/RefObjects/5
        [ResponseType(typeof(RefObjects))]
        public IHttpActionResult GetRefObjects(int id)
        {
            RefObjects refobjects = db.RefObjects.Find(id);
            if (refobjects == null)
            {
                return NotFound();
            }

            return Ok(refobjects);
        }

        // PUT api/RefObjects/5
        public IHttpActionResult PutRefObjects(string id, RefObjects refobjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != refobjects.id)
            {
                return BadRequest();
            }

            db.Entry(refobjects).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RefObjectsExists(id))
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

        // POST api/RefObjects
        [ResponseType(typeof(RefObjects))]
        public IHttpActionResult PostRefObjects(RefObjects refobjects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RefObjects.Add(refobjects);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = refobjects.id }, refobjects);
        }

        // DELETE api/RefObjects/5
        [ResponseType(typeof(RefObjects))]
        public IHttpActionResult DeleteRefObjects(string id)
        {
            RefObjects refobjects = db.RefObjects.Find(id);
            if (refobjects == null)
            {
                return NotFound();
            }

            db.RefObjects.Remove(refobjects);
            db.SaveChanges();

            return Ok(refobjects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RefObjectsExists(string id)
        {
            return db.RefObjects.Count(e => e.id == id) > 0;
        }
    }
}