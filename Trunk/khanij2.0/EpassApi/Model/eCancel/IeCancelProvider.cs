using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.eCancel
{
    public interface IeCancelProvider : IDisposable, IRepository
    {
        //Task<List<eCancelModel>> eCancel(eCancelModel objtran);
       
        //Task<List<DD>> ddmodule(DD objOpenPermit);
        Task<List<TPCancelModelEF>> GetTP_Cancel(TPCancelModelEF objOpenPermit);
    }
}
