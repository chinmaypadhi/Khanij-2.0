// ***********************************************************************
//  Controller Name          : LesseeLeaseAreaDetailsController
//  Desciption               : Lessee Lease Area Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 21 April 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApi.Model.LesseeLeaseArea;
using MasterEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class LesseeLeaseAreaDetailsController : ControllerBase
    {
        public ILesseeLeaseAreaProvider _objILesseeLeaseAreaProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objILesseeLeaseAreaProvider"></param>
        public LesseeLeaseAreaDetailsController(ILesseeLeaseAreaProvider objILesseeLeaseAreaProvider)
        {
            _objILesseeLeaseAreaProvider = objILesseeLeaseAreaProvider;
        }
        /// <summary>
        /// POST method to bind State List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetStateList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetStateList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind District List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetDistrictList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Tehsil List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetTehsilList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetTehsilList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Village List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetVillageList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Lessee Lease Area Details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<LeaseAreaViewModel>> GetLeaseAreaDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseAreaDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Lease Land District List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLeaseLandDistrictList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseLandDistrictList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Lease Land Village List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLeaseLandVillageList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseLandVillageList(objLeaseAreaModel);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Update(LeaseAreaViewModel objLeaseAreaModel)
        {
            return _objILesseeLeaseAreaProvider.UpdateLeaseAreaDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// To bind Lease Area Log History details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLeaseAreaLogDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseAreaLogDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// o bind Lease Area Compare details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLeaseAreaCompareDetails(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseAreaCompareDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// To Approve Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Approve(LeaseAreaViewModel objLeaseAreaModel)
        {
            return _objILesseeLeaseAreaProvider.ApproveLeaseAreaDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// To Reject Lesse Lease Area details by DD
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Reject(LeaseAreaViewModel objLeaseAreaModel)
        {
            return _objILesseeLeaseAreaProvider.RejectLeaseAreaDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// To Delete Lesse Lease Area details
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Delete(LeaseAreaViewModel objLeaseAreaModel)
        {
            return _objILesseeLeaseAreaProvider.DeleteLeaseAreaDetails(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Land List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLandList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLandList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Lease Land Block List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLeaseLandBlockList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLeaseLandBlockList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Vidhan Sabha List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetVidhanSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetVidhanSabhaList(objLeaseAreaModel);
        }
        /// <summary>
        /// POST method to bind Lok Sabha List
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<LeaseAreaViewModel>>> GetLokSabhaList(LeaseAreaViewModel objLeaseAreaModel)
        {
            return await _objILesseeLeaseAreaProvider.GetLokSabhaList(objLeaseAreaModel);
        }
    }
}
