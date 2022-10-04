// ***********************************************************************
//  Interface Name           : LabReportsModel
//  Desciption               : CRUD,Forward,Get Status,Get sample of Lab Reports
//  Created By               : Lingaraj Dalai
//  Created On               : 24 Feb 2021
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GeologyApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace GeologyApp.Models.LabReports
{
    public class LabReportsModel:ILabReportsModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public LabReportsModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Submit New Samples
        /// <summary>
        /// To Add the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Add(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("LabReports/Add",JsonConvert.SerializeObject(objLabReportmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Update(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LabReports/Update",JsonConvert.SerializeObject(objLabReportmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To View the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> View(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOmaster = new List<LabReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/View",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("LabReports/Delete",JsonConvert.SerializeObject(objLabReportmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit the Lab Report master details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public LabReportmaster Edit(LabReportmaster objLabReportmaster)
        {
            try
            {
                objLabReportmaster = JsonConvert.DeserializeObject<LabReportmaster>(_objIHttpWebClients.PostRequest("LabReports/Edit",JsonConvert.SerializeObject(objLabReportmaster)));
                return objLabReportmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Forward the Lab Report master details data
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF SendForForward(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("LabReports/SendForForward",JsonConvert.SerializeObject(objLabReportmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #region Bind dropdowns
        /// <summary>
        /// To bind MPR code list details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> GetMPRCodeList(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOtype = new List<LabReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/GetMPRCodeList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral list details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> GetMineralList(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOtype = new List<LabReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/GetMineralList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind Division list details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> GetDivisionList(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOtype = new List<LabReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/GetDivisionList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To bind Regional Office list details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> GetRegionalOfficeList(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOtype = new List<LabReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/GetRegionalOfficeList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get Study Analysis details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> GetTypeOfStudyAnalysis(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOtype = new List<LabReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/GetTypeOfStudyAnalysis",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To bind Officer details in view
        /// </summary>
        /// <param name="objLabReportmaster"></param>
        /// <returns></returns>
        public LabReportmaster GetOfficerNameAndDesignation(LabReportmaster objLabReportmaster)
        {
            try
            {
                objLabReportmaster = JsonConvert.DeserializeObject<LabReportmaster>(_objIHttpWebClients.PostRequest("LabReports/GetOfficerNameAndDesignation",JsonConvert.SerializeObject(objLabReportmaster)));
                return objLabReportmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region Lab Report Forward
        /// <summary>
        /// To View the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> ViewLabReportForward(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOmaster = new List<LabReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/ViewLabReportForward",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Add the Lab Report details data in view
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF SendForApproval(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("LabReports/SendForApproval",JsonConvert.SerializeObject(objLabReportmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region StatusofLabReport
        /// <summary>
        /// To View the Lab Report status Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> ViewStatusOfLabReport(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOmaster = new List<LabReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/ViewStatusOfLabReport",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Upload result in Lab report
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public MessageEF UploadResult(LabReportmaster objLabReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("LabReports/UploadResult",JsonConvert.SerializeObject(objLabReportmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region GetAnalysedSamples
        /// <summary>
        /// To View the Analysed samples Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> ViewAnalysedSamples(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOmaster = new List<LabReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/ViewAnalysedSamples",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View the Files list Details Data in View
        /// </summary>
        /// <param name="objLabReportsmaster"></param>
        /// <returns></returns>
        public List<LabReportmaster> ViewFilesList(LabReportmaster objLabReportmaster)
        {
            try
            {
                List<LabReportmaster> objlistFPOmaster = new List<LabReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<LabReportmaster>>(_objIHttpWebClients.PostRequest("LabReports/ViewFilesList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
