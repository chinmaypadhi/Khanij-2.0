using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.MineralSchedulePart
{
    public class MineralSchedulePartMasterModel : IMineralSchedulePartMasterModel
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
        public MineralSchedulePartMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedulePart/Add", JsonConvert.SerializeObject(mineralSchedulePartModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedulePart/Delete", JsonConvert.SerializeObject(mineralSchedulePartModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public MineralSchedulePartModel Edit(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {
                mineralSchedulePartModel = JsonConvert.DeserializeObject<MineralSchedulePartModel>(_objIHttpWebClients.PostRequest("MineralSchedulePart/Edit", JsonConvert.SerializeObject(mineralSchedulePartModel)));
                return mineralSchedulePartModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedulePart" +
                    "/Update", JsonConvert.SerializeObject(mineralSchedulePartModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<MineralSchedulePartModel> View(MineralSchedulePartModel mineralSchedulePartModel)
        {
            try
            {
                List<MineralSchedulePartModel> listMineralSchedulePartModel = new List<MineralSchedulePartModel>();
                listMineralSchedulePartModel = JsonConvert.DeserializeObject<List<MineralSchedulePartModel>>(_objIHttpWebClients.PostRequest("MineralSchedulePart/ViewDetails", JsonConvert.SerializeObject(mineralSchedulePartModel)));
                return listMineralSchedulePartModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
