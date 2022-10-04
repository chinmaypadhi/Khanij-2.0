using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.RailwayZone
{
    public class RailwayZoneMasterModel : IRailwayZoneMasterModel
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
        public RailwayZoneMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(RailwayZoneModel railwayZoneModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RailwayZone/Add", JsonConvert.SerializeObject(railwayZoneModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(RailwayZoneModel railwayZoneModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RailwayZone/Delete", JsonConvert.SerializeObject(railwayZoneModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public RailwayZoneModel Edit(RailwayZoneModel railwayZoneModel)
        {
            try
            {
                railwayZoneModel = JsonConvert.DeserializeObject<RailwayZoneModel>(_objIHttpWebClients.PostRequest("RailwayZone/Edit", JsonConvert.SerializeObject(railwayZoneModel)));
                return railwayZoneModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(RailwayZoneModel railwayZoneModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RailwayZone" +
                    "/Update", JsonConvert.SerializeObject(railwayZoneModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<RailwayZoneModel> View(RailwayZoneModel railwayZoneModel)
        {
            try
            {
                List<RailwayZoneModel> listRailwayZoneModel = new List<RailwayZoneModel>();
                listRailwayZoneModel = JsonConvert.DeserializeObject<List<RailwayZoneModel>>(_objIHttpWebClients.PostRequest("RailwayZone/ViewDetails", JsonConvert.SerializeObject(railwayZoneModel)));
                return listRailwayZoneModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
