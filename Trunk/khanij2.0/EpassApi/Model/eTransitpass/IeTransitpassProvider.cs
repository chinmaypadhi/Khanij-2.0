// ***********************************************************************
//  Model Name               : IeTransitpassProvider
//  Desciption               : Add ,Fetch Etransit Pass Details
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 07-jul-2021
// ************************************************************************

using EpassApi.Repository;
using System;
using EpassEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EpassApi.Model.eTransitpass
{
    public interface IeTransitpassprovider : IDisposable, IRepository
    {
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<List<TransitPassModel>> GetApprovedBulkPermitList(TransitPassModel objOpenModel);
        /// <summary>
        /// Added by suroj on 7-jul-2021 to fetch Lessee basic details like District,Tehsil,village in Etransit Pass Page
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<TransitPassModel> getTransitpassdtls(TransitPassModel objOpenModel);
        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<TransitPassModel> getBulkPermitDataByBulkPermitId(TransitPassModel objOpenModel);
        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<List<TransitPassModel>> GetCascadePurchaserConsignee(TransitPassModel objOpenModel);
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        Task<TransitPassModel> GetDataByPurchaserConsigneeId(TransitPassModel objOpenModel);

        Task<List<TPVehicleModel>> GetAllVehicleInformation(TransitPassModel objtran);

        ReturnOuputResult AddTransitPassDetails(TransitPassModel model);

        TransitPassModel PassReportDesignView(TransitPassModel model);

        /// <summary>
        /// Added by suroj on 29-jul-2021 to fetch RTP Application no whose transportmode is inside railways and road-rail
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        Task<List<TransitPassModel>> GetForwardingNote(TransitPassModel objtran);


        TransitPassModel RailTPDataFetch(TransitPassModel model);

        Task<List<EndUser_ETransitPassModel>> BindReceivePermit(EndUser_ETransitPassModel objtran);
        /// <summary>
        /// Added by suroj on 04-Aug-2021 to fill Mineral Details on Permit No Change Event.
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        Task<List<EndUser_ETransitPassModel>> GetGridData(EndUser_ETransitPassModel objtran);
        /// <summary>
        /// Added by suroj on 07-aug-2021 to update Mineral Recieve 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<string> UpdateMineralReceipt(EndUser_ETransitPassModel model);
        /// <summary>
        /// Added by suroj on 17-aug-2021 to Add Recieve mineral
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        Task<List<EndUser_ETransitPassModel>> MineralReceiveData(EndUser_ETransitPassModel objtran);
        /// <summary>
        /// Added by suroj kumar pradhan on 23-aug-2021 to bind Permit No in RPTP
        /// </summary>
        /// <returns></returns>
        Task<List<RPTPModel>> GetApprovedBulkPermitListRPTP(RPTPModel objmodel);
        /// <summary>
        /// Added by suroj on 24-Aug-2021 to fetch details against permitNO RPTP
        /// </summary>
        /// <param name="objRPTP"></param>
        /// <returns></returns>
        RPTPModel GetDataByBulkPermitId(RPTPModel objRPTP);

        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass RPTP
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<List<RPTPModel>> GetCascadePurchaserConsigneeRPTP(RPTPModel objRPTP);

        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>

        RPTPModel GetDataByPurchaserConsigneeIdRPTP(RPTPModel objTP);
        /// <summary>
        /// Added by suroj on 25-aug-2021 to add RPTP details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        ReturnOuputResultRPTP AddData(RPTPModel model);
        /// <summary>
        /// Added by suroj on 26-08-21 to print RPTP
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        RPTPModel getRecordForReport(RPTPModel model);
    }
}
