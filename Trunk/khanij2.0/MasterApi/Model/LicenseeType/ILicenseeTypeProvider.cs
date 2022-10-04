// ***********************************************************************
//  Controller Name          : LicenseeTypeController
//  Description              : Add,View,Edit,Update,Delete Licensee Type details
//  Created By               : Sanjay Kumar
//  Created On               : 08 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LicenseeType
{
    public interface ILicenseeTypeProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        MessageEF AddLicenseeType(LicenseeTypeMaster objLicenseeType);
        /// <summary>
        /// View Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        List<LicenseeTypeMaster> ViewLicenseeType(LicenseeTypeMaster objLicenseeType);
        /// <summary>
        /// Edit Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        LicenseeTypeMaster EditLicenseeType(LicenseeTypeMaster objLicenseeType);
        /// <summary>
        /// Delete Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        MessageEF DeleteLicenseeType(LicenseeTypeMaster objLicenseeType);
        /// <summary>
        /// Update Licensee Type details in view
        /// </summary>
        /// <param name="objLicenseeType"></param>
        /// <returns></returns>
        MessageEF UpdateLicenseeType(LicenseeTypeMaster objLicenseeType);
    }
}
