using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
  public  class MineralNatureModel
    {
        public int? MineralNatureId { get; set; }
         
        public int? MineralTypeId { get; set; }
         
        public int? MineralId { get; set; }

        public string MineralName { get; set; }
        public string MineralTypeName { get; set; }
        public string MineralType { get; set; }


        public string MineralNature { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
    }
}
