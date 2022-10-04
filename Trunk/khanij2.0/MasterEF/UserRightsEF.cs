using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class UserRightsEF
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public int RoleTypeId { get; set; }
        public string RoleTypeName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Total { get; set; }
        public int IsActive { get; set; }
        
        public int UserTypeId { get; set; }
        public string UserType { get; set; }
        public string Check { get; set; }

    }
    public class AcessUserTypeEF
    {
        public string UserTypeid { get; set; }
        public List<string> Menuid { get; set; }
    }
    public class AcessUserIdEf
    {
        public string Userid { get; set; }
        public string UserTypeid { get; set; }
        public string Roleid { get; set; }
        public List<string> Menuid { get; set; }
    }
    public  class UserRoleMenuAssignment
    {
        public int UserRoleMenuAssignmentId { get; set; }
        public int MenuId { get; set; }
        
        public Nullable<bool> IsAdd { get; set; }
        public Nullable<bool> IsEdit { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<bool> IsView { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }

        
    }

    public class TreeMenu
    {
        public int userid{get;set;}
        public int DisplaySrNo { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public int Operation { get; set; }

    }

    public class Bindfild
    {
       public string CheckSatus { get; set; }
        public string Paramiterid { get; set; }
       public string Text { get; set; }
        public string Value { get; set; }
    }

    public class userRights
    {

        public int UserID { get; set; }
        public string Check { get; set; }
        public int UserTypeId { get; set; }
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public int ParentId { get; set; }
        public string CanCreate { get; set; }
        public string CanDelete { get; set; }
        public string CanView { get; set; }
        public string CanEdit { get; set; }
    }

}
