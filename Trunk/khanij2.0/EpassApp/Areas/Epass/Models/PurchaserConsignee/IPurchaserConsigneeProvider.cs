using EpassEF;
using EpassEF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.PurchaserConsignee
{
    public interface IPurchaserConsigneeProvider
    {
        List<PurchaserConsigneeOpenEpermitModel> GetOpenEpermitDetails(PurchaserConsigneeOpenEpermitModel objOpenModel);
        
        List<PurchaserConsigneeModelView> PurchaserConsigneeByPermitId(PurchaserConsigneeModelView purchaserConsignee);
        PurchaserConsigneePermitModel getGridBulkPermitMasterDataByBulkPermitId(PurchaserConsigneePermitModel purchaserConsignee);
        List<EmpDropDown> Dropdown(EmpDropDown objEmpDropDown);

        List<PurchaseConsignee> GetEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee);
        PurchaserConsigneePermitModel getDestinationByPurchaseConsigneeId(PurchaserConsigneePermitModel purchaserConsignee);
        List<PurchaserConsigneePermitModel> GetTransportationModeList(PurchaserConsigneePermitModel objPurchaseConsignee);
        List<EmpDropDown> GetStateDistrictList();
        List<EmpDropDown> GetLicenseeTypeLists(PurchaserConsigneePermitModel objpurchase);

        string GetCaptiveMineStatusOfLessee(PurchaserConsigneePermitModel objpurchase);


        List<PurchaseConsignee> GetEndUserLisensee(PurchaserConsigneePermitModel objpurchase);
        List<PurchaseConsignee> GetEndUserLisenseeTypeForWasheryDetails(PurchaserConsigneePermitModel objpurchase);
        List<PurchaseConsignee> GetEndUserLisenseeWasheryDetails(PurchaserConsigneePermitModel objpurchase);

        string AddData(PurchaserConsigneeModel objpurchase);

        List<PurchaserConsigneeModel> GetGridData(PurchaserConsigneeModel objpurchase);

        string DeleteData(PurchaserConsigneeModel objpurchase);

        List<PurchaseConsignee> GetOtherEndUserLisenseeDetails(PurchaseConsignee objPurchaseConsignee);


        /// <summary>
        /// Added by suroj on 01-jul-2021 to get checkpost names for other purchase consignee
        /// </summary>
        /// <param name="objpurchase"></param>
        /// <returns></returns>
        List<PurchaserConsigneeModel> Getcheckpost();
        
    }
}
