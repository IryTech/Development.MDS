namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VendorImage")]
    public partial class VendorImage
    {
        public int VendorImageId { get; set; }

        public string ImageName { get; set; }

        public string ImageLocation { get; set; }

        public int? VendorCompanyId { get; set; }

        public int? VendorCourseId { get; set; }

        public int? VendorId { get; set; }

        public int? CustomerId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Vendor Vendor { get; set; }

        public virtual VendorCompany VendorCompany { get; set; }

        public virtual VendorCourse VendorCourse { get; set; }
    }
}
