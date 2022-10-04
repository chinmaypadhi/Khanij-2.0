using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationApp.Models.Utility;
using userregistrationEF;

namespace userregistrationApp.Areas.Contractor.Models.TailingDam
{
    public class TailingDamModel : ITailingDamModel
    {
        IHttpWebClients _objIHttpWebClients;
        public TailingDamModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Add TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public MessageEF AddTailingDam(cls_TailingDam tailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TailingDam/AddTailingDam", JsonConvert.SerializeObject(tailingDam)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Company List
        /// </summary>
        /// <param name="companyDetails"></param>
        /// <returns></returns>
        public List<CompanyDetails> GetCompanyList(CompanyDetails companyDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CompanyDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetCompanyList", JsonConvert.SerializeObject(companyDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get State District List
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetStateDistrictList(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetStateDistrictList", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Tehsil List By DistrictID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetTehsilListByDistrictID(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetTehsilListByDistrictID", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get village From TehsilID
        /// </summary>
        /// <param name="commonAddressDetails"></param>
        /// <returns></returns>
        public List<CommonAddressDetails> GetvillageFromTehsilID(CommonAddressDetails commonAddressDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<CommonAddressDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetvillageFromTehsilID", JsonConvert.SerializeObject(commonAddressDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Type Of Site List
        /// </summary>
        /// <param name="messageEF"></param>
        /// <returns></returns>
        public List<TypeOfSite> GetTypeOfSiteList(MessageEF messageEF)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<TypeOfSite>>(_objIHttpWebClients.PostRequest("TailingDam/GetTypeOfSiteList", JsonConvert.SerializeObject(messageEF)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get MineralType List_TailingDam
        /// </summary>
        /// <param name="mineralType"></param>
        /// <returns></returns>
        public List<MineralType> GetMineralTypeList_TailingDam(MineralType mineralType)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<MineralType>>(_objIHttpWebClients.PostRequest("TailingDam/GetMineralTypeList_TailingDam", JsonConvert.SerializeObject(mineralType)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Cascade Mineral
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public List<MineralDetails> GetCascadeMineral(MineralDetails mineralDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<MineralDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetCascadeMineral", JsonConvert.SerializeObject(mineralDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Cascade MineralNature
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public List<MineralDetails> GetCascadeMineralNature(MineralDetails mineralDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<MineralDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetCascadeMineralNature", JsonConvert.SerializeObject(mineralDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Get Cascade MineralGrade
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public List<MineralDetails> GetCascadeMineralGrade(MineralDetails mineralDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<MineralDetails>>(_objIHttpWebClients.PostRequest("TailingDam/GetCascadeMineralGrade", JsonConvert.SerializeObject(mineralDetails)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #region Update Tailing dam profile details
        /// <summary>
        /// Bind Profile details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        public cls_TailingDam GetProfileDetails(cls_TailingDam objcls_TailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<cls_TailingDam>(_objIHttpWebClients.PostRequest("TailingDam/GetProfileDetails", JsonConvert.SerializeObject(objcls_TailingDam)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public MessageEF UpdateTailingDam(cls_TailingDam tailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TailingDam/UpdateTailingDam", JsonConvert.SerializeObject(tailingDam)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region Update Royalty details of Lessee/Licensee users
        /// <summary>
        /// Update TailingDam
        /// </summary>
        /// <param name="tailingDam"></param>
        /// <returns></returns>
        public MessageEF UpdateRoyaltyPay(cls_TailingDam tailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TailingDam/UpdateRoyaltyPay", JsonConvert.SerializeObject(tailingDam)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Existing User Details
        /// <summary>
        /// Get Existing user details in view
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        public cls_TailingDam GetExistingUserDetails(cls_TailingDam objcls_TailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<cls_TailingDam>(_objIHttpWebClients.PostRequest("TailingDam/GetExistingUserDetails", JsonConvert.SerializeObject(objcls_TailingDam)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
        #region DD View/Approve Tailing Dam details
        /// <summary>
        /// Get TailingDumpDDApprove
        /// </summary>
        /// <param name="objTailingDumpDDApprove"></param>
        /// <returns></returns>
        public List<cls_TailingDam>ViewTailingDumpDDApprove(cls_TailingDam objTailingDumpDDApprove)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<cls_TailingDam>>(_objIHttpWebClients.PostRequest("TailingDam/View", JsonConvert.SerializeObject(objTailingDumpDDApprove)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Approve Tailing dam details by DD
        /// </summary>
        /// <param name="objcls_TailingDam"></param>
        /// <returns></returns>
        public MessageEF TailingDumpDDApprove(cls_TailingDam tailingDam)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("TailingDam/TailingDumpDDApprove", JsonConvert.SerializeObject(tailingDam)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
