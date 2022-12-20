using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ReminderModel
    {
        public ReminderModel(PlantReminder rem)
        {
            Id = rem.Id;
            ReminderMode = rem.ReminderMode;
            ReminderDate = rem.ReminderDate;
            ReminderTime = rem.ReminderTime;
            IdPlant = rem.IdPlant;
            Notes = rem.Notes;
        }

        public int Id { get; set; }
        public string ReminderMode { get; set; }
        public DateTime ReminderDate { get; set; }
        public TimeSpan ReminderTime { get; set; }
        public int IdPlant { get; set; }
        public string Notes { get; set; }
    }
}