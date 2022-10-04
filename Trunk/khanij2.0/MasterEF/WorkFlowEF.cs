using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterEF
{
    public class WorkFlowDropDown
    {

        public int? Check { get; set; }
        public string Text { get; set; }
        public string Value { get; set; }
        public int? Id { get; set; }
        public int? Id2 { get; set; }
        public int? Id3 { get; set; }


    }

    #region Activity
    public class ActivityEF
    {
        public int? Check { get; set; }
        public int ActivityId { get; set; }
        public int ModuleId { get; set; }
        public int SubModuleId { get; set; }
        public string ActivityName { get; set; }

        public string ActionIdList { get; set; }
        public List<int> ActionCount { get; set; }

        public int? ActionTobeTakenAt { get; set; }
        public int? ActionTobeTakenBy { get; set; }
        public bool RequiredNotification { get; set; }
        public int? NotificationType { get; set; }
        public int? Step { get; set; }
        public bool StatusId { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
    public class ActivityEFQuery
    {
      

        public int? Check { get; set; }
        public int ActivityId { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string ActivityName { get; set; }
        public string ActionName { get; set; }

        public string ActionTobeTakenAt { get; set; }
        public string ActionTobeTakenBy { get; set; }

        public string RequiredNotification { get; set; }
        public string NotificationType { get; set; }
        public int Step { get; set; }

    }
    #endregion

    #region WorkFlow
    public class WorkFlowEF
    {

        public int? Check { get; set; }
        public int? intWorkFlowId { get; set; }
        public int? intModuleId { get; set; }
        public int? intSubModuleId { get; set; }
        public int? intActivityId { get; set; }
        public bool bitActiveStatus { get; set; }
        public bool bitDeleted { get; set; }


        public int? intStep { get; set; }
        public int? intSetAuthority { get; set; }


        public int? intActionToBeTakenAt { get; set; }
        public int? intActionToBeTakenBy { get; set; }

        public string ActionToBeTakenAt { get; set; }
        public string ActionToBeTakenBy { get; set; }



        public string AuthorityType { get; set; }
        public bool bitAuthorityMultiple { get; set; }
        public int? intNoofMultipleAuthority { get; set; }
        public int? intPrimaryOfficeLevelId { get; set; }
        public int? intPrimaryDesignationId { get; set; }
        public int? intPrimaryAuthorityUserId { get; set; }

        public int? intSecondaryOfficeLevelid { get; set; }
        public int? intSecondaryDesignationId { get; set; }
        public int? intSecondaryAuthorityUserId { get; set; }

        public bool bitEscalation { get; set; }
        public int? intEscalationinDays { get; set; }

        public bool IsSameUser { get; set; }
        public int? CreatedBy { get; set; }

        public int? intPrimaryDistrictId { get; set; }
        public int? intSecondaryDistrictId { get; set; }
        public List<WorkFlowTransactionEF> WorkFlowtransaction = new List<WorkFlowTransactionEF>();
    }
    public class WorkFlowTransactionEF
    {
    
        public int? Check { get; set; }
        public int intId { get; set; }
        public int intWorkFlowId { get; set; }
        public string AuthorityType { get; set; }

        public int? intPrimaryOfficeLevelId { get; set; }
        public string PrimaryOfficeLevel { get; set; }
        public int? intPrimaryDesignationId { get; set; }
        public string PrimaryDesignation { get; set; }

        public int? intPrimaryAuthorityUserId { get; set; }
        public string PrimaryAuthorityUser { get; set; }

        public int? intSecondaryOfficeLevelid { get; set; }
        public int? intSecondaryDesignationId { get; set; }
        public int? intSecondaryAuthorityUserId { get; set; }
        public bool bitActiveStatus { get; set; }
        public bool bitDeleted { get; set; }
        public int? CreatedBy { get; set; }

        public int? intPrimaryDistrictId { get; set; }
        public int? intSecondaryDistrictId { get; set; }
    }

    public class WorkFlowEFQuery
    {
      
        public int? Check { get; set; }
        public int intWorkFlowId { get; set; }

        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string ActivityName { get; set; }
        public int intStep { get; set; }
        public string AuthorityType { get; set; }
        public string Escalation { get; set; }
        public int intEscalationinDays { get; set; }
        public int intSetAuthority { get; set; }
        public string SetAuthority { get; set; }

        public string ActionToBeTakenAt { get; set; }
        public string ActionToBeTakenBy { get; set; }

    }

    public class WorkFlowAuthorityLogEF
    {
        public int? Check { get; set; }
        public int? intWorkFlowId { get; set; }
        public string PrimaryAuthority { get; set; }
        public string SecondaryAuthority { get; set; }

    }
    #endregion
}
