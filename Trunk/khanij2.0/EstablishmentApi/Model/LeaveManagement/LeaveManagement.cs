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
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using System.Data;
using Dapper;

namespace EstablishmentApi.Model.LeaveManagement
{
    public class LeaveManagement : RepositoryBase, ILeaveManagement
    {
        public LeaveManagement(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        #region LeaveRule

        /// <summary>
        /// Add leave rule master
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF AddLeaveRuleMaster(LeaveRuleMasterEF objLeaveRule)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveRule.Check);
                p.Add("@P_RuleId", objLeaveRule.RuleId);
                p.Add("@P_RuleName", objLeaveRule.RuleName);
                p.Add("@P_RuleNo", objLeaveRule.RuleNo);
                p.Add("@P_IsActive", objLeaveRule.IsActive);
                p.Add("@P_CreatedBy", objLeaveRule.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.Add("@P_outRuleId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveRuleMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                //int intEmployeeid = p.Get<int>("P_outRuleId");
                objMessageEF.Satus = newID.ToString();
                //objMessageEF.Msg = intEmployeeid.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }


        /// <summary>
        /// Delete leave rule
        /// </summary>
        /// <param name="objLeaveRule"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveRuleDetails(LeaveRuleMasterEF objLeaveRule)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveRule.Check);
                p.Add("@P_RuleId", objLeaveRule.RuleId);
                p.Add("@P_CreatedBy", objLeaveRule.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveRuleMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }
        /// <summary>
        /// view leave rule master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<List<LeaveRuleMasterEF>> ViewLeaveRuleMaster(LeaveRuleMasterEF objLeaveRuleMaster)
        {

            List<LeaveRuleMasterEF> ListLeaveRuleMaster = new List<LeaveRuleMasterEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveRuleMaster.Check);
                var Output = await Connection.QueryAsync<LeaveRuleMasterEF>("uspLeaveRuleMaster", p, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ListLeaveRuleMaster = Output.ToList();
                }

                return ListLeaveRuleMaster;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

                ListLeaveRuleMaster = null;
            }
        }
        /// <summary>
        /// view leave rule master details
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<LeaveRuleMasterEF> ViewLeaveRuleMasterDetails(LeaveRuleMasterEF objLeaveRuleMaster)
        {
            LeaveRuleMasterEF objLeaveRule = new LeaveRuleMasterEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveRuleMaster.Check);
                p.Add("@P_RuleId", objLeaveRuleMaster.RuleId);
                var Output = await Connection.QueryAsync<LeaveRuleMasterEF>("uspLeaveRuleMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {

                    objLeaveRule = Output.FirstOrDefault();
                }

                return objLeaveRule;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

                objLeaveRule = null;
            }
        }
        #endregion

        #region LeaveType
        /// <summary>
        /// Bind Leave Rule
        /// </summary>
        /// <param name="objRule"></param>
        /// <returns></returns>
        public async Task<List<LeaveDropDown>> BindLeaveRule(LeaveDropDown objRule)
        {
            List<LeaveDropDown> objLeaveRule = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objRule.Check);
                var Output = await Connection.QueryAsync<LeaveDropDown>("uspLeaveTypeMaster", p, commandType: CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    objLeaveRule = Output.ToList();
                }
                return objLeaveRule;
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Add leave type
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF AddLeaveTypeMaster(LeaveTypeMasterEF objLeaveType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveType.Check);
                p.Add("@P_RuleId", objLeaveType.RuleId);
                p.Add("@P_LeaveTypeId", objLeaveType.LeaveTypeId);
                p.Add("@P_LeaveType", objLeaveType.LeaveType);
                p.Add("@P_NoOfLeave", objLeaveType.NoOfLeave);
                p.Add("@P_BitIncludeHoliday", objLeaveType.BitIncludeHoliday);
                p.Add("@P_Description", objLeaveType.Description);
                p.Add("@P_BitCarryForward", objLeaveType.BitCarryForward);


                p.Add("@P_BitDocRequired", objLeaveType.BitDocRequired);
                p.Add("@P_BitPerMonthLeave", objLeaveType.BitPerMonthLeave);
                p.Add("@P_IntPerMonthLeave", objLeaveType.intPerMonthLeave);

                p.Add("@P_CreatedBy", objLeaveType.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveTypeMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                //int intEmployeeid = p.Get<int>("P_outRuleId");
                objMessageEF.Satus = newID.ToString();
                //objMessageEF.Msg = intEmployeeid.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;

        }
        /// <summary>
        /// view leave type
        /// </summary>
        /// <param name="objLeaveTypeMaster"></param>
        /// <returns></returns>
        public async Task<LeaveTypeMasterEF> ViewLeaveTypeMasterDetails(LeaveTypeMasterEF objLeaveTypeMaster)
        {
            LeaveTypeMasterEF objLeaveRule = new LeaveTypeMasterEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveTypeMaster.Check);
                p.Add("@P_LeaveTypeId", objLeaveTypeMaster.LeaveTypeId);
                var Output = await Connection.QueryAsync<LeaveTypeMasterEF>("uspLeaveTypeMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {

                    objLeaveRule = Output.FirstOrDefault();
                }

                return objLeaveRule;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {

                objLeaveRule = null;
            }
        }
        /// <summary>
        /// view leave type master
        /// </summary>
        /// <param name="objLeaveRuleMaster"></param>
        /// <returns></returns>
        public async Task<List<LeaveTypeMasterEF>> ViewLeaveTypeMaster(LeaveTypeMasterEF objLeaveRuleMaster)
        {
            List<LeaveTypeMasterEF> ListLeaveTypeMaster = new List<LeaveTypeMasterEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveRuleMaster.Check);

                var Output = await Connection.QueryAsync<LeaveTypeMasterEF>("uspLeaveTypeMaster", p, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {

                    ListLeaveTypeMaster = Output.ToList();
                }

                return ListLeaveTypeMaster;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                ListLeaveTypeMaster = null;
            }
        }
        /// <summary>
        /// delete leave type 
        /// </summary>
        /// <param name="objLeaveType"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaveTypeDetails(LeaveTypeMasterEF objLeaveType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveType.Check);
                p.Add("@P_LeaveTypeId", objLeaveType.LeaveTypeId);
                p.Add("@P_CreatedBy", objLeaveType.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspLeaveTypeMaster", p, commandType: CommandType.StoredProcedure);
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

        #region HolidayType
        public async Task<List<HolidayTypeMasterEF>> ViewHolidayTypeMaster(HolidayTypeMasterEF objHolidayTypeMaster)
        {
            List<HolidayTypeMasterEF> listHolidayTypeMaster = new List<HolidayTypeMasterEF>();

            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHolidayTypeMaster.Check);
                var Output = await Connection.QueryAsync<HolidayTypeMasterEF>("uspHolidayTypeMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    listHolidayTypeMaster = Output.ToList();

                }
                return listHolidayTypeMaster;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                listHolidayTypeMaster = null;
            }

        }

        public MessageEF AddHolidayType(HolidayTypeMasterEF objHolidayType)
        {

            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHolidayType.Check);
                p.Add("@P_HolidayTypeId", objHolidayType.HolidayTypeId);
                p.Add("@P_HolidayTypeName", objHolidayType.HolidayTypeName);
                p.Add("@P_HolidayType", objHolidayType.HolidayType);
                p.Add("@P_CreatedBy", objHolidayType.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspHolidayTypeMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                //int intEmployeeid = p.Get<int>("P_outRuleId");
                objMessageEF.Satus = newID.ToString();
                //objMessageEF.Msg = intEmployeeid.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<HolidayTypeMasterEF> ViewHolidayTypeDetails(HolidayTypeMasterEF objHolidayTypeDetails)
        {
            HolidayTypeMasterEF objHoliday = new HolidayTypeMasterEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHolidayTypeDetails.Check);
                p.Add("@P_HolidayTypeId", objHolidayTypeDetails.HolidayTypeId);
                var output = await Connection.QueryAsync<HolidayTypeMasterEF>("uspHolidayTypeMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    objHoliday = output.FirstOrDefault();
                }
                return objHoliday;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                objHoliday = null;
            }
        }

        public MessageEF DeleteHolidayType(HolidayTypeMasterEF objHolidayType)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHolidayType.Check);
                p.Add("@P_HolidayTypeId", objHolidayType.HolidayTypeId);
                p.Add("@P_CreatedBy", objHolidayType.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspHolidayTypeMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("@P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
        #endregion

        #region Holiday
        public MessageEF AddHoliday(HolidayMasterEF objHoliday)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHoliday.Check);
                p.Add("@P_HolidayId", objHoliday.HolidayId);
                p.Add("@P_HolidayName", objHoliday.HolidayName);
                p.Add("@P_HolidayTypeId", objHoliday.HolidayTypeId);
                p.Add("@P_HolidayDate", objHoliday.HolidayDate);
                p.Add("@P_CreatedBy", objHoliday.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspHolidayMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }

            return objMessageEF;
        }

        public async Task<List<LeaveDropDown>> BindDropdown(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listHolidayMaster = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var Output = await Connection.QueryAsync<LeaveDropDown>("uspHolidayMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    listHolidayMaster = Output.ToList();
                }
                return listHolidayMaster;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                listHolidayMaster = null;
            }
        }

        public async Task<List<HolidayMasterEF>> ViewHoliday(HolidayMasterEF objHoliday)
        {
            List<HolidayMasterEF> listHolidayMaster = new List<HolidayMasterEF>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHoliday.Check);
                var Output = await Connection.QueryAsync<HolidayMasterEF>("uspHolidayMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    listHolidayMaster = Output.ToList();
                }
                return listHolidayMaster;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<HolidayMasterEF> ViewHolidayDetails(HolidayMasterEF objHoliday)
        {
            HolidayMasterEF HolidayMaster = new HolidayMasterEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHoliday.Check);
                p.Add("@P_HolidayId", objHoliday.HolidayId);
                var Output = await Connection.QueryAsync<HolidayMasterEF>("uspHolidayMaster", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    HolidayMaster = Output.FirstOrDefault();
                }
                return HolidayMaster;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MessageEF DeleteHoliday(HolidayMasterEF objHoliday)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objHoliday.Check);
                p.Add("@P_HolidayId", objHoliday.HolidayId);
                p.Add("@P_CreatedBy", objHoliday.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspHolidayMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }

            return objMessageEF;
        }



        #endregion
        #region RiderLeave
        public async Task<List<LeaveDropDown>> BindDistrict(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listHolidayMaster = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var Output = await Connection.QueryAsync<LeaveDropDown>("uspRiderLeave", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    listHolidayMaster = Output.ToList();
                }
                return listHolidayMaster;
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task<List<LeaveDropDown>> BindDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listHolidayMaster = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var Output = await Connection.QueryAsync<LeaveDropDown>("uspRiderLeave", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    listHolidayMaster = Output.ToList();
                }
                return listHolidayMaster;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindLeaveType(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listHolidayMaster = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspRiderLeave", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listHolidayMaster = output.ToList();
                }
                return listHolidayMaster;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddRiderLeave(RiderLeave objRiderLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objRiderLeave.Check);
                p.Add("@P_RiderLeaveId", objRiderLeave.RiderLeaveId);
                p.Add("@P_DistrictId", objRiderLeave.DistrictId);
                p.Add("@P_DesignationId", objRiderLeave.DesignationId);
                p.Add("@P_LeaveTypeId", objRiderLeave.LeaveTypeId);
                p.Add("@P_NoOfDays", objRiderLeave.NoOfDays);
                p.Add("@P_Remarks", objRiderLeave.Remarks);
                p.Add("@P_IsDocumentRequired", objRiderLeave.IsDocumentRequired);
                p.Add("@P_CreatedBy", objRiderLeave.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRiderLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<RiderLeave>> ViewRiderleave(RiderLeave objRiderLeave)
        {
            List<RiderLeave> listRiderLeave = new List<RiderLeave>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objRiderLeave.Check);
                var output = await Connection.QueryAsync<RiderLeave>("uspRiderLeave", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listRiderLeave = output.ToList();
                }
                return listRiderLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<RiderLeave> ViewRiderleaveDetails(RiderLeave objRiderLeave)
        {
            RiderLeave rLeave = new RiderLeave();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objRiderLeave.Check);
                p.Add("@P_RiderLeaveId", objRiderLeave.RiderLeaveId);
                var Output = await Connection.QueryAsync<RiderLeave>("uspRiderLeave", p, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    rLeave = Output.FirstOrDefault();
                }
                return rLeave;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MessageEF DeleteRiderLeave(RiderLeave objRiderLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objRiderLeave.Check);
                p.Add("@P_RiderLeaveId", objRiderLeave.RiderLeaveId);
                p.Add("@P_CreatedBy", objRiderLeave.CreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRiderLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        #endregion

        #region AuthoritySetting
        public async Task<List<LeaveDropDown>> BindState_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindState = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
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
        public async Task<List<LeaveDropDown>> BindDistrict_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intStateId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindVerifyDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindForwardDepartment_Authority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindForwardDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<LeaveDropDown>> BindOICApproveDesignation(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindOICOfficer(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindOICApproveUser(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_FirstLevel(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation1(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveUser1(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public async Task<List<LeaveDropDown>> BindNoOfDaysExceed_secondLevel(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveDesignation2(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<List<LeaveDropDown>> BindNextApproveUser2(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindDistrict = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveDropDown.Check);
                p.Add("@P_intDesignationId", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listBindDistrict = output.ToList();
                }
                return listBindDistrict;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intAuthorityId);

                p.Add("@P_intStateId", objAuthoritySetting.intStateId);
                p.Add("@P_intDepartmentId", objAuthoritySetting.intDepartmentId);
                p.Add("@P_intDistrictId", objAuthoritySetting.intDistrictId);

                p.Add("@P_intVerifyDesignationId", objAuthoritySetting.intVerifyDesignationId);
                p.Add("@P_intForwardDepartmentId", objAuthoritySetting.intForwardDepartmentId);
                p.Add("@P_intForwardDesignationId", objAuthoritySetting.intForwardDesignationId);

                p.Add("@P_intOicOfficerId", objAuthoritySetting.intOicOfficerId);
                p.Add("@P_intOicApproveDesignationId", objAuthoritySetting.intOicApproveDesignationId);
                p.Add("@P_intOicApproveUserId", objAuthoritySetting.intOicApproveUserId);

                p.Add("@P_intDaysExceed1", objAuthoritySetting.intDaysExceed1);
                p.Add("@P_intNextApprovedDesignationId1", objAuthoritySetting.intNextApprovedDesignationId1);
                p.Add("@P_intNextApprovedUserId1", objAuthoritySetting.intNextApprovedUserId1);

                p.Add("@P_intDaysExceed2", objAuthoritySetting.intDaysExceed2);
                p.Add("@P_intNextApprovedDesignationId2", objAuthoritySetting.intNextApprovedDesignationId2);
                p.Add("@P_intNextApprovedUserId2", objAuthoritySetting.intNextApprovedUserId2);

                p.Add("@P_CreatedBy", objAuthoritySetting.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspAuthoritySetting", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<AuthoritySettingQuery>> ViewAuthoritySetting(AuthoritySettingQuery objAuthoritySetting)
        {
            List<AuthoritySettingQuery> listAuthoritySetting = new List<AuthoritySettingQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                var output = await Connection.QueryAsync<AuthoritySettingQuery>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listAuthoritySetting = output.ToList();
                }
                return listAuthoritySetting;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<AuthoritySetting> ViewAuthoritySettingDetails(AuthoritySetting objAuthoritySetting)
        {
            AuthoritySetting objAuthority = new AuthoritySetting();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intAuthorityId);
                var output = await Connection.QueryAsync<AuthoritySetting>("uspAuthoritySetting_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    objAuthority = output.FirstOrDefault();
                }
                return objAuthority;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MessageEF DeleteAuthoritySetting(AuthoritySetting objAuthoritySetting)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intAuthorityId);

                p.Add("@P_CreatedBy", objAuthoritySetting.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspAuthoritySetting", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
        #endregion

        #region ApplyLeave
        public async Task<List<LeaveDropDown>> BindEmployee(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindState = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspApplyLeave_Query", p, commandType: CommandType.StoredProcedure);
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
        public async Task<List<LeaveDropDown>> BindLeaveType_ApplyLeave(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listBindState = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                p.Add("@P_CreatedBy", objLeaveDropDown.Id);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspApplyLeave_Query", p, commandType: CommandType.StoredProcedure);
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

        public MessageEF AddApplyLeave(ApplyLeave objApplyleave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objApplyleave.Check);
                p.Add("@P_intLeaveId", objApplyleave.intLeaveId);
                p.Add("@P_intEmployeeId", objApplyleave.intEmployeeId);
                p.Add("@P_intLeaveTypeId", objApplyleave.intLeaveTypeId);

                p.Add("@P_dtFromDate", DateTime.ParseExact(objApplyleave.dtFromDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));
                p.Add("@P_bitFromHalfDay", objApplyleave.bitFromHalfDay);
                p.Add("@P_intFromHalfDay", objApplyleave.intFromHalfDay);

                p.Add("@P_dtToDate", DateTime.ParseExact(objApplyleave.dtToDate, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));
                p.Add("@P_bitToHalfDay", objApplyleave.bitToHalfDay);
                p.Add("@P_intToHalfDay", objApplyleave.intToHalfDay);


                p.Add("@P_decNoOfDaysApply", objApplyleave.NoOfDays);
                p.Add("@P_varReason", objApplyleave.varReason);
                p.Add("@P_varOffice", objApplyleave.varOffice);
                p.Add("@P_varSection", objApplyleave.varSection);
                p.Add("@P_varPay", objApplyleave.varPay);
                p.Add("@P_varHouseAndRentAllowance", objApplyleave.varHouseAndRentAllowance);
                p.Add("@P_varSundayHoliday", objApplyleave.varSundayHoliday);
                p.Add("@P_varProposedToAvail", objApplyleave.varProposedToAvail);
                p.Add("@P_varChildName", objApplyleave.varChildName);
                if (objApplyleave.dtChildDOB != null)
                {
                    p.Add("@P_dtChildDOB", DateTime.ParseExact(objApplyleave.dtChildDOB, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));

                }
                p.Add("@P_bitPermissionRequired", objApplyleave.bitPermissionRequired);
                //p.Add("@P_dtDateOfReturn", objApplyleave.dtDateOfReturn);

                p.Add("@P_intCreatedBy", objApplyleave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspApplyLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<LeaveDetails> BindLeaveCount(LeaveDetails objLeaveDetails)
        {
            LeaveDetails objLeave = new LeaveDetails();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDetails.Check);
                p.Add("@P_intEmployeeId", objLeaveDetails.intEmployeeId);
                p.Add("@P_intLeaveTypeId", objLeaveDetails.intLeaveTypeId);
                var output = await Connection.QueryAsync<LeaveDetails>("uspApplyLeave_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    objLeave = output.FirstOrDefault();
                }
                return objLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<ApplyLeaveQuery>> ViewApplyLeave(ApplyLeaveQuery objApplyLeave)
        {
            List<ApplyLeaveQuery> listApplyLeave = new List<ApplyLeaveQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_CreatedBy", objApplyLeave.intCreatedBy);
                p.Add("@P_intModuleId", objApplyLeave.intModuleId);
                p.Add("@P_intSubModuleId", objApplyLeave.intSubModuleId);
                var output = await Connection.QueryAsync<ApplyLeaveQuery>("uspApplyLeave_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.ToList();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ApplyLeave> ViewApplyLeaveDetails(ApplyLeave objApplyLeave)
        {
            ApplyLeave objLeave = new ApplyLeave();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_intLeaveId", objApplyLeave.intLeaveId);
                var output = await Connection.QueryAsync<ApplyLeave>("uspApplyLeave_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    objLeave = output.FirstOrDefault();
                }
                return objLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public MessageEF DeleteApplyLeave(ApplyLeave objApplyleave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objApplyleave.Check);
                p.Add("@P_intLeaveId", objApplyleave.intLeaveId);
                p.Add("@P_intCreatedBy", objApplyleave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspApplyLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }


        #endregion


        #region TribalDistrictLeave
        public MessageEF AddTribalDistrictLeave(TribalDistLeave objTribalDistrict)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objTribalDistrict.Check);
                p.Add("@P_intTribalLeaveid", objTribalDistrict.intTribalLeaveid);
                p.Add("@P_intLeaveTypeId", objTribalDistrict.intLeaveTypeId);
                p.Add("@P_IntDistrictId", objTribalDistrict.IntDistrictId);
                p.Add("@P_intNoOfLeave", objTribalDistrict.intNoOfLeave);
                p.Add("@P_intCreatedBy", objTribalDistrict.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspTribalDistrictLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<TribalDistLeaveQuery>> ViewTribalDistrictLeave(TribalDistLeaveQuery objApplyLeave)
        {
            List<TribalDistLeaveQuery> listApplyLeave = new List<TribalDistLeaveQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                var output = await Connection.QueryAsync<TribalDistLeaveQuery>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.ToList();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<TribalDistLeave> ViewTribalDistrictLeaveDetails(TribalDistLeave objApplyLeave)
        {
            TribalDistLeave listApplyLeave = new TribalDistLeave();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_intId", objApplyLeave.intTribalLeaveid);
                var output = await Connection.QueryAsync<TribalDistLeave>("uspSectionOfficerTagging_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.FirstOrDefault();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteTribalDistrictLeave(TribalDistLeave objTribalDistrict)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objTribalDistrict.Check);
                p.Add("@P_intTribalLeaveid", objTribalDistrict.intTribalLeaveid);
                p.Add("@P_intCreatedBy", objTribalDistrict.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspTribalDistrictLeave", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        #endregion

        #region userwise authority

        public async Task<List<LeaveDropDown>> BindDropDownSetAuthority(LeaveDropDown objLeaveDropDown)
        {
            List<LeaveDropDown> listApplyLeave = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objLeaveDropDown.Check);
                p.Add("@P_intId", objLeaveDropDown.Id);
                p.Add("@P_intId2", objLeaveDropDown.Id2);
                p.Add("@P_intId3", objLeaveDropDown.Id3);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspUserWiseSetAuthority_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.ToList();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF AddUserWiseSetAuthority(UserWiseSetAuthority objAuthoritySetting)
        {

            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intAuthorityId);
                p.Add("@P_intEmpStateId", objAuthoritySetting.intEmpStateId);
                p.Add("@P_intEmpDepartmentId", objAuthoritySetting.intEmpDepartmentId);
                p.Add("@P_intEmpOfficeLevelId", objAuthoritySetting.intEmpOfficeLevelId);
                p.Add("@P_intEmpDesignationId", objAuthoritySetting.intEmpDesignationId);
                p.Add("@P_intEmployeeId", objAuthoritySetting.intEmployeeId);
                p.Add("@P_intStep", objAuthoritySetting.intStep);
                p.Add("@P_intPrimaryOfficeLevelId", objAuthoritySetting.intPrimaryOfficeLevelId);
                p.Add("@P_intPrimaryDesignationId", objAuthoritySetting.intPrimaryDesignationId);
                p.Add("@P_intPrimaryAuthorityUserId", objAuthoritySetting.intPrimaryAuthorityUserId);
                p.Add("@P_intSecondaryOfficeLevelid", objAuthoritySetting.intSecondaryOfficeLevelid);
                p.Add("@P_intSecondaryDesignationId", objAuthoritySetting.intSecondaryDesignationId);
                p.Add("@P_intSecondaryAuthorityUserId", objAuthoritySetting.intSecondaryAuthorityUserId);
                p.Add("@P_intCreatedBy", objAuthoritySetting.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);

                p.Add("@P_outintId", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Query<int>("uspUserWiseSetAuthority", p, commandType: CommandType.StoredProcedure);
                int intId = p.Get<int>("@P_outintId");
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
                objMessageEF.Id = intId;
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<UserWiseSetAuthority> ViewUserWiseSetAuthoritySettingDetails(UserWiseSetAuthority objUserWiseAuthority)
        {
            UserWiseSetAuthority listApplyLeave = new UserWiseSetAuthority();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objUserWiseAuthority.Check);
                p.Add("@P_intAuthorityId", objUserWiseAuthority.intAuthorityId);
                var output = await Connection.QueryAsync<UserWiseSetAuthority>("uspUserWiseSetAuthority_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.FirstOrDefault();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<UserWiseSetAuthorityChild>> ViewUserWiseSetAuthorityChild(UserWiseSetAuthority objUserWiseAuthority)
        {
            List<UserWiseSetAuthorityChild> listApplyLeave = new List<UserWiseSetAuthorityChild>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objUserWiseAuthority.Check);
                p.Add("@P_intAuthorityId", objUserWiseAuthority.intAuthorityId);
                var output = await Connection.QueryAsync<UserWiseSetAuthorityChild>("uspUserWiseSetAuthority_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.ToList();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public MessageEF RemoveUserWiseSetAuthoritychild(UserWiseSetAuthorityChild objAuthoritySetting)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intChildId);
                p.Add("@P_intCreatedBy", objAuthoritySetting.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@P_outintId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUserWiseSetAuthority", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
                int intId = p.Get<int>("P_outintId");
                objMessageEF.Id = intId;
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }

        public async Task<List<UserWiseSetAuthorityQuery>> ViewUserWiseSetAuthority(UserWiseSetAuthorityQuery objUserWiseAuthority)
        {
            List<UserWiseSetAuthorityQuery> listAuthority = new List<UserWiseSetAuthorityQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objUserWiseAuthority.Check);
                var output = await Connection.QueryAsync<UserWiseSetAuthorityQuery>("uspUserWiseSetAuthority_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listAuthority = output.ToList();
                }
                return listAuthority;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF DeleteUserWiseSetAuthoritySetting(UserWiseSetAuthority objAuthoritySetting)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objAuthoritySetting.Check);
                p.Add("@P_intAuthorityId", objAuthoritySetting.intAuthorityId);
                p.Add("@P_intCreatedBy", objAuthoritySetting.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                //p.Add("@P_outintId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUserWiseSetAuthority", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
                //int intId = p.Get<int>("P_outintId");
                //objMessageEF.Id = intId;
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }


        #endregion

        #region LeaveInbox

        public async Task<List<LeaveInboxQuery>> ViewLeaveInbox(LeaveInboxQuery objApplyLeave)
        {
            List<LeaveInboxQuery> listApplyLeave = new List<LeaveInboxQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_CreatedBy", objApplyLeave.intCreatedBy);
                var output = await Connection.QueryAsync<LeaveInboxQuery>("uspLeaveInbox_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    listApplyLeave = output.ToList();
                }
                return listApplyLeave;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox)
        {
            LeaveInboxDetails _objLeaveInbox = new LeaveInboxDetails();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeaveInbox.Check);
                p.Add("@P_intLeaveId", objLeaveInbox.intLeaveId);
                p.Add("@P_CreatedBy", objLeaveInbox.intCreatedBy);
                var output = await Connection.QueryAsync<LeaveInboxDetails>("uspLeaveInbox_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    _objLeaveInbox = output.FirstOrDefault();
                }
                return _objLeaveInbox;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public MessageEF TakeAction(LeaveInboxDetails objLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeave.Check);
                p.Add("@P_intLeaveId", objLeave.intLeaveId);
                //p.Add("@P_intStatus", objLeave.intStatus);
                p.Add("@P_vchRemarks", objLeave.vchRemarks);
                p.Add("@P_intActionId", objLeave.intActionId);
                p.Add("@P_intCreatedBy", objLeave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Query<int>("uspWorkFlowAction", p, commandType: CommandType.StoredProcedure);
                //Connection.Query<int>("uspLeaveInbox", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
        public async Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType)
        {
            List<LeaveDropDown> _objListActionType = new List<LeaveDropDown>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objActionType.Check);
                p.Add("@P_intLeaveId", objActionType.Id);
                p.Add("@P_intModuleId", objActionType.Id2);
                p.Add("@P_intSubModuleId", objActionType.Id3);
                var output = await Connection.QueryAsync<LeaveDropDown>("uspLeaveInbox_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    _objListActionType = output.ToList();
                }
                return _objListActionType;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion

        #region ProcessFlow


        //public Task<List<LeaveDropDown>> BindSubModuleName(LeaveDropDown objLeaveDropDown)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<List<LeaveDropDown>> BindAction(LeaveDropDown objLeaveDropDown)
        //{
        //    throw new NotImplementedException();
        //}



        #endregion
    }
}
