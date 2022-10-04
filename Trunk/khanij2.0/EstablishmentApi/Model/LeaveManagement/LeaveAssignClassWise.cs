// ***********************************************************************
//  Controller Name          : LeaveManagement
//  Desciption               : Leave Management Details 
//  Created By               : Suresh Kumar Behera
//  Created On               : 13-Jul-2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EstablishmentEf;
using System.Data;
using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;


namespace EstablishmentApi.Model.LeaveManagement
{
    public class LeaveAssignClassWise :RepositoryBase, ILeaveAssignClassWise
    {
        public LeaveAssignClassWise(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region leaveAssign
        public async Task<List<LeaveDropDown>> BindEmployeeClass(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindState = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspLeaveAssignClassWise_Query", p, commandType: CommandType.StoredProcedure);
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

        public async Task<List<LeaveDropDown>> BindLeaveTypeClass(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindState = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspLeaveAssignClassWise_Query", p, commandType: CommandType.StoredProcedure);
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


        public MessageEF AddLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objApplyLeave.Check);
                p.Add("@P_intId", objApplyLeave.intId);
                p.Add("@P_intClassId", objApplyLeave.intClassId);
                p.Add("@P_intLeaveTypeId", objApplyLeave.intLeaveTypeId);
                p.Add("@P_decNoOfDays", objApplyLeave.decNoOfDays);
                p.Add("@P_CreatedBy", objApplyLeave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveAssignClassWise", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<LeaveAssignClassWiseQuery>> ViewLeaveAssignClassWise(LeaveAssignClassWiseQuery objApplyLeave)
        {
            List<LeaveAssignClassWiseQuery> listLeave = new List<LeaveAssignClassWiseQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                var output = await Connection.QueryAsync<LeaveAssignClassWiseQuery>("uspLeaveAssignClassWise_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listLeave = output.ToList();
                }
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<EstablishmentEf.LeaveAssignClassWise> ViewLeaveAssignClassWiseDetails(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            EstablishmentEf.LeaveAssignClassWise listLeave = new EstablishmentEf.LeaveAssignClassWise();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_intId", objApplyLeave.intId);
                var output = await Connection.QueryAsync<EstablishmentEf.LeaveAssignClassWise>("uspLeaveAssignClassWise_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listLeave = output.FirstOrDefault();
                }
                return listLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteLeaveAssignClassWise(EstablishmentEf.LeaveAssignClassWise objApplyLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objApplyLeave.Check);
                p.Add("@P_intId", objApplyLeave.intId);
                p.Add("@P_CreatedBy", objApplyLeave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveAssignClassWise", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }
            return objMessageEF;
        }
        #endregion
    }
}
