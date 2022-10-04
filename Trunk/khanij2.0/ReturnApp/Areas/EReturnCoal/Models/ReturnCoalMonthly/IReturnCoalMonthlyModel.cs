// ***********************************************************************
// Assembly         : Khanij
// Author           : Akshaya Dalei
// Created          : 22-June-2021
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.EReturnCoal.Models.ReturnCoalMonthly
{
    public interface IReturnCoalMonthlyModel
    {
        #region Mine Details
        List<MonthlyReturnModel> eReturnMonthlyDetails(MonthlyReturnModel monthlyReturnModel);
        CoalMonthlyMineDetailsModel GetLesseMineDeatils(CoalMonthlyMineDetailsModel coalMonthlyMineDetailsModel);

        CoalMonthlyMineDetailsModel Get_CoalMonthlyMineDetails(MonthlyReturnModel monthlyReturnModel);
        MessageEF Update_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel);
        MessageEF ADD_MineDetails(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Table A
        MessageEF AddCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model);
        MessageEF UpdateCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model);
        MessageEF DeleteCoal_TableAMonthly(TABLE_A_Model tABLE_A_Model); 
        List<TABLE_A_Model> Coal_TableAMonthlyDetails(MonthlyReturnModel monthlyReturnModel);
        List<TABLE_A_Model> GetCoal_TableADispatchDetails(MonthlyReturnModel monthlyReturnModel);
        TABLE_A_Model Coal_TableAOpeningStock(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Table B
        MessageEF AddMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        MessageEF UpdateMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        MessageEF DeleteMACHINERY_TableBMonthly(TABLE_B_Model tABLE_B_Model);
        List<TABLE_B_Model> GetMACHINERY_TableBMonthly(MonthlyReturnModel monthlyReturnModel);
        List<TABLE_B_Model> GetWorkingBackGroungType(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Table C Men & Work
        CoalMonthlyModel Get_NumberOF_Work_TableCMonthly(MonthlyReturnModel monthlyReturnModel);
        MessageEF Update_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel);
        MessageEF ADD_NumberOF_Work_TableCMonthly(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Table D
        Table_D_Model Get_EarnDetails_TableDMonthly(MonthlyReturnModel monthlyReturnModel);
        MessageEF Update_Table_D(CoalMonthlyViewModel coalMonthlyViewModel);
        MessageEF ADD_Table_D(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Final Submit
        MessageEF Update_FinalSubmit(CoalMonthlyViewModel coalMonthlyViewModel);
        #endregion

        #region Previous Month Closing Stock
        string PreviousMonthClosingStock(MonthlyReturnModel monthlyReturnModel);
        #endregion

        #region Mineral Form & Grade Details
        List<MonthlyReturnModel> GetMineralNature(MonthlyReturnModel monthlyReturnModel);

        List<MonthlyReturnModel> GetMineralGrade(MonthlyReturnModel monthlyReturnModel);
        #endregion

    }
}
