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
            IdType = plants.IdType;
            IdCare = plants.IdCare;
            IdWatering = plants.IdWatering;
            IdLighting = plants.IdLighting;
            IdSpraying = plants.IdSpraying;
            IdView = plants.IdView;
            Link = plants.Link;
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int IdType { get; set; }
        public int IdCare { get; set; }
        public int IdWatering { get; set; }
        public int IdLighting { get; set; }
        public int IdSpraying { get; set; }
        public int IdView { get; set; }
        public string Link { get; set; }
    }
}