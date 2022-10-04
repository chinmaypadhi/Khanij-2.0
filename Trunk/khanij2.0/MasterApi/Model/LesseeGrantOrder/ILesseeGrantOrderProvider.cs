// ***********************************************************************
//  Interface Name           : ILesseeOfficeMasterProvider
//  Description              : Lessee Grant Order Interface Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;

namespace MasterApi.Model.LesseeGrantOrder
{
    public interface ILesseeGrantOrderProvider
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
        /// To bind Grant Order Log History details in view
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
        /// To Delete Lesse Grant Order details
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
        /// To bind Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objMiningProductionModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetApprovedQuantityDetails(MiningProductionModel objMiningProductionModel);
        /// <summary>
        /// To bind Lessee Grant Order Approved quantity details data in view
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
        /// To bind Grant Order Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        Task<List<MiningProductionModel>> GetLesseeGrantOrderApprovedQuantityCompareDetails(MiningProductionModel objGrantorderModel);
    }
}
