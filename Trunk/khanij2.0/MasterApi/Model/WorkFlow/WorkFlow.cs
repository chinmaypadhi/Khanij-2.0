using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Data;
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterApi;

namespace MasterApi.Model.WorkFlow
{
    public class WorkFlow : RepositoryBase, IWorkFlow
    {
        public WorkFlow(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<List<WorkFlowDropDown>> BindWorkFlowDDL(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listBindState = new List<WorkFlowDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intWorkFlowId", objWorkFlow.Id);
                var output = await Connection.QueryAsync<WorkFlowDropDown>("UspWorkFlow_Query", p, commandType: CommandType.StoredProcedure);
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

        public MessageEF AddWorkFlow(WorkFlowEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intWorkFlowId", objWorkFlow.intWorkFlowId);
                p.Add("@P_intModuleId", objWorkFlow.intModuleId);
                p.Add("@P_intSubModuleId", objWorkFlow.intSubModuleId);
                p.Add("@P_intActivityId", objWorkFlow.intActivityId);

                p.Add("@P_intStep", objWorkFlow.intStep);

                p.Add("@P_bitAuthorityMultiple", objWorkFlow.bitAuthorityMultiple);
                p.Add("@P_intNoofMultipleAuthority", objWorkFlow.intNoofMultipleAuthority);

                p.Add("@P_ActionToBeTakenAt", objWorkFlow.intActionToBeTakenAt);
                p.Add("@P_ActionToBeTakenBy", objWorkFlow.intActionToBeTakenBy);
                p.Add("@P_intSetAuthority", objWorkFlow.intSetAuthority);

                p.Add("@P_intPrimaryOfficeLevelId", objWorkFlow.intPrimaryOfficeLevelId);
                p.Add("@P_intPrimaryDistrictId", objWorkFlow.intPrimaryDistrictId);
                p.Add("@P_intPrimaryDesignationId", objWorkFlow.intPrimaryDesignationId);
                p.Add("@P_intPrimaryAuthorityUserId", objWorkFlow.intPrimaryAuthorityUserId);

                p.Add("@P_intSecondaryOfficeLevelid", objWorkFlow.intSecondaryOfficeLevelid);
                p.Add("@P_intSecondaryDistrictId", objWorkFlow.intSecondaryDistrictId);
                p.Add("@P_intSecondaryDesignationId", objWorkFlow.intSecondaryDesignationId);
                p.Add("@P_intSecondaryAuthorityUserId", objWorkFlow.intSecondaryAuthorityUserId);

                p.Add("@P_bitEscalation", objWorkFlow.bitEscalation);
                p.Add("@P_intEscalationinDays", objWorkFlow.intEscalationinDays);

                //p.Add("@P_bitNotification", objWorkFlow.bitNotification);
                //p.Add("@P_intNotificationType", objWorkFlow.intNotificationType);

                p.Add("@P_intCreatedBy", objWorkFlow.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@P_outintId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Query<int>("UspWorkFlow", p, commandType: CommandType.StoredProcedure);
                int intId = p.Get<int>("@P_outintId");

                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
                objMessageEF.Id = intId;

            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }

        public async Task<List<WorkFlowEFQuery>> ViewWorkFlow(WorkFlowEFQuery objWorkFlow)
        {
            List<WorkFlowEFQuery> listBindState = new List<WorkFlowEFQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                var output = await Connection.QueryAsync<WorkFlowEFQuery>("UspWorkFlow_Query", p, commandType: CommandType.StoredProcedure);
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

        public async Task<WorkFlowEF> ViewWorkFlowDetails(WorkFlowEF objWorkFlow)
        {
            WorkFlowEF _objWorkFlow = new WorkFlowEF();//.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intModuleId", objWorkFlow.intModuleId);
                p.Add("@P_intSubModuleId", objWorkFlow.intSubModuleId);
                p.Add("@P_intWorkFlowId", objWorkFlow.intWorkFlowId);
                var output = await Connection.QueryAsync<WorkFlowEF>("uspWorkFlow_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    _objWorkFlow = output.FirstOrDefault();
                }
                return _objWorkFlow;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteWorkFlow(WorkFlowEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intWorkFlowId", objWorkFlow.intWorkFlowId);
                p.Add("@P_intCreatedBy", objWorkFlow.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("UspWorkFlow", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {
                throw;
            }
            return objMessageEF;
        }

        public async Task<List<WorkFlowTransactionEF>> ViewWorkFlowDetailsTransaction(WorkFlowEF objWorkFlow)
        {
            List<WorkFlowTransactionEF> listBindState = new List<WorkFlowTransactionEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intWorkFlowId", objWorkFlow.intWorkFlowId);
                var output = await Connection.QueryAsync<WorkFlowTransactionEF>("UspWorkFlow_Query", p, commandType: CommandType.StoredProcedure);
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

        public MessageEF RemoveWorkFlowTransaction(WorkFlowTransactionEF objWorkFlow)
        {
            MessageEF objMessageEF = new MessageEF();//.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intId", objWorkFlow.intId);
                p.Add("@P_intCreatedBy", objWorkFlow.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@P_outintId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Query<int>("UspWorkFlow", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();

                int intId = p.Get<int>("@P_outintId");
                objMessageEF.Id = intId;
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<WorkFlowDropDown>> BindActionType(WorkFlowDropDown objWorkFlow)
        {
            List<WorkFlowDropDown> listBindState = new List<WorkFlowDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intLeaveId", objWorkFlow.Id);
                p.Add("@P_intModuleId", objWorkFlow.Id2);
                p.Add("@P_intSubModuleId", objWorkFlow.Id3);
                var output = await Connection.QueryAsync<WorkFlowDropDown>("uspWorkFlowAction_Query", p, commandType: CommandType.StoredProcedure);

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

        public async Task<List<WorkFlowAuthorityLogEF>> ViewActionTakingAuthority(WorkFlowAuthorityLogEF objWorkFlow)
        {
            List<WorkFlowAuthorityLogEF> listBindState = new List<WorkFlowAuthorityLogEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objWorkFlow.Check);
                p.Add("@P_intWorkFlowId", objWorkFlow.intWorkFlowId);
                //p.Add("@P_intModuleId", objWorkFlow.Id2);
                //p.Add("@P_intSubModuleId", objWorkFlow.Id3);
                var output = await Connection.QueryAsync<WorkFlowAuthorityLogEF>("uspWorkFlow_Query", p, commandType: CommandType.StoredProcedure);

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
    }
}
