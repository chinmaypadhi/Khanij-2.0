// ***********************************************************************
//  Class Name               : LogEntry
//  Desciption               : Log entry Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************

namespace DashboardEF
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
