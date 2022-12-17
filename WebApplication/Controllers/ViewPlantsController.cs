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
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ViewPlantsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/ViewPlants
        [ResponseType(typeof(List<ViewModel>))]
        public IHttpActionResult GetViewPlants()
        {
            return Ok(db.ViewPlants.ToList().ConvertAll(x => new ViewModel(x)));
        }

        // GET: api/ViewPlants/5
        [ResponseType(typeof(ViewPlants))]
        public IHttpActionResult GetViewPlants(int id)
        {
            ViewPlants viewPlants = db.ViewPlants.Find(id);
            if (viewPlants == null)
            {
                return NotFound();
            }

            return Ok(viewPlants);
        }

        // PUT: api/ViewPlants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViewPlants(int id, ViewPlants viewPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viewPlants.Id)
            {
                return BadRequest();
            }

            db.Entry(viewPlants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViewPlantsExists(id))
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

        // POST: api/ViewPlants
        [ResponseType(typeof(ViewPlants))]
        public IHttpActionResult PostViewPlants(ViewPlants viewPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViewPlants.Add(viewPlants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viewPlants.Id }, viewPlants);
        }

        // DELETE: api/ViewPlants/5
        [ResponseType(typeof(ViewPlants))]
        public IHttpActionResult DeleteViewPlants(int id)
        {
            ViewPlants viewPlants = db.ViewPlants.Find(id);
            if (viewPlants == null)
            {
                return NotFound();
            }

            db.ViewPlants.Remove(viewPlants);
            db.SaveChanges();

            return Ok(viewPlants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViewPlantsExists(int id)
        {
            return db.ViewPlants.Count(e => e.Id == id) > 0;
        }
    }
}