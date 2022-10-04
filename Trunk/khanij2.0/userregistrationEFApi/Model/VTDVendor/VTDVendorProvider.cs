using Dapper;
using MasterApi.Factory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using userregistrationEFApi.Repository;

namespace userregistrationEFApi.Model.VTDVendor
{
    public class VTDVendorProvider : RepositoryBase, IVTDVendorProvider
    {
        public VTDVendorProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region For VTD Vendor Registration
        /// <summary>
        /// Add VTD Vendor
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddVTDVendor(VTDVendorModel vTDVendorModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@Chk", 1);
                p.Add("@VTDVendorId", vTDVendorModel.VTDVendorId);
                p.Add("@CompanyName", vTDVendorModel.CompanyName);
                p.Add("@GST", vTDVendorModel.GST);
                p.Add("@Company_Corp_Address", vTDVendorModel.Company_Corp_Address);
                p.Add("@Company_Corp_State", vTDVendorModel.Company_Corp_State);
                p.Add("@Company_Corp_District", vTDVendorModel.Company_Corp_District);
                p.Add("@Company_Corp_Block", vTDVendorModel.Company_Corp_Block);
                p.Add("@Company_Corp_PinCode", vTDVendorModel.Company_Corp_PinCode);
                p.Add("@Company_Local_Address", vTDVendorModel.Company_Local_Address);
                p.Add("@Company_Local_State", vTDVendorModel.Company_Local_State);
                p.Add("@Company_Local_District", vTDVendorModel.Company_Local_District);
                p.Add("@Company_Local_Block", vTDVendorModel.Company_Local_Block);
                p.Add("@Company_Local_PinCode", vTDVendorModel.Company_Local_PinCode);
                p.Add("@Contact_Person_Name", vTDVendorModel.Contact_Person_Name);
                p.Add("@Contact_Person_MobileNo", vTDVendorModel.Contact_Person_MobileNo);
                p.Add("@Contact_Person_EmailId", vTDVendorModel.Contact_Person_EmailId);
                p.Add("@Transport_Dept_ApprovalLetter", vTDVendorModel.Transport_Dept_ApprovalLetter);
                p.Add("@Transport_Dept_ApprovalLetter_Path", vTDVendorModel.Transport_Dept_ApprovalLetter_Path);
                p.Add("@RegistrationNo", vTDVendorModel.RegistrationNo);
                p.Add("Is_Existing", 0);
                p.Add("Is_Approved", 0);
                p.Add("Is_Forwarded", 1);
                p.Add("@Contact_Person_Designation", vTDVendorModel.Contact_Person_Designation);
                p.Add("@Secondary_Contact_Person_Name", vTDVendorModel.Secondary_Contact_Person_Name);
                p.Add("@Secondary_Contact_Person_MobileNo", vTDVendorModel.Secondary_Contact_Person_MobileNo);
                p.Add("@Secondary_Contact_Person_EmailId", vTDVendorModel.Secondary_Contact_Person_EmailId);
                p.Add("@Secondary_Designation", vTDVendorModel.Secondary_Designation);
                p.Add("@CompanyId", vTDVendorModel.CompanyId);
                if (vTDVendorModel.VTDUserModelPortDetails != null)
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("ModelName");
                    dt.Columns.Add("PortNo");
                    for (var i = 0; i < vTDVendorModel.VTDUserModelPortDetails.Count; i++)
                    {
                        dt.Rows.Add();
                        dt.Rows[i]["ModelName"] = vTDVendorModel.VTDUserModelPortDetails[i].ModelName;
                        dt.Rows[i]["PortNo"] = vTDVendorModel.VTDUserModelPortDetails[i].PortNo;
                    }
                    p.Add("@VTDUserModelPortDetailsUDF", dt, DbType.Object);
                }

                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("uspInsertVTDUserData", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");

                string response = newID.ToString();
                objMessage.Satus = response;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Get VTD User Details By UserId
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<VTDVendorModel> GetVTDUserDetailsByUserId(VTDVendorModel vTDVendorModel)
        {
            try
            {
                var paramList = new
                {
                    ProfileUserId = vTDVendorModel.UserId,
                    Check = 1,


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<VTDVendorModel>("uspVTDUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    vTDVendorModel = result.FirstOrDefault();
                }
                return vTDVendorModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                vTDVendorModel = null;

            }
        }

        /// <summary>
        /// Get State Details
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetStateDetails(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<CommonAddressDetails>("select StateID,StateName from StateMaster where IsActive=1 and IsDelete=0", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// Get District Details By StateId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetDistrictDetailsByStateId(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<CommonAddressDetails>("select DistrictID,DistrictName from DistrictMaster where StateID='" + commonAddressDetails.StateID + "' and IsActive=1 and IsDelete=0", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// Get Block Details By DistrictId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public async Task<List<CommonAddressDetails>> GetBlockDetailsByDistrictId(CommonAddressDetails commonAddressDetails)
        {
            List<CommonAddressDetails> lstCommonAddressDetails = new List<CommonAddressDetails>();
            try
            {
                var paramList = new { };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<CommonAddressDetails>("select BlockId,BlockName from LeaseBlockMaster where DistrictId='" + commonAddressDetails.DistrictID + "' and ActiveStatus=1", paramList, commandType: System.Data.CommandType.Text);

                if (result.Count() > 0)
                {
                    lstCommonAddressDetails = result.ToList();
                }
                return lstCommonAddressDetails;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                lstCommonAddressDetails = null;
            }
        }

        /// <summary>
        /// View VTD All Request
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        public async Task<List<VTDVendorModel>> ViewVTDAllRequest(MessageEF messageEF)
        {
            List<VTDVendorModel> lstVTDVendorModel = new List<VTDVendorModel>();
            try
            {
                var paramList = new { Check = 2 };
                var result = await Connection.QueryAsync<VTDVendorModel>("uspVTDUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    lstVTDVendorModel = result.ToList();
                }
                return lstVTDVendorModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                lstVTDVendorModel = null;
            }
        }

        /// <summary>
        /// Get VTD New Request Details
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<VTDVendorModel> GetVTDNewRequestDetails(VTDVendorModel vTDVendorModel)
        {

            try
            {
                var paramList = new { Check = 3, USER_ID = vTDVendorModel.VTDVendorId };
                var result = await Connection.QueryAsync<VTDVendorModel>("uspVTDUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    vTDVendorModel = result.FirstOrDefault();
                }
                return vTDVendorModel;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                vTDVendorModel = null;
            }
        }

        /// <summary>
        /// Approve End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> ApproveVTDUser(VTDVendorModel vTDVendorModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Mode", "NEW PROFILE");
                p.Add("Action", "APPROVED");
                p.Add("VTDUserId", vTDVendorModel.VTDVendorId);
                p.Add("Remarks", vTDVendorModel.Remarks);
                p.Add("ProfileUserId", vTDVendorModel.UserId);
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                await Connection.QueryAsync<string>("uspVTDUserProfileApprovalProcess", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");
                objMessage.Msg = Res.ToString();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Reject End User
        /// </summary>
        /// <param name="objER"></param>
        /// <returns></returns>
        public async Task<MessageEF> RejectVTDUser(VTDVendorModel vTDVendorModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("Mode", "NEW PROFILE");
                p.Add("Action", "REJECT");
                p.Add("VTDUserId", vTDVendorModel.VTDVendorId);
                p.Add("Remarks", vTDVendorModel.Remarks);
                p.Add("ProfileUserId", vTDVendorModel.UserId);
                p.Add("Result", dbType: DbType.String, direction: ParameterDirection.Output, size: 5215585);
                await Connection.QueryAsync<string>("uspVTDUserProfileApprovalProcess", p, commandType: CommandType.StoredProcedure);
                string Res = p.Get<string>("Result");
                objMessage.Msg = Res.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        /// <summary>
        /// Action Taken Request
        /// </summary>
        /// <param name="OBJEU"></param>
        /// <returns></returns>
        public async Task<List<ForceFullDataVTDUser>> VTDActionTakenRequest(VTDVendorModel vTDVendorModel)
        {
            List<ForceFullDataVTDUser> ListForceFullDataVTDUser = new List<ForceFullDataVTDUser>();
            try
            {
                var paramList = new { Check = 4, USER_ID = vTDVendorModel.UserId };
                var result = await Connection.QueryAsync<ForceFullDataVTDUser>("uspVTDUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListForceFullDataVTDUser = result.ToList();
                }
                return ListForceFullDataVTDUser;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ListForceFullDataVTDUser = null;
            }

        }

        /// <summary>
        /// VTD User DataView
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public async Task<VTDVendorModel> VTDUserDataView(VTDVendorModel vTDVendorModel)
        {
            try
            {
                var paramList = new
                {
                    USER_ID = vTDVendorModel.VTDVendorId,
                    Check = 5,


                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<VTDVendorModel>("uspVTDUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    vTDVendorModel = result.FirstOrDefault();
                }
                return vTDVendorModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                vTDVendorModel = null;

            }
        }
        #endregion
        #region For VTD Vendor View,Update Profile
        /// <summary>
        /// View,Update VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        public async Task<Result<VTDVendorProfileModel>> VTDUserProfileDataView(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            Result<VTDVendorProfileModel> result = new Result<VTDVendorProfileModel>();
            try
            {
                var paramList = new
                {
                    VCH_USERNAME = objVTDVendorProfileModel.UserName,
                    INT_ACTION = 1,
                };
                DynamicParameters param = new DynamicParameters();
                var res = await Connection.QueryAsync<VTDVendorProfileModel>("[USP_VIEW_UPDATE_VTDVENDOR_PROFILE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (res.Count() > 0)
                {
                    result.Data = res.FirstOrDefault();
                    result.Status = true;
                    result.Message = new List<string>() { "Successfull!" };
                }
                else
                {
                    result.Data = null;
                    result.Status = false;
                    result.Message = new List<string>() { "Failed!" };

                }
                return result;
            }
            catch (Exception ex)
            {
                result.Status = false;
                result.Message.Add("Exception Occured! - " + ex.Message.ToString());
                return result;
            }
            finally
            {
                objVTDVendorProfileModel = null;
                result = null;
            }
        }
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateVTDVendor(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@INT_ACTION", 2);
                p.Add("@VTDVendorId", objVTDVendorProfileModel.VTDvendorId);
                //p.Add("@CompanyName", objVTDVendorProfileModel.CompanyName);
                p.Add("@GST", objVTDVendorProfileModel.GSTNo);
                p.Add("@Company_Corp_Address", objVTDVendorProfileModel.CorpAddress);
                p.Add("@Company_Corp_State", objVTDVendorProfileModel.CorpStateId);
                p.Add("@Company_Corp_District", objVTDVendorProfileModel.CorpDistrictId);
                p.Add("@Company_Corp_Block", objVTDVendorProfileModel.CorpBlockName);
                p.Add("@Company_Corp_PinCode", objVTDVendorProfileModel.CorpPincode);
                p.Add("@Company_Local_Address", objVTDVendorProfileModel.LocalAddress);
                p.Add("@Company_Local_State", objVTDVendorProfileModel.LocalStateId);
                p.Add("@Company_Local_District", objVTDVendorProfileModel.LocalDistrictId);
                p.Add("@Company_Local_Block", objVTDVendorProfileModel.LocalBlockId);
                p.Add("@Company_Local_PinCode", objVTDVendorProfileModel.LocalPincode);
                p.Add("@Contact_Person_Name", objVTDVendorProfileModel.PrimaryContactName);
                p.Add("@Contact_Person_MobileNo", objVTDVendorProfileModel.PrimaryContactMobileNo);
                p.Add("@Contact_Person_EmailId", objVTDVendorProfileModel.PrimaryContactEmailId);
                p.Add("@Transport_Dept_ApprovalLetter", objVTDVendorProfileModel.Transport_Dept_ApprovalLetter);
                p.Add("@Transport_Dept_ApprovalLetter_Path", objVTDVendorProfileModel.Transport_Dept_ApprovalLetter_Path);
                p.Add("@UserId", objVTDVendorProfileModel.UserId);
                p.Add("@UserLoginId", objVTDVendorProfileModel.UserLoginId);
                p.Add("@Contact_Person_Designation", objVTDVendorProfileModel.PrimaryContactDesignation);
                p.Add("@Secondary_Contact_Person_Name", objVTDVendorProfileModel.SecondaryContactName);
                p.Add("@Secondary_Contact_Person_MobileNo", objVTDVendorProfileModel.SecondaryContactMobileNo);
                p.Add("@Secondary_Contact_Person_EmailId", objVTDVendorProfileModel.SecondaryContactEmailId);
                p.Add("@Secondary_Designation", objVTDVendorProfileModel.SecondaryContactDesignation); 
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("[USP_VIEW_UPDATE_VTDVENDOR_PROFILE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        public async Task<MessageEF> CheckMobileNoOnUpdate(TransporterModel transporterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {

                DynamicParameters param = new DynamicParameters();
                
                string result = await Connection.ExecuteScalarAsync<string>("select top 1 MobileNo from UserMaster join UserTypeMaster ON UserMaster.UserTypeId=UserTypeMaster.UserTypeId where UserMaster.IsActive=1 and UserMaster.IsDelete=0 AND UserTypeMaster.UserType='" + transporterModel.UserType + "' and UserMaster.MobileNo='" + transporterModel.MobileNo + "'and UserMaster.UserId='" + transporterModel.UserId +"'", param, commandType: System.Data.CommandType.Text);

                messageEF.Satus = result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        public async Task<MessageEF> GetOTPOnUpdate(TransporterModel transporterModel)
        {
            MessageEF messageEF = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@MobileNo", transporterModel.MobileNo);
                p.Add("@EmailId", transporterModel.EmailID);
                p.Add("@chk", "GET_OTP");
                var OTP = await Connection.ExecuteScalarAsync<string>("USP_OTPVerification", p, commandType: CommandType.StoredProcedure);
                if (!string.IsNullOrEmpty(OTP.ToString()))
                {
                    messageEF.Satus = OTP.ToString();

                }
                else
                {
                    messageEF.Satus = string.Empty;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return messageEF;
        }
        #endregion
    }
}
