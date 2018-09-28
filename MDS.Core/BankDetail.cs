namespace MDS.Core
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BankDetail
    {
        [Key]
        public int BankDetailsId { get; set; }

        public int VendorCompanyId { get; set; }

        [StringLength(30)]
        public string AccountHolderName { get; set; }

        [StringLength(20)]
        public string AccountNumber { get; set; }

        [StringLength(20)]
        public string ConfirmAccountNumber { get; set; }

        [StringLength(20)]
        public string IFSC { get; set; }

        [StringLength(30)]
        public string BankName { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(30)]
        public string City { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

        public virtual VendorCompany VendorCompany { get; set; }
    }
}
