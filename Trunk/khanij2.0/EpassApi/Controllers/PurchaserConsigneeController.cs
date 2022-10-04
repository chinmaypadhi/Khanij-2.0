using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EpassEF;
using EpassApi.Model.PurchaserConsignee;
using EpassEF.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class PurchaserConsigneeController : ControllerBase
    {
        IPurchaserConsigneeProvider _objIPurchaserConsigneeProvider;
        public PurchaserConsigneeController(IPurchaserConsigneeProvider objIPurchaserConsigneeProvider)
        {
            _objIPurchaserConsigneeProvider = objIPurchaserConsigneeProvider;
        }
        //[HttpPost]
        //public List<PurchaserConsigneeOpenEpermitModel> ReadOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenPermit)
        //{
        //    return _objIPurchaserConsigneeProvider.ReadOpenEpermitDetails(objOpenPermit);
        //}
        [Authorize]
        [HttpPost]
        public async Task<List<PurchaserConsigneeOpenEpermitModel>> ReadOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenPermit)
        {
            return await _objIPurchaserConsigneeProvider.ReadOpenEpermitDetails(objOpenPermit);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<PurchaserConsigneeModelView>> getDataByPermitId(PurchaserConsigneeModelView purchaserConsigneeModel)
        {
            return await _objIPurchaserConsigneeProvider.getDataByPermitId(purchaserConsigneeModel);
        }

        public async Task<PurchaserConsigneePermitModel> getGridBulkPermitMasterDataByBulkPermitId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            return await _objIPurchaserConsigneeProvider.getGridBulkPermitMasterDataByBulkPermitId(purchaserConsignee);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown)
        {
            return await _objIPurchaserConsigneeProvider.Dropdown(objEmpDropDown);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            return await _objIPurchaserConsigneeProvider.GetEndUserLisenseeDetails(objPurchaseConsignee);
        }
        [Authorize]
        [HttpPost]
        public async Task<PurchaserConsigneePermitModel> getDestinationByPurchaseConsigneeId(PurchaserConsigneePermitModel purchaserConsignee)
        {
            return await _objIPurchaserConsigneeProvider.getDestinationByPurchaseConsigneeId(purchaserConsignee);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<PurchaserConsigneePermitModel>> GetTransportationModeList(PurchaserConsigneePermitModel objPurchaseConsignee)
        {
            return await _objIPurchaserConsigneeProvider.GetTransportationModeList(objPurchaseConsignee);
        }
        [Authorize]
        [HttpPost]
        public async Task<List<EmpDropDown>> GetStateDistrictList()
        {
            return await _objIPurchaserConsigneeProvider.GetStateDistrictList();
        }
        [Authorize]
        [HttpPost]
        public async Task<List<EmpDropDown>> GetLicenseeTypeLists(PurchaserConsigneePermitModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetLicenseeTypeLists(objpurchase);
        }

        public async Task<string> GetCaptiveMineStatusOfLessee(PurchaserConsigneePermitModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetCaptiveMineStatusOfLessee(objpurchase);
        }

        public async Task<List<PurchaseConsignee>> GetEndUserLisensee(PurchaserConsigneePermitModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetEndUserLisensee(objpurchase);
        }
        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeTypeForWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetEndUserLisenseeTypeForWasheryDetails(objpurchase);
        }

        public async Task<List<PurchaseConsignee>> GetEndUserLisenseeWasheryDetails(PurchaserConsigneePermitModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetEndUserLisenseeWasheryDetails(objpurchase);
        }

        public async Task<string> AddData(PurchaserConsigneeModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.AddData(objpurchase);
        }

        public async Task<List<PurchaserConsigneeModel>> GetGridData(PurchaserConsigneeModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.GetGridData(objpurchase);
        }

        public async Task<string> DeleteData(PurchaserConsigneeModel objpurchase)
        {
            return await _objIPurchaserConsigneeProvider.DeleteData(objpurchase);
        }

        public async Task<List<PurchaseConsignee>> GetOtherEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee)
        {
            return await _objIPurchaserConsigneeProvider.GetOtherEndUserLisenseeDetails(objPurchaseConsignee);
        }
        /// <summary>
        /// Added by suroj on 01-jul-2021 to get checkpost names for other purchase consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        public async Task<List<PurchaserConsigneeModel>> Getcheckpost()
        {
            return await _objIPurchaserConsigneeProvider.Getcheckpost();
        }
    }
}
