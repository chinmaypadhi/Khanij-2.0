// ***********************************************************************
//  Interface Name           : MPRModel
//  Desciption               : CRUD,Create,Approve,Forward Monthly Progress Report
//  Created By               : Lingaraj Dalai
//  Created On               : 18 Feb 2021
// ***********************************************************************
using GeologyApp.Models.Utility;
using GeologyEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GeologyApp.Models.MPR
{
    public class MPRModel:IMPRModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public MPRModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region MPR Creator
        /// <summary>
        /// To Add the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public MessageEF Add(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/Add",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MessageEF Update(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MPRCreator/Update",JsonConvert.SerializeObject(objMPRMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To View the Monthly Progress Report list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> View(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOmaster = new List<MPRmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/View",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MessageEF Delete(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MPRCreator/Delete",JsonConvert.SerializeObject(objMPRMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Edit the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MPRmaster Edit(MPRmaster objMPRMaster)
        {
            try
            {
                objMPRMaster = JsonConvert.DeserializeObject<MPRmaster>(_objIHttpWebClients.PostRequest("MPRCreator/Edit",JsonConvert.SerializeObject(objMPRMaster)));
                return objMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Get the Officer details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MPRmaster GetOfficerNameAndDesignation(MPRmaster objMPRMaster)
        {
            try
            {
                objMPRMaster = JsonConvert.DeserializeObject<MPRmaster>(_objIHttpWebClients.PostRequest("MPRCreator/GetOfficerNameAndDesignation",JsonConvert.SerializeObject(objMPRMaster)));
                return objMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Get the Field Program Order details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MPRmaster GetFPOdetailsByFPOCode(MPRmaster objMPRMaster)
        {
            try
            {
                objMPRMaster = JsonConvert.DeserializeObject<MPRmaster>(_objIHttpWebClients.PostRequest("MPRCreator/GetFPOdetailsByFPOCode",JsonConvert.SerializeObject(objMPRMaster)));
                return objMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To send the data for approval
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MessageEF SendForApproval(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/SendForApproval",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get the Mail details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MPRmaster GetMaildata(MPRmaster objMPRMaster)
        {
            try
            {
                objMPRMaster = JsonConvert.DeserializeObject<MPRmaster>(_objIHttpWebClients.PostRequest("MPRCreator/GetMaildata",JsonConvert.SerializeObject(objMPRMaster)));
                return objMPRMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Preview the Monthly Progress Report details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public MPRmaster PreviewMPRMaster(MPRmaster objMPRMaster)
        {
            try
            {
                MPRmaster objlistFPOmaster = new MPRmaster();
                objlistFPOmaster = JsonConvert.DeserializeObject<MPRmaster>(_objIHttpWebClients.PostRequest("MPRCreator/PreviewMPRMaster",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Bind dropdowns
        /// <summary>
        /// To bind the Monthly Progress Report code list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetMPRCodeList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetMPRCodeList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind the Mineral list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetMineralList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetMineralList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind the Division list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetDivisionList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetDivisionList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind the District list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetDistrictList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetDistrictList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind the Tehsil list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetTehsilList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetTehsilList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the Village list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetVillageList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetVillageList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind the Regional list details data in view
        /// </summary>
        /// <param name="objMPRMaster"></param>
        /// <returns></returns>
        public List<MPRmaster> GetRegionalOfficeList(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOtype = new List<MPRmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/GetRegionalOfficeList",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #endregion
        #region MPR Approver
        /// <summary>
        /// To bind the Monthly Progress Report approver list details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public List<MPRmaster> ViewMPRApprover(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOmaster = new List<MPRmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/ViewMPRApprover",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Monthly Progress Report status
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateMPR_Status(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/UpdateMPR_Status",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Monthly Progress Report refer status
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateMPR_Referback(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/UpdateMPR_Referback",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region MPR Forwarder
        /// <summary>
        /// To bind the Monthly Progress Report Forwarder list details data in view
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public List<MPRmaster> ViewMPRForwarder(MPRmaster objMPRMaster)
        {
            try
            {
                List<MPRmaster> objlistFPOmaster = new List<MPRmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<MPRmaster>>(_objIHttpWebClients.PostRequest("MPRCreator/ViewMPRForwarder",JsonConvert.SerializeObject(objMPRMaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Forward the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public MessageEF FORWARD_TO_DGM(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/FORWARD_TO_DGM",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Forward refer back the Monthly Progress Report Forwarder list details data to DGM
        /// </summary>
        /// <param name="objMPRmaster"></param>
        /// <returns></returns>
        public MessageEF FORWARDER_REFER_BACK(MPRmaster objMPRMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRCreator/FORWARDER_REFER_BACK",JsonConvert.SerializeObject(objMPRMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region MPR Work
        /// <summary>
        /// To Add the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        public MessageEF AddMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("MPRWork/AddMPRWorkMaster", JsonConvert.SerializeObject(objMPRWorkMaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        public List<MPRWorkmaster> ViewMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            try
            {
                List<MPRWorkmaster> objlistMPRWorkmaster = new List<MPRWorkmaster>();
                objlistMPRWorkmaster = JsonConvert.DeserializeObject<List<MPRWorkmaster>>(_objIHttpWebClients.PostRequest("MPRWork/ViewMPRWorkMaster", JsonConvert.SerializeObject(objMPRWorkMaster)));
                return objlistMPRWorkmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MPRWork/UpdateMPRWorkMaster", JsonConvert.SerializeObject(objMPRWorkMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Delete the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        public MessageEF DeleteMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("MPRWork/DeleteMPRWorkMaster", JsonConvert.SerializeObject(objMPRWorkMaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Edit the Monthly Progress Report work details data in view
        /// </summary>
        /// <param name="objMPRWorkmaster"></param>
        /// <returns></returns>
        public MPRWorkmaster EditMPRWorkMaster(MPRWorkmaster objMPRWorkMaster)
        {
            try
            {
                objMPRWorkMaster = JsonConvert.DeserializeObject<MPRWorkmaster>(_objIHttpWebClients.PostRequest("MPRWork/EditMPRWorkMaster", JsonConvert.SerializeObject(objMPRWorkMaster)));
                return objMPRWorkMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
