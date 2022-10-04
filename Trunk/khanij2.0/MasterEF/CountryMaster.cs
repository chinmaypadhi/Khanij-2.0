using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class CountryMaster
    {
        public int? CountryId { get; set; }
        public string CountryName { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public string Status { get; set; }
        public int? IsDelete { get; set; }
        public int? UserLoginId { get; set; }
    }
}
