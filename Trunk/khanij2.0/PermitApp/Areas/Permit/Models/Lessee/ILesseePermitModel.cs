using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Areas.Permit.Models.Lessee
{
   public interface ILesseePermitModel
    {
        ePermitResult GetCoalMineralNatureList(ePermitModel objUser);
        ePermitResult GetMineralGradeListOnNatureList(ePermitModel objUser);
        MessageEF AddBulkPermit(ePermitModel objUser);
        MessageEF AddMergeBulkPermit(ePermitModel objUser);
        ePermitResult CheckTotalPermitByUser(ePermitModel objUser);
        ePermitResult GetPermitDetailsByUserID(ePermitModel objUser);
        ePermitResult GetPermitOperation(ePermitModel objUser);
        ePermitResult GetPermitOperationByBulkId(ePermitModel objUser);
        List<ePermitModel> GradeWiseCheckECQTY(ePermitModel objUser);
        List<ePaymentData> RevisedPayableRoyaltyRate(ePermitModel objUser);
        List<ePaymentData> MergeRevisedPayableRoyaltyRate(ePermitModel objUser);
        ePermitResult GetePermitPayment(ePermitModel objUser);
        List<ePermitModel> GetMergePermitList(ePermitModel objUser);
        ePermitResult GetMergePermitMineralGrade(ePermitModel objUser);
        ePermitResult MergeEpermitOperation(ePermitModel objUser);
        ePermitResult GetMineralNatureName(ePermitModel objUser);
        List<ePermitModel> GetBulkPermitDetails(ePermitModel objUser);
        List<ePermitModel> GetApprovedBulkPermitDetails(ePermitModel objUser);
        ePermitResult GetPermitViewWithoutDSC(ePermitModel objUser);
        ePermitResult GetPermitTransDetails(ePermitModel objUser);
        List<LicenseInfoRPTP> GetRPTPPendingPermitList(ePermitModel objUser);
        LicenseeRPTPResult GetLicenseeRPTPPermit(LicenseInfoRPTP objUser);
        LicenseeRPTPResult GetLicenseeRPTPClosingPermit(LicenseInfoRPTP objUser);
        List<LicenseInfoRPTP> GetDGMApprovedRPTPList(LicenseInfoRPTP objUser);
        MessageEF ArchviveUnArchivePermit(ePermitModel objUser);
        MessageEF AddRPTPBulkPermit(LicenseInfoRPTP objUser);
        List<LicenseInfoRPTP> getRPTPDetails(LicenseInfoRPTP objUser);
        ePermitResult CheckMergePermitDetails(ePermitModel objUser);
        ePermitResult GetMergePermitTransDetails(ePermitModel objUser);
        ePermitResult FillState(ePermitModel objUser);
        ePermitResult FillDistrict(ePermitModel objUser);
        ePermitResult FillUserType(ePermitModel objUser);
        ePermitResult FillModuleType(ePermitModel objUser);
        ePermitResult FillSubModuleType(ePermitModel objUser);
        List<ePermitModel> GetCheckListData(ePermitModel objUser);
        MessageEF AddRiderConfigMaster(ePermitModel objUser);
        List<ePermitModel> ViewRiderConfigMaster(ePermitModel objUser);
        MessageEF DeleteRiderConfigMaster(ePermitModel objUser);
        ePermitResult EditRiderConfigMaster(ePermitModel objUser);
        MessageEF CheckOutPayment(ePermitModel objUser);
        ePermitResult GetCheckOutPermitPayment(ePermitModel objUser);
        List<ePermitModel> GetPermitQuantity(ePermitModel objUser);
        List<ePermitModel> GetTotalPermitByUser(ePermitModel objUser);
        MessageEF AddTotalPermitByUser(ePermitModel objUser);
        List<ePermitModel> GetPermitColosingDtls(ePermitModel objUser);
        MessageEF AddWeighbridge(PermitWeighBridgeMapp objUser);
        MessageEF UpdateWeighbridge(PermitWeighBridgeMapp objUser);
        PermitWeighBridgeMapp EditWeighbridge(PermitWeighBridgeMapp objUser);
        List<PermitWeighBridgeMapp> ViewWeighbridge(PermitWeighBridgeMapp objUser);
        MessageEF DeleteWeighbridge(PermitWeighBridgeMapp objUser);
        PermitWeighBridgeMapp FilterViewWeighbridge(PermitWeighBridgeMapp objUser);
        ePermitResult GetSECLDODetails(ePermitModel objUser);
        ePermitModel GetTaggedDetails(ePermitModel objUser);
    }
}
