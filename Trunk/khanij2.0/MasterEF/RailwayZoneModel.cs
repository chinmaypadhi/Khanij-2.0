using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class RailwayZoneModel
    {
        public int? RailwayZoneID { get; set; } 
        public string RailwayZoneName { get; set; }
         
        public int? VillageID { get; set; }
        public string VillageName { get; set; }

         
        public int? TehsilID { get; set; }
        public string TehsilName { get; set; }

         
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
 
        public int? RegionalID { get; set; }
        public string RegionalName { get; set; }

 
        public int? StateID { get; set; }
        public string StateName { get; set; }

        public string ActiveStatus { get; set; }
        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public string Status { get; set; }
        public int CreatedBy { get; set; }
    }
}
