using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class MineralSizeMaster
    {
        public int? MineralSizeId { get; set; }
        public string MineralSize { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public string Status { get; set; }
    }
}
