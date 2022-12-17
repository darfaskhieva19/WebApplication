using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class SprayingModel
    {
        public SprayingModel(SprayingPlants spraying)
        {
            Id = spraying.Id;
            Spraying = spraying.Spraying;
        }

        public int Id { get; set; }
        public string Spraying { get; set; }
    }
}