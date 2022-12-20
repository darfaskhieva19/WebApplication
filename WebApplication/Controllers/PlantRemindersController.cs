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
    public class PlantRemindersController : ApiController
    {
        private PlantsEntities db = new PlantsEntities();

        // GET: api/PlantReminders
        [ResponseType(typeof(List<ReminderModel>))]
        public IHttpActionResult GetPlantReminder()
        {
            return Ok(db.PlantReminder.ToList().ConvertAll(x => new ReminderModel(x)));
        }

        // GET: api/PlantReminders/5
        [ResponseType(typeof(PlantReminder))]
        public IHttpActionResult GetPlantReminder(int id)
        {
            PlantReminder plantReminder = db.PlantReminder.Find(id);
            if (plantReminder == null)
            {
                return NotFound();
            }

            return Ok(plantReminder);
        }

        // PUT: api/PlantReminders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlantReminder(int id, PlantReminder plantReminder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plantReminder.Id)
            {
                return BadRequest();
            }

            db.Entry(plantReminder).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantReminderExists(id))
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

        // POST: api/PlantReminders
        [ResponseType(typeof(PlantReminder))]
        public IHttpActionResult PostPlantReminder(PlantReminder plantReminder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlantReminder.Add(plantReminder);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = plantReminder.Id }, plantReminder);
        }

        // DELETE: api/PlantReminders/5
        [ResponseType(typeof(PlantReminder))]
        public IHttpActionResult DeletePlantReminder(int id)
        {
            PlantReminder plantReminder = db.PlantReminder.Find(id);
            if (plantReminder == null)
            {
                return NotFound();
            }

            db.PlantReminder.Remove(plantReminder);
            db.SaveChanges();

            return Ok(plantReminder);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlantReminderExists(int id)
        {
            return db.PlantReminder.Count(e => e.Id == id) > 0;
        }
    }
}