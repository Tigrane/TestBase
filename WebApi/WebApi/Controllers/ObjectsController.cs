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
    public class ObjectsController : ApiController
    {
        //private TestBaseEntities db = new TestBaseEntities();
        public TestBaseEntities db = new TestBaseEntities();

        // GET api/Objects
        public IQueryable<Objects> GetObjects()
        {
            return db.Objects;
        }

        // GET api/Objects/5
        [ResponseType(typeof(Objects))]
        public IHttpActionResult GetObjects(int id)
        {
            Objects objects = db.Objects.Find(id);
            if (objects == null)
            {
                return NotFound();
            }

            return Ok(objects);
        }

        // GET api/Objects/5
        [ResponseType(typeof(Objects))]
        public Objects GetObjectsFull(int id)
        {
            Objects objects = db.Objects.Find(id);
            if (objects != null)
            {
                objects.RefObjects = db.RefObjects.Where(x => int.Equals(x.idObjects, id)).ToList();
            }

            return objects;
        }

        // PUT api/Objects/5
        public IHttpActionResult PutObjects(string id, Objects objects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != objects.id)
            {
                return BadRequest();
            }

            db.Entry(objects).State = EntityState.Modified;

            //SetDue(ref objects);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObjectsExists(id))
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

        private void SetDue(ref Objects objects)
        {
            if (db.Objects.ToList().Count > 0)
            {
                if (!string.IsNullOrEmpty(objects.idParent))
                {
                    string val = objects.idParent;
                    string curDue = db.Objects.FirstOrDefault(x => x.id == val).due;
                    objects.due = string.Format("{0}{1}.", curDue, objects.id);
                }
                else
                {
                    objects.due = string.Format("{0}.", objects.id);
                }
            }
            else
            {
                objects.due = string.Format("{0}.", objects.id);
            }
        }

        // POST api/Objects
        [ResponseType(typeof(Objects))]
        public IHttpActionResult PostObjects(Objects objects)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(objects.due))
            {
                SetDue(ref objects);
            }

            //int maxId;
            ////формируем due код для быстрого поиска в дереве
            //if (db.Objects.Count() > 0)
            //{
            //    maxId = db.Objects.Max(x => x.id) + 1;
            //}
            //else
            //{
            //    maxId = 1;
            //}


            //if (db.Objects.ToList().Count > 0)
            //{
            //    if (objects.idParent.HasValue)
            //    {
            //        string curDue = db.Objects.FirstOrDefault(x => x.id == objects.idParent).due;
            //        objects.due = string.Format("{0}{1}.", curDue, maxId);
            //    }
            //    else
            //    {
            //        objects.due = string.Format("{0}.", maxId);
            //    }
            //}
            //else
            //{
            //    objects.due = string.Format("{0}.", maxId);
            //}

            db.Objects.Add(objects);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = objects.id }, objects);
        }

        // DELETE api/Objects/5
        [ResponseType(typeof(Objects))]
        public IHttpActionResult DeleteObjects(string id)
        {
            Objects objects = db.Objects.Find(id);
            if (objects == null)
            {
                return NotFound();
            }

            db.SaveChanges();

            db.Objects.Remove(objects);
            db.SaveChanges();

            return Ok(objects);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ObjectsExists(string id)
        {
            return db.Objects.Count(e => e.id == id) > 0;
        }
    }
}