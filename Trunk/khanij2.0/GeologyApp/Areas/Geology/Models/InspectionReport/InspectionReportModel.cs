// ***********************************************************************
//  Interface Name           : InspectionReportModel
//  Desciption               : Add,View,Edit,Update,Delete Inspection Report
//  Created By               : Lingaraj Dalai
//  Created On               : 01 March 2021
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using GeologyApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace GeologyApp.Models.InspectionReport
{
    public class InspectionReportModel:IInspectionReportModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public InspectionReportModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Submit Inspection Report
        /// <summary>
        /// To Add the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Add(InspectionReportmaster objInspectionReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("InspectionReport/Add",JsonConvert.SerializeObject(objInspectionReportmaster))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Update(InspectionReportmaster objInspectionReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("InspectionReport/Update",JsonConvert.SerializeObject(objInspectionReportmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To View the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public List<InspectionReportmaster> View(InspectionReportmaster objInspectionReportmaster)
        {
            try
            {
                List<InspectionReportmaster> objlistFPOmaster = new List<InspectionReportmaster>();
                objlistFPOmaster = JsonConvert.DeserializeObject<List<InspectionReportmaster>>(_objIHttpWebClients.PostRequest("InspectionReport/ViewInspectionReportsmaster", JsonConvert.SerializeObject(objInspectionReportmaster)));
                return objlistFPOmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public MessageEF Delete(InspectionReportmaster objInspectionReportmaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("InspectionReport/Delete",JsonConvert.SerializeObject(objInspectionReportmaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Edit the Inspection Report details data in view
        /// </summary>
        /// <param name="objInspectionReportsmaster"></param>
        /// <returns></returns>
        public InspectionReportmaster Edit(InspectionReportmaster objInspectionReportmaster)
        {
            try
            {
                objInspectionReportmaster = JsonConvert.DeserializeObject<InspectionReportmaster>(_objIHttpWebClients.PostRequest("InspectionReport/Edit",JsonConvert.SerializeObject(objInspectionReportmaster)));
                return objInspectionReportmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// To Get the MPR code list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public List<InspectionReportmaster> GetMPRCodeList(InspectionReportmaster objLabReportmaster)
        {
            try
            {
                List<InspectionReportmaster> objlistFPOtype = new List<InspectionReportmaster>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<InspectionReportmaster>>(_objIHttpWebClients.PostRequest("InspectionReport/GetMPRCodeList", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Get the Officer list details data in view
        /// </summary>
        /// <param name="objFPOMaster"></param>
        /// <returns></returns>
        public InspectionReportmaster GetOfficerNameAndDesignation(InspectionReportmaster objLabReportmaster)
        {
            try
            {
                objLabReportmaster = JsonConvert.DeserializeObject<InspectionReportmaster>(_objIHttpWebClients.PostRequest("InspectionReport/GetOfficerNameAndDesignation", JsonConvert.SerializeObject(objLabReportmaster)));
                return objLabReportmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region new Geology insertion
        public MessageEF AddGeologyNew(GeologyMainData objGeologyMainData)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("InspectionReport/AddGeologyNew", JsonConvert.SerializeObject(objGeologyMainData))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<GeologyMainData> GetDistrict(GeologyMainData objLabReportmaster)
        {
            try
            {
                List<GeologyMainData> objlistFPOtype = new List<GeologyMainData>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<GeologyMainData>>(_objIHttpWebClients.PostRequest("InspectionReport/GetDistrict", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GeologyMainData> GetTahasil(GeologyMainData objLabReportmaster)
        {
            try
            {
                List<GeologyMainData> objlistFPOtype = new List<GeologyMainData>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<GeologyMainData>>(_objIHttpWebClients.PostRequest("InspectionReport/GetTahasil", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GeologyMainData> GetVillage(GeologyMainData objLabReportmaster)
        {
            try
            {
                List<GeologyMainData> objlistFPOtype = new List<GeologyMainData>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<GeologyMainData>>(_objIHttpWebClients.PostRequest("InspectionReport/GetVillage", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GeologyMainData> GetDesig(GeologyMainData objLabReportmaster)
        {
            try
            {
                List<GeologyMainData> objlistFPOtype = new List<GeologyMainData>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<GeologyMainData>>(_objIHttpWebClients.PostRequest("InspectionReport/GetDesig", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<GeologyMainData> GetVehicle(GeologyMainData objLabReportmaster)
        {
            try
            {
                List<GeologyMainData> objlistFPOtype = new List<GeologyMainData>();
                objlistFPOtype = JsonConvert.DeserializeObject<List<GeologyMainData>>(_objIHttpWebClients.PostRequest("InspectionReport/GetVehicle", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {     
                throw ex;
            }
        }

        public SelectQueryMultiple GetAllRecord(GeologyMainData objLabReportmaster)
        {
            try
            {
                SelectQueryMultiple objlistFPOtype = new SelectQueryMultiple();
                objlistFPOtype = JsonConvert.DeserializeObject<SelectQueryMultiple>(_objIHttpWebClients.PostRequest("InspectionReport/GetAllRecord", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteInspection(GeologyMainData objGeologyMainData)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("InspectionReport/DeleteInspection", JsonConvert.SerializeObject(objGeologyMainData))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public SelectQueryMultiple SelectDataForUpdate(GeologyMainData objLabReportmaster)
        {
            try
            {
                SelectQueryMultiple objlistFPOtype = new SelectQueryMultiple();
                objlistFPOtype = JsonConvert.DeserializeObject<SelectQueryMultiple>(_objIHttpWebClients.PostRequest("InspectionReport/SelectDataForUpdate", JsonConvert.SerializeObject(objLabReportmaster)));
                return objlistFPOtype;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF UpdateGeologyNew(GeologyMainData objGeologyMainData)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>((_objIHttpWebClients.PostRequest("InspectionReport/UpdateGeologyNew", JsonConvert.SerializeObject(objGeologyMainData))));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
