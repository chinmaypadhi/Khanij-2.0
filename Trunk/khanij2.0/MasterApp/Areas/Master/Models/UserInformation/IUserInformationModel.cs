using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApp.Areas.Master.Models.UserInformation
{
   public interface IUserInformationModel
    {
        LesseeResult LeaseTypeView(UserInformationEF objUser);
        LesseeResult GetAuctionIDList(UserInformationEF objUser);
        ApplicationResult GetApplicationData(UserInformationEF objUser);
        MessageEF SaveApplication(UserInformationEF objUser);
        MessageEF ApproveLesseeApplicationDetails(UserInformationEF objUser);
        MessageEF RejectLesseeApplicationDetails(UserInformationEF objUser);
        ApplicationResult GetGrantOrder(UserInformationEF objUser);
        ApplicationResult GetProfileCount(UserInformationEF objUser);
        MessageEF SaveGrantDetails(UserInformationEF objUser);
        MessageEF ApproveLesseeGrantDetails(UserInformationEF objUser);
        MessageEF RejectLesseeGrantDetails(UserInformationEF objUser);
        ApplicationResult GetLeaseArea(UserInformationEF objUser);
        ApplicationResult GetLesseeProfileStatus(UserInformationEF objUser);
        LesseeResult GetStateList(UserInformationEF objUser);
        LesseeResult GetDistrictList(UserInformationEF objUser);
        LesseeResult GetTehsilList(UserInformationEF objUser);
        LesseeResult GetVillageList(UserInformationEF objUser);
        MessageEF SaveLeaseArea(UserInformationEF objUser);
        MessageEF ApproveLesseeAreaDetails(UserInformationEF objUser);
        MessageEF RejectLesseeAreaDetails(UserInformationEF objUser);
        ApplicationResult GetMineralCategory(UserInformationEF objUser);
        ApplicationResult GetMineralNameFromMineralType(UserInformationEF objUser);
        ApplicationResult GetLicenseeIBMDetail(UserInformationEF objUser);
        MessageEF NewLicenseeIBMDetail(UserInformationEF objUser);
        MessageEF UpdateLicenseeIBMDetail(UserInformationEF objUser);
        MessageEF ApproveLicenseeIBMDetails(UserInformationEF objUser);
        MessageEF RejectLicenseeIBMDetails(UserInformationEF objUser);
        LesseeResult GetMiningPlanYearList(UserInformationEF objUser);
        ApplicationResult GetMiningPlanData(UserInformationEF objUser);
        MessageEF SaveMiningPlanData(UserInformationEF objUser);
        MessageEF ApproveLesseeMiningDetails(UserInformationEF objUser);
        MessageEF RejectLesseeMiningDetails(UserInformationEF objUser);
        ApplicationResult GetForestClearence(UserInformationEF objUser);
        MessageEF SaveForestClearenceDetails(UserInformationEF objUser);
        MessageEF ApproveLesseeForestDetails(UserInformationEF objUser);
        MessageEF RejectLesseeForestDetails(UserInformationEF objUser);
        ApplicationResult GetLicenseeEnvDetail(UserInformationEF objUser);
        MessageEF NewLicenseeEnvDetail(UserInformationEF objUser);
        MessageEF UpdateLicenseeEnvironmentDetail(UserInformationEF objUser);
        MessageEF ApproveLicenseeECDetails(UserInformationEF objUser);
        MessageEF RejectLicenseeECDetails(UserInformationEF objUser);
        ApplicationResult GetLicenseeCTEDetail(UserInformationEF objUser);
        MessageEF NewLicenseeCTEDetail(UserInformationEF objUser);
        MessageEF UpdateLicenseeCTEDetail(UserInformationEF objUser);
        MessageEF ApproveLicenseeCTEDetails(UserInformationEF objUser);
        MessageEF RejectLicenseeCTEDetails(UserInformationEF objUser);
        ApplicationResult GetLicenseeCTODetail(UserInformationEF objUser);
        MessageEF NewLicenseeCTODetail(UserInformationEF objUser);
        MessageEF UpdateLicenseeCTODetail(UserInformationEF objUser);
        MessageEF ApproveLicenseeCTODetails(UserInformationEF objUser);
        MessageEF RejectLicenseeCTODetails(UserInformationEF objUser);
        ApplicationResult GetAssesmentReport(UserInformationEF objUser);
        MessageEF NewAssesmentReport(UserInformationEF objUser);
        MessageEF UpdateAssessmentReport(UserInformationEF objUser);
        MessageEF ApproveAssessmentReport(UserInformationEF objUser);
        MessageEF RejectAssessmentReport(UserInformationEF objUser);
    }
}
