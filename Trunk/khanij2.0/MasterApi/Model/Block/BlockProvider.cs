// ***********************************************************************
//  Class Name               : BlockProvider
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Block
{
    public class BlockProvider: RepositoryBase,IBlockProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public BlockProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddBlockmaster(BlockMaster objBlockMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_STATE_ID", objBlockMaster.StateId);
                p.Add("P_INT_DISTRICT_ID", objBlockMaster.DistrictId);
                p.Add("P_VCH_BLOCK_NAME", objBlockMaster.BlockName);
                p.Add("P_INT_USER_LOGIN_ID", objBlockMaster.UserLoginID);
                p.Add("P_INT_USER_ID", objBlockMaster.UserID);
                p.Add("P_BIT_ACTIVE", objBlockMaster.IsActive);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_BLOCK_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Edit Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<List<BlockMaster>> ViewBlockMaster(BlockMaster objBlockMaster)
        {
            List<BlockMaster> ListChecklistmaster = new List<BlockMaster>();
            try
            {
                var paramList = new
                {
                    P_INT_BLOCK_ID = objBlockMaster.BlockId,
                    P_INT_DISTRICT_ID = objBlockMaster.DistrictId,
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<BlockMaster>("USP_BLOCK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListChecklistmaster = result.ToList();
                }
                return ListChecklistmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<BlockMaster> EditBlockMaster(BlockMaster objBlockMaster)
        {
            BlockMaster LobjChecklistmaster = new BlockMaster();
            try
            {
                var paramList = new
                {
                    P_INT_BLOCK_ID = objBlockMaster.BlockId,
                    P_VCH_ACTION = "SELECT",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<BlockMaster>("USP_BLOCK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjChecklistmaster = result.FirstOrDefault();
                }
                return LobjChecklistmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteBlockMaster(BlockMaster objBlockMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_BLOCK_ID", objBlockMaster.BlockId);
                p.Add("P_INT_USER_LOGIN_ID", objBlockMaster.UserLoginID); 
                p.Add("P_INT_USER_ID", objBlockMaster.UserID);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<int>("USP_BLOCK_MASTER", p, commandType: System.Data.CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Block details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateBlockMaster(BlockMaster objBlockMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_BLOCK_ID", objBlockMaster.BlockId);
                p.Add("P_INT_STATE_ID", objBlockMaster.StateId);
                p.Add("P_INT_DISTRICT_ID", objBlockMaster.DistrictId);
                p.Add("P_VCH_BLOCK_NAME", objBlockMaster.BlockName);
                p.Add("P_INT_USER_LOGIN_ID", objBlockMaster.UserLoginID);
                p.Add("P_INT_USER_ID", objBlockMaster.UserID);
                p.Add("P_BIT_ACTIVE", objBlockMaster.IsActive);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_BLOCK_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Bind State List Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<List<BlockMaster>> GetStateList(BlockMaster objBlockMaster)
        {
            List<BlockMaster> ObjStateList = new List<BlockMaster>();
            try
            {
                var paramList = new
                {
                    Chk = "State"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<BlockMaster>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjStateList = result.ToList();
                }
                return ObjStateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        ///// <summary>
        ///// Bind Division details in view
        ///// </summary>
        ///// <param name="objBlockMaster"></param>
        ///// <returns></returns>
        //public async Task<List<BlockMaster>> GetDivisionList(BlockMaster objBlockMaster)
        //{
        //    List<BlockMaster> ObjDivisionList = new List<BlockMaster>();
        //    try
        //    {
        //        var paramList = new
        //        {

        //        };
        //        DynamicParameters param = new DynamicParameters();
        //        var result = await Connection.QueryAsync<BlockMaster>("spGetDivisionData", paramList, commandType: System.Data.CommandType.StoredProcedure);
        //        if (result.Count() > 0)
        //        {
        //            ObjDivisionList = result.ToList();
        //        }
        //        return ObjDivisionList;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public async Task<List<BlockMaster>> GetDistrictList(BlockMaster objBlockMaster)
        {
            List<BlockMaster> ObjDistrictList = new List<BlockMaster>();
            try
            {
                var paramList = new
                {
                    Chk = "District",
                    StateID = objBlockMaster.StateId
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<BlockMaster>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjDistrictList = result.ToList();
                }
                return ObjDistrictList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
