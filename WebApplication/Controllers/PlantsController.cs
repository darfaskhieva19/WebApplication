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
    public class PlantsController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        [Route("api/Plants/Filter")]
        [HttpGet]
        [ResponseType(typeof(List<PlantModel>))]
        public IHttpActionResult FilterPlants(string sort, string care, string spraying, string watering, string lighting)
        {
            List<Plants> list = db.Plants.ToList();
            if(sort!="по умолчанию")
            {
                if(sort=="по возрастанию")
                {
                    list = list.OrderBy(z => z.Title).ToList();
                }
                else
                {
                    list = list.OrderByDescending(z => z.Title).ToList();
                }
            }
            if(care!="Весь уход")
            {
                list = list.Where(z => z.PlantCare.Care == care).ToList();
            }
            if(spraying!="Все опрыскивание")
            {
                list = list.Where(z => z.SprayingPlants.Spraying == spraying).ToList();
            }
            if(watering!="Весь полив")
            {
                list = list.Where(z => z.WateringPlants.Watering == watering).ToList();
            }
            if(lighting!="Все освещение")
            {
                list = list.Where(z => z.PlantLighting.Lighting == lighting).ToList();
            }
            return Ok(list.ConvertAll(z => new PlantModel(z)));
        }


        // GET: api/Plants
        [ResponseType(typeof(List<PlantModel>))]
        public IHttpActionResult GetPlants()
        {
            return Ok(db.Plants.ToList().ConvertAll(x => new PlantModel(x)));
        }

        // GET: api/Plants/5
        [ResponseType(typeof(Plants))]
        public IHttpActionResult GetPlants(int id)
        {
            Plants plants = db.Plants.Find(id);
            if (plants == null)
            {
                return NotFound();
            }

            return Ok(plants);
        }

        // PUT: api/Plants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlants(int id, Plants plants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plants.Id)
            {
                return BadRequest();
            }

            db.Entry(plants).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantsExists(id))
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

        // POST: api/Plants
        [ResponseType(typeof(Plants))]
        public IHttpActionResult PostPlants(Plants plants)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Plants.Add(plants);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plants.Id }, plants);
        }

        // DELETE: api/Plants/5
        [ResponseType(typeof(Plants))]
        public IHttpActionResult DeletePlants(int id)
        {
            Plants plants = db.Plants.Find(id);
            if (plants == null)
            {
                return NotFound();
            }

            db.Plants.Remove(plants);
            db.SaveChanges();

            return Ok(plants);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantsExists(int id)
        {
            return db.Plants.Count(e => e.Id == id) > 0;
        }
    }
}