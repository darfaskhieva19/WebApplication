//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PlantReminder
    {
        public int Id { get; set; }
        public string ReminderMode { get; set; }
        public System.DateTime ReminderDate { get; set; }
        public System.TimeSpan ReminderTime { get; set; }
        public int IdPlant { get; set; }
        public string Notes { get; set; }
    
        public virtual Plants Plants { get; set; }
    }
}