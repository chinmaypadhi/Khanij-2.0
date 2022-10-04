using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.MineralSchedule
{
    public class MineralScheduleMasterModel : IMineralScheduleMasterModel
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
        public MineralScheduleMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(MineralScheduleModel mineralScheduleModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedule/Add", JsonConvert.SerializeObject(mineralScheduleModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(MineralScheduleModel mineralScheduleModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedule/Delete", JsonConvert.SerializeObject(mineralScheduleModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public MineralScheduleModel Edit(MineralScheduleModel mineralScheduleModel)
        {
            try
            {
                mineralScheduleModel = JsonConvert.DeserializeObject<MineralScheduleModel>(_objIHttpWebClients.PostRequest("MineralSchedule/Edit", JsonConvert.SerializeObject(mineralScheduleModel)));
                return mineralScheduleModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(MineralScheduleModel mineralScheduleModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralSchedule" +
                    "/Update", JsonConvert.SerializeObject(mineralScheduleModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View 
        public List<MineralScheduleModel> View(MineralScheduleModel mineralScheduleModel)
        {
            try
            {
                List<MineralScheduleModel> listMineralScheduleModel = new List<MineralScheduleModel>();
                listMineralScheduleModel = JsonConvert.DeserializeObject<List<MineralScheduleModel>>(_objIHttpWebClients.PostRequest("MineralSchedule/ViewDetails", JsonConvert.SerializeObject(mineralScheduleModel)));
                return listMineralScheduleModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
