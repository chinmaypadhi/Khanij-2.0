// ***********************************************************************
//  Interface Name           : ILeaseTypeProvider
//  Description              : Add,View,Edit,Update,Delete LeaseType details
//  Created By               : Lingaraj Dalai
//  Created On               : 08 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.LeaseType
{
    public interface ILeaseTypeProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Add LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        MessageEF AddLeaseType(LeaseTypeMaster objLeaseType);
        /// <summary>
        /// View LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        List<LeaseTypeMaster> ViewLeaseType(LeaseTypeMaster objLeaseType);
        /// <summary>
        /// Edit LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        LeaseTypeMaster EditLeaseType(LeaseTypeMaster objLeaseType);
        /// <summary>
        /// Delete LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        MessageEF DeleteLeaseType(LeaseTypeMaster objLeaseType);
        /// <summary>
        /// Update LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        MessageEF UpdateLeaseType(LeaseTypeMaster objLeaseType);
    }
}
