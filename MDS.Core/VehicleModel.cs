using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MDS.Core
{
   public partial class VehicleModel
    {
        public int VehicleModelId { get; set; }
        
        public int VehicleId { get; set; }

        [StringLength(100)]
        public string VehicleModelName { get; set; }

        public virtual Vehicle Vehicle { get; set; }
    }
}
