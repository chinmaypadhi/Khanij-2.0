using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;

namespace EstablishmentApi.Model.WorkFlow
{
    public class Activity : RepositoryBase, IActivity
    {
        public Activity(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<List<WorkFlowDropDown>> BindActivityDDL(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listBindState = new List<WorkFlowDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_ModuleId", objWorkFlow.Id);
                var output = await Connection.QueryAsync<WorkFlowDropDown>("uspModuleActivityMaster_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindState = output.ToList();
                }
                return listBindState;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddWorkFlowActivity(ActivityEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_ActivityId", objWorkFlow.ActivityId);
                p.Add("@P_ModuleId", objWorkFlow.ModuleId);
                p.Add("@P_SubModuleId", objWorkFlow.SubModuleId);
                p.Add("@P_ActivityName", objWorkFlow.ActivityName);

                p.Add("@P_ActionId", objWorkFlow.ActionId);
                p.Add("@P_WorkSpecific", objWorkFlow.WorkSpecific);
                p.Add("@P_RequiredNotification", objWorkFlow.RequiredNotification);
                p.Add("@P_NotificationType", objWorkFlow.NotificationType);

                p.Add("@P_Step", objWorkFlow.Step);
                p.Add("@P_StatusId", objWorkFlow.StatusId);
                p.Add("@P_IsActive", objWorkFlow.IsActive);

                p.Add("@P_CreatedBy", objWorkFlow.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspModuleActivityMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }

        public async Task<List<ActivityEFQuery>> ViewWorkFlowActivity(ActivityEFQuery objWorkFlow)
        {
            List<ActivityEFQuery> listActivity = new List<ActivityEFQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                var output = await Connection.QueryAsync<ActivityEFQuery>("uspModuleActivityMaster_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listActivity = output.ToList();
                }
                return listActivity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActivityEF> ViewWorkFlowActivityDetails(ActivityEF objWorkFlow)
        {
            ActivityEF objActivity = ActivityEF.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_ActivityId", objWorkFlow.ActivityId);
                var output = await Connection.QueryAsync<ActivityEF>("uspModuleActivityMaster_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    objActivity = output.FirstOrDefault();
                }
                return objActivity;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteWorkFlowActivity(ActivityEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_ActivityId", objWorkFlow.ActivityId);
                p.Add("@P_CreatedBy", objWorkFlow.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspModuleActivityMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
    }
}
