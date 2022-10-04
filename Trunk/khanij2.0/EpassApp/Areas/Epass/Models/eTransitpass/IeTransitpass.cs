
// ***********************************************************************
//  Model Name               : IeTransitpass
//  Desciption               : Add ,Fetch Etransit Pass Details
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 07-jul-2021
// ************************************************************************
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Areas.Epass.Models.eTransitpass
{
    public interface IeTransitpass
    {
        /// <summary>
        /// Added by suroj on 7-jul-2021  to fetch Permit No
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        List<TransitPassModel> GetApprovedBulkPermitList(TransitPassModel objOpenModel);
        /// <summary>
        /// Added by suroj on 7-jul-2021 to fetch Lessee basic details like District,Tehsil,village in Etransit Pass Page
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        TransitPassModel getTransitpassdtls(TransitPassModel objOpenModel);

        /// <summary>
        /// Added by suroj on 08-jul-2021 to fetch details like mineral name,address agaiinst permit number in Transit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        TransitPassModel getBulkPermitDataByBulkPermitId(TransitPassModel objOpenModel);

        /// <summary>
        /// Added by suroj on 08-jul-2021 to bind Purchase/Consignee in eTransit Pass
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        List<TransitPassModel> GetCascadePurchaserConsignee(TransitPassModel objOpenModel);


        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        TransitPassModel GetDataByPurchaserConsigneeId(TransitPassModel objOpenModel);

        List<TPVehicleModel> GetAllVehicleInformation(TransitPassModel objtran);

        ReturnOuputResult AddTransitPassDetails(TransitPassModel model);
        /// <summary>
        /// Added by Suroj on 15-jul-2021 to generate print eTransit Pass
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 

        TransitPassModel PassReportDesignView(TransitPassModel model);


        List<TransitPassModel> GetForwardingNote(TransitPassModel objtran);
        /// <summary>
        /// Added by Suroj on 15-jul-2021 to generate print Railway eTransit Pass
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        TransitPassModel RailTPDataFetch(TransitPassModel model);

        List<EndUser_ETransitPassModel> BindReceivePermit(EndUser_ETransitPassModel objtran);
        /// <summary>
        /// Added by suroj on 04-Aug-2021 to fill Mineral Details on Permit No Change Event.
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        List<EndUser_ETransitPassModel> GetGridData(EndUser_ETransitPassModel objtran);
        /// <summary>
        /// Added by suroj on 07-aug-2021 to update Mineral Recieve 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        string UpdateMineralReceipt(EndUser_ETransitPassModel model);
        /// <summary>
        /// Added by suroj on 17-aug-2021 to Add Recieve mineral
        /// </summary>
        /// <param name="objtran"></param>
        /// <returns></returns>
        List<EndUser_ETransitPassModel> MineralReceiveData(EndUser_ETransitPassModel objtran);

        /// <summary>
        /// Added by suroj kumar pradhan on 23-aug-2021 to bind Permit No in RPTP
        /// </summary>
        /// <returns></returns>
        List<RPTPModel> GetApprovedBulkPermitListRPTP(RPTPModel objmodel);
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
        List<RPTPModel> GetCascadePurchaserConsigneeRPTP(RPTPModel objRPTP);
        /// <summary>
        /// Added by suroj on 08-jul-2021 to Get destination Against Purchase consignee ID RPTP
        /// </summary>
        /// <param name="objTP"></param>
        /// <returns></returns>
        RPTPModel GetDataByPurchaserConsigneeIdRPTP(RPTPModel objmodel);

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
        /// <summary>
        ///  Added by Shyam Sir on 5-1-21 to print  Add
        ///  
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //ReturnOuputResult AddUserWiseTPConfiguration(UserWiseTPConfigurationViewModel model);
        //List<UserWiseTPConfigurationModel> ListUserWiseTPConfiguration(UserWiseTPConfigurationModel model);


    }
}
