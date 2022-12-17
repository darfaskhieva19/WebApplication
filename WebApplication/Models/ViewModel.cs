using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ViewModel
    {
        public ViewModel(ViewPlants view)
        {
            Id = view.Id;
            Views = view.Views;
        }

        public int Id { get; set; }
        public string Views { get; set; }
    }
}