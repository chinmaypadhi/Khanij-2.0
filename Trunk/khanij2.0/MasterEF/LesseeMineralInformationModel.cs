// ***********************************************************************
//  Class Name               : LesseeMineralInformationModel
//  Description              : Lessee Mineral Information Model Details class
//  Created By               : Lingaraj Dalai
//  Created On               : 04 August 2021
// ***********************************************************************
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace MasterEF
{
    public class LesseeMineralInformationModel
    {
        public int LESSEE_MINERAL_INFORMATION_ID { get; set; }
        public int? MINERAL_CATEGORY_ID { get; set; }
        public string MINERAL_CATEGORY_NAME { get; set; }
        public string MineralID { get; set; }
        public string MineralName { get; set; }
        public int? MINERAL_GRADE_ID { get; set; }
        public string MINERAL_GRADE_NAME { get; set; }
        public string MineralFormName { get; set; }
        public List<int> MineralFormCount { get; set; }
        public class MineralFormAssignment
        {
            public int? Value { get; set; }
        }
        public string MineralGradeName { get; set; }
        public List<int> MineralGradeCount { get; set; }
        public class MineralGradeAssignment
        {
            public int? Value { get; set; }
        }
        public string ESTIMATED_RESERVE { get; set; }
        public string MINABLE_RESERVE { get; set; }
        public string COPY_OF_MP_SOM_ESTIMATION_FILE_NAME { get; set; }
        public string COPY_OF_MP_SOM_ESTIMATION_FILE_PATH { get; set; }
        public int? STATUS { get; set; }
        public int? CREATED_BY { get; set; }
        public string Remarks { get; set; }
        public IFormFile FILE { get; set; }
        public string SubResion { get; set; }
        public string SubApprove { get; set; }
        public string SubReject { get; set; }
        public List<int?> MineralCount { get; set; }
        public class MineralAssignment
        {
            public int? Value { get; set; }
        }   
        public int? UserLoginId { get; set; }
        public string MineralNatureId { get; set; }
        public string MineralNature { get; set; }
        public string MineralGradeId { get; set; }
        public string MineralGrade { get; set; }
        public string MineralIdList { get; set; }
        public string MineralFormIdList { get; set; }
        public string MineralGradeIdList { get; set; }   
        public string ModifyDate { get; set; }
        public string ModifyYear { get; set; }
    }
}
