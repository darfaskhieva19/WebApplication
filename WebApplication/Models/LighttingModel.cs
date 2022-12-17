using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class LighttingModel
    {
        public LighttingModel(PlantLighting light)
        {
            Id = light.Id;
            Lighting = light.Lighting;
        }
        public int Id { get; set; }
        public string Lighting { get; set; }
    }
}