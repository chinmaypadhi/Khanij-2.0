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
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApp.Areas.EReturnCoal.Models.ReturnCoalYearly
{
    public interface IReturnCoalYearlyModel
    {
        #region Coal Return Details
        List<YearlyReturnModel> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Mine Details
        CoalYearlyMineDetailsModel GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel);
        CoalYearlyMineDetailsModel Get_CoalYearlyMineDetails(YearlyReturnModel yearlyReturnModel);
        MessageEF ADD_MineDetails(CoalYearlyViewModel coalYearlyViewModel);
        MessageEF Update_MineDetails(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table A
        EMPLOYMENT Get_EMPLOYMENT(YearlyReturnModel yearlyReturnModel);
        MessageEF ADD_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel);
        MessageEF Update_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table B 
        ELECTRICAL_APPARTATUS Get_ELECTRICAL_APPARTATUS(YearlyReturnModel yearlyReturnModel); 
        MessageEF ADD_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel); 
        MessageEF Update_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table C 
        MACHINERY_EQUIPMENT Get_MACHINERY_EQUIPMENT(YearlyReturnModel yearlyReturnModel); 
        MessageEF ADD_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel); 
        MessageEF Update_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table D 
        MECHANICAL_VENTILATORS Get_MECHANICAL_VENTILATORS(YearlyReturnModel yearlyReturnModel); 
        MessageEF ADD_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel); 
        MessageEF Update_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table E(a) 
        List<E_EXPLOSIVES> GetE_EXPLOSIVES(YearlyReturnModel yearlyReturnModel); 
        MessageEF AddE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES); 
        MessageEF UpdateE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES); 
        MessageEF DeleteE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES); 
        List<E_EXPLOSIVES> GetMineralGarde(YearlyReturnModel yearlyReturnModel); 
        E_EXPLOSIVES Change_MineralGrade(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Table E(b) 
        E_EXPLOSIVES_b Get_E_EXPLOSIVES_b(YearlyReturnModel yearlyReturnModel); 
        MessageEF ADD_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel); 
        MessageEF Update_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Final Submit 
        MessageEF Update_FinalSubmit(E_EXPLOSIVES_b e_EXPLOSIVES_B);
        #endregion
    }
}
