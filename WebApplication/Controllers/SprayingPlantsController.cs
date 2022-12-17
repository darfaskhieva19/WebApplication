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
    public class SprayingPlantsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/SprayingPlants
        [ResponseType(typeof(List<SprayingModel>))]
        public IHttpActionResult GetSprayingPlants()
        {
            return Ok(db.SprayingPlants.ToList().ConvertAll(x => new SprayingModel(x)));
        }

        // GET: api/SprayingPlants/5
        [ResponseType(typeof(SprayingPlants))]
        public IHttpActionResult GetSprayingPlants(int id)
        {
            SprayingPlants sprayingPlants = db.SprayingPlants.Find(id);
            if (sprayingPlants == null)
            {
                return NotFound();
            }

            return Ok(sprayingPlants);
        }

        // PUT: api/SprayingPlants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSprayingPlants(int id, SprayingPlants sprayingPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sprayingPlants.Id)
            {
                return BadRequest();
            }

            db.Entry(sprayingPlants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SprayingPlantsExists(id))
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

        // POST: api/SprayingPlants
        [ResponseType(typeof(SprayingPlants))]
        public IHttpActionResult PostSprayingPlants(SprayingPlants sprayingPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SprayingPlants.Add(sprayingPlants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sprayingPlants.Id }, sprayingPlants);
        }

        // DELETE: api/SprayingPlants/5
        [ResponseType(typeof(SprayingPlants))]
        public IHttpActionResult DeleteSprayingPlants(int id)
        {
            SprayingPlants sprayingPlants = db.SprayingPlants.Find(id);
            if (sprayingPlants == null)
            {
                return NotFound();
            }

            db.SprayingPlants.Remove(sprayingPlants);
            db.SaveChanges();

            return Ok(sprayingPlants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SprayingPlantsExists(int id)
        {
            return db.SprayingPlants.Count(e => e.Id == id) > 0;
        }
    }
}