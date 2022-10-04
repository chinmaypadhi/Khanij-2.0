// ***********************************************************************
//  Controller Name          : DailyProduction
//  Desciption               : Add/View/Delete of Dailly Production Details 
//  Created By               : Debaraj Swain
//  Created On               : 29 May 2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnApi.Model.DailyProduction;
using ReturnEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class DailyProductionController : ControllerBase
    {
        public IDailyProductionProvider _objIDailyProductionProvider;
        public DailyProductionController(IDailyProductionProvider objDailyProductionProvider)
        {
            _objIDailyProductionProvider = objDailyProductionProvider;
        }

        /// <summary>
        /// Add Dailly Production
        /// </summary>
        /// <param name="objDailyProduction"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> Add(DailyProductionModel objDailyProduction)
        {
            return await _objIDailyProductionProvider.AddDailyProduction(objDailyProduction);
        }

        /// <summary>
        /// View Mineral Dropdownlist
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>GetMineralResult class</returns>
        [HttpPost]
        public async Task<GetMineralResult> ViewMineralDDL(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.ListOfMineralForm(objDP);
        }

        /// <summary>
        /// View Mineral wise Grade
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>GetMineralResult class</returns>
        [HttpPost]
        public async Task<GetMineralResult> ViewMineralWiseGrade(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.ListOfGradeByMineralForm(objDP);
        }

        /// <summary>
        /// Get all mineral
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetMineral(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetMineralByUserId(objDP);
        }

        /// <summary>
        /// Insert Dailly Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> InsertDP(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.InsertDPData(objDP);
        }

        /// <summary>
        /// Get Total Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetTotalProd(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetProdCaacity(objDP);
        }

        /// <summary>
        /// VIew Summary Report
        /// </summary>
        /// <param name="ObjDp"></param>
        /// <returns>List of DailyProductionModel class</returns>
        [HttpPost]
        public async Task<List<DailyProductionModel>> ViewSReport(DailyProductionModel ObjDp)
        {
            return await _objIDailyProductionProvider.ViewDPSummary(ObjDp);
        }

        /// <summary>
        /// Get Year Details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel classs</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetYear(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetProdYear(objDP);
        }

        /// <summary>
        /// Get Month Details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetMonth(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetProdMonth(objDP);
        }

        /// <summary>
        /// View Details Report
        /// </summary>
        /// <param name="ObjDp"></param>
        /// <returns>List of DailyProductionModel class</returns>
        [HttpPost]
        public async Task<List<DailyProductionModel>> ViewDetailsReport(DailyProductionModel ObjDp)
        {
            return await _objIDailyProductionProvider.ViewDPDetails(ObjDp);
        }

        /// <summary>
        /// Delete Dailly Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> DeleteDP(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.DeleteDP(objDP);
        }

        /// <summary>
        /// Submit Dailly Production
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> SubmitDaillyProduction(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.SubmitDP(objDP);
        }

        /// <summary>
        /// View Month DropdownList
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>GetMonthResult class</returns>
        [HttpPost]
        public async Task<GetMonthResult> ViewMonthDDL(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.ListOfMonth(objDP);
        }

        /// <summary>
        /// View Year DropdownList
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>GetYearResult class</returns>
        [HttpPost]
        public async Task<GetYearResult> ViewYearDDL(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.ListOfYear(objDP);
        }

        /// <summary>
        /// Get Payment Details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetPayment(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetPaymentDetailsByUserId(objDP);
        }

        /// <summary>
        /// Get Payment Month Year
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetPaymentMonthYear(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetPaymentDetailsByUserIdMOnthYear(objDP);
        }

        /// <summary>
        /// Get Unique Id for payment
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>DailyProductionModel class</returns>
        [HttpPost]
        public async Task<DailyProductionModel> GetUniqueID(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetUId(objDP);
        }

        /// <summary>
        /// Get Payment Gateway Details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>PaymentMode class</returns>
        [HttpPost]
        public async Task<PaymentModel> GetPaymentGetWay(DailyProductionModel objDP)
        {
            return await _objIDailyProductionProvider.GetPGateWay(objDP);
        }

        /// <summary>
        /// Insert Production details
        /// </summary>
        /// <param name="objDP"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> InsertPR(PaymentModel objDP)
        {
            return await _objIDailyProductionProvider.InsertPaymentRequest(objDP);
        }

        /// <summary>
        /// Dailly production details month Year
        /// </summary>
        /// <param name="ObjDp"></param>
        /// <returns>List of DailyProductionModel class</returns>
        [HttpPost]
        public async Task<List<DailyProductionModel>> DPDEtailsMonthYear(DailyProductionModel ObjDp)
        {
            return await _objIDailyProductionProvider.ViewDPDetailsMonthYearWise(ObjDp);
        }
    }
}
