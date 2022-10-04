// ***********************************************************************
//  Class Name               : MineralMapModel
//  Desciption               : Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeEF
{
    public class ViewMineralMapModel
    {
        public int RegionalID { get; set; }
        public int DistrictID { get; set; }
        public string DistrictName { get; set; }
        public int LesseeTotal { get; set; }
        public int LesseeMajormineral { get; set; }
        public int LesseeMinormineral { get; set; }
        public int LicenseeTotal { get; set; }
        public int LicenseeMajorMineral { get; set; }
        public int LicenseeMinorMineral { get; set; }
    }
}
