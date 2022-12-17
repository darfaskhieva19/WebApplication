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
    public class PlantLightingsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/PlantLightings
        [ResponseType(typeof(List<LighttingModel>))]
        public IHttpActionResult GetPlantLighting()
        {
            return Ok(db.PlantLighting.ToList().ConvertAll(x => new LighttingModel(x)));
        }

        // GET: api/PlantLightings/5
        [ResponseType(typeof(PlantLighting))]
        public IHttpActionResult GetPlantLighting(int id)
        {
            PlantLighting plantLighting = db.PlantLighting.Find(id);
            if (plantLighting == null)
            {
                return NotFound();
            }

            return Ok(plantLighting);
        }

        // PUT: api/PlantLightings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantLighting(int id, PlantLighting plantLighting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantLighting.Id)
            {
                return BadRequest();
            }

            db.Entry(plantLighting).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantLightingExists(id))
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

        // POST: api/PlantLightings
        [ResponseType(typeof(PlantLighting))]
        public IHttpActionResult PostPlantLighting(PlantLighting plantLighting)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlantLighting.Add(plantLighting);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plantLighting.Id }, plantLighting);
        }

        // DELETE: api/PlantLightings/5
        [ResponseType(typeof(PlantLighting))]
        public IHttpActionResult DeletePlantLighting(int id)
        {
            PlantLighting plantLighting = db.PlantLighting.Find(id);
            if (plantLighting == null)
            {
                return NotFound();
            }

            db.PlantLighting.Remove(plantLighting);
            db.SaveChanges();

            return Ok(plantLighting);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantLightingExists(int id)
        {
            return db.PlantLighting.Count(e => e.Id == id) > 0;
        }
    }
}