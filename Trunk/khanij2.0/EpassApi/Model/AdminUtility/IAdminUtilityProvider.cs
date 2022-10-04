using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.AdminUtility
{
    public interface IAdminUtilityProvider : IDisposable, IRepository
    {
        /// <summary>
        /// Added By Dinesh 29-Apr-2022
        /// </summary>
        /// <param name="objOpenModel"></param>
        /// <returns></returns>
        Task<MessageEF> CancleTPApproval(TPCancelModelEF objOpenModel);
    }
}
