using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Mineral
{
    public class MineralMasterModel : IMineralMasterModel
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
        public MineralMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        /// <summary>
        /// Add  Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public MessageEF Add(MineralModel mineralModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/AddMineral", JsonConvert.SerializeObject(mineralModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public MessageEF Delete(MineralModel mineralModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral/DeleteMineral", JsonConvert.SerializeObject(mineralModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public MineralModel Edit(MineralModel mineralModel)
        {
            try
            {
                mineralModel = JsonConvert.DeserializeObject<MineralModel>(_objIHttpWebClients.PostRequest("Mineral/EditMineral", JsonConvert.SerializeObject(mineralModel)));
                return mineralModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public MessageEF Update(MineralModel mineralModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Mineral" +
                    "/UpdateMineral", JsonConvert.SerializeObject(mineralModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        /// <summary>
        /// Bind Mineral details in view
        /// </summary>
        /// <param name="mineralModel"></param>
        /// <returns></returns>
        public List<MineralModel> View(MineralModel mineralModel)
        {
            try
            {
                List<MineralModel> listMineralModel = new List<MineralModel>();
                listMineralModel = JsonConvert.DeserializeObject<List<MineralModel>>(_objIHttpWebClients.PostRequest("Mineral/ViewMineral", JsonConvert.SerializeObject(mineralModel)));
                return listMineralModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
