using EpassApi.Repository;
using System;
using EpassEF;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpassEF.ViewModel;

namespace EpassApi.Model.PurchaserConsignee
{
    public interface IPurchaserConsigneeProvider : IDisposable, IRepository
    {
        Task<List<PurchaserConsigneeOpenEpermitModel>> ReadOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenModel);
        Task<List<PurchaserConsigneeModelView>> getDataByPermitId(PurchaserConsigneeModelView purchaserConsigneeModel);

        Task<PurchaserConsigneePermitModel> getGridBulkPermitMasterDataByBulkPermitId(PurchaserConsigneePermitModel objPurchaserConsigneeModel);
        Task<List<EmpDropDown>> Dropdown(EmpDropDown objEmpDropDown);
        Task<List<PurchaseConsignee>> GetEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee);

         Task<PurchaserConsigneePermitModel> getDestinationByPurchaseConsigneeId(PurchaserConsigneePermitModel purchaserConsignee);
         Task<List<PurchaserConsigneePermitModel>> GetTransportationModeList(PurchaserConsigneePermitModel objPurchaseConsignee);

        Task<List<EmpDropDown>> GetStateDistrictList();

        Task<List<EmpDropDown>> GetLicenseeTypeLists(PurchaserConsigneePermitModel objpurchase);
        Task<string> GetCaptiveMineStatusOfLessee(PurchaserConsigneePermitModel objpurchase);

        Task<List<PurchaseConsignee>> GetEndUserLisensee(PurchaserConsigneePermitModel objpurchase);
        Task<List<PurchaseConsignee>> GetEndUserLisenseeTypeForWasheryDetails(PurchaserConsigneePermitModel objpurchase);

        Task<List<PurchaseConsignee>> GetEndUserLisenseeWasheryDetails(PurchaserConsigneePermitModel objpurchase);

        Task<string> AddData(PurchaserConsigneeModel objpurchase);

        Task<List<PurchaserConsigneeModel>> GetGridData(PurchaserConsigneeModel objpurchase);
        Task<string> DeleteData(PurchaserConsigneeModel objpurchase);

        Task<List<PurchaseConsignee>> GetOtherEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee);

        /// <summary>
        /// Added by suroj on 01-jul-2021 to get checkpost names for other purchase consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        Task<List<PurchaserConsigneeModel>> Getcheckpost();


    }
}
