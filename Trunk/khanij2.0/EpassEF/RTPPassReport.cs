using System;
using System.Collections.Generic;
using System.Text;

namespace EpassEF
{
    public class RTPPassReport
    {
        public int? RTPPassId { get; set; }
        public string RTPPassNo { get; set; }
        public string FarwdingBulkPermit { get; set; }
        public string ForwardingNo { get; set; }
        public string BulkPermitNo { get; set; }
        public string SchemeofCoal { get; set; }
        public string DistrictName { get; set; }
        public string NameOfConsiger { get; set; }
        public string AddressOfConsiger { get; set; }

        public string GrantOrderNo { get; set; }
        public string GrantOrderDate { get; set; }
        public string IssueDateTime { get; set; }

        public string MineralName { get; set; }
        public string MineralGrade { get; set; }
        public string QtyUnit { get; set; }
        public string NameofRailway { get; set; }
        public string RailwayZoneName { get; set; }
        public string AddressofRailway { get; set; }

        public string TrainNo { get; set; }
        public string RackNo { get; set; }

        public string NameofEndUser { get; set; }
        public string AddressofEndUser { get; set; }
        public string ForwardDate { get; set; }
        public string ForwardingNote { get; set; }

        public string DestinationRailwayName { get; set; }
        public string DestinationRailwayAddress { get; set; }

        public string EDRMNumber { get; set; }
        public string EDRMDate { get; set; }
        public string EDRMQty { get; set; }

        public DateTime SystemDateTime { get; set; }
        public string RePrintCount { get; set; }


        public int Userid { get; set; }
        public int Passid { get; set; }

    }
}
