using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class MainMenuMaster
    {
        public int? MmenuID { get; set; }
        public string MainMenuName { get; set; }
        public int? ModuleId { get; set; }
        public string icon { get; set; }
        public string LinkPath { get; set; }
        public int? Slno { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
        public int? IsDelete { get; set; }
        public int? UserLoginId { get; set; }
        public string Status { get; set; }
        public string ModuleName { get; set; }
        public string SvgPath { get; set; }
        public string divclass { get; set; }
    }
}
