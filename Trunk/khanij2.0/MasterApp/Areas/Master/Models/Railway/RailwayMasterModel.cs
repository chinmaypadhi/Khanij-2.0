using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Railway
{
    public class RailwayMasterModel : IRailwayMasterModel
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
        public RailwayMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(RailwayModel railwayModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Railway/Add", JsonConvert.SerializeObject(railwayModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(RailwayModel railwayModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Railway/Delete", JsonConvert.SerializeObject(railwayModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public RailwayModel Edit(RailwayModel railwayModel)
        {
            try
            {
                railwayModel = JsonConvert.DeserializeObject<RailwayModel>(_objIHttpWebClients.PostRequest("Railway/Edit", JsonConvert.SerializeObject(railwayModel)));
                return railwayModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(RailwayModel railwayModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Railway" +
                    "/Update", JsonConvert.SerializeObject(railwayModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<RailwayModel> View(RailwayModel railwayModel)
        {
            try
            {
                List<RailwayModel> listRailwayModel = new List<RailwayModel>();
                listRailwayModel = JsonConvert.DeserializeObject<List<RailwayModel>>(_objIHttpWebClients.PostRequest("Railway/ViewDetails", JsonConvert.SerializeObject(railwayModel)));
                return listRailwayModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
