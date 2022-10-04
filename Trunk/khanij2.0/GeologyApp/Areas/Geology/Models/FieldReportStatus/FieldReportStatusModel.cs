// ***********************************************************************
//  Class Name               : FieldReportStatusModel
//  Desciption               : Field Report Status
//  Created By               : Lingaraj Dalai
//  Created On               : 19 March 2021
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GeologyApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace GeologyApp.Areas.Geology.Models.FieldReportStatus
{
    public class FieldReportStatusModel:IFieldReportStatusModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public FieldReportStatusModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Field Report Status
        /// <summary>
        /// To Add Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public MessageEF Add(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("FieldReportStatus/Add", JsonConvert.SerializeObject(objFieldReportStatusmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public MessageEF Update(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("FieldReportStatus/Update",JsonConvert.SerializeObject(objFieldReportStatusmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To View Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public List<FieldReportStatusmaster> View(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                List<FieldReportStatusmaster> objlistFPOmaster = new List<FieldReportStatusmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<FieldReportStatusmaster>>(_objIHttpWebClients.PostRequest("FieldReportStatus/View",JsonConvert.SerializeObject(objFieldReportStatusmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("FieldReportStatus/Delete",JsonConvert.SerializeObject(objFieldReportStatusmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit Field Report Status Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public FieldReportStatusmaster Edit(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                objFieldReportStatusmaster = JsonConvert.DeserializeObject<FieldReportStatusmaster>(_objIHttpWebClients.PostRequest("FieldReportStatus/Edit",JsonConvert.SerializeObject(objFieldReportStatusmaster)));
                return objFieldReportStatusmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Bind the Regional Office Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public List<FieldReportStatusmaster> GetRegionalOfficeList(FieldReportStatusmaster objLabReportmaster)
        {
            try
            {
                List<FieldReportStatusmaster> objlistFPOtype = new List<FieldReportStatusmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<FieldReportStatusmaster>>(_objIHttpWebClients.PostRequest("FieldReportStatus/GetRegionalOfficeList",JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Submit Field Report to Regional Office
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public MessageEF UpdateStatusOfReport_STOREGIONALOFFICE(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("FieldReportStatus/ForwardToRO", JsonConvert.SerializeObject(objFieldReportStatusmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Fetch Email Details Data in View
        /// </summary>
        /// <param name="objFieldReportStatusmaster"></param>
        /// <returns></returns>
        public FieldReportStatusmaster ViewEmailDetails(FieldReportStatusmaster objFieldReportStatusmaster)
        {
            try
            {
                FieldReportStatusmaster objlistFPOmaster = new FieldReportStatusmaster();
                objlistFPOmaster = JsonConvert.DeserializeObject<FieldReportStatusmaster>(_objIHttpWebClients.PostRequest("FieldReportStatus/ViewEmailDetails", JsonConvert.SerializeObject(objFieldReportStatusmaster)));
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
