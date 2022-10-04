// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 25-May-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Model.eReturnCoalMonthly;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class eReturnMonthlyCoalController : ControllerBase
    {
        private readonly IMonthlyCoalReturnProvider monthlyCoalReturnProvider;

        public eReturnMonthlyCoalController(IMonthlyCoalReturnProvider monthlyCoalReturnProvider)
        {
            this.monthlyCoalReturnProvider = monthlyCoalReturnProvider;
        }

        #region Monthly Coal Return
        /// <summary>
        /// To Bind Monthly Return Coal Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MonthlyReturnModel>> MonthlyReturnDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.eReturnMonthlyDetails(monthlyReturnModel);
        }

        #region Mine Details
        /// <summary>
        /// To Bind Mine Details Lessee
        /// </summary>
        /// <param name="coalMonthlyMineDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CoalMonthlyMineDetailsModel> LesseMonthlyCoalMineDeatils(CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel)
        {
            return await monthlyCoalReturnProvider.LesseMineDeatils(coalMonthlyMineDetailsModel);
        }

        /// <summary>
        /// To Bind Mine Details 
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CoalMonthlyMineDetailsModel> CoalMonthlyMineDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.Get_CoalMonthlyMineDetails(monthlyReturnModel);
        }

        /// <summary>
        ///Update Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.Update_MineDetails(coalMonthlyViewModel);
        }

        /// <summary>
        /// Add Mine Details
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADD_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.ADD_MineDetails(coalMonthlyViewModel);
        }
        #endregion

        #region Table A
        /// <summary>
        /// Table A Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TABLE_A_Model>> GetCoal_TableAMonthlyDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.Coal_TableAMonthlyDetails(monthlyReturnModel);
        }

        /// <summary>
        /// Despatch Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TABLE_A_Model>> GetCoal_TableADispatchDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.GetCoal_TableADispatchDetails(monthlyReturnModel);
        }

        /// <summary>
        /// Opening Stock
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<TABLE_A_Model> GetCoal_OpeningStock(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.Coal_TableAOpeningStock(monthlyReturnModel);
        }

        /// <summary>
        /// Delete Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model)
        {
            return await monthlyCoalReturnProvider.DeleteCoal_TableAMonthly(tABLE_A_Model);
        }

        /// <summary>
        /// Update Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateCoalMonthly_eReturn(TABLE_A_Model tABLE_A_Model)
        {
            return await monthlyCoalReturnProvider.UpdateCoal_TableAMonthly(tABLE_A_Model);
        }

        /// <summary>
        /// Add Table A
        /// </summary>
        /// <param name="tABLE_A_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDCoalMonthly_eReturn(TABLE_A_Model tABLE_A_Model)
        {
            return await monthlyCoalReturnProvider.AddCoal_TableAMonthly(tABLE_A_Model);
        }
        #endregion

        #region Table B
        /// <summary>
        /// Add Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDMACHINERYMonthly_eReturn(TABLE_B_Model tABLE_B_Model)
        {
            return await monthlyCoalReturnProvider.AddMACHINERY_TableBMonthly(tABLE_B_Model);
        }

        /// <summary>
        /// Update Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMACHINERYMonthly_eReturn(TABLE_B_Model tABLE_B_Model)
        {
            return await monthlyCoalReturnProvider.UpdateMACHINERY_TableBMonthly(tABLE_B_Model);
        }

        /// <summary>
        /// Delete Table B
        /// </summary>
        /// <param name="tABLE_B_Model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteMACHINERYMonthly_eReturn(TABLE_B_Model tABLE_B_Model)
        {
            return await monthlyCoalReturnProvider.DeleteMACHINERY_TableBMonthly(tABLE_B_Model);
        }

        /// <summary>
        /// Table B Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>

        [HttpPost]
        public async Task<List<TABLE_B_Model>> GetMACHINERYMonthly_eReturn(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.GetMACHINERY_TableBMonthly(monthlyReturnModel);
        }

        /// <summary>
        /// Table B Working Background Type
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<TABLE_B_Model>> WorkingBackgroundType(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.GetWorkingBackGroungType(monthlyReturnModel);
        }
        #endregion

        #region Table C Men & Work
        /// <summary>
        /// Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CoalMonthlyModel> GetTableCDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.Get_NumberOF_Work_TableCMonthly(monthlyReturnModel);
        }

        /// <summary>
        /// Update Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.Update_NumberOF_Work_TableCMonthly(coalMonthlyViewModel);
        }

        /// <summary>
        /// Add Table C
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADD_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.ADD_NumberOF_Work_TableCMonthly(coalMonthlyViewModel);
        }
        #endregion

        #region Table D
        /// <summary>
        /// Table D Details
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Table_D_Model> GetEarnDetailsTableDMonthly(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.Get_EarnDetails_TableDMonthly(monthlyReturnModel);
        }

        /// <summary>
        /// Update Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.Update_Table_D(coalMonthlyViewModel);
        }

        /// <summary>
        /// Add Table D
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADD_Table_D(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.ADD_Table_D(coalMonthlyViewModel);
        }
        #endregion

        #region Final Submit
        /// <summary>
        /// Monthly Coal Final Submission
        /// </summary>
        /// <param name="coalMonthlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> Update_FinalSubmit(CoalMonthlyViewModel coalMonthlyViewModel)
        {
            return await monthlyCoalReturnProvider.Update_FinalSubmit(coalMonthlyViewModel);
        }
        #endregion

        #region Previous Month Closing Stock
        /// <summary>
        /// Previous Month Closing Stock
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<string> PreviousMonthClosingStock(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.PreviousMonthClosingStock(monthlyReturnModel);
        }
        #endregion

        #region Get Mineral Form & Grade
        /// <summary>
        /// Get Mineral Form
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MonthlyReturnModel>> MineralNatureDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.GetMineralNature(monthlyReturnModel);
        }

        /// <summary>
        /// Get Mineral Grade
        /// </summary>
        /// <param name="monthlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<MonthlyReturnModel>> MineralGradeDetails(MonthlyReturnModel monthlyReturnModel)
        {
            return await monthlyCoalReturnProvider.GetMineralGrade(monthlyReturnModel);
        }
        #endregion

        #endregion
    }
}
