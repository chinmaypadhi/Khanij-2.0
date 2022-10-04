using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class CommonAddressDetails
    {
        public int? StateID { get; set; }
        public string StateName { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? BlockId { get; set; }
        public string BlockName { get; set; }
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }
        public int? VillageID { get; set; }
        public string VillageName { get; set; }
    }
}
