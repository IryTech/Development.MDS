namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SubscriptionType")]
    public partial class SubscriptionType
    {
        public int SubscriptionTypeId { get; set; }

        [StringLength(50)]
        public string SubTitle { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int VendorId { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
