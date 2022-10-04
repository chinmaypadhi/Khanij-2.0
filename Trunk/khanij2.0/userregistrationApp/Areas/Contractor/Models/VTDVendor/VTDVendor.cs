using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.VTDVendor
{
    public class VTDVendor : IVTDVendor
    {

        IHttpWebClients _objIHttpWebClients;
        public VTDVendor(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region For VTD Vendor Registration
        /// <summary>
        /// Add VTD Vendor
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public MessageEF AddVTDVendor(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VTDVendorReg/AddVTDVendor", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get VTD User Details By UserId
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public VTDVendorModel GetVTDUserDetailsByUserId(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<VTDVendorModel>(_objIHttpWebClients.PostRequest("VTDVendorReg/GetVTDUserDetailsByUserId", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


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

        /// <summary>
        /// Get State Details
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetStateDetails(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("VTDVendorReg/GetStateDetails", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get District Details By StateId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetDistrictDetailsByStateId(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("VTDVendorReg/GetDistrictDetailsByStateId", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get BlockDetails By DistrictId
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetBlockDetailsByDistrictId(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("VTDVendorReg/GetBlockDetailsByDistrictId", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// View VTD All Request
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        public List<VTDVendorModel> ViewVTDAllRequest(MessageEF messageEF)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<VTDVendorModel>>(_objIHttpWebClients.PostRequest("VTDVendorReg/ViewVTDAllRequest", JsonConvert.SerializeObject(messageEF)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get VTD New Request Details
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public VTDVendorModel GetVTDNewRequestDetails(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<VTDVendorModel>(_objIHttpWebClients.PostRequest("VTDVendorReg/GetVTDNewRequestDetails", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Approve VTD User
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public MessageEF ApproveVTDUser(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VTDVendorReg/ApproveVTDUser", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Reject VTD User
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public MessageEF RejectVTDUser(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VTDVendorReg/RejectVTDUser", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Action Taken Request
        /// </summary>
        /// <param name="vTDVendorModel"></param>
        /// <returns></returns>
        public List<ForceFullDataVTDUser> VTDActionTakenRequest(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ForceFullDataVTDUser>>(_objIHttpWebClients.PostRequest("VTDVendorReg/VTDActionTakenRequest", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public VTDVendorModel VTDUserDataView(VTDVendorModel vTDVendorModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<VTDVendorModel>(_objIHttpWebClients.PostRequest("VTDVendorReg/VTDUserDataView", JsonConvert.SerializeObject(vTDVendorModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region For VTD Vendor View,Update Profile
        /// <summary>
        /// View,Update VTD Vendor Profile details
        /// </summary>
        /// <param name="ObjVTDVendorProfileModel"></param>
        /// <returns></returns>
        public VTDVendorProfileModel VTDUserProfileDataView(VTDVendorProfileModel ObjVTDVendorProfileModel)
        {
            try
            {
                Result<VTDVendorProfileModel> objVTDVendorProfileModel = new Result<VTDVendorProfileModel>();
                objVTDVendorProfileModel = JsonConvert.DeserializeObject<Result<VTDVendorProfileModel>>(_objIHttpWebClients.PostRequest("VTDVendorReg/VTDUserProfileDataView", JsonConvert.SerializeObject(ObjVTDVendorProfileModel)));
                return objVTDVendorProfileModel.Data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit VTD Vendor Profile details
        /// </summary>
        /// <param name="objVTDVendorProfileModel"></param>
        /// <returns></returns>
        public MessageEF UpdateVTDVendor(VTDVendorProfileModel objVTDVendorProfileModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("VTDVendorReg/UpdateVTDVendor", JsonConvert.SerializeObject(objVTDVendorProfileModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
