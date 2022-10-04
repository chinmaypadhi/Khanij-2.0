// ***********************************************************************
//  Controller Name          : eReturnYearly
//  Desciption               : Liecensee Yearly Coal Return
//  Created By               : Akshaya Dalei
//  Created On               : 25 June 2021
// ***********************************************************************
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReturnApi.Model.eReturnCoalYearly;
using ReturnEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReturnApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class eReturnYearlyCoalController : ControllerBase
    {
        private readonly IYearlyCoalReturnProvider yearlyCoalReturnProvider;

        public eReturnYearlyCoalController(IYearlyCoalReturnProvider yearlyCoalReturnProvider)
        {
            this.yearlyCoalReturnProvider = yearlyCoalReturnProvider;
        }

        #region Yearly Return Coal Details
        /// <summary>
        /// Yearly Return Coal Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<YearlyReturnModel>> YearlyReturnCoalDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.GetYearlyReturnDetails(yearlyReturnModel);
        }
        #endregion

        #region Mine Details
        /// <summary>
        /// Lessee Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CoalYearlyMineDetailsModel> LesseMineDeatils(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.GetLesseMineDeatils(yearlyReturnModel);
        }

        /// <summary>
        /// Mine Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<CoalYearlyMineDetailsModel> CoalYearlyMineDetails(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_CoalYearlyMineDetails(yearlyReturnModel);
        }

        /// <summary>
        /// Add Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDMineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_MineDetails(coalYearlyViewModel);
        }

        /// <summary>
        /// Update Mine Details
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMineDetails(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_MineDetails(coalYearlyViewModel);
        }
        #endregion

        #region Table A
        /// <summary>
        /// Get Employment Details
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<EMPLOYMENT> GetEMPLOYMENT(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_EMPLOYMENT(yearlyReturnModel);
        }

        /// <summary>
        /// Add Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDEMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_EMPLOYMENT(coalYearlyViewModel);
        }

        /// <summary>
        /// Update Employment
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateEMPLOYMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_EMPLOYMENT(coalYearlyViewModel);
        }
        #endregion

        #region Table B
        /// <summary>
        /// To Get ELECTRICAL APPARTATUS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ELECTRICAL_APPARTATUS> GetELECTRICAL_APPARTATUS(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_ELECTRICAL_APPARTATUS(yearlyReturnModel);
        }

        /// <summary>
        /// To Add ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_ELECTRICAL_APPARTATUS(coalYearlyViewModel);
        }

        /// <summary>
        /// To Update ELECTRICAL APPARTATUS Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateELECTRICAL_APPARTATUS(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_ELECTRICAL_APPARTATUS(coalYearlyViewModel);
        }
        #endregion

        #region Table C
        /// <summary>
        /// To Get MACHINERY EQUIPMENT Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MACHINERY_EQUIPMENT> GetMACHINERY_EQUIPMENT(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_MACHINERY_EQUIPMENT(yearlyReturnModel);
        }

        /// <summary>
        /// To ADD MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDMACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_MACHINERY_EQUIPMENT(coalYearlyViewModel);
        }

        /// <summary>
        /// To UPDATE MACHINERY EQUIPMENT Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMACHINERY_EQUIPMENT(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_MACHINERY_EQUIPMENT(coalYearlyViewModel);
        }
        #endregion

        #region Table D
        /// <summary>
        /// To Get MECHANICAL VENTILATORS Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MECHANICAL_VENTILATORS> GetMECHANICAL_VENTILATORS(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_MECHANICAL_VENTILATORS(yearlyReturnModel);
        }

        /// <summary>
        /// To Add MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDMECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_MECHANICAL_VENTILATORS(coalYearlyViewModel);
        }

        /// <summary>
        /// To Update MECHANICAL VENTILATORS Details Data 
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateMECHANICAL_VENTILATORS(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_MECHANICAL_VENTILATORS(coalYearlyViewModel);
        }
        #endregion

        #region Table E(a)
        /// <summary>
        /// To Get E EXPLOSIVES Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<E_EXPLOSIVES>> GetEEXPLOSIVES(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.GetE_EXPLOSIVES(yearlyReturnModel);
        }

        /// <summary>
        /// To Add E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> AddEEXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            return await yearlyCoalReturnProvider.AddE_EXPLOSIVES(e_EXPLOSIVES);
        }

        /// <summary>
        /// To Update E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateEEXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            return await yearlyCoalReturnProvider.UpdateE_EXPLOSIVES(e_EXPLOSIVES);
        }

        /// <summary>
        /// To Delete E EXPLOSIVES Details Data 
        /// </summary>
        /// <param name="e_EXPLOSIVES"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> DeleteEEXPLOSIVES(E_EXPLOSIVES e_EXPLOSIVES)
        {
            return await yearlyCoalReturnProvider.DeleteE_EXPLOSIVES(e_EXPLOSIVES);
        }
        /// <summary>
        /// To Get Mineral Grade Details Data 
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<E_EXPLOSIVES>> GetMineralGarde(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.GetMineralGarde(yearlyReturnModel);
        }

        /// <summary>
        /// To Get Details By Mineral Id Data 
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<E_EXPLOSIVES> ChangeMineralGrade(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Change_MineralGrade(yearlyReturnModel);
        }
        #endregion

        #region Table E(b)
        /// <summary>
        /// To Get E EXPLOSIVES b Details Data in View
        /// </summary>
        /// <param name="yearlyReturnModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<E_EXPLOSIVES_b> GetEEXPLOSIVES_b(YearlyReturnModel yearlyReturnModel)
        {
            return await yearlyCoalReturnProvider.Get_E_EXPLOSIVES_b(yearlyReturnModel);
        }

        /// <summary>
        /// To Add E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> ADDEEXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.ADD_E_EXPLOSIVES_b(coalYearlyViewModel);
        }

        /// <summary>
        /// To Update E EXPLOSIVES b Details Data
        /// </summary>
        /// <param name="coalYearlyViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateEEXPLOSIVES_b(CoalYearlyViewModel coalYearlyViewModel)
        {
            return await yearlyCoalReturnProvider.Update_E_EXPLOSIVES_b(coalYearlyViewModel);
        }
        #endregion

        #region Final Submit
        /// <summary>
        /// Final Submit Of EReturn Coal
        /// </summary>
        /// <param name="e_EXPLOSIVES_B"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<MessageEF> UpdateFinalSubmit(E_EXPLOSIVES_b e_EXPLOSIVES_B)
        {
            return await yearlyCoalReturnProvider.Update_FinalSubmit(e_EXPLOSIVES_B);
        }
        #endregion
    }
}
