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
    
    public partial class Plants
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plants()
        {
            this.PlantReminder = new HashSet<PlantReminder>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int IdCare { get; set; }
        public int IdWatering { get; set; }
        public int IdLighting { get; set; }
        public int IdSpraying { get; set; }
        public string Link { get; set; }
    
        public virtual PlantCare PlantCare { get; set; }
        public virtual PlantLighting PlantLighting { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlantReminder> PlantReminder { get; set; }
        public virtual SprayingPlants SprayingPlants { get; set; }
        public virtual WateringPlants WateringPlants { get; set; }
    }
}
