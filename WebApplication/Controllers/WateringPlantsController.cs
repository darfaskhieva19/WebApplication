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
    public class WateringPlantsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/WateringPlants
        [ResponseType(typeof(List<WateringModel>))]
        public IHttpActionResult GetWateringPlants()
        {
            return Ok(db.WateringPlants.ToList().ConvertAll(x => new WateringModel(x)));
        }

        // GET: api/WateringPlants/5
        [ResponseType(typeof(WateringPlants))]
        public IHttpActionResult GetWateringPlants(int id)
        {
            WateringPlants wateringPlants = db.WateringPlants.Find(id);
            if (wateringPlants == null)
            {
                return NotFound();
            }

            return Ok(wateringPlants);
        }

        // PUT: api/WateringPlants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWateringPlants(int id, WateringPlants wateringPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wateringPlants.Id)
            {
                return BadRequest();
            }

            db.Entry(wateringPlants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WateringPlantsExists(id))
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

        // POST: api/WateringPlants
        [ResponseType(typeof(WateringPlants))]
        public IHttpActionResult PostWateringPlants(WateringPlants wateringPlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.WateringPlants.Add(wateringPlants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = wateringPlants.Id }, wateringPlants);
        }

        // DELETE: api/WateringPlants/5
        [ResponseType(typeof(WateringPlants))]
        public IHttpActionResult DeleteWateringPlants(int id)
        {
            WateringPlants wateringPlants = db.WateringPlants.Find(id);
            if (wateringPlants == null)
            {
                return NotFound();
            }

            db.WateringPlants.Remove(wateringPlants);
            db.SaveChanges();

            return Ok(wateringPlants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WateringPlantsExists(int id)
        {
            return db.WateringPlants.Count(e => e.Id == id) > 0;
        }
    }
}