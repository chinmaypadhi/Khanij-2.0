// ***********************************************************************
//  Controller Name          : FPOOrderController
//  Desciption               : Add,Edit,Update,View,Delete Field Program Order
//  Created By               : Lingaraj Dalai
//  Created On               : 12 Feb 2021
// ***********************************************************************
using System.Collections.Generic;
using System.Threading.Tasks;
using GeologyApi.Model.FPO;
using GeologyEF;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeologyApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class FPOOrderController : ControllerBase
    {
        /// <summary>
        /// Global variable declaration
        /// </summary>
        public IFPOProvider _objIFPOProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objFPOProvider"></param>
        public FPOOrderController(IFPOProvider objFPOProvider)
        {
            _objIFPOProvider = objFPOProvider;
        }
        /// <summary>
        /// Post method to Add Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.AddFPOMaster(objFPOMaster);
        }
        /// <summary>
        /// Post method to View Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<FPOOrdermaster>> View(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.ViewFPOMaster(objFPOMaster);
        }
        /// <summary>
        /// Post method to Edit Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<FPOOrdermaster> Edit(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.EditFPOMaster(objFPOMaster);
        }
        /// <summary>
        /// Post method to Update Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.UpdateFPOMaster(objFPOMaster);
        }
        /// <summary>
        /// Post method to Delete Field Program Order
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.DeleteFPOMaster(objFPOMaster);
        }
        /// <summary>
        /// Post method to bind Field Season list details in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<FPOOrdermaster>> GetFieldSeasonList(FPOOrdermaster objFPOMaster)
        {
            return await _objIFPOProvider.GetFieldSeasonList(objFPOMaster);
        }
    }
}