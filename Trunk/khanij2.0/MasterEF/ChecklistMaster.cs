// ***********************************************************************
//  Class Name               : ChecklistMaster
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************

namespace MasterEF
{
    public class ChecklistMaster
    {
        public int? ChecklistId { get; set; }
        public string CheckListDescription { get; set; }
        public int? ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public string ActiveStatus { get; set; }
    }
}
