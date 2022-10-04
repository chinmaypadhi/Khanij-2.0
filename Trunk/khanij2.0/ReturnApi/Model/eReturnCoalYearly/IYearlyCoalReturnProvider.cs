

using ReturnApi.Repository;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Model.eReturnCoalYearly
{
    public interface IYearlyCoalReturnProvider : IDisposable, IRepository
    {
        #region Coal Yearly Return Details 
        Task<List<YearlyReturnModel>> GetYearlyReturnDetails(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Mine Details
        Task<CoalYearlyMineDetailsModel> GetLesseMineDeatils(YearlyReturnModel yearlyReturnModel);
        Task<CoalYearlyMineDetailsModel> Get_CoalYearlyMineDetails(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_MineDetails(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_MineDetails(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table A
        Task<EMPLOYMENT> Get_EMPLOYMENT(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_EMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table B 
        Task<ELECTRICAL_APPARTATUS> Get_ELECTRICAL_APPARTATUS(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_ELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table C 
        Task<MACHINERY_EQUIPMENT> Get_MACHINERY_EQUIPMENT(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_MACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table D 
        Task<MECHANICAL_VENTILATORS> Get_MECHANICAL_VENTILATORS(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_MECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Table E(a) for coal 
        Task<List<E_EXPLOSIVES>> GetE_EXPLOSIVES(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> AddE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES);
        Task<MessageEF> UpdateE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES);
        Task<MessageEF> DeleteE_EXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES);
        Task<List<E_EXPLOSIVES>> GetMineralGarde(YearlyReturnModel yearlyReturnModel);
        Task<E_EXPLOSIVES> Change_MineralGrade(YearlyReturnModel yearlyReturnModel);
        #endregion

        #region Table E(b) for coke 
        Task<E_EXPLOSIVES_b> Get_E_EXPLOSIVES_b(YearlyReturnModel yearlyReturnModel);
        Task<MessageEF> ADD_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel);
        Task<MessageEF> Update_E_EXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel);
        #endregion

        #region Final Submit 
        Task<MessageEF> Update_FinalSubmit(E_EXPLOSIVES_b e_EXPLOSIVES_B);
        #endregion
    }
}
