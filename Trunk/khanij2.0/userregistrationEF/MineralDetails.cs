using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace userregistrationEF
{
    public class MineralDetails
    {
        public int? MineralTypeId { get; set; }
        public int? MineralID { get; set; }
        public string MineralName { get; set; }
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public int? MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
    }
}
