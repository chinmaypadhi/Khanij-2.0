using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class BreakdownRequestFromMobileApp
    {
        public int? TransitPassID { get; set; }
        public string TransitPassNo { get; set; }
        public int? New_VehicleId { get; set; }
        public string New_VehicleNo { get; set; }
        public string New_DriverName { get; set; }
        public string DriverMobileNo { get; set; }
        public string BreakdownReason { get; set; }
        public string BreakdownLocation { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public int? UserId { get; set; }
    }
}
