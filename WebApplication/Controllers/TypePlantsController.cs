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
    public class TypePlantsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/TypePlants
        [ResponseType(typeof(List<TypeModel>))]
        public IHttpActionResult GetTypePlants()
        {
            return Ok(db.TypePlants.ToList().ConvertAll(x => new TypeModel(x)));
        }

        // GET: api/TypePlants/5
        [ResponseType(typeof(TypePlants))]
        public IHttpActionResult GetTypePlants(int id)
        {
            TypePlants typePlants = db.TypePlants.Find(id);
            if (typePlants == null)
            {
                return NotFound();
            }

            return Ok(typePlants);
        }

        // PUT: api/TypePlants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTypePlants(int id, TypePlants typePlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != typePlants.Id)
            {
                return BadRequest();
            }

            db.Entry(typePlants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypePlantsExists(id))
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

        // POST: api/TypePlants
        [ResponseType(typeof(TypePlants))]
        public IHttpActionResult PostTypePlants(TypePlants typePlants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TypePlants.Add(typePlants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = typePlants.Id }, typePlants);
        }

        // DELETE: api/TypePlants/5
        [ResponseType(typeof(TypePlants))]
        public IHttpActionResult DeleteTypePlants(int id)
        {
            TypePlants typePlants = db.TypePlants.Find(id);
            if (typePlants == null)
            {
                return NotFound();
            }

            db.TypePlants.Remove(typePlants);
            db.SaveChanges();

            return Ok(typePlants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TypePlantsExists(int id)
        {
            return db.TypePlants.Count(e => e.Id == id) > 0;
        }
    }
}