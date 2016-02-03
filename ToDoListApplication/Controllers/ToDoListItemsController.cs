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
using ToDoListApplication.Models;

namespace ToDoListApplication.Controllers
{
    public class ToDoListItemsController : ApiController
    {
        private ToDoListContext db = new ToDoListContext();

        // GET: api/ToDoListItems
        public IQueryable<ToDoListItems> GetToDoListItems()
        {
            return db.ToDoListItems;
        }

        // GET: api/ToDoListItems/5
        [ResponseType(typeof(ToDoListItems))]
        public IHttpActionResult GetToDoListItems(int id)
        {
            ToDoListItems toDoListItems = db.ToDoListItems.Find(id);
            if (toDoListItems == null)
            {
                return NotFound();
            }

            return Ok(toDoListItems);
        }

        // PUT: api/ToDoListItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutToDoListItems(int id, ToDoListItems toDoListItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDoListItems.Id)
            {
                return BadRequest();
            }

            db.Entry(toDoListItems).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoListItemsExists(id))
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

        // POST: api/ToDoListItems
        [ResponseType(typeof(ToDoListItems))]
        public IHttpActionResult PostToDoListItems(ToDoListItems toDoListItems)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ToDoListItems.Add(toDoListItems);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = toDoListItems.Id }, toDoListItems);
        }

        // DELETE: api/ToDoListItems/5
        [ResponseType(typeof(ToDoListItems))]
        public IHttpActionResult DeleteToDoListItems(int id)
        {
            ToDoListItems toDoListItems = db.ToDoListItems.Find(id);
            if (toDoListItems == null)
            {
                return NotFound();
            }

            db.ToDoListItems.Remove(toDoListItems);
            db.SaveChanges();

            return Ok(toDoListItems);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToDoListItemsExists(int id)
        {
            return db.ToDoListItems.Count(e => e.Id == id) > 0;
        }
    }
}