using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using ReturnEF;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using ReturnApp.Models.Utility;

namespace ReturnApp.Areas.Dailyproduction.Models
{
    public class DailyProductionmodel: IDailyProductionModel
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public DailyProductionmodel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }

        /// <summary>
        /// Add Daily Production Details
        /// </summary>
        /// <param name="objDailyProductionmodel"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF Add(DailyProductionModel objDailyProductionmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DailyProduction/Add", JsonConvert.SerializeObject(objDailyProductionmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bet Mineral DropDown
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public GetMineralResult GetMineralDDL(DailyProductionModel objDD)
        {
            try
            {
                List<DailyProductionModel> objlistDD= new List<DailyProductionModel>();
                return JsonConvert.DeserializeObject<GetMineralResult>(_objIHttpWebClients.PostRequest("DailyProduction/ViewMineralDDL", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Grade DropDown
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMineralResult class</returns>
        public GetMineralResult GetGradeDDL(DailyProductionModel objDD)
        {
            try
            {
                List<DailyProductionModel> objlistDD = new List<DailyProductionModel>();
                return JsonConvert.DeserializeObject<GetMineralResult>(_objIHttpWebClients.PostRequest("DailyProduction/ViewMineralWiseGrade", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Mineral Name Datails
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetMineralName(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetMineral", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Insert Daily Production Details
        /// </summary>
        /// <param name="objDailyProductionmodel"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF InsertDailyProd(DailyProductionModel objDailyProductionmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DailyProduction/InsertDP", JsonConvert.SerializeObject(objDailyProductionmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get Total Capacity
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetTotalCap(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetTotalProd", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Summary Report
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>List of DailyProductionModel class</returns>
        public List<DailyProductionModel> ViewSReport(DailyProductionModel objDP)
        {
            try
            {
                List<DailyProductionModel> objlistDP = new List<DailyProductionModel>();
                objlistDP = JsonConvert.DeserializeObject<List<DailyProductionModel>>(_objIHttpWebClients.PostRequest("DailyProduction/ViewSReport", JsonConvert.SerializeObject(objDP)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Year Details
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetYear(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetYear", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get month Details
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetMonth(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetMonth", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// View Details Report
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>List DailyProductionModel class</returns>
        public List<DailyProductionModel> ViewDetailsReport(DailyProductionModel objDP)
        {
            try
            {
                List<DailyProductionModel> objlistDP = new List<DailyProductionModel>();
                objlistDP = JsonConvert.DeserializeObject<List<DailyProductionModel>>(_objIHttpWebClients.PostRequest("DailyProduction/ViewDetailsReport", JsonConvert.SerializeObject(objDP)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Delete Daily Production
        /// </summary>
        /// <param name="objDailyProductionmodel"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF Delete(DailyProductionModel objDailyProductionmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DailyProduction/DeleteDP", JsonConvert.SerializeObject(objDailyProductionmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Submit Daily Production
        /// </summary>
        /// <param name="objDailyProductionmodel"></param>
        /// <returns>MessageEF Class</returns>
        public MessageEF SubmitDp(DailyProductionModel objDailyProductionmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DailyProduction/SubmitDaillyProduction", JsonConvert.SerializeObject(objDailyProductionmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Get Month DropdownList
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetMonthResult class</returns>
        public GetMonthResult GetMonthDDL(DailyProductionModel objDD)
        {
            try
            {
                List<DailyProductionModel> objlistDD = new List<DailyProductionModel>();
                return JsonConvert.DeserializeObject<GetMonthResult>(_objIHttpWebClients.PostRequest("DailyProduction/ViewMonthDDL", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get DropdownList
        /// </summary>
        /// <param name="objDD"></param>
        /// <returns>GetYearResult class</returns>
        public GetYearResult GetYearDDL(DailyProductionModel objDD)
        {
            try
            {
                List<DailyProductionModel> objlistDD = new List<DailyProductionModel>();
                return JsonConvert.DeserializeObject<GetYearResult>(_objIHttpWebClients.PostRequest("DailyProduction/ViewYearDDL", JsonConvert.SerializeObject(objDD)));

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Payment Details
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetPaymentDetails(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetPayment", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Payment Details Month and Year
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetPaymentDetailsMonthYear(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetPaymentMonthYear", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get unique ID
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>DailyProductionModel class</returns>
        public DailyProductionModel GetUniqueID(DailyProductionModel ObjDP)
        {
            try
            {
                ObjDP = JsonConvert.DeserializeObject<DailyProductionModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetUniqueID", JsonConvert.SerializeObject(ObjDP)));
                return ObjDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Get Payment Gateway Details
        /// </summary>
        /// <param name="ObjDP"></param>
        /// <returns>PaymentModel class</returns>
        public PaymentModel GetPaymentGateWay(DailyProductionModel ObjDP)
        {
            try
            {
                PaymentModel objpm = new PaymentModel();
                objpm = JsonConvert.DeserializeObject<PaymentModel>(_objIHttpWebClients.PostRequest("DailyProduction/GetPaymentGetWay", JsonConvert.SerializeObject(ObjDP)));
                return objpm;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Insert Payment Status Details
        /// </summary>
        /// <param name="objPaymentProductionmodel"></param>
        /// <returns>MessageEF class</returns>
        public MessageEF InsertPaymentStatus(PaymentModel objPaymentProductionmodel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("DailyProduction/InsertPR", JsonConvert.SerializeObject(objPaymentProductionmodel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Summery Details Report
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>List of DailyProductionModel class</returns>
        public List<DailyProductionModel> SummeryDetails(DailyProductionModel objDP)
        {
            try
            {
                List<DailyProductionModel> objlistDP = new List<DailyProductionModel>();
                objlistDP = JsonConvert.DeserializeObject<List<DailyProductionModel>>(_objIHttpWebClients.PostRequest("DailyProduction/DPDEtailsMonthYear", JsonConvert.SerializeObject(objDP)));
                return objlistDP;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
