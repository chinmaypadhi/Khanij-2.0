using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SupportEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SupportApp.Models.Utility;

namespace SupportApp.Areas.Inspection.Models
{
    public class inspectionModel : IinspectionModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public inspectionModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// To Get User DEtails
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>InspectionModel Class</returns>
        /// 

        public InspectionModel GetUDetails(InspectionModel ObjEU)
        {
            try
            {
                Result<InspectionModel> r = new Result<InspectionModel>();
                r = JsonConvert.DeserializeObject  < Result<InspectionModel>> (_objIHttpWebClients.PostRequest("InspectionReport/GetUserData", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get User Type
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>FillDDlInspection Class</returns>
        public FillDDlInspection GetUserType(InspectionModel ObjEU)
        {
            try
            {
                Result<FillDDlInspection> r = new Result<FillDDlInspection>();
                // List<InspectionModel> objlistDD = new List<InspectionModel>();

                r= JsonConvert.DeserializeObject<Result<FillDDlInspection>>(_objIHttpWebClients.PostRequest("InspectionReport/fillUtype", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }
        }
        /// <summary>
        /// To Inspection List
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List of NoticeModel Class</returns>
        public List<NoticeModel> GetLst(NoticeModel model)
        {
            try
            {
                Result<List<NoticeModel>> r = new Result<List<NoticeModel>>();
                List<NoticeModel> objlist = new List<NoticeModel>();
                r = JsonConvert.DeserializeObject<Result<List<NoticeModel>>>(_objIHttpWebClients.PostRequest("InspectionReport/GetLst", JsonConvert.SerializeObject(model)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                model = null;
            }

        }
        /// <summary>
        /// To Get User List
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>FillDDlInspection Class</returns>
        public FillDDlInspection GetUserList(InspectionModel ObjEU)
        {
            try
            {
                Result<FillDDlInspection> r = new Result<FillDDlInspection>();
                r= JsonConvert.DeserializeObject<Result<FillDDlInspection>>(_objIHttpWebClients.PostRequest("InspectionReport/fillLuser", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// To Get User Details
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>InspectionModel Class</returns>
        public InspectionModel GetUserDetails(InspectionModel ObjEU)
        {
            try
            {
                Result<InspectionModel> r = new Result<InspectionModel>();
                r = JsonConvert.DeserializeObject<Result<InspectionModel>>(_objIHttpWebClients.PostRequest("InspectionReport/UserData", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }
        }
        /// <summary>
        /// Add inspection Data
        /// </summary>
        /// <param name="ObjEU"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF AddInspectionData(InspectionModel ObjEU)
        {
            try
            {
                return JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("InspectionReport/AddData", JsonConvert.SerializeObject(ObjEU)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
        /// <summary>
        /// View inspection Data
        /// </summary>
        /// <param name="model"></param>
        /// <returns>List InspectionModel Class</returns>
        public List<InspectionModel> ViewLst(InspectionModel model)
        {
            List<InspectionModel> objlist = new List<InspectionModel>();
            try
            {
                Result<List<InspectionModel>> r = new Result<List<InspectionModel>>();
                r = JsonConvert.DeserializeObject <Result<List<InspectionModel>>>(_objIHttpWebClients.PostRequest("InspectionReport/ViewData", JsonConvert.SerializeObject(model)));
                return r.Data;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                model = null;
                objlist = null;
            }

        }
        public List<InspectionModel> GetInspectionDetails(InspectionModel ObjEU)
        {
            try
            {
                Result<List<InspectionModel>> r = new Result<List<InspectionModel>>();

                List<InspectionModel> objlist = new List<InspectionModel>();
                r = JsonConvert.DeserializeObject<Result<List<InspectionModel>>>(_objIHttpWebClients.PostRequest("InspectionReport/ViewInspectionDetails", JsonConvert.SerializeObject(ObjEU)));
                return r.Data;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                ObjEU = null;
            }

        }
    }
}
