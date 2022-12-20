using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class WateringModel
    {
        public WateringModel(WateringPlants water)
        {
            Id= water.Id;
            Watering = water.Watering;
        }

       public int Id { get; set; }
       public string Watering { get; set; }
    }
}