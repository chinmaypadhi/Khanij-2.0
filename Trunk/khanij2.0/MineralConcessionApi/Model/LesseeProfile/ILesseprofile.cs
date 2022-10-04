// ***********************************************************************
//  Model Name               : LesseProfile
//  Desciption               : Used to manage lessee profile
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 11-apr-2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MineralConcessionApi.Repository;
using MineralConcessionEF;

namespace MineralConcessionApi.Model.LesseeProfile
{
    public interface ILesseprofile : IDisposable, IRepository
    {
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get company master detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<LeaseApplicationModel> GetCompMasterData(LeaseApplicationModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 19-apr-2021 to add profile creation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        MessageEF Add(LeaseApplicationModel model);
        /// <summary>
        /// Added by suroj on 25-sep-2021 to edit lesse data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        LeaseApplicationModel GetlesseEditdata(LeaseApplicationModel model);
    }
}
