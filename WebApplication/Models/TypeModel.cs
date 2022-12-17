using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class TypeModel
    {
        public TypeModel(TypePlants type)
        {
            Id = type.Id;
            Type = type.Type;
        }

        public int Id { get; }
        public string Type { get; }
    }
}