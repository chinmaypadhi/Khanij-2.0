using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Royalty
{
    public class RoyaltyMasterModel : IRoyaltyMasterModel
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
        public RoyaltyMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(RoyaltyModel royaltyModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Royalty/Add", JsonConvert.SerializeObject(royaltyModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(RoyaltyModel royaltyModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Royalty/Delete", JsonConvert.SerializeObject(royaltyModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public RoyaltyModel Edit(RoyaltyModel royaltyModel)
        {
            try
            {
                royaltyModel = JsonConvert.DeserializeObject<RoyaltyModel>(_objIHttpWebClients.PostRequest("Royalty/Edit", JsonConvert.SerializeObject(royaltyModel)));
                return royaltyModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(RoyaltyModel royaltyModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Royalty" +
                    "/Update", JsonConvert.SerializeObject(royaltyModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<RoyaltyModel> View(RoyaltyModel royaltyModel)
        {
            try
            {
                List<RoyaltyModel> listRoyaltyModel = new List<RoyaltyModel>();
                listRoyaltyModel = JsonConvert.DeserializeObject<List<RoyaltyModel>>(_objIHttpWebClients.PostRequest("Royalty/ViewDetails", JsonConvert.SerializeObject(royaltyModel)));
                return listRoyaltyModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
