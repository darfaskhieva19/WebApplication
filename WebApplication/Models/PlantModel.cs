using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class PlantModel
    {
        public PlantModel(Plants plants)
        {
            Id = plants.Id;
            Title = plants.Title;
            Description = plants.Description;
            Photo = plants.Photo;
            Care = plants.PlantCare.Care;
            Watering = plants.WateringPlants.Watering;
            Lighting = plants.PlantLighting.Lighting;
            Spraying = plants.SprayingPlants.Spraying;
            Link = plants.Link;

        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public string Care { get; set; }
        public string Watering { get; set; }
        public string Lighting { get; set; }
        public string Spraying { get; set; }
        public string Link { get; set; }
    }
}