// ***********************************************************************
//  Controller Name          : eTransitpassController
//  Desciption               : Add ,Fetch Etransit Pass Details
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 07-jul-2021
// ************************************************************************
using EpassApi.Model.eTransitpass;
using EpassEF;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    public class eTransitpasscontroller : ControllerBase
    {
        private IeTransitpassprovider _objIPurchaserConsigneeProvider;
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public eTransitpasscontroller(IeTransitpassprovider objIPurchaserConsigneeProvider)
        {
            _objIPurchaserConsigneeProvider = objIPurchaserConsigneeProvider;
        }
        [HttpPost]
        public async Task<List<TransitPassModel>> GetApprovedBulkPermitList(TransitPassModel objOpenPermit)
        {
            return await _objIPurchaserConsigneeProvider.GetApprovedBulkPermitList(objOpenPermit);
        }
        /// <summary>
        /// Added by suroj on 7-jul-2021 to fetch Lessee basic details like District,Tehsil,village in Etransit Pass Page
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        public async Task<TransitPassModel> getTransitpassdtls(TransitPassModel objOpenModel)
        {
            return await _objIPurchaserConsigneeProvider.getTransitpassdtls(objOpenModel);
        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>

        public async Task<TransitPassModel> getBulkPermitDataByBulkPermitId(TransitPassModel objOpenModel)
        {
            return await _objIPurchaserConsigneeProvider.getBulkPermitDataByBulkPermitId(objOpenModel);
        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>

        public async Task<List<TransitPassModel>> GetCascadePurchaserConsignee(TransitPassModel objOpenModel)
        {
            return await _objIPurchaserConsigneeProvider.GetCascadePurchaserConsignee(objOpenModel);
        }
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public async Task<TransitPassModel> GetDataByPurchaserConsigneeId(TransitPassModel objOpenModel)
        {
            return await _objIPurchaserConsigneeProvider.GetDataByPurchaserConsigneeId(objOpenModel);
        }
        public async Task<List<TPVehicleModel>> GetAllVehicleInformation(TransitPassModel objtran)
        {
            return await _objIPurchaserConsigneeProvider.GetAllVehicleInformation(objtran);
        }

        public ReturnOuputResult AddTransitPassDetails(TransitPassModel model)
        {
            return _objIPurchaserConsigneeProvider.AddTransitPassDetails(model);
        }

        public TransitPassModel PassReportDesignView(TransitPassModel model)
        {
            return _objIPurchaserConsigneeProvider.PassReportDesignView(model);
        }

        /// <summary>
        /// Added by suroj on 29-jul-2021 to fetch RTP Application no whose transportmode is inside railways and road-rail
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>

        public async Task<List<TransitPassModel>> GetForwardingNote(TransitPassModel objtran)
        {
            return await _objIPurchaserConsigneeProvider.GetForwardingNote(objtran);
        }

        public TransitPassModel RailTPDataFetch(TransitPassModel model)
        {
            return _objIPurchaserConsigneeProvider.RailTPDataFetch(model);
        }

        public async Task<List<EndUser_ETransitPassModel>> BindReceivePermit(EndUser_ETransitPassModel objtran)
        {
            return await _objIPurchaserConsigneeProvider.BindReceivePermit(objtran);
        }



        public async Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran)
        {
            return await _objIPurchaserConsigneeProvider.GetGridData(objtran);
        }

        public async Task<string> UpdateMineralReceipt(EndUser_ETransitPassModel model)
        {
            return await _objIPurchaserConsigneeProvider.UpdateMineralReceipt(model);
        }

        public async Task<List<EndUser_ETransitPassModel>> MineralReceiveData(EndUser_ETransitPassModel objtran)
        {
            return await _objIPurchaserConsigneeProvider.MineralReceiveData(objtran);
        }
        /// <summary>
        /// Added by suroj kumar pradhan on 23-aug-2021 to bind Permit No in RPTP
        /// </summary>
        /// <returns></returns>

        public async Task<List<RPTPModel>> GetApprovedBulkPermitListRPTP(RPTPModel objmodel)
        {
            return await _objIPurchaserConsigneeProvider.GetApprovedBulkPermitListRPTP(objmodel);
        }


        /// <summary>
        /// Added by suroj on 24-Aug-2021 to fetch details against permitNO RPTP
        /// </summary>
        /// <param name="objRPTP"></param>
        /// <returns></returns>
        /// 

        public RPTPModel GetDataByBulkPermitId(RPTPModel objmodel)
        {
            return _objIPurchaserConsigneeProvider.GetDataByBulkPermitId(objmodel);
        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass RPTP
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>


        public async Task<List<RPTPModel>> GetCascadePurchaserConsigneeRPTP(RPTPModel objmodel)
        {
            return await _objIPurchaserConsigneeProvider.GetCascadePurchaserConsigneeRPTP(objmodel);
        }

        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>


        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        public RPTPModel GetDataByPurchaserConsigneeIdRPTP(RPTPModel objmodel)
        {
            return _objIPurchaserConsigneeProvider.GetDataByPurchaserConsigneeIdRPTP(objmodel);
        }

        /// <summary>
        /// Added by suroj on 25-aug-2021 to add RPTP details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ReturnOuputResultRPTP AddData(RPTPModel model)
        {
            return _objIPurchaserConsigneeProvider.AddData(model);
        }

        /// <summary>
        /// Added by suroj on 26-08-21 to print RPTP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         public RPTPModel getRecordForReport(RPTPModel objmodel)
        {
            return _objIPurchaserConsigneeProvider.getRecordForReport(objmodel);
        }
}
}
