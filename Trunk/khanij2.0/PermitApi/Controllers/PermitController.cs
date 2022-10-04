using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.Permit;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class PermitController : Controller
    {
        public ILesseeProvider _objILesseeProvider;
        public PermitController(ILesseeProvider objILesseeProvider)
        {
            _objILesseeProvider = objILesseeProvider;
        }
        [HttpPost]
        public async  Task<ePermitResult> GetCoalMineralNatureList(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetCoalMineralNatureList(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMineralGradeListOnNatureList(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetMineralGradeListOnNatureList(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddBulkPermit(ePermitModel objLease)
        {
            return await _objILesseeProvider.AddBulkPermit(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddMergeBulkPermit(ePermitModel objLease)
        {
            return await _objILesseeProvider.AddMergeBulkPermit(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> CheckTotalPermitByUser(ePermitModel objLease)
        {
            return await _objILesseeProvider.CheckTotalPermitByUser(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitDetailsByUserID(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitDetailsByUserID(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitOperation(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitOperation(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitOperationByBulkId(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitOperationByBulkId(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GradeWiseCheckECQTY(ePermitModel objLease)
        {
            return await _objILesseeProvider.GradeWiseCheckECQTY(objLease);
        }
        [HttpPost]
        public async Task<List<ePaymentData>> RevisedPayableRoyaltyRate(ePermitModel objLease)
        { 
            return await _objILesseeProvider.RevisedPayableRoyaltyRate(objLease);
        }
        [HttpPost]
        public async Task<List<ePaymentData>> MergeRevisedPayableRoyaltyRate(ePermitModel objLease)
        {
            return await _objILesseeProvider.MergeRevisedPayableRoyaltyRate(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetePermitPayment(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetePermitPayment(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetMergePermitList(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetMergePermitList(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMergePermitMineralGrade(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetMergePermitMineralGrade(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> MergeEpermitOperation(ePermitModel objLease)
        {
            return await _objILesseeProvider.MergeEpermitOperation(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMineralNatureName(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetMineralNatureName(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetBulkPermitDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetBulkPermitDetails(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetApprovedBulkPermitDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetApprovedBulkPermitDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitViewWithoutDSC(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitTransDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitTransDetails(objLease);
        }
        [HttpPost]
        public async Task<List<LicenseInfoRPTP>> GetRPTPPendingPermitList(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetRPTPPendingPermitList(objLease);
        }
        [HttpPost]
        public async Task<LicenseeRPTPResult> GetLicenseeRPTPPermit(LicenseInfoRPTP objLease)
        {
            return await _objILesseeProvider.GetLicenseeRPTPPermit(objLease);
        }
        [HttpPost]
        public async Task<LicenseeRPTPResult> GetLicenseeRPTPClosingPermit(LicenseInfoRPTP objLease)
        {
            return await _objILesseeProvider.GetLicenseeRPTPClosingPermit(objLease);
        }
        [HttpPost]
        public async Task<List<LicenseInfoRPTP>> GetDGMApprovedRPTPList(LicenseInfoRPTP objLease)
        {
            return await _objILesseeProvider.GetDGMApprovedRPTPList(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> ArchviveUnArchivePermit(ePermitModel objLease)
        {
            return await _objILesseeProvider.ArchviveUnArchivePermit(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddRPTPBulkPermit(LicenseInfoRPTP objLease)
        {
            return await _objILesseeProvider.AddRPTPBulkPermit(objLease);
        }
        [HttpPost]
        public async Task<List<LicenseInfoRPTP>> getRPTPDetails(LicenseInfoRPTP objLease)
        {
            return await _objILesseeProvider.getRPTPDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> CheckMergePermitDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.CheckMergePermitDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMergePermitTransDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetMergePermitTransDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillState(ePermitModel objLease)
        {
            return await _objILesseeProvider.FillState(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillDistrict(ePermitModel objLease)
        {
            return await _objILesseeProvider.FillDistrict(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillUserType(ePermitModel objLease)
        {
            return await _objILesseeProvider.FillUserType(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillModuleType(ePermitModel objLease)
        {
            return await _objILesseeProvider.FillModuleType(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> FillSubModuleType(ePermitModel objLease)
        {
            return await _objILesseeProvider.FillSubModuleType(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetCheckListData(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetCheckListData(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddRiderConfigMaster(ePermitModel objLease)
        {
            return await _objILesseeProvider.AddRiderConfigMaster(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> ViewRiderConfigMaster(ePermitModel objLease)
        {
            return await _objILesseeProvider.ViewRiderConfigMaster(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteRiderConfigMaster(ePermitModel objLease)
        {
            return await _objILesseeProvider.DeleteRiderConfigMaster(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> EditRiderConfigMaster(ePermitModel objLease)
        {
            return await _objILesseeProvider.EditRiderConfigMaster(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> CheckOutPayment(ePermitModel objLease)
        {
            return await _objILesseeProvider.CheckOutPayment(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetCheckOutPermitPayment(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetCheckOutPermitPayment(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetPermitQuantity(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitQuantity(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetTotalPermitByUser(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetTotalPermitByUser(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddTotalPermitByUser(ePermitModel objLease)
        {
            return await _objILesseeProvider.AddTotalPermitByUser(objLease);
        }
        [HttpPost]
        public async Task<List<ePermitModel>> GetPermitColosingDtls(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetPermitColosingDtls(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> AddWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.AddWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<MessageEF> UpdateWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.UpdateWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<PermitWeighBridgeMapp> EditWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.EditWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<List<PermitWeighBridgeMapp>> ViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.ViewWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.DeleteWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<PermitWeighBridgeMapp> FilterViewWeighbridge(PermitWeighBridgeMapp objUser)
        {
            return await _objILesseeProvider.FilterViewWeighbridge(objUser);
        }
        [HttpPost]
        public async Task<ePermitResult> GetSECLDODetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetSECLDODetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitModel> GetTaggedDetails(ePermitModel objLease)
        {
            return await _objILesseeProvider.GetTaggedDetails(objLease);
        }
    }
}