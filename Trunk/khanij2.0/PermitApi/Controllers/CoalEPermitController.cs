using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PermitApi.Model.CoalEPermit;
using PermitApi.Model.GradeUpdate;
using PermitEF;

namespace PermitApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class CoalEPermitController : Controller
    {
        public ICoalEPermitProvider _objICoalPermitProvider;
        public IUpgradeGrade _objIUpgradeGradeProvider;
        public CoalEPermitController(ICoalEPermitProvider objICoalPermitProvider, IUpgradeGrade objIUpgradeGradeProvider)
        {
            _objICoalPermitProvider = objICoalPermitProvider;
            _objIUpgradeGradeProvider = objIUpgradeGradeProvider;
        }
        [HttpPost]
        public async Task<ePermitResult> GetTypeOfCoal(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetTypeOfCoal(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> CheckTotalPermitByUser(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.CheckTotalPermitByUser(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitDetailsByUserID(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetPermitDetailsByUserID(objLease);
        }
        
        [HttpPost]
        public async Task<ePermitResult> GetPermitOperation(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetPermitOperation(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitOperationByBulkId(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetPermitOperationByBulkId(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetePermitPayment(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetePermitPayment(objLease);
        }
        [HttpPost]
        public async Task<List<ListCoalPermit>> GetSavedCoalPermit(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetSavedCoalPermit(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> DeleteCoalData(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.DeleteCoalData(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetPermitViewWithoutDSC(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetPermitViewWithoutDSC(objLease);
        }
        [HttpPost]
        public async Task<MessageEF> CheckOutPayment(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.CheckOutPayment(objLease);
        }
        [HttpPost]
        public async Task<ePermitResult> GetCheckOutPermitPayment(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetCheckOutPermitPayment(objLease);
        }
        [HttpPost]
        public async Task<List<ePaymentData>> GetDetailsOfConfig(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetDetailsOfConfig(objLease);
        }
        [HttpPost]
        public async Task<List<SampleGradeModel>> GetGradeDetails(SampleGradeModel objUser)
        {
            return await _objIUpgradeGradeProvider.GetGradeDetails(objUser);
        }
        [HttpPost]
        public async Task<MessageEF> UpgradeMineral(ePermitModel objUser)
        {
            return await _objICoalPermitProvider.UpgradeMineral(objUser);
        }
        [HttpPost]
        public async Task<ePermitModel> GetDetailsOfUpgrade(ePermitModel objUser)
        {
            return await _objICoalPermitProvider.GetDetailsOfUpgrade(objUser);
        }
        [HttpPost]
        public async Task<ePermitResult> GetMinesDetails(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetMinesDetails(objLease);
        }
        [HttpPost]
        public async Task<ePermitModel> GetComapny(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetComapny(objLease);
        }
        [HttpPost]
        public async Task<ePermitModel> GetCoalRoyalty(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetCoalRoyalty(objLease);
        }
        [HttpPost]
        public async Task<List<ePaymentData>> GetPaymentStatus(ePermitModel objLease)
        {
            return await _objICoalPermitProvider.GetPaymentStatus(objLease);
        }
    }
}