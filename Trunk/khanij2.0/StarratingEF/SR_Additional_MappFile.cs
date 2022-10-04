// ***********************************************************************
//  Class Name               : SR_Additional_MappFile
//  Desciption               : Add other file of Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class SR_Additional_MappFile
    {
        public int FileMasterID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public List<IFormFile> file1 { get; set; }
        public int OtherID { get; set; }
        public string OtherName { get; set; }
        public int AssesmentID { get; set; }
        public int FileMappID { get; set; }
        public String FileUploadValidation { get; set; }
        public string Action { get; set; }
    }
}
