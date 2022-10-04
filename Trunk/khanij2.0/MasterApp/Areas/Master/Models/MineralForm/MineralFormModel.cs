using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.MineralForm
{
    public class MineralFormModel : IMineralFormModel
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
        public MineralFormModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(MineralNatureModel mineralNatureModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralForm/Add", JsonConvert.SerializeObject(mineralNatureModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(MineralNatureModel mineralNatureModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralForm/Delete", JsonConvert.SerializeObject(mineralNatureModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public MineralNatureModel Edit(MineralNatureModel mineralNatureModel)
        {
            try
            {
                mineralNatureModel = JsonConvert.DeserializeObject<MineralNatureModel>(_objIHttpWebClients.PostRequest("MineralForm/Edit", JsonConvert.SerializeObject(mineralNatureModel)));
                return mineralNatureModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(MineralNatureModel mineralNatureModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MineralForm" +
                    "/Update", JsonConvert.SerializeObject(mineralNatureModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<MineralNatureModel> View(MineralNatureModel mineralNatureModel)
        {
            try
            {
                List<MineralNatureModel> listMineralNatureModel = new List<MineralNatureModel>();
                listMineralNatureModel = JsonConvert.DeserializeObject<List<MineralNatureModel>>(_objIHttpWebClients.PostRequest("MineralForm/ViewDetails", JsonConvert.SerializeObject(mineralNatureModel)));
                return listMineralNatureModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<MineralGradeModel> ViewMineralCategory(MineralGradeModel mineralGradeModel)
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
