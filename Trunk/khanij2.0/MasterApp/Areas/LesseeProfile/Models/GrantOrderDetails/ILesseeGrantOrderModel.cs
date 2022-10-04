// ***********************************************************************
//  Interface Name           : ILesseeGrantOrderModel
//  Description              : Lessee Grant Order View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.LesseeProfile.Models.GrantOrderDetails
{
    public interface ILesseeGrantOrderModel
    {
        /// <summary>
        /// To bind Grant Order details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<GrantOrderViewModel> GetGrantOrderDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Grant Order details
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        MessageEF UpdateGrantOrderDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To bind Grant Order Log details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetGrantOrderLogDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To bind Grant Order Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetGrantOrderCompareDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To Approve Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        MessageEF ApproveLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To Reject Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        MessageEF RejectLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To Delete Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        MessageEF DeleteLesseeGrantOrderDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To Bind the Auction Type Details Data in View
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetAuctionTypeList(GrantOrderViewModel objGrantorderModel);

        /// <summary>
        /// To bind FY details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetFYDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To bind Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objGrantorderModel);
        /// <summary>
        /// To get Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetails(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To bind Grant Order Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<GrantOrderViewModel>> GetLesseeGrantOrderApprovedQuantityLogDetailsView(GrantOrderViewModel objGrantorderModel);
        /// <summary>
        /// To bind Grant Order Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetLesseeGrantOrderApprovedQuantityCompareDetails(MiningProductionModel objGrantorderModel);
    }
}
