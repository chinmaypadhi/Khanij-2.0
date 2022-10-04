using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class EditProductionModel
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Please Select Financial Year")]
        public string FinancialYear { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Mineral Category")]
        public int? MineralCategoryID { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please Select Mineral")]
        public int? MineralID { get; set; }
        public string Mineral { get; set; }
        [Required(ErrorMessage = "Enter Production Value")]
        public int? Production { get; set; }
        [Required(ErrorMessage = "Enter Despatch Value")]
        public int? Despatch { get; set; }
        public int? Updated_By { get; set; }
    }
    public class ViewProductionModel
    {
        public int? ID { get; set; }
        public string FinancialYear { get; set; }
        public string Mineral { get; set; }
        public int? Production { get; set; }
        public int? Despatch { get; set; }
        public int? Updated_By { get; set; }
    }
}
