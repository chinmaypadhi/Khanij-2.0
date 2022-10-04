using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.UserInformation
{
    public class UserInformationModel:IUserInformationModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public UserInformationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        public LesseeResult LeaseTypeView(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/LeaseTypeView", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LesseeResult GetAuctionIDList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetAuctionIDList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ApplicationResult GetApplicationData(UserInformationEF objNotice)
        {
            try
            {
                // MessageEF objMessageEF = new MessageEF();
                // objMessageEF = JsonConvert.DeserializeObject<UserTypeResult>(SupportApp.Models.Utility.HttpWebClients.PostRequest("NoticeLetter/ManageUserTypeView", objNotice));
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetApplicationData", JsonConvert.SerializeObject(objNotice)));
                //  return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF SaveApplication(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/SaveApplication", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLesseeApplicationDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLesseeApplicationDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLesseeApplicationDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLesseeApplicationDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetGrantOrder(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetGrantOrder", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetProfileCount(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetProfileCount", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF SaveGrantDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/SaveGrantDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLesseeGrantDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLesseeGrantDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLesseeGrantDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLesseeGrantDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetLeaseArea(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLeaseArea", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetLesseeProfileStatus(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLesseeProfileStatus", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public LesseeResult GetStateList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetStateList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LesseeResult GetDistrictList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetDistrictList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LesseeResult GetTehsilList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetTehsilList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public LesseeResult GetVillageList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetVillageList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public MessageEF SaveLeaseArea(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/SaveLeaseArea", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLesseeAreaDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLesseeAreaDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLesseeAreaDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLesseeAreaDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetMineralCategory(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetMineralCategory", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ApplicationResult GetMineralNameFromMineralType(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetMineralNameFromMineralType", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ApplicationResult GetLicenseeIBMDetail(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLicenseeIBMDetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF NewLicenseeIBMDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/NewLicenseeIBMDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateLicenseeIBMDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/UpdateLicenseeIBMDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLicenseeIBMDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLicenseeIBMDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLicenseeIBMDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLicenseeIBMDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public LesseeResult GetMiningPlanYearList(UserInformationEF objNotice)
        {
            try
            {
                return JsonConvert.DeserializeObject<LesseeResult>(_objIHttpWebClients.PostRequest("UserInformation/GetMiningPlanYearList", JsonConvert.SerializeObject(objNotice)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ApplicationResult GetMiningPlanData(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetMiningPlanData", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF SaveMiningPlanData(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/SaveMiningPlanData", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLesseeMiningDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLesseeMiningDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLesseeMiningDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLesseeMiningDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetForestClearence(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetForestClearence", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF SaveForestClearenceDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/SaveForestClearenceDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLesseeForestDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLesseeForestDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLesseeForestDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLesseeForestDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetLicenseeEnvDetail(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLicenseeEnvDetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF NewLicenseeEnvDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/NewLicenseeEnvDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateLicenseeEnvironmentDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/UpdateLicenseeEnvironmentDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLicenseeECDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLicenseeECDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLicenseeECDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLicenseeECDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetLicenseeCTEDetail(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLicenseeCTEDetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF NewLicenseeCTEDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/NewLicenseeCTEDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateLicenseeCTEDetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/UpdateLicenseeCTEDetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLicenseeCTEDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLicenseeCTEDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLicenseeCTEDetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLicenseeCTEDetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetLicenseeCTODetail(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetLicenseeCTODetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF NewLicenseeCTODetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/NewLicenseeCTODetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateLicenseeCTODetail(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/UpdateLicenseeCTODetail", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveLicenseeCTODetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveLicenseeCTODetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectLicenseeCTODetails(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectLicenseeCTODetails", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ApplicationResult GetAssesmentReport(UserInformationEF objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationResult>(_objIHttpWebClients.PostRequest("UserInformation/GetAssesmentReport", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF NewAssesmentReport(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/NewAssesmentReport", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF UpdateAssessmentReport(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/UpdateAssessmentReport", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF ApproveAssessmentReport(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/ApproveAssessmentReport", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public MessageEF RejectAssessmentReport(UserInformationEF objNotice)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformation/RejectAssessmentReport", JsonConvert.SerializeObject(objNotice)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

}
