using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using userregistrationApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace userregistrationApp.Areas.EndUserRegistration.Models
{
    public class EndUserRegModel: IEndUserRegModel
    {

        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public EndUserRegModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Get OTP details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>EndUserModel class</returns>
        public EndUserModel GetOTPModel(EndUserModel ObjEU)
        {
            try
            {
                ObjEU = JsonConvert.DeserializeObject<EndUserModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetOTP",JsonConvert.SerializeObject(ObjEU)));
                return ObjEU;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get Industry Type Class
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetIndustryType class</returns>
        public GetIndustryType GetIType(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetIndustryType>(_objIHttpWebClients.PostRequest("EndUserReg/ViewIType",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get List of state
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetState(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLState",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get List of DIstrict
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState classw</returns>
        public GetListState GetDistrict(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLDistrict",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get List of state other
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState</returns>
        public GetListState GetState_O(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLState_O",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get List of district Other
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetDistrict_O(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLDistrict_O",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get Securict Questions
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetSQ(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/ViewLSQ",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get All Mineral Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetMineral(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineral",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get all Mineral Form
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetMineralForm(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineralForm",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get all mineral Grade
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>GetListState class</returns>
        public GetListState GetMineralGrade(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<GetListState>(_objIHttpWebClients.PostRequest("EndUserReg/GetMineralGrade",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Verify OTP
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF VerifyOTP(EndUserModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();        
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/OTPVerify",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Add End User
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF AddEuser(EndUserModel ObjEU)
        {
            try
            {
               
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/AddEndUser",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get User Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>EndUserModel class</returns>
        public EndUserModel GetUDModel(EndUserModel ObjEU)
        {
            try
            {
                ObjEU = JsonConvert.DeserializeObject<EndUserModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetUserDet",JsonConvert.SerializeObject(ObjEU)));
                return ObjEU;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// View all End User Data
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of EndUserModel</returns>
        public List<EndUserModel> ViewAllReport(EndUserModel objEU)
        {
            try
            {
                List<EndUserModel> objlistDP = new List<EndUserModel>();
                objlistDP = JsonConvert.DeserializeObject<List<EndUserModel>>(_objIHttpWebClients.PostRequest("EndUserReg/ViewAllReport",JsonConvert.SerializeObject(objEU)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get all user wise data
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>EndUserBasicInfoModel class</returns>
        public EndUserBasicInfoModel GetallUserWiseData(EndUserModel ObjEU)
        {
            EndUserBasicInfoModel OBJdt;
            try
            {
                OBJdt = JsonConvert.DeserializeObject<EndUserBasicInfoModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetNewRequsetUserWise",JsonConvert.SerializeObject(ObjEU)));
                return OBJdt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Approve End User Data
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF ApproveEuser(EndUserBasicInfoModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/ApproveEndUser",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get all End User Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns></returns>
        public EndUserBasicInfoModel GetallUserDataDetails(EndUserBasicInfoModel ObjEU)
        {
            EndUserBasicInfoModel OBJdt;
            try
            {
                OBJdt = JsonConvert.DeserializeObject<EndUserBasicInfoModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetUDetails",JsonConvert.SerializeObject(ObjEU)));
                return OBJdt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Reject End USer Data
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF RejectEuser(EndUserBasicInfoModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/RejectEndUser",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// View all end user updated data
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of EndUserModel</returns>
        public List<EndUserModel> ViewUpdationReport(EndUserModel objEU)
        {
            try
            {
                List<EndUserModel> objlistDP = new List<EndUserModel>();
                objlistDP = JsonConvert.DeserializeObject<List<EndUserModel>>(_objIHttpWebClients.PostRequest("EndUserReg/ViewUpdationReport",JsonConvert.SerializeObject(objEU)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get all action taken report
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of ForceFullDataEndUser</returns>
        public List<ForceFullDataEndUser> AllActionTakenReport(EndUserModel objEU)
        {
            try
            {
                List<ForceFullDataEndUser> objlistDP = new List<ForceFullDataEndUser>();
                objlistDP = JsonConvert.DeserializeObject<List<ForceFullDataEndUser>>(_objIHttpWebClients.PostRequest("EndUserReg/ActionTakenReport",JsonConvert.SerializeObject(objEU)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get action taken user wise data
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>EndUserBasicInfoModel class</returns>
        public EndUserBasicInfoModel GetActionTakenUserWiseData(EndUserModel ObjEU)
        {
            EndUserBasicInfoModel OBJdt;
            try
            {
                OBJdt = JsonConvert.DeserializeObject<EndUserBasicInfoModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetActionTakenUserWise",JsonConvert.SerializeObject(ObjEU)));
                return OBJdt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// View End User Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF ViewEndUserDetails(EndUserBasicInfoModel ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/GetEuserStatus",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// Get end user status
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>EndUserModel class</returns>
        public EndUserModel GetEuserStatus(EndUserModel ObjEU)
        {
            EndUserModel OBJdt;
            try
            {
                OBJdt = JsonConvert.DeserializeObject<EndUserModel>(_objIHttpWebClients.PostRequest("EndUserReg/GetEuserStatusDEt",JsonConvert.SerializeObject(ObjEU)));
                return OBJdt;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// View End User Profile Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF ViewEndUserProfDetails(EndUserModel1 ObjEU)
        {
            try
            {
                List<EndUserModel> objlistDD = new List<EndUserModel>();
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("EndUserReg/GetEuserProfileStatus",JsonConvert.SerializeObject(ObjEU)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #region Update Encrypted Password
        /// <summary>
        /// Update Encrypted Password
        /// </summary>
        /// <param name="updateEncryptPasswordModel"></param>
        /// <returns></returns>
        public MessageEF UpdateEncryptPassword(UpdateEncryptPasswordModel updateEncryptPasswordModel)
        {
            try
            {

                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LicenseApplication/UpdateEncryptPassword", JsonConvert.SerializeObject(updateEncryptPasswordModel)));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
