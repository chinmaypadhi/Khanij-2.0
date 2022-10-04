using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstablishmentEf
{


    public class WorkFlowDropDown
    {
        private static WorkFlowDropDown instance = null;
        public static WorkFlowDropDown GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkFlowDropDown();
            }
            return instance;
        }

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
        private static ActivityEF instance = null;
        public static ActivityEF GetInstance()
        {
            if (instance == null)
            {
                instance = new ActivityEF();
            }
            return instance;
        }

        public int? Check { get; set; }
        public int ActivityId { get; set; }
        public int ModuleId { get; set; }
        public int SubModuleId { get; set; }
        public string ActivityName { get; set; }
        public int? ActionId { get; set; }
        public int? WorkSpecific { get; set; }
        public bool RequiredNotification { get; set; }
        public int? NotificationType { get; set; }
        public int? Step { get; set; }
        public bool StatusId { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
    public class ActivityEFQuery
    {
        private static ActivityEFQuery instance = null;
        public static ActivityEFQuery GetInstance()
        {
            if (instance == null)
            {
                instance = new ActivityEFQuery();
            }
            return instance;
        }

        public int? Check { get; set; }
        public int ActivityId { get; set; }
        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string ActivityName { get; set; }
        public string ActionName { get; set; }
        public string WorkSpecific { get; set; }
        public string RequiredNotification { get; set; }
        public string NotificationType { get; set; }
        public int Step { get; set; }

    }
    #endregion

    #region WorkFlow
    public class WorkFlowEF
    {
        private static WorkFlowEF instance = null;
        public static WorkFlowEF GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkFlowEF();
            }
            return instance;
        }
        public int? Check { get; set; }
        public int intWorkFlowId { get; set; }
        public int intModuleId { get; set; }
        public int intSubModuleId { get; set; }
        public int intActivityId { get; set; }
        public bool bitActiveStatus { get; set; }
        public bool bitDeleted { get; set; }
      

        public int intStep { get; set; }



        public string AuthorityType { get; set; }
        public bool bitAuthorityMultiple { get; set; }
        public int? intNoofMultipleAuthority { get; set; }
        public int intPrimaryOfficeLevelId { get; set; }
        public int intPrimaryDesignationId { get; set; }
        public int intPrimaryAuthorityUserId { get; set; }

        public int? intSecondaryOfficeLevelid { get; set; }
        public int? intSecondaryDesignationId { get; set; }
        public int? intSecondaryAuthorityUserId { get; set; }

        public bool bitEscalation { get; set; }
        public int? intEscalationinDays { get; set; }
        public bool bitNotification { get; set; }
        public int? intNotificationType { get; set; }

        public bool IsSameUser { get; set; }
        public int CreatedBy { get; set; }


        public List<WorkFlowTransactionEF> WorkFlowtransaction = new List<WorkFlowTransactionEF>();
    }
    public class WorkFlowTransactionEF
    {
        private static WorkFlowTransactionEF instance = null;
        public static WorkFlowTransactionEF GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkFlowTransactionEF();
            }
            return instance;
        }
        public int? Check { get; set; }
        public int intId { get; set; }
        public int intWorkFlowId { get; set; }
        //public int intStep { get; set; }

        //public bool bitAuthorityMultiple { get; set; }
        public string AuthorityType { get; set; }
        //public int intNoofMultipleAuthority { get; set; }

        public int intPrimaryOfficeLevelId { get; set; }
        public string PrimaryOfficeLevel { get; set; }
        public int intPrimaryDesignationId { get; set; }
        public string PrimaryDesignation { get; set; }

        public int intPrimaryAuthorityUserId { get; set; }
        public string PrimaryAuthorityUser { get; set; }

        public int intSecondaryOfficeLevelid { get; set; }
        public int intSecondaryDesignationId { get; set; }
        public int intSecondaryAuthorityUserId { get; set; }
        //public bool bitEscalation { get; set; }
        //public int intEscalationinDays { get; set; }
        //public bool bitNotification { get; set; }
        //public int intNotificationType { get; set; }
        public bool bitActiveStatus { get; set; }
        public bool bitDeleted { get; set; }
        public int CreatedBy { get; set; }

    }

    public class WorkFlowEFQuery
    {
        private static WorkFlowEFQuery instance = null;
        public static WorkFlowEFQuery GetInstance()
        {
            if (instance == null)
            {
                instance = new WorkFlowEFQuery();
            }
            return instance;
        }
        public int? Check { get; set; }
        public int intWorkFlowId { get; set; }

        public string ModuleName { get; set; }
        public string SubModuleName { get; set; }
        public string ActivityName { get; set; }
        public int intStep { get; set; }
        public string AuthorityType { get; set; }

        public string Escalation { get; set; }
        public int intEscalationinDays { get; set; }
        public string Notification { get; set; }
        public string NotificationType { get; set; }
    }
    #endregion
}
