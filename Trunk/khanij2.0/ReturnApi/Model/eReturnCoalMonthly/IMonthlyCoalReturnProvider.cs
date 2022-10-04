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

using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.eReturnCoalMonthly
{
    public interface IMonthlyCoalReturnProvider : IDisposable, IRepository
    {
        #region Mine Details
        Task<List<MonthlyReturnModel>> eReturnMonthlyDetails(MonthlyReturnModel monthlyReturnModel);
        Task<CoalMonthlyMineDetailsModel> LesseMineDeatils(CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel);

        Task<CoalMonthlyMineDetailsModel> Get_CoalMonthlyMineDetails(MonthlyReturnModel monthlyReturnModel);
        Task<MessageEF> Update_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel);
        Task<MessageEF> ADD_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Table A
        Task<MessageEF> AddCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model);
        Task<MessageEF> UpdateCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model);
        Task<MessageEF> DeleteCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model);  
        Task<List<TABLE_A_Model>> Coal_TableAMonthlyDetails(MonthlyReturnModel monthlyReturnModel);
        Task<List<TABLE_A_Model>> GetCoal_TableADispatchDetails(MonthlyReturnModel monthlyReturnModel);
        Task<TABLE_A_Model> Coal_TableAOpeningStock(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Table B
        Task<MessageEF> AddMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        Task<MessageEF> UpdateMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        Task<MessageEF> DeleteMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        Task<List<TABLE_B_Model>> GetMACHINERY_TableBMonthly(MonthlyReturnModel monthlyReturnModel);
        Task<List<TABLE_B_Model>> GetWorkingBackGroungType(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Table C Men & Work
        Task<CoalMonthlyModel> Get_NumberOF_Work_TableCMonthly(MonthlyReturnModel monthlyReturnModel);
        Task<MessageEF> Update_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel);
        Task<MessageEF> ADD_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Table D
        Task<Table_D_Model> Get_EarnDetails_TableDMonthly(MonthlyReturnModel monthlyReturnModel);
        Task<MessageEF> Update_Table_D(CoalMonthlyViewModel coalMonthlyViewModel);
        Task<MessageEF> ADD_Table_D(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Previous Month Closing Stock
        //Previous Month Closing Stock
        Task<string> PreviousMonthClosingStock(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Final Submit
        //Final Monthly Coal Submission
        Task<MessageEF> Update_FinalSubmit(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Get Mineral Form & Grade
        //Get Mineral Form Details
        Task<List<MonthlyReturnModel>> GetMineralNature(MonthlyReturnModel monthlyReturnModel);

        //Get Mineral Grade Details
        Task<List<MonthlyReturnModel>> GetMineralGrade(MonthlyReturnModel monthlyReturnModel);
        #endregion
    }
}
