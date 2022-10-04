// ***********************************************************************
//  Class Name               : LesseeOfficeMasterModel
//  Description              : Lessee Office Master View Model Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 13 July 2021
// ***********************************************************************
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.LesseeProfile.Models.OfficeDetails
{
    public class LesseeOfficeMasterModel:ILesseeOfficeMasterModel
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
        public LesseeOfficeMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To bind Company/Association details in view
        /// </summary>
        /// <param name="objLesseeInfoModel"></param>
        /// <returns></returns>
        public async Task<List<OfficeMasterViewModel>> GetAssociationListDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objofficelist = new List<OfficeMasterViewModel>();
                objofficelist = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(await _objIHttpWebClients.AwaitPostRequest("LesseeOfficeDetails/GetAssociationListDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objofficelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Office Master details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public OfficeMasterViewModel GetOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                OfficeMasterViewModel objOfficeMaster = new OfficeMasterViewModel();
                objOfficeMaster = JsonConvert.DeserializeObject<OfficeMasterViewModel>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetOfficeMasterDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objOfficeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Lesse Office details
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public MessageEF UpdateOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/Update", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        ///  To bind Last approved Lessee Office Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeOfficeMasterCompareDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeOfficeMasterCompareDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/Approve", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// To Reject Lesse Office details by DD
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public MessageEF RejectLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/Reject", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        ///  To bind Lessee Category Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeCategoryLogDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeCategoryLogDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  To bind Lessee Corporate Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeCorporateOfficeLogDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeCorporateOfficeLogDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  To bind Lessee Branch Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeBranchOfficeLogDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeBranchOfficeLogDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  To bind Lessee Site Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeSiteOfficeLogDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeSiteOfficeLogDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  To bind Lessee Agent Office Log Details in view
        /// </summary>
        /// <param name="objOfficeMasterModel"></param>
        /// <returns></returns>
        public List<OfficeMasterViewModel> GetLesseeAgentOfficeLogDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                List<OfficeMasterViewModel> objlistOffice = new List<OfficeMasterViewModel>();
                objlistOffice = JsonConvert.DeserializeObject<List<OfficeMasterViewModel>>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/GetLesseeAgentOfficeLogDetails", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objlistOffice;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Lesse Office Master details
        /// </summary>
        /// <param name="objOfficemasterModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLesseeOfficeMasterDetails(OfficeMasterViewModel objOfficeMasterModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LesseeOfficeDetails/Delete", JsonConvert.SerializeObject(objOfficeMasterModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
