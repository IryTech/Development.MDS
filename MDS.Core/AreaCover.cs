namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AreaCover")]
    public partial class AreaCover
    {
        public int AreaCoverId { get; set; }

        public int VendorCompanyId { get; set; }

        [StringLength(100)]
        public string AreaName { get; set; }

        [StringLength(100)]
        public string PopularName { get; set; }

        [StringLength(100)]
        public string AreaTitle { get; set; }

        [StringLength(100)]
        public string AreaUrl { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual VendorCompany VendorCompany { get; set; }
    }
}
