// ***********************************************************************
//  Interface Name           : IDivisionProvider
//  Description              : Add,View,Edit,Update,Delete Division details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Division
{
    public interface IDivisionProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        MessageEF AddDivision(RegionalModel regionalModel);
        /// <summary>
        /// View Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        List<RegionalModel> ViewDivision(RegionalModel regionalModel);
        /// <summary>
        /// edit Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        RegionalModel EditDivision(RegionalModel regionalModel);
        /// <summary>
        /// Delete Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        MessageEF DeleteDivision(RegionalModel regionalModel);
        /// <summary>
        /// Update Division details in view
        /// </summary>
        /// <param name="regionalModel"></param>
        /// <returns></returns>
        MessageEF UpdateDivision(RegionalModel regionalModel);
    }
}
