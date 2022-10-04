using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MasterApi.Model.UserInformation;
using MasterEF;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class UserInformationController : Controller
    {
        public IUserInformationProvider _objIUserInformationProvider;
        public UserInformationController(IUserInformationProvider objIUserInformationProvider)
        {
            _objIUserInformationProvider = objIUserInformationProvider;
        }
        [HttpPost]
        public LesseeResult LeaseTypeView(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.LeaseTypeView(objLease);
        }
        [HttpPost]
        public LesseeResult GetAuctionIDList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetAuctionIDList(objLease);
        }
        [HttpPost]
        public ApplicationResult GetApplicationData(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetApplicationData(objLease);
        }
        [HttpPost]
        public MessageEF SaveApplication(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.SaveApplication(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLesseeApplicationDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLesseeApplicationDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLesseeApplicationDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLesseeApplicationDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetGrantOrder(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetGrantOrder(objLease);
        }
        [HttpPost]
        public ApplicationResult GetProfileCount(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetProfileCount(objLease);
        }
        [HttpPost]
        public MessageEF SaveGrantDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.SaveGrantDetails(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLesseeGrantDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLesseeGrantDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLesseeGrantDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLesseeGrantDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLeaseArea(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLeaseArea(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLesseeProfileStatus(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLesseeProfileStatus(objLease);
        }
        [HttpPost]
        public LesseeResult GetStateList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetStateList(objLease);
        }
        [HttpPost]
        public LesseeResult GetDistrictList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetDistrictList(objLease);
        }
        [HttpPost]
        public LesseeResult GetTehsilList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetTehsilList(objLease);
        }
        [HttpPost]
        public LesseeResult GetVillageList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetVillageList(objLease);
        }
        [HttpPost]
        public MessageEF SaveLeaseArea(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.SaveLeaseArea(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLesseeAreaDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLesseeAreaDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLesseeAreaDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLesseeAreaDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetMineralCategory(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetMineralCategory(objLease);
        }
        [HttpPost]
        public ApplicationResult GetMineralNameFromMineralType(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetMineralNameFromMineralType(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLicenseeIBMDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLicenseeIBMDetail(objLease);
        }
        [HttpPost]
        public MessageEF NewLicenseeIBMDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.NewLicenseeIBMDetail(objLease);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeIBMDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.UpdateLicenseeIBMDetail(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeIBMDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLicenseeIBMDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLicenseeIBMDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLicenseeIBMDetails(objLease);
        }
        [HttpPost]
        public LesseeResult GetMiningPlanYearList(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetMiningPlanYearList(objLease);
        }
        [HttpPost]
        public ApplicationResult GetMiningPlanData(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetMiningPlanData(objLease);
        }
        [HttpPost]
        public ApplicationResult GetForestClearence(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetForestClearence(objLease);
        }
        [HttpPost]
        public MessageEF SaveForestClearenceDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.SaveForestClearenceDetails(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLesseeForestDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLesseeForestDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLesseeForestDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLesseeForestDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLicenseeEnvDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLicenseeEnvDetail(objLease);
        }
        [HttpPost]
        public MessageEF NewLicenseeEnvDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.NewLicenseeEnvDetail(objLease);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeEnvironmentDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.UpdateLicenseeEnvironmentDetail(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeECDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLicenseeECDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLicenseeECDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLicenseeECDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLicenseeCTEDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLicenseeCTEDetail(objLease);
        }
        [HttpPost]
        public MessageEF NewLicenseeCTEDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.NewLicenseeCTEDetail(objLease);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeCTEDetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.UpdateLicenseeCTEDetail(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeCTEDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLicenseeCTEDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLicenseeCTEDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLicenseeCTEDetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetLicenseeCTODetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetLicenseeCTODetail(objLease);
        }
        [HttpPost]
        public MessageEF NewLicenseeCTODetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.NewLicenseeCTODetail(objLease);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeCTODetail(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.UpdateLicenseeCTODetail(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeCTODetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLicenseeCTODetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLicenseeCTODetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLicenseeCTODetails(objLease);
        }
        [HttpPost]
        public ApplicationResult GetAssesmentReport(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.GetAssesmentReport(objLease);
        }
        [HttpPost]
        public MessageEF NewAssesmentReport(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.NewAssesmentReport(objLease);
        }
        [HttpPost]
        public MessageEF UpdateAssessmentReport(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.UpdateAssessmentReport(objLease);
        }
        [HttpPost]
        public MessageEF ApproveAssessmentReport(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveAssessmentReport(objLease);
        }
        [HttpPost]
        public MessageEF RejectAssessmentReport(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectAssessmentReport(objLease);
        }
        [HttpPost]
        public MessageEF SaveMiningPlanData(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.SaveMiningPlanData(objLease);
        }
        [HttpPost]
        public MessageEF ApproveLesseeMiningDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.ApproveLesseeMiningDetails(objLease);
        }
        [HttpPost]
        public MessageEF RejectLesseeMiningDetails(UserInformationEF objLease)
        {
            return _objIUserInformationProvider.RejectLesseeMiningDetails(objLease);
        }
    }
}