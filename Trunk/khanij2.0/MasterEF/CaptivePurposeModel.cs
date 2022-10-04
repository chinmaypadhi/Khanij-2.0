// ***********************************************************************
//  Model Name               : CaptivePurposeModel
//  Desciption               : Captive purpose Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 April 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class CaptivePurposeModel
    {
        public CaptivePurposeModel()
        {
            State_Id = 0;
            StateName = "";
            District_Id = 0;
            DisrictName = "";
            UserType_Id = 0;
            UserType = "";
            CaptiveUser_Id = 0;
            CaptiveUserName = "";
            CREATED_BY = 0;
            IsLeasePurpose = "";
        }
        public int State_Id { get; set; }
        public string StateName { get; set; }
        public int District_Id { get; set; }
        public string DisrictName { get; set; }
        public int UserType_Id { get; set; }
        public string UserType { get; set; }
        public int CaptiveUser_Id { get; set; }
        public string CaptiveUserName { get; set; }
        public int? CREATED_BY { get; set; }
        public string IsLeasePurpose { get; set; } 
    }
}
