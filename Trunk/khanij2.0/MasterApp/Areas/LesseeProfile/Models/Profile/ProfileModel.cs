// ***********************************************************************
//  Class Name               : ProfileModel
//  Description              : Lessee Profile Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 10 Feb 2022
// ***********************************************************************
using MasterApp.Models.Utility;
using MasterEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MasterApp.Areas.LesseeProfile.Models.Profile
{
    public class ProfileModel:IProfileModel
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
        public ProfileModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Bind Profile Completion Count Details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public LesseeInfoModel GetProfileCompletionCount(LesseeInfoModel objLesseeInfoModel)
        {
            try
            {
                LesseeInfoModel ObjLesseeInfoModel = new LesseeInfoModel();
                ObjLesseeInfoModel = JsonConvert.DeserializeObject<LesseeInfoModel>(_objIHttpWebClients.PostRequest("Profile/GetProfileCompletionCount", JsonConvert.SerializeObject(objLesseeInfoModel)));
                return ObjLesseeInfoModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Profile Completion Request Count Details in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        public LesseeProfileIndividualCountModel GetLesseeProfileIndividualCountModel(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            try
            {
                LesseeProfileIndividualCountModel ObjLesseeProfileIndividualCountModel = new LesseeProfileIndividualCountModel();
                ObjLesseeProfileIndividualCountModel = JsonConvert.DeserializeObject<LesseeProfileIndividualCountModel>(_objIHttpWebClients.PostRequest("Profile/GetLesseeProfileIndividualCountModel", JsonConvert.SerializeObject(objLesseeProfileIndividualCountModel)));
                return ObjLesseeProfileIndividualCountModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Lessee Licensee Users by District in view
        /// </summary>
        /// <param name="objLesseeProfileIndividualCountModel"></param>
        /// <returns></returns>
        public List<LesseeProfileIndividualCountModel> GetLesseeLicneseeUserByDistrict(LesseeProfileIndividualCountModel objLesseeProfileIndividualCountModel)
        {
            try
            {
                List<LesseeProfileIndividualCountModel> ObjlistLesseeProfileIndividualCountModel = new List<LesseeProfileIndividualCountModel>();
                ObjlistLesseeProfileIndividualCountModel = JsonConvert.DeserializeObject<List<LesseeProfileIndividualCountModel>>(_objIHttpWebClients.PostRequest("Profile/GetLesseeLicneseeUserByDistrict", JsonConvert.SerializeObject(objLesseeProfileIndividualCountModel)));
                return ObjlistLesseeProfileIndividualCountModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Lessee Users by User,Role type in view
        /// </summary>
        /// <param name="objLesseeListForDGMModel"></param>
        /// <returns></returns>
        public List<LesseeListForDGMModel> GetLesseeListDGM(LesseeListForDGMModel objLesseeListForDGMModel)
        {
            try
            {
                List<LesseeListForDGMModel> ObjLesseeListForDGMModel = new List<LesseeListForDGMModel>();
                ObjLesseeListForDGMModel = JsonConvert.DeserializeObject<List<LesseeListForDGMModel>>(_objIHttpWebClients.PostRequest("Profile/GetLesseeListDGM", JsonConvert.SerializeObject(objLesseeListForDGMModel)));
                return ObjLesseeListForDGMModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
