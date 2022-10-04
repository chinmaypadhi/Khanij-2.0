using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PermitEF
{
   public class UpdateDSCPath
    {
        public string fileName { get; set; }
        public int? ID { get; set; }
        public string UpdateIn { get; set; }
        public int? UserId { get; set; }
        public string MonthYear { get; set; }
    }
}
