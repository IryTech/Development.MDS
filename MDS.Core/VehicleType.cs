namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VehicleType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VehicleType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        [Key]
        public int VehicleTypesId { get; set; }

        public int VendorCourseId { get; set; }

        [StringLength(50)]
        public string WhealsType { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string YourUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vehicle> Vehicles { get; set; }

        public virtual VendorCourse VendorCourse { get; set; }
    }
}
