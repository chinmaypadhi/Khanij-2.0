// ***********************************************************************
//  Class Name               : SR_FileMaster
//  Desciption               : Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 30 April 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;

namespace StarratingEF
{
    public class SR_FileMaster
    {
        public int FileMasterID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int Assessment_ID { get; set; }
        public string SPName { get; set; }
        public string mFile { get; set; }
        public string HasObtainOther { get; set; }
        public bool IsFileUpload { get; set; }
        public SR_Protection_Environment SR_PE { get; set; }
        public SR_Health_Saftey SR_HS { get; set; }
        public SR_Statutory_Compliance SR_SC { get; set; }
        public string Action { get; set; }
    }
}
