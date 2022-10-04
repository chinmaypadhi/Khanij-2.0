// ***********************************************************************
//  Controller Name          : BlockController
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MasterEF;
using System.Collections.Generic;
using MasterApi.Model.Block;
using System.Threading.Tasks;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class BlockController : Controller
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public IBlockProvider _objIBlockProvider;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public BlockController(IBlockProvider objIBlockProvider)
        {
            _objIBlockProvider = objIBlockProvider;
        }
        /// <summary>
        /// Add Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Add(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.AddBlockmaster(objBlockMaster);
        }
        /// <summary>
        /// View Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<BlockMaster>> View(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.ViewBlockMaster(objBlockMaster);
        }
        /// <summary>
        /// Edit Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<BlockMaster> Edit(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.EditBlockMaster(objBlockMaster);
        }
        /// <summary>
        /// Delete Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Delete(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.DeleteBlockMaster(objBlockMaster);
        }
        /// <summary>
        /// Update Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.UpdateBlockMaster(objBlockMaster);
        }
        /// <summary>
        /// Bind State List Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<BlockMaster>> GetStateList(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.GetStateList(objBlockMaster);
        }
        ///// <summary>
        ///// Bind Division List Details in view
        ///// </summary>
        ///// <param name="objBlockMaster"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public async Task<List<BlockMaster>> GetDivisionList(BlockMaster objBlockMaster)
        //{
        //    return await _objIBlockProvider.GetDivisionList(objBlockMaster);
        //}
        /// <summary>
        /// Bind District List Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<BlockMaster>> GetDistrictList(BlockMaster objBlockMaster)
        {
            return await _objIBlockProvider.GetDistrictList(objBlockMaster);
        }
    }
}
