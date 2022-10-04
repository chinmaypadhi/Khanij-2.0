// ***********************************************************************
//  Class Name               : MineralInformationModel
//  Description              : Lessee Mineral Information Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 20 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.MineralInformation
{
    public class MineralInformationModel: IMineralInformationModel
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
        public MineralInformationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralCategoryDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objmineralcategorylist = new List<LesseeMineralInformationModel>();
                objmineralcategorylist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralCategoryDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objmineralcategorylist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralNameDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objmineralnamelist = new List<LesseeMineralInformationModel>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralNameDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralFormDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objmineralnamelist = new List<LesseeMineralInformationModel>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralFormDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralGradeDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objmineralnamelist = new List<LesseeMineralInformationModel>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralGradeDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<LesseeMineralInformationModel> GetMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                LesseeMineralInformationModel objmineralinformationlist = new LesseeMineralInformationModel();
                objmineralinformationlist = JsonConvert.DeserializeObject<LesseeMineralInformationModel>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralInformationDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objmineralinformationlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Log details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralInformationLogDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objgrantorderlist = new List<LesseeMineralInformationModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralInformationLogDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public async Task<List<LesseeMineralInformationModel>> GetMineralInformationCompareDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                List<LesseeMineralInformationModel> objgrantorderlist = new List<LesseeMineralInformationModel>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<LesseeMineralInformationModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeMineralInformation/GetMineralInformationCompareDetails", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Mineral Information details
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF UpdateMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMineralInformation/Update", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Approve Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMineralInformation/Approve", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMineralInformation/Reject", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Lesse Mineral Information details by DD
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeMineralInformationDetails(LesseeMineralInformationModel objLesseeMineralInformationModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeMineralInformation/Delete", JsonConvert.SerializeObject(objLesseeMineralInformationModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
