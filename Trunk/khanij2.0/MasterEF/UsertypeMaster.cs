// ***********************************************************************
//  Class Name               : UsertypeMaster
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
namespace MasterEF
{
    public class UsertypeMaster
    {
        public int? UsertypeId { get; set; }
        public string Usertype { get; set; }
        public int? UserID { get; set; }
        public bool? IsActive { get; set; }
        public string ActiveStatus { get; set; }
    }
}
