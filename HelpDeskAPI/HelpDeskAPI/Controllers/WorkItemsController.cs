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
using HelpDeskAPI.Models;

namespace HelpDeskAPI.Controllers
{
    public class WorkItemsController : ApiController
    {
        private HelpDeskSystemEntities1 db = new HelpDeskSystemEntities1();

        // GET: api/WorkItems
        public IQueryable<object> GetWorkItems()
        {
            return db.WorkItems;
        }

        // GET: api/WorkItems/5
        [ResponseType(typeof(WorkItems))]
        public IHttpActionResult GetWorkItems(int id)
        {
            WorkItems workItems = db.WorkItems.Find(id);
            if (workItems == null)
            {
                return NotFound();
            }

            return Ok(workItems);
        }

        // PUT: api/WorkItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWorkItems(int id, WorkItems workItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != workItems.ID)
            {
                return BadRequest();
            }

            db.Entry(workItems).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WorkItemsExists(id))
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

        // POST: api/WorkItems
        [ResponseType(typeof(WorkItems))]
        public IHttpActionResult PostWorkItems(WorkItems workItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WorkItems.Add(workItems);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = workItems.ID }, workItems);
        }

        // DELETE: api/WorkItems/5
        [ResponseType(typeof(WorkItems))]
        public IHttpActionResult DeleteWorkItems(int id)
        {
            WorkItems workItems = db.WorkItems.Find(id);
            if (workItems == null)
            {
                return NotFound();
            }

            db.WorkItems.Remove(workItems);
            db.SaveChanges();

            return Ok(workItems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WorkItemsExists(int id)
        {
            return db.WorkItems.Count(e => e.ID == id) > 0;
        }
    }
}