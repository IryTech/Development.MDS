namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleType
    {
        [Key]
        public int VehicleTypesId { get; set; }

        public int VendorCourseId { get; set; }

        [StringLength(50)]
        public string WhealsType { get; set; }

        [StringLength(100)]
        public string VehicleTypeTitle { get; set; }

        [StringLength(100)]
        public string VehicleTypeUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual VendorCourse VendorCourse { get; set; }
    }
}
