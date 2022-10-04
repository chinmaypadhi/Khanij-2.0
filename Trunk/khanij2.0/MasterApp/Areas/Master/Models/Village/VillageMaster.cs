using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Village
{
    public class VillageMaster : IVillageMaster
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
        public VillageMaster(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(VillageModel villageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Village/Add", JsonConvert.SerializeObject(villageModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(VillageModel villageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Village/Delete", JsonConvert.SerializeObject(villageModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public VillageModel Edit(VillageModel villageModel)
        {
            try
            {
                villageModel = JsonConvert.DeserializeObject<VillageModel>(_objIHttpWebClients.PostRequest("Village/Edit", JsonConvert.SerializeObject(villageModel)));
                return villageModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(VillageModel villageModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Village" +
                    "/Update", JsonConvert.SerializeObject(villageModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<VillageModel> View(VillageModel villageModel)
        {
            try
            {
                List<VillageModel> listVillageModel = new List<VillageModel>();
                listVillageModel = JsonConvert.DeserializeObject<List<VillageModel>>(_objIHttpWebClients.PostRequest("Village/ViewDetails", JsonConvert.SerializeObject(villageModel)));
                return listVillageModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
