namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorCourse")]
    public partial class VendorCourse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorCourse()
        {
            VendorImages = new HashSet<VendorImage>();
        }

        public int VendorCourseId { get; set; }

        public int? VendorCompanyId { get; set; }

        [StringLength(50)]
        public string CourseTitle { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [StringLength(25)]
        public string Duration { get; set; }

        public decimal? VendorPrice { get; set; }

        public int? Vehicle { get; set; }

        public int? VehicleModel { get; set; }

        [StringLength(100)]
        public string VehicleTitle { get; set; }

        [StringLength(100)]
        public string VehicleUrl { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string CourseUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual VendorCompany VendorCompany { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorImage> VendorImages { get; set; }
    }
}
