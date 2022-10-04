using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using Newtonsoft.Json;
using PermitApp.Models.Utility;

namespace PermitApp.Areas.Permit.Models.Lessee
{
    public class LesseePermitModel : ILesseePermitModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public LesseePermitModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        public ePermitResult GetCoalMineralNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetCoalMineralNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralGradeListOnNatureList(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetMineralGradeListOnNatureList", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddBulkPermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddBulkPermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF AddMergeBulkPermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddMergeBulkPermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult CheckTotalPermitByUser(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/CheckTotalPermitByUser", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitDetailsByUserID(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetPermitDetailsByUserID", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitOperation(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetPermitOperation", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitOperationByBulkId(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetPermitOperationByBulkId", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GradeWiseCheckECQTY(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GradeWiseCheckECQTY", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePaymentData> RevisedPayableRoyaltyRate(ePermitModel objPermit)
        {
            try
            {
                List<ePaymentData> objlistNotice = new List<ePaymentData>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePaymentData>>(_objIHttpWebClients.PostRequest("Permit/RevisedPayableRoyaltyRate", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePaymentData> MergeRevisedPayableRoyaltyRate(ePermitModel objPermit)
        {
            try
            {
                List<ePaymentData> objlistNotice = new List<ePaymentData>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePaymentData>>(_objIHttpWebClients.PostRequest("Permit/MergeRevisedPayableRoyaltyRate", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetePermitPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetePermitPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetMergePermitList(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetMergePermitList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMergePermitMineralGrade(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetMergePermitMineralGrade", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult MergeEpermitOperation(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/MergeEpermitOperation", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetMineralNatureName(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetMineralNatureName", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetBulkPermitDetails(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetBulkPermitDetails", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetApprovedBulkPermitDetails(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetApprovedBulkPermitDetails", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitViewWithoutDSC(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetPermitViewWithoutDSC", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult GetPermitTransDetails(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetPermitTransDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<LicenseInfoRPTP> GetRPTPPendingPermitList(ePermitModel objPermit)
        {
            try
            {
                List<LicenseInfoRPTP> objlistNotice = new List<LicenseInfoRPTP>();
                objlistNotice = JsonConvert.DeserializeObject<List<LicenseInfoRPTP>>(_objIHttpWebClients.PostRequest("Permit/GetRPTPPendingPermitList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LicenseeRPTPResult GetLicenseeRPTPPermit(LicenseInfoRPTP objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeRPTPResult>(_objIHttpWebClients.PostRequest("Permit/GetLicenseeRPTPPermit", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LicenseeRPTPResult GetLicenseeRPTPClosingPermit(LicenseInfoRPTP objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeRPTPResult>(_objIHttpWebClients.PostRequest("Permit/GetLicenseeRPTPClosingPermit", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<LicenseInfoRPTP> GetDGMApprovedRPTPList(LicenseInfoRPTP objPermit)
        {
            try
            {
                List<LicenseInfoRPTP> objlistNotice = new List<LicenseInfoRPTP>();
                objlistNotice = JsonConvert.DeserializeObject<List<LicenseInfoRPTP>>(_objIHttpWebClients.PostRequest("Permit/GetDGMApprovedRPTPList", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF ArchviveUnArchivePermit(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/ArchviveUnArchivePermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF AddRPTPBulkPermit(LicenseInfoRPTP objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddRPTPBulkPermit", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<LicenseInfoRPTP> getRPTPDetails(LicenseInfoRPTP objPermit)
        {
            try
            {
                List<LicenseInfoRPTP> objlistNotice = new List<LicenseInfoRPTP>();
                objlistNotice = JsonConvert.DeserializeObject<List<LicenseInfoRPTP>>(_objIHttpWebClients.PostRequest("Permit/getRPTPDetails", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// check for merge permit data
        /// </summary>
        /// <param name="objPermit"></param>
        /// <returns></returns>
        public ePermitResult CheckMergePermitDetails(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/CheckMergePermitDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get the details of Mergepermit
        /// </summary>
        /// <param name="objUser"></param>
        /// <returns></returns>
        public ePermitResult GetMergePermitTransDetails(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetMergePermitTransDetails", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillUserType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillUserType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillState(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillState", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillDistrict(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillDistrict", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillModuleType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillModuleType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ePermitResult FillSubModuleType(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/FillSubModuleType", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetCheckListData(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetCheckListData", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddRiderConfigMaster(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddRiderConfigMaster", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> ViewRiderConfigMaster(ePermitModel objPermit)
        {
            try
            {
                List<ePermitModel> objlistNotice = new List<ePermitModel>();
                objlistNotice = JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/ViewRiderConfigMaster", JsonConvert.SerializeObject(objPermit)));
                return objlistNotice;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF DeleteRiderConfigMaster(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/DeleteRiderConfigMaster", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult EditRiderConfigMaster(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/EditRiderConfigMaster", JsonConvert.SerializeObject(objPermit)));
               

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF CheckOutPayment(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/CheckOutPayment", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ePermitResult GetCheckOutPermitPayment(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetCheckOutPermitPayment", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetPermitQuantity(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetPermitQuantity", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public List<ePermitModel> GetTotalPermitByUser(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetTotalPermitByUser", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF AddTotalPermitByUser(ePermitModel objPermit)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddTotalPermitByUser", JsonConvert.SerializeObject(objPermit)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<ePermitModel> GetPermitColosingDtls(ePermitModel objPermit)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<ePermitModel>>(_objIHttpWebClients.PostRequest("Permit/GetPermitColosingDtls", JsonConvert.SerializeObject(objPermit)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public MessageEF AddWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/AddWeighbridge", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            } 
        }

        public MessageEF UpdateWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/UpdateWeighbridge", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PermitWeighBridgeMapp EditWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<PermitWeighBridgeMapp>(_objIHttpWebClients.PostRequest("Permit/EditWeighbridge", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<PermitWeighBridgeMapp> ViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<List<PermitWeighBridgeMapp>>(_objIHttpWebClients.PostRequest("Permit/ViewWeighbridge", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF DeleteWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Permit/DeleteWeighbridge", JsonConvert.SerializeObject(objUser)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PermitWeighBridgeMapp FilterViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<PermitWeighBridgeMapp>(_objIHttpWebClients.PostRequest("Permit/FilterViewWeighbridge", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitResult GetSECLDODetails(ePermitModel objUser)
        {
            try
            {
                return JsonConvert.DeserializeObject<ePermitResult>(_objIHttpWebClients.PostRequest("Permit/GetSECLDODetails", JsonConvert.SerializeObject(objUser)));

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ePermitModel GetTaggedDetails(ePermitModel objUser)
        {
            return JsonConvert.DeserializeObject<ePermitModel>(_objIHttpWebClients.PostRequest("Permit/GetTaggedDetails", JsonConvert.SerializeObject(objUser)));
        }
    }

}
