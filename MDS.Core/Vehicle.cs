namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehicle")]
    public partial class Vehicle
    {
        public int VehicleId { get; set; }

        [StringLength(100)]
        public string VehicleCompany { get; set; }

        public virtual ICollection<VehicleModel> VehicleModels{ get; set; }
    }
}
