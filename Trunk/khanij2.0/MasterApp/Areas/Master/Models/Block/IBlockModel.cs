// ***********************************************************************
//  Interface Name           : IBlockModel
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using System.Collections.Generic;
using MasterEF;

namespace MasterApp.Areas.Master.Models.Block
{
    public interface IBlockModel
    {
        /// <summary>
        /// Add Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        MessageEF Add(BlockMaster objBlockMaster);
        /// <summary>
        /// Update Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        MessageEF Update(BlockMaster objBlockMaster);
        /// <summary>
        /// Bind Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        List<BlockMaster> View(BlockMaster objBlockMaster);
        /// <summary>
        /// Delete Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        MessageEF Delete(BlockMaster objBlockMaster);
        /// <summary>
        /// Edit Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        BlockMaster Edit(BlockMaster objBlockMaster);
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        List<BlockMaster> GetStateList(BlockMaster objBlockMaster);
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        List<BlockMaster> GetDistrictList(BlockMaster objBlockMaster);
    }
}
