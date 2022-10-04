// ***********************************************************************
//  Controller Name          : MPRCreatorController
//  Desciption               : Create,Approve,Forward Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.MPR;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class MPRCreatorController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IMPRProvider _objIMPRProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objMPRProvider"></param>
        public MPRCreatorController(IMPRProvider objMPRProvider)
        {
            _objIMPRProvider = objMPRProvider;
        }
        #region MPR Creator
        /// <summary>
        /// Post method to View Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> View(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.ViewMPRMaster(objMPRMaster);
        }
        /// <summary>
        /// Post method to Add Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.AddMPRMaster(objMPRMaster);
        }
        /// <summary>
        /// Post method to Edit Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRmaster> Edit(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.EditMPRMaster(objMPRMaster);
        }
        /// <summary>
        /// Post method to Update Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.UpdateMPRMaster(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Officer details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRmaster> GetOfficerNameAndDesignation(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetOfficerNameAndDesignation(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Field Progress Order details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRmaster> GetFPOdetailsByFPOCode(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetFPOdetailsByFPOCode(objMPRMaster);
        }
        /// <summary>
        /// Post method to Approve details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> SendForApproval(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.SendForApproval(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Mail data details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRmaster> GetMaildata(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetMaildata(objMPRMaster);
        }
        /// <summary>
        /// Post method to Preview Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MPRmaster> PreviewMPRMaster(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.PreviewMPRMaster(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Monthly Progress Report list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetMPRCodeList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetMPRCodeList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Mineral list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetMineralList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetMineralList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Division list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetDivisionList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetDivisionList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get District list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetDistrictList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetDistrictList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Tehsil list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetTehsilList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetTehsilList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Village list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetVillageList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetVillageList(objMPRMaster);
        }
        /// <summary>
        /// Post method to Get Regional Office list details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> GetRegionalOfficeList(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.GetRegionalOfficeList(objMPRMaster);
        }
        #endregion
        #region MPR Approver
        /// <summary>
        /// Post method to View Monthly Progress Report details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> ViewMPRApprover(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.ViewMPRApprover(objMPRMaster);
        }
        /// <summary>
        /// Post method to Update Monthly Progress Report status details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMPR_Status(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.UpdateMPR_Status(objMPRMaster);
        }
        /// <summary>
        /// Post method to Add Monthly Progress Report status details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMPR_Referback(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.UpdateMPR_Referback(objMPRMaster);
        }
        #endregion
        #region MPR Forwarder
        /// <summary>
        /// Post method to View Monthly Progress Report forward details
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MPRmaster>> ViewMPRForwarder(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.ViewMPRForwarder(objMPRMaster);
        }
        /// <summary>
        /// Post method to Forward to DGM
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> FORWARD_TO_DGM(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.FORWARD_TO_DGM(objMPRMaster);
        }
        /// <summary>
        /// Post method to Forward refer back
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> FORWARDER_REFER_BACK(MPRmaster objMPRMaster)
        {
            return await _objIMPRProvider.FORWARDER_REFER_BACK(objMPRMaster);
        }
        #endregion
    }
}