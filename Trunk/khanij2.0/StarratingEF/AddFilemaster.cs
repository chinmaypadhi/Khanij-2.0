// ***********************************************************************
//  Class Name               : AddFilemaster
//  Desciption               : Add Other File Assessment of Lessee 
//  Created By               : Lingaraj Dalai
//  Created On               : 19 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace StarratingEF
{
    public class AddFilemaster
    {
        public int? FileMasterID { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string OtherName { get; set; }
        public int AssesmentID { get; set; }
        public int FileMappID { get; set; }
    }
    public class UploadDocument : AddFilemaster
    {
        public List<IFormFile> file { get; set; }
    }
}
