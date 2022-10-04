using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.MineralGrade
{
    public class MineralGradeMasterModel : IMineralGradeMasterModel
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
        public MineralGradeMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(MineralGradeModel mineralGradeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralGrade/Add", JsonConvert.SerializeObject(mineralGradeModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(MineralGradeModel mineralGradeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralGrade/Delete", JsonConvert.SerializeObject(mineralGradeModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public MineralGradeModel Edit(MineralGradeModel mineralGradeModel)
        {
            try
            {
                mineralGradeModel = JsonConvert.DeserializeObject<MineralGradeModel>(_objIHttpWebClients.PostRequest("MineralGrade/Edit", JsonConvert.SerializeObject(mineralGradeModel)));
                return mineralGradeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(MineralGradeModel mineralGradeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralGrade/Update", JsonConvert.SerializeObject(mineralGradeModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<MineralGradeModel> View(MineralGradeModel mineralGradeModel)
        {
            try
            {
                List<MineralGradeModel> listMineralGradeModel = new List<MineralGradeModel>();
                listMineralGradeModel = JsonConvert.DeserializeObject<List<MineralGradeModel>>(_objIHttpWebClients.PostRequest("MineralGrade/ViewDetails", JsonConvert.SerializeObject(mineralGradeModel)));
                return listMineralGradeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        
        #endregion
    }
}
