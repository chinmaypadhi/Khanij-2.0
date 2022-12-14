using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;
using PermitApi.Repository;

namespace PermitApi.Model.ValidityExpired
{
   public interface IValidityExpiredProvider : IDisposable, IRepository
    {
        Task<List<ValidityExpiredEF>> GetValidityExpiredDetails(ValidityExpiredEF objUser);
    }
}
