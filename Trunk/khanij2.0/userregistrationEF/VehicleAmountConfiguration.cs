using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class VehicleAmountConfiguration
    {
        public int? Id { get; set; }
        public decimal? VehicleAmount { get; set; }
        public int? ExpiryPeriod { get; set; }
        public int? UserId { get; set; }
    }
}
