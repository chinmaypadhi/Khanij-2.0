// ***********************************************************************
//  Class Name               : BlockModel
//  Description              : Add,View,Edit,Update,Delete Block Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MasterApp.Areas.Master.Models.Block
{
    public class BlockModel:IBlockModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public BlockModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Block Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public MessageEF Add(BlockMaster objBlockMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Block/Add", JsonConvert.SerializeObject(objBlockMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update Block Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public MessageEF Update(BlockMaster objBlockMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Block/Update", JsonConvert.SerializeObject(objBlockMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// View Block Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public List<BlockMaster> View(BlockMaster objBlockMaster)
        {
            try
            {
                List<BlockMaster> objlistCheckPostmaster = new List<BlockMaster>();
                objlistCheckPostmaster = JsonConvert.DeserializeObject<List<BlockMaster>>(_objIHttpWebClients.PostRequest("Block/View", JsonConvert.SerializeObject(objBlockMaster)));
                return objlistCheckPostmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Delete Block Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(BlockMaster objBlockMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Block/Delete", JsonConvert.SerializeObject(objBlockMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Edit Block Details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public BlockMaster Edit(BlockMaster objBlockMaster)
        {
            try
            {
                objBlockMaster = JsonConvert.DeserializeObject<BlockMaster>(_objIHttpWebClients.PostRequest("Block/Edit", JsonConvert.SerializeObject(objBlockMaster)));
                return objBlockMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public List<BlockMaster> GetStateList(BlockMaster objBlockMaster)
        {
            try
            {
                List<BlockMaster> objlistDistrict = new List<BlockMaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<BlockMaster>>(_objIHttpWebClients.PostRequest("Block/GetStateList", JsonConvert.SerializeObject(objBlockMaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objBlockMaster"></param>
        /// <returns></returns>
        public List<BlockMaster> GetDistrictList(BlockMaster objBlockMaster)
        {
            try
            {
                List<BlockMaster> objlistDistrict = new List<BlockMaster>();
                objlistDistrict = JsonConvert.DeserializeObject<List<BlockMaster>>(_objIHttpWebClients.PostRequest("Block/GetDistrictList", JsonConvert.SerializeObject(objBlockMaster)));
                return objlistDistrict;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
