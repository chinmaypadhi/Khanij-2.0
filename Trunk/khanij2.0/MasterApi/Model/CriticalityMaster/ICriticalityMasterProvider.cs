// ***********************************************************************
//  Interface Name           : ICriticalityMasterProvider
//  Description              : Add,View,Edit,Update,Delete Criticality details
//  Created By               : Akshaya Dalei
//  Created On               : 15 Jan 2021
// ***********************************************************************

using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.CriticalityMasters
{
   public interface ICriticalityMasterProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        MessageEF AddCriticalityMaster(CriticalityMaster objCriticalityMaster);
        /// <summary>
        /// View Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        List<CriticalityMaster> ViewCriticalityMaster(CriticalityMaster criticalityMaster);
        /// <summary>
        /// Edit Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        CriticalityMaster EditCriticalityMaster(CriticalityMaster objCriticalityMaster);
        /// <summary>
        /// Delete Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        MessageEF DeleteCriticalityMaster(CriticalityMaster objCriticalityMaster);
        /// <summary>
        /// Udpate Criticality details in veiw
        /// </summary>
        /// <param name="criticalityMaster"></param>
        /// <returns></returns>
        MessageEF UpdateCriticalityMaster(CriticalityMaster objCriticalityMaster);
    }
}
