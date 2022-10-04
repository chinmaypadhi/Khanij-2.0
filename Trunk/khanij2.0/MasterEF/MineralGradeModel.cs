using System;
using System.Collections.Generic;
using System.Text;

namespace MasterEF
{
   public class MineralGradeModel
    {
        public int? MineralGradeId { get; set; }

       // [Required(ErrorMessage = "Select Mineral Category")]//Must be required field
       /// [Display(Name = "Mineral Type")]// Name of lable
        public int? MineralTypeId { get; set; }
        public string MineralTypeName { get; set; }
        public string MineralType { get; set; }
        //[Required(ErrorMessage = "Select Mineral Name")]//Must be required field
        // [Display(Name = "Mineral Name")]// Name of lable        
        public int? MineralId { get; set; }
        public string MineralName { get; set; }

        //[Required(ErrorMessage = "Select Mineral Form")]//Must be required field
        public int? MineralNatureId { get; set; }
        public string MineralNature { get; set; }


        //[Required(ErrorMessage = "Enter Mineral Grade")]//Must be required field
        //[Display(Name = "Mineral Grade")]// Name of lable
       // [StringLength(200, ErrorMessage = "Mineral Grade must be less than 200 characters")]// Maximum length 50
        public string MineralGrade { get; set; }

        public int? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public int? UserLoginId { get; set; }
        public string Status { get; set; }
        public int? CHK { get; set; }

        public string CalculationTypeId { get; set; }
        public string CalculationTypeName { get; set; }
    }
}
