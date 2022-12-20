using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class CareModel
    {
       public CareModel(PlantCare care)
       {
            Id = care.Id;
            Care = care.Care;
       }
        public int Id { get; set; }
        public string Care { get; set; }
    }
}