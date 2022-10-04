// ***********************************************************************
//  Class Name               : LogEntry
//  Desciption               : LogEntry of Starrating Assessment
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace StarratingEF
{
    public class LogEntry
    {        
        public string Controller     { get; set; }
        public string Action         { get; set; }
        public string ReturnType     { get; set; }
        public string ErrorMessage   { get; set; }
        public string StackTrace     { get; set; }
        public string CreatedDate    { get; set; }
        public string UserLoginID    { get; set; }
        public string UserID         { get; set; }
    }
}
