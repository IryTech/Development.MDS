namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorCompany")]
    public partial class VendorCompany
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VendorCompany()
        {
            AreaCovers = new HashSet<AreaCover>();
            BankDetails = new HashSet<BankDetail>();
            VendorCourses = new HashSet<VendorCourse>();
            VendorImages = new HashSet<VendorImage>();
        }

        public int VendorCompanyId { get; set; }

        public int? VendorId { get; set; }

        [StringLength(100)]
        public string BranchName { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        public int? State { get; set; }

        public int? City { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        public int? ZIPCode { get; set; }

        [StringLength(200)]
        public string AddressLine1 { get; set; }

        [StringLength(200)]
        public string AddressLine2 { get; set; }

        [StringLength(500)]
        public string ShortDescription { get; set; }

        public string LongDescription { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(100)]
        public string YourUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AreaCover> AreaCovers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BankDetail> BankDetails { get; set; }

        public virtual Vendor Vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorCourse> VendorCourses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VendorImage> VendorImages { get; set; }
    }
}
