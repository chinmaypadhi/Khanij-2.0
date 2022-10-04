using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpassEF
{
    public class ePassConfigurationEF
    {
        public int? MineralID { get; set; }
        public string TransportationMode { get; set; }
        public string TransportationModeId { get; set; }
        public int? AllowConsigneeTypeid { get; set; }
        public string AllowConsigneeType { get; set; }
        public string RouteFetch  { get; set; }
        public int? RouteFetchID { get; set; }
        public string TripClose { get; set; }
        public int? TripCloseID { get; set; }
        public string Time { get; set; }
        public int? id { get; set; }
        public int? DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int? UserTypeID { get; set; }
        public string UserType{ get; set; }
        public int? Userid { get; set; }
        public int? MineralTypeID { get; set; }
        public int? CreatedBy { get; set; }
        public string PassConfigType { get; set; }      
        public int? PassConfigTypeID { get; set; }
        public string MineralType { get; set; }
        public string MineralName { get; set; }
        public string UserName { get; set; }
        public string Status { get; set; }
        public string hdnmi { get; set; }
        public IList<IdentificationDoc> DocumentList { get; set; }  
    }
   public class IdentificationDoc
    {
        public int id { get; set; }
    }
   
}
