using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class EditRevenueModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please Select Financial Year")]
        public string FinancialYear { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Mineral Category")]
        public int? MineralCategoryID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Mineral")]
        public int? MineralID { get; set; }
        [Required(ErrorMessage = "Please Select Mineral")]
        public string MineralName { get; set; }
        [Required(ErrorMessage = "Please enter DMF")]
        public int? DMF { get; set; }
        [Required(ErrorMessage = "Please enter NMET")]
        public int? NMET { get; set; }
        [Required(ErrorMessage = "Please enter Royalty")]
        public int? Royalty { get; set; }
        public int? Updated_By { get; set; }
    }
    public class ViewRevenueModel
    {
        public int? ID { get; set; }
        public string FinancialYear { get; set; }
        public string MineralName { get; set; }
        public int? DMF { get; set; }
        public int? NMET { get; set; }
        public int? Royalty { get; set; }
    }
}
