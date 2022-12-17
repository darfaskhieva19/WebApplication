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
    public class PlantCaresController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/PlantCares
        [ResponseType(typeof(List<CareModel>))]
        public IHttpActionResult GetPlantCare()
        {
            return Ok(db.PlantCare.ToList().ConvertAll(x => new CareModel(x)));
        }

        // GET: api/PlantCares/5
        [ResponseType(typeof(PlantCare))]
        public IHttpActionResult GetPlantCare(int id)
        {
            PlantCare plantCare = db.PlantCare.Find(id);
            if (plantCare == null)
            {
                return NotFound();
            }

            return Ok(plantCare);
        }

        // PUT: api/PlantCares/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantCare(int id, PlantCare plantCare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantCare.Id)
            {
                return BadRequest();
            }

            db.Entry(plantCare).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantCareExists(id))
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

        // POST: api/PlantCares
        [ResponseType(typeof(PlantCare))]
        public IHttpActionResult PostPlantCare(PlantCare plantCare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlantCare.Add(plantCare);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plantCare.Id }, plantCare);
        }

        // DELETE: api/PlantCares/5
        [ResponseType(typeof(PlantCare))]
        public IHttpActionResult DeletePlantCare(int id)
        {
            PlantCare plantCare = db.PlantCare.Find(id);
            if (plantCare == null)
            {
                return NotFound();
            }

            db.PlantCare.Remove(plantCare);
            db.SaveChanges();

            return Ok(plantCare);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantCareExists(int id)
        {
            return db.PlantCare.Count(e => e.Id == id) > 0;
        }
    }
}