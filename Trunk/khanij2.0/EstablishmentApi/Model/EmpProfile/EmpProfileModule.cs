using Dapper;
using EstablishmentApi.Factory;
using EstablishmentApi.Repository;
using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApi.Model.EmpProfile
{
    public class EmpProfileModule: RepositoryBase,IEmpProfile
    {
        public EmpProfileModule(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF AddEmpProfile(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_Status", objEmpProfileEf.Satus);
                p.Add("P_intEmployeeid", objEmpProfileEf.intEmployeeid);
                p.Add("P_VchEmployeeid", objEmpProfileEf.VchEmployeeid);
                p.Add("P_VchName", objEmpProfileEf.VchName);
                p.Add("P_VchFatherName", objEmpProfileEf.VchFatherName);
                p.Add("P_VchEmployeeType", objEmpProfileEf.VchEmployeeType);
                p.Add("P_VchAadharNumber", objEmpProfileEf.VchAadharNumber);
                p.Add("P_VchAadharCard", objEmpProfileEf.VchAadharCard);
                p.Add("P_Intdesignation", objEmpProfileEf.Intdesignation);
                p.Add("P_VchCategory", objEmpProfileEf.VchCategory);
                p.Add("P_IntClass", objEmpProfileEf.IntClass);
                p.Add("P_VchMobileNo", objEmpProfileEf.VchMobileNo);
                p.Add("P_VchEmailid", objEmpProfileEf.VchEmailid);
                p.Add("P_DateDateofbirth", DateTime.ParseExact(objEmpProfileEf.DateDateofbirth, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));
                //p.Add("P_DateDateofbirth"        ,objEmpProfileEf.DateDateofbirth);
                p.Add("P_IntHomeSate", objEmpProfileEf.IntHomeSate);
                p.Add("P_IntHomeDistrict", objEmpProfileEf.IntHomeDistrict);
                p.Add("P_VchGender", objEmpProfileEf.VchGender);
                p.Add("P_VchMaritalStatus", objEmpProfileEf.VchMaritalStatus);
                p.Add("P_VchSignature", objEmpProfileEf.VchSignature);
                p.Add("P_VchPhoto", objEmpProfileEf.VchPhoto);
                p.Add("P_intApproveStatus", objEmpProfileEf.intApproveStatus);
                p.Add("P_BitdeletedFlage", objEmpProfileEf.BitdeletedFlage);
                p.Add("P_intCreatedBy", objEmpProfileEf.intCreatedBy);
                p.Add("P_intUpdatedBy", objEmpProfileEf.intCreatedBy);
               
                p.Add("P_VchAadharCardPath", objEmpProfileEf.VchAadharCardPath);
                p.Add("P_VchSignaturePath", objEmpProfileEf.VchSignaturePath);
                p.Add("P_VchPhotoPath", objEmpProfileEf.VchPhotoPath);

                //p.Add("@P_IsLoginExists", objEmpProfileEf.IsLoginExists);
                //p.Add("@P_UserId", objEmpProfileEf.UserId);
                //p.Add("@P_UserName", objEmpProfileEf.UserName);

                //p.Add("@Password", objEmpProfileEf.Password);
                //p.Add("@EncryptPassword", objEmpProfileEf.EncryptPassword);
                //p.Add("@P_UserLoginId", objEmpProfileEf.UserLoginId);

                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("@P_outEmployeeid", dbType: DbType.Int32, direction: ParameterDirection.Output);

                Connection.Query<int>("USP_T_EmployeePersonalDetails", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                int intEmployeeid = p.Get<int>("P_outEmployeeid");
                objMessageEF.Satus = newID.ToString();
                objMessageEF.Msg = intEmployeeid.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public async Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown)
        {
            List<EmpDropDown> objListEmpDropDown = new List<EmpDropDown>();
            try
            {
                var paramList = new
                {
                    P_Acction = objEmpDropDown.Action,
                    P_StartId= objEmpDropDown.Stateid
                };
                var result = await Connection.QueryAsync<EmpDropDown>("Usp_Emp_profile_DropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    objListEmpDropDown = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objListEmpDropDown;
        }
        public MessageEF AddAddress(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                 p.Add("@P_Status"                ,objEmpProfileEf.Satus);
                 p.Add("@P_intEmployeeid"         ,objEmpProfileEf.intEmployeeid);
                 p.Add("@P_intAddressId"          ,objEmpProfileEf.intAddressId);
                 p.Add("@P_intPresentState"       ,objEmpProfileEf.intPresentState);
                 p.Add("@P_intPresentDistrict"    ,objEmpProfileEf.intPresentDistrict);
                 p.Add("@P_vchPresentAddress"     ,objEmpProfileEf.vchPresentAddress);
                 p.Add("@P_vchPresentPINCode"     ,objEmpProfileEf.vchPresentPINCode);
                 p.Add("@P_intPermanentState"     ,objEmpProfileEf.intPermanentState);
                 p.Add("@P_intPermanentDistrict"  ,objEmpProfileEf.intPermanentDistrict);
                 p.Add("@P_vchPermanentAddress"   ,objEmpProfileEf.vchPermanentAddress);
                 p.Add("@P_vchPermanentPINCode"   ,objEmpProfileEf.vchPermanentPINCode);                
                 p.Add("@P_BitdeletedFlage"       ,objEmpProfileEf.BitdeletedFlage );
                 p.Add("@P_intCreatedBy"          ,objEmpProfileEf.intCreatedBy);
                 //p.Add("@P_dateCreatedOn"         ,objEmpProfileEf.dateCreatedOn);
                 p.Add("@P_intUpdatedBy"          ,objEmpProfileEf.intCreatedBy);
                //p.Add("@P_dateUpdatedOn"          ,objEmpProfileEf.dateCreatedOn);

                //p.Add("@P_VchAadharCardPath", objEmpProfileEf.VchAadharCardPath);
                //p.Add("@P_VchSignaturePath", objEmpProfileEf.VchSignaturePath);
                //p.Add("@P_VchPhotoPath", objEmpProfileEf.VchPhotoPath);


                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_T_AdressMaster", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public MessageEF AddPostingAddress(EmpProfileEf objEmpProfileEf)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Status", objEmpProfileEf.Satus);
                p.Add("@P_intEmployeeid", objEmpProfileEf.intEmployeeid);
                p.Add("@P_intPostingid", objEmpProfileEf.intPostingid);
                p.Add("@P_intPostingDepartment", objEmpProfileEf.intPostingDepartment);
                p.Add("@P_intPostingDistrict", objEmpProfileEf.intPostingDistrict);
                p.Add("@P_IntOfficeLevel", objEmpProfileEf.IntOfficeLevel);

                p.Add("@P_DateOfJoining", DateTime.ParseExact(objEmpProfileEf.DateOfJoining, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));
                //p.Add("@P_DateOfJoining"               ,objEmpProfileEf.DateOfJoining);

                p.Add("@P_DateOfRetirement", DateTime.ParseExact(objEmpProfileEf.DateOfRetirement, "dd-MM-yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("en-GB")).ToString("dd-MMM-yyyy"));
                //p.Add("@P_DateOfRetirement"            ,objEmpProfileEf.DateOfRetirement);

                p.Add("@P_intEstablishmentoffice", objEmpProfileEf.intEstablishmentoffice);
                p.Add("@P_VchModeofRecruitment", objEmpProfileEf.VchModeofRecruitment);
                p.Add("@P_DecPayBand", objEmpProfileEf.DecPayBand);
                p.Add("@P_DecBasicPay", objEmpProfileEf.DecBasicPay);
                p.Add("@P_DecGradePay", objEmpProfileEf.DecGradePay);
                p.Add("@P_BitdeletedFlage", objEmpProfileEf.BitdeletedFlage);
                p.Add("@P_intCreatedBy", objEmpProfileEf.intCreatedBy);

                p.Add("@P_intSection", objEmpProfileEf.intSection);

                //p.Add("@P_dateCreatedOn"               ,objEmpProfileEf.dateCreatedOn);
                p.Add("@P_intUpdatedBy", objEmpProfileEf.intCreatedBy);

                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_T_EmployeePosting", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = Convert.ToString(newID);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessageEF;
        }
        public async Task<List<EmpProfileEf>> getList(EmpProfileEf objEmpProfileEf)
        {
            List<EmpProfileEf> objListEmpProfileEf = new List<EmpProfileEf>();
            try
            {
                var paramList = new
                {
                    P_Status = objEmpProfileEf.Satus,
                    P_intCreatedBy = objEmpProfileEf.intCreatedBy
                };
                var result = await Connection.QueryAsync<EmpProfileEf>("USP_T_EmployeePersonalDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objListEmpProfileEf = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objListEmpProfileEf;
        }
        public async Task<EmpProfileEf> ViewDetails(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                var paramList = new
                {
                    @intEmployeeid = objEmpProfileEf.intEmployeeid,
                    @P_intCreatedBy = objEmpProfileEf.intCreatedBy

                };
                var result =await Connection.QueryAsync<EmpProfileEf>("USP_EmpDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objEmpProfileEf = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objEmpProfileEf;
        }

        //public async Task<EmpProfileEf> GetUserId(EmpProfileEf objEmpProfileEf)
        //{
        //   EmpProfileEf objListEmpProfileEf = new EmpProfileEf();
        //    try
        //    {
        //        var paramList = new
        //        {
        //            @P_Status = objEmpProfileEf.Satus,
        //            @P_UserName = objEmpProfileEf.UserName
        //        };
        //        var result =await Connection.QueryAsync<EmpProfileEf>("USP_T_EmployeePersonalDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            objListEmpProfileEf = result.FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objListEmpProfileEf;
        //}

        public async Task<EmpProfileEf> ViewUserInformation(EmpProfileEf objEmpProfileEf)
        {
            try
            {
                var paramList = new
                {
                    @P_Chk = objEmpProfileEf.Satus,
                    @P_intUserid = objEmpProfileEf.intCreatedBy,
                    @P_intEmployeeid = objEmpProfileEf.intEmployeeid
                };
                var result = await Connection.QueryAsync<EmpProfileEf>("USP_EmpDetailsQuery", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objEmpProfileEf = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objEmpProfileEf;
        }

        #region LeaveInbox

        public async Task<List<EmployeeProfileInboxQuery>> ViewEmployeeProfileInbox(EmployeeProfileInboxQuery objApplyLeave)
        {
            List<EmployeeProfileInboxQuery> listApplyLeave = new List<EmployeeProfileInboxQuery>();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objApplyLeave.Check);
                p.Add("@P_intModuleId", objApplyLeave.intModuleId);
                p.Add("@P_intSubModuleId", objApplyLeave.intSubModuleId);
                p.Add("@P_CreatedBy", objApplyLeave.intCreatedBy);
                var output = await Connection.QueryAsync<EmployeeProfileInboxQuery>("uspProfileInbox_Query", p, commandType: CommandType.StoredProcedure);
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

        public async Task<EmployeeProfileInboxDetails> ViewEmployeeProfileInboxDetails(EmployeeProfileInboxDetails objProfile)
        {
            EmployeeProfileInboxDetails _objProfile = EmployeeProfileInboxDetails.GetInstance();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_chk", objProfile.Check);
                p.Add("@P_intModuleId", objProfile.intModuleId);
                p.Add("@P_intSubModuleId", objProfile.intSubModuleId);
                p.Add("@P_intEmployeeId", objProfile.intEmployeeid);
                p.Add("@P_CreatedBy", objProfile.intCreatedBy);
                var output = await Connection.QueryAsync<EmployeeProfileInboxDetails>("uspProfileInbox_Query", p, commandType: CommandType.StoredProcedure);
                if (output.Count() > 0)
                {
                    _objProfile = output.FirstOrDefault();
                }
                return _objProfile;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //public async Task<LeaveInboxDetails> ViewLeaveInboxDetails(LeaveInboxDetails objLeaveInbox)
        //{
        //    LeaveInboxDetails _objLeaveInbox = new LeaveInboxDetails();
        //    try
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@P_Chk", objLeaveInbox.Check);
        //        p.Add("@P_intLeaveId", objLeaveInbox.intLeaveId);
        //        p.Add("@P_CreatedBy", objLeaveInbox.intCreatedBy);
        //        var output = await Connection.QueryAsync<LeaveInboxDetails>("uspLeaveInbox_Query", p, commandType: CommandType.StoredProcedure);
        //        if (output.Count() > 0)
        //        {
        //            _objLeaveInbox = output.FirstOrDefault();
        //        }
        //        return _objLeaveInbox;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        public MessageEF ProfileTakeAction(EmployeeProfileInboxDetails objLeave)
        {
            MessageEF objMessageEF = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@P_Chk", objLeave.Check);
                p.Add("@P_intEmployeeid", objLeave.intEmployeeid);
                //p.Add("@P_intStatus", objLeave.intStatus);
                p.Add("@P_vchRemarks", objLeave.VchRemarks);
                p.Add("@P_intActionId", objLeave.IntActionId);
                p.Add("@P_intCreatedBy", objLeave.intCreatedBy);
                p.Add("@P_Message", dbType: DbType.Int32, direction: ParameterDirection.Output);
 Connection.Query<int>("uspWorkFlowAction", p, commandType: CommandType.StoredProcedure);
                //Connection.Query<int>("uspProfileInbox", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_Message");
                objMessageEF.Satus = newID.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            return objMessageEF;
        }
        //public async Task<List<LeaveDropDown>> BindActionType(LeaveDropDown objActionType)
        //{
        //    List<LeaveDropDown> _objListActionType = new List<LeaveDropDown>();
        //    try
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("@P_Chk", objActionType.Check);
        //        p.Add("@P_intLeaveId", objActionType.Id);
        //        p.Add("@P_intModuleId", objActionType.Id2);
        //        p.Add("@P_intSubModuleId", objActionType.Id3);
        //        var output = await Connection.QueryAsync<LeaveDropDown>("uspLeaveInbox_Query", p, commandType: CommandType.StoredProcedure);
        //        if (output.Count() > 0)
        //        {
        //            _objListActionType = output.ToList();
        //        }
        //        return _objListActionType;
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}

        #endregion
    }
}
