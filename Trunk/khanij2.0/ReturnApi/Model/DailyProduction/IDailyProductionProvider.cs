// ***********************************************************************
// Assembly         : Khanij
// Author           : Debaraj Swain
// Created          : 11-Jan-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.DailyProduction
{
   public interface IDailyProductionProvider: IDisposable, IRepository
    {
        Task<MessageEF> AddDailyProduction(DailyProductionModel objDailyProduction);
        Task<GetMineralResult> ListOfMineralForm(DailyProductionModel objDailyProduction);
        Task<GetMineralResult> ListOfGradeByMineralForm(DailyProductionModel objDailyProduction);
        Task<DailyProductionModel> GetMineralByUserId(DailyProductionModel objDP);
        Task<MessageEF> InsertDPData(DailyProductionModel objDailyProduction);
        Task<DailyProductionModel> GetProdCaacity(DailyProductionModel objDP);
        
        Task<List<DailyProductionModel>> ViewDPSummary(DailyProductionModel objDP);
        Task<DailyProductionModel> GetProdYear(DailyProductionModel objDP);
        Task<DailyProductionModel> GetProdMonth(DailyProductionModel objDP);
        Task<List<DailyProductionModel>> ViewDPDetails(DailyProductionModel objDP);
        Task<MessageEF> DeleteDP(DailyProductionModel objDP);
        Task<MessageEF> SubmitDP(DailyProductionModel objDP);
        Task<GetMonthResult> ListOfMonth(DailyProductionModel objDailyProduction);
        Task<GetYearResult> ListOfYear(DailyProductionModel objDailyProduction);
        Task<DailyProductionModel> GetPaymentDetailsByUserId(DailyProductionModel objDP);
        Task<DailyProductionModel> GetPaymentDetailsByUserIdMOnthYear(DailyProductionModel objDP);
        Task<DailyProductionModel> GetUId(DailyProductionModel objDP);
        Task<PaymentModel> GetPGateWay(DailyProductionModel objDP);
        Task<MessageEF> InsertPaymentRequest(PaymentModel ObjPM);
        Task<List<DailyProductionModel>> ViewDPDetailsMonthYearWise(DailyProductionModel model);


    }
}
