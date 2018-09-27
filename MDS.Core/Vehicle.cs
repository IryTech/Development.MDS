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

        public int VehicleTypesId { get; set; }

        [StringLength(100)]
        public string VehicleCompany { get; set; }

        [StringLength(50)]
        public string VehicleModel { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string YourUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual VehicleType VehicleType { get; set; }
    }
}
