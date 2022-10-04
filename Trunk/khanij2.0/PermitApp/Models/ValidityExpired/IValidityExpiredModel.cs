using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PermitEF;

namespace PermitApp.Models.ValidityExpired
{
  public  interface IValidityExpiredModel
    {
        List<ValidityExpiredEF> GetValidityExpiredDetails(ValidityExpiredEF objUser);
    }
}
