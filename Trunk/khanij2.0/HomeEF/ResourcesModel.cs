using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class EditResourcesModel
    {
        public int? ID { get; set; }
        [Required(ErrorMessage = "Please Enter Totalcoal in India")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Totalcoal in India")]
        public int? Totalcoal_India { get; set; }
        [Required(ErrorMessage = "Please Enter Iron Ore in India")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Iron Ore in India")]
        public int? TotalIronore_India { get; set; }
        [Required(ErrorMessage = "Please Enter Limestone in India")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Limestone in India")]
        public int? TotalLimestone_India { get; set; }
        [Required(ErrorMessage = "Please Enter Bauxite in India")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Bauxite in India")]
        public int? TotalBauxite_India { get; set; }
        [Required(ErrorMessage = "Please Enter Coal in Chattisgarh")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Coal in Chattisgarh")]
        public int? Totalcoal_Chattisgarh { get; set; }
        [Required(ErrorMessage = "Please Enter Iron Ore in Chattisgarh")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Iron Ore in Chattisgarh")]
        public int? TotalIronore_Chattisgarh { get; set; }
        [Required(ErrorMessage = "Please Enter Limestone in Chattisgarh")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Limestone in Chattisgarh")]
        public int? TotalLimestone_Chattisgarh { get; set; }
        [Required(ErrorMessage = "Please Enter Bauxite in Chattisgarh")]
        [Range(1, int.MaxValue, ErrorMessage = "Please Enter Bauxite in Chattisgarh")]
        public int? TotalBauxite_Chattisgarh { get; set; }
        public int? Updated_By { get; set; }
    }
    public class ViewResourcesModel
    {
        public int? ID { get; set; }
        public int? Totalcoal_India { get; set; }
        public int? TotalIronore_India { get; set; }
        public int? TotalLimestone_India { get; set; }
        public int? TotalBauxite_India { get; set; }
        public int? Totalcoal_Chattisgarh { get; set; }
        public int? TotalIronore_Chattisgarh { get; set; }
        public int? TotalLimestone_Chattisgarh { get; set; }
        public int? TotalBauxite_Chattisgarh { get; set; }
        public int? Updated_By { get; set; }
    }
}
