// ***********************************************************************
//  Interface Name           : IDistrictProvider
//  Description              : Add,View,Edit,Update,Delete District details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.District
{
    public interface IDistrictProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        MessageEF AddDistrict(DistrictModel districtModel);
        /// <summary>
        /// View District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        List<DistrictModel> ViewDistrict(DistrictModel districtModel);
        /// <summary>
        /// Edit District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        DistrictModel EditDistrict(DistrictModel districtModel);
        /// <summary>
        /// Delete District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        MessageEF DeleteDistrict(DistrictModel districtModel);
        /// <summary>
        /// Update District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        MessageEF UpdateDistrict(DistrictModel districtModel);
    }
}
