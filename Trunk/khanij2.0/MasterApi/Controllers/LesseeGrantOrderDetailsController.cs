// ***********************************************************************
//  Controller Name          : LesseeGrantOrderDetailsController
//  Description              : Lessee Grant Order Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 16 July 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Model.LesseeGrantOrder;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeGrantOrderDetailsController : ControllerBase
    {
        public ILesseeGrantOrderProvider _objILesseeGrantOrderProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeOfficeMasterProvider"></param>
        public LesseeGrantOrderDetailsController(ILesseeGrantOrderProvider objILesseeGrantOrderProvider)
        {
            _objILesseeGrantOrderProvider = objILesseeGrantOrderProvider;
        }
        /// To bind Grant Order details in view
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<GrantOrderViewModel>> GetGrantOrderDetails(GrantOrderViewModel objGrantOrderViewModel)
        {
            return await _objILesseeGrantOrderProvider.GetGrantOrderDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Grant Order details
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(GrantOrderViewModel objGrantOrderViewModel)
        {
            return _objILesseeGrantOrderProvider.UpdateGrantOrderDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// To bind Grant order Log History details in view
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GrantOrderViewModel>>> GetGrantOrderLogDetails(GrantOrderViewModel objGrantOrderViewModel)
        {
            return await _objILesseeGrantOrderProvider.GetGrantOrderLogDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// o bind Grant order Compare details in view
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GrantOrderViewModel>>> GetGrantOrderCompareDetails(GrantOrderViewModel objGrantOrderViewModel)
        {
            return await _objILesseeGrantOrderProvider.GetGrantOrderCompareDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// To Approve Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(GrantOrderViewModel objGrantOrderViewModel)
        {
            return _objILesseeGrantOrderProvider.ApproveLesseeGrantOrderDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// To Reject Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(GrantOrderViewModel objGrantOrderViewModel)
        {
            return _objILesseeGrantOrderProvider.RejectLesseeGrantOrderDetails(objGrantOrderViewModel);
        }
        /// <summary>
        /// To bind Auction Type dropdown in view
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<GrantOrderViewModel>> GetAuctionTypeList(GrantOrderViewModel objGrantOrderViewModel)
        {
            return await _objILesseeGrantOrderProvider.GetAuctionTypeList(objGrantOrderViewModel);
        }
        /// <summary>
        /// To Delete Lesse Grant Order details by DD
        /// </summary>
        /// <param name="objGrantOrderViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(GrantOrderViewModel objGrantOrderViewModel)
        {
            return _objILesseeGrantOrderProvider.DeleteLesseeGrantOrderDetails(objGrantOrderViewModel);
        }
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetApprovedQuantityDetails(MiningProductionModel objGrantorderModel)
        {
            return await _objILesseeGrantOrderProvider.GetApprovedQuantityDetails(objGrantorderModel);
        }
        /// <summary>
        /// To get Grant Order Approved Quantity details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GrantOrderViewModel>>> GetLesseeGrantOrderApprovedQuantityLogDetails(GrantOrderViewModel objGrantorderModel)
        {
            return await _objILesseeGrantOrderProvider.GetLesseeGrantOrderApprovedQuantityLogDetails(objGrantorderModel);
        }
        /// <summary>
        /// To bind Grant Order Approved Quantity Log History details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GrantOrderViewModel>>> GetLesseeGrantOrderApprovedQuantityLogDetailsView(GrantOrderViewModel objGrantorderModel)
        {
            return await _objILesseeGrantOrderProvider.GetLesseeGrantOrderApprovedQuantityLogDetailsView(objGrantorderModel);
        }
        /// <summary>
        /// To bind Grant Order Approved Quantity Compare details in view
        /// </summary>
        /// <param name="objGrantorderModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MiningProductionModel>>> GetLesseeGrantOrderApprovedQuantityCompareDetails(MiningProductionModel objGrantorderModel)
        {
            return await _objILesseeGrantOrderProvider.GetLesseeGrantOrderApprovedQuantityCompareDetails(objGrantorderModel);
        }
    }
}
