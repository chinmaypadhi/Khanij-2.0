using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.Permit
{
   public  interface ILesseeProvider : IDisposable, IRepository
    {
        Task<ePermitResult> GetCoalMineralNatureList(ePermitModel objUser);
        Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objUser);
        Task<MessageEF> AddBulkPermit(ePermitModel objUser);
        Task<MessageEF> AddMergeBulkPermit(ePermitModel objUser);
        Task<ePermitResult> CheckTotalPermitByUser(ePermitModel objUser);
        Task<ePermitResult> GetPermitDetailsByUserID(ePermitModel objUser);
        Task<ePermitResult> GetPermitOperation(ePermitModel objUser);
        Task<ePermitResult> GetPermitOperationByBulkId(ePermitModel objUser);
        Task<List<ePermitModel>> GradeWiseCheckECQTY(ePermitModel objUser);
        Task<List<ePaymentData>> RevisedPayableRoyaltyRate(ePermitModel objUser);
        Task<List<ePaymentData>> MergeRevisedPayableRoyaltyRate(ePermitModel objUser);
        Task<ePermitResult> GetePermitPayment(ePermitModel objUser);
        Task<List<ePermitModel>> GetMergePermitList(ePermitModel objUser);
        Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objUser);
        Task<ePermitResult> MergeEpermitOperation(ePermitModel objUser);
        Task<ePermitResult> GetMineralNatureName(ePermitModel objUser);
        Task<List<ePermitModel>> GetBulkPermitDetails(ePermitModel objUser);
        Task<List<ePermitModel>> GetApprovedBulkPermitDetails(ePermitModel objUser);
        Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objUser);
        Task<ePermitResult> GetPermitTransDetails(ePermitModel objUser);
        Task<List<LicenseInfoRPTP>> GetRPTPPendingPermitList(ePermitModel objUser);
        Task<LicenseeRPTPResult> GetLicenseeRPTPPermit(LicenseInfoRPTP objUser);
        Task<LicenseeRPTPResult> GetLicenseeRPTPClosingPermit(LicenseInfoRPTP objUser);
        Task<List<LicenseInfoRPTP>> GetDGMApprovedRPTPList(LicenseInfoRPTP objUser);
        Task<MessageEF> ArchviveUnArchivePermit(ePermitModel objUser);
        Task<MessageEF> AddRPTPBulkPermit(LicenseInfoRPTP objUser);
        Task<List<LicenseInfoRPTP>> getRPTPDetails(LicenseInfoRPTP objUser);
        Task<ePermitResult> CheckMergePermitDetails(ePermitModel objUser);
        Task<ePermitResult> GetMergePermitTransDetails(ePermitModel objUser);
        Task<ePermitResult> FillState(ePermitModel objUser);
        Task<ePermitResult> FillDistrict(ePermitModel objUser);
        Task<ePermitResult> FillUserType(ePermitModel objUser);
        Task<ePermitResult> FillModuleType(ePermitModel objUser);
        Task<List<ePermitModel>> GetCheckListData(ePermitModel objUser);
        Task<MessageEF> AddRiderConfigMaster(ePermitModel objUser);
        Task<List<ePermitModel>> ViewRiderConfigMaster(ePermitModel objUser);
        Task<MessageEF> DeleteRiderConfigMaster(ePermitModel objUser);
        Task<ePermitResult> EditRiderConfigMaster(ePermitModel objUser);
        Task<ePermitResult> FillSubModuleType(ePermitModel objUser);
        Task<MessageEF> CheckOutPayment(ePermitModel objUser);
        Task<ePermitResult> GetCheckOutPermitPayment(ePermitModel objUser);
        Task<List<ePermitModel>> GetPermitQuantity(ePermitModel objUser);
        Task<List<ePermitModel>> GetTotalPermitByUser(ePermitModel objUser);
        Task<MessageEF> AddTotalPermitByUser(ePermitModel objUser);
        Task<List<ePermitModel>> GetPermitColosingDtls(ePermitModel objUser);
        Task<MessageEF> AddWeighbridge(PermitWeighBridgeMapp objUser);
        Task<MessageEF> UpdateWeighbridge(PermitWeighBridgeMapp objUser);
        Task<PermitWeighBridgeMapp> EditWeighbridge(PermitWeighBridgeMapp objUser);
        Task<List<PermitWeighBridgeMapp>> ViewWeighbridge(PermitWeighBridgeMapp objUser);
        Task<MessageEF> DeleteWeighbridge(PermitWeighBridgeMapp objUser);
        Task<PermitWeighBridgeMapp> FilterViewWeighbridge(PermitWeighBridgeMapp objUser);
        Task<ePermitResult> GetSECLDODetails(ePermitModel objUser);
        Task<ePermitModel> GetTaggedDetails(ePermitModel objUser);
    }
}
