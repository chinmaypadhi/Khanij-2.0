// ***********************************************************************
//  Class Name               : MineralUnitModel
//  Description              : Add,View,Edit,Update,Delete Mineral Unit Details
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Jan 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.MineralUnit
{
    public class MineralUnitModel:IMineralUnitModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public MineralUnitModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Add Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF Add(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralUnit/Add", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Update Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF Update(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralUnit/Update", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public List<MineralUnitmaster> View(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                List<MineralUnitmaster> objlistMineralUnitmaster = new List<MineralUnitmaster>();
                objlistMineralUnitmaster = JsonConvert.DeserializeObject<List<MineralUnitmaster>>(_objIHttpWebClients.PostRequest("MineralUnit/View", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objlistMineralUnitmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralUnit/Delete", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Edit Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public MineralUnitmaster Edit(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                objMineralUnitmaster = JsonConvert.DeserializeObject<MineralUnitmaster>(_objIHttpWebClients.PostRequest("MineralUnit/Edit", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objMineralUnitmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Bind Lessee Mineral Unit Details in view
        /// </summary>
        /// <param name="objMineralUnitmaster"></param>
        /// <returns></returns>
        public List<MineralUnitmaster> ViewLesseeUnit(MineralUnitmaster objMineralUnitmaster)
        {
            try
            {
                List<MineralUnitmaster> objlistMineralUnitmaster = new List<MineralUnitmaster>();
                objlistMineralUnitmaster = JsonConvert.DeserializeObject<List<MineralUnitmaster>>(_objIHttpWebClients.PostRequest("MineralUnit/ViewLesseeUnit", JsonConvert.SerializeObject(objMineralUnitmaster)));
                return objlistMineralUnitmaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
