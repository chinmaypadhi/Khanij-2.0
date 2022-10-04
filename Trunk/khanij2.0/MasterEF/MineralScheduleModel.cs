using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
    public class MineralScheduleModel
    {
        public int? MineralScheduleID { get; set; } 
        public string MineralScheduleName { get; set; } 

        public int? MineralTypeId { get; set; }
        public string MineralTypeName { get; set; }

        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }

        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? UserLoginId { get; set; }

        public string Status { get; set; }
    }
}
