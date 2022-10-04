// ***********************************************************************
//  Interface Name           : IBlockProvider
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 26 Dec 2021
// ***********************************************************************
using MasterEF;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasterApi.Model.Block
{
    public interface IBlockProvider
    {
        /// <summary>
        /// Add Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<MessageEF> AddBlockmaster(BlockMaster objBlockMaster);
        /// <summary>
        /// View Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<List<BlockMaster>> ViewBlockMaster(BlockMaster objBlockMaster);
        /// <summary>
        /// Edit Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<BlockMaster> EditBlockMaster(BlockMaster objBlockMaster);
        /// <summary>
        /// Delete Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<MessageEF> DeleteBlockMaster(BlockMaster objBlockMaster);
        /// <summary>
        /// Update Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<MessageEF> UpdateBlockMaster(BlockMaster objBlockMaster);
        /// <summary>
        /// Bind State List Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<List<BlockMaster>> GetStateList(BlockMaster objBlockMaster);
        ///// <summary>
        ///// Bind Module List Details in view
        ///// </summary>
        ///// <param name="objBlockMaster"></param>
        ///// <returns></returns>
        //Task<List<BlockMaster>> GetDivisionList(BlockMaster objBlockMaster);
        /// <summary>
        /// Bind Division List Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        Task<List<BlockMaster>> GetDistrictList(BlockMaster objBlockMaster);
    }
}
