// ***********************************************************************
//  Interface Name           : ICompanyProvider
//  Description              : Add,View,Edit,Update,Delete Company details
//  Created By               : Lingaraj Dalai
//  Created On               : 08 Jan 2021
// ***********************************************************************
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Company
{
    public interface ICompanyProvider: IDisposable, IRepository
    {
        /// <summary>
        /// Add Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        MessageEF AddCompany(CompanyMaster objCompanyMaster);
        /// <summary>
        /// View Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        List<CompanyMaster> ViewCompany(CompanyMaster objCompanyMaster);
        /// <summary>
        /// Edit Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        CompanyMaster EditCompany(CompanyMaster objCompanyMaster);
        /// <summary>
        /// Delete Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        MessageEF DeleteCompany(CompanyMaster objCompanyMaster);
        /// <summary>
        /// Update Copmany details in view
        /// </summary>
        /// <param name="objCompanyMaster"></param>
        /// <returns></returns>
        MessageEF UpdateCompnay(CompanyMaster objCompanyMaster);
    }
}
