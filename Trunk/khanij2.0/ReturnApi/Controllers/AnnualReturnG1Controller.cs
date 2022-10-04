// ***********************************************************************
//  Controller Name          : AnnualReturnG1
//  Desciption               : Add Yearly return of Iron Ore,Lime Stone Etc. API
//  Created By               : Debaraj Swain
//  Created On               : 25 June 2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReturnApi.Model.DailyProduction;
using ReturnEF;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Model.e_Return_NonCoal;
using ReturnApi.Model.e_Return_NonCoal_AnnualG1;
using Microsoft.AspNetCore.Authorization;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class AnnualReturnG1Controller : ControllerBase
    {
        public IeReturnNonCoalYearlyG1Provider _objIeReturnNonCoalYearlyG1Provider;
        public AnnualReturnG1Controller(IeReturnNonCoalYearlyG1Provider objeReturnNonCoalYearlyG1Provider)
        {
            _objIeReturnNonCoalYearlyG1Provider = objeReturnNonCoalYearlyG1Provider;
        }

        /// <summary>
        /// Get Details of Yearly Return
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>List of YearlyReturnModel</returns>
        [HttpPost]
        public async Task<List<YearlyReturnModel>> GetYearlyReturnDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetYearlyReturnDetails(objEU);
        }

        #region Part 1 H1
        /// <summary>
        /// Get all mines other details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>AnnualReturnH1ViewModel lass</returns>
        [HttpPost]
        public async Task<AnnualReturnH1ViewModel> GetMineOtherDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetMineOtherDetails(objEU);
        }

        /// <summary>
        /// Get Perticulars of Area
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>ParticularsofArea Class</returns>
        [HttpPost]
        public async Task<ParticularsofArea> GetParticularsofArea(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetParticularsofArea(objEU);
        }

        /// <summary>
        /// Get Lease Area details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>LeaseArea Class</returns>
        public async Task<LeaseArea> GetLeasearea(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetLeasearea(objEU);
        }

        /// <summary>
        /// Get Lessee details of mines
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MineDetailsModel class</returns>
        [HttpPost]
        public async Task<MineDetailsModel> GetLesseMineDeatils(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetLesseMineDeatils(objEU);
        }

        /// <summary>
        /// Get all Agency of mines
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>list of GetDDL class</returns>
        [HttpPost]
        public async Task<List<GetDDL>> GetAgencyOfMine(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetAgencyOfMine(objEU);
        }

        /// <summary>
        /// Add mining other details (Part 1 of G1)
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddMineOtherDetails(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddMineOtherDetails(objEU);
        }

        /// <summary>
        /// Add particulars of Area
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddParticularsofArea(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddParticularsofArea(objEU);
        }

        /// <summary>
        /// Add lease Area details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddLeasearea(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddLeasearea(objEU);
        }

        /// <summary>
        /// Update mines other details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMineOtherDetails(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateMineOtherDetails(objEU);
        }

        /// <summary>
        /// Update particulars of Area
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateParticularsofArea(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateParticularsofArea(objEU);
        }

        /// <summary>
        /// Update lease Area
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateLeasearea(AnnualReturnH1ViewModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateLeasearea(objEU);
        }
        #endregion

        #region Part 2 H1
        /// <summary>
        /// Get staff and work details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>StaffandWorkModel class</returns>
        [HttpPost]
        public async Task<StaffandWorkModel> GetStaffandWork(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetStaffandWork(objEU);
        }

        /// <summary>
        /// Get salary wages paid details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>SalaryWagesPaidModel class</returns>
        [HttpPost]
        public async Task<SalaryWagesPaidModel> GetSalaryWagesPaid(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetSalaryWagesPaid(objEU);
        }

        /// <summary>
        /// Get Capital Structure Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>CapitalStructure class</returns>
        [HttpPost]
        public async Task<CapitalStructure> GetCapitalStructure(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetCapitalStructure(objEU);
        }

        /// <summary>
        /// Get Source of Finance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>SourceOfFinance class</returns>
        [HttpPost]
        public async Task<SourceOfFinance> GetSourceOfFinance(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetSourceOfFinance(objEU);
        }

        /// <summary>
        /// Get work details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>WorkModel class</returns>
        [HttpPost]
        public async Task<WorkModel> GetWorkDetails(MonthlyReturnModelNonCoal objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.GetWorkDetails(objEU);
        }

        /// <summary>
        /// Add Staff and work
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddStaffandWork(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddStaffandWork(objEU);
        }

        /// <summary>
        /// Add work details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddWorkDetails(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddWorkDetails(objEU);
        }

        /// <summary>
        /// Add salary wages paid
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddSalaryWagesPaid(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddSalaryWagesPaid(objEU);
        }

        /// <summary>
        /// Add capital Structure Details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddCapitalStructure(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddCapitalStructure(objEU);
        }

        /// <summary>
        /// Add source of finance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> AddSourceOfFinance(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.AddSourceOfFinance(objEU);
        }

        /// <summary>
        /// Update staff and work
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateStaffandWork(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateStaffandWork(objEU);
        }

        /// <summary>
        /// Update work details
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateWorkDetails(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateWorkDetails(objEU);
        }

        /// <summary>
        /// Update salary wages paid
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSalaryWagesPaid(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateSalaryWagesPaid(objEU);
        }

        /// <summary>
        /// Update capital structure
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateCapitalStructure(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateCapitalStructure(objEU);
        }

        /// <summary>
        /// Update source of finance
        /// </summary>
        /// <param name="objEU"></param>
        /// <returns>MessageEF class</returns>
        [HttpPost]
        public async Task<MessageEF> UpdateSourceOfFinance(AnnualReturnH1PartTwoModel objEU)
        {
            return await _objIeReturnNonCoalYearlyG1Provider.UpdateSourceOfFinance(objEU);
        }
        #endregion
    }
}

