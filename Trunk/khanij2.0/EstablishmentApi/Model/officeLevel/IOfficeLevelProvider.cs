using EstablishmentApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstablishmentEf;

namespace EstablishmentApi.Model.officeLevel
{
    public interface IOfficeLevelProvider: IDisposable, IRepository
    {
        MessageEF AddUpdateDelete(officeLevelEF officeLevel);
        List<officeLevelEF> GetOfficeLevel(officeLevelEF officeLevel);
        officeLevelEF EditOfficeLevel(officeLevelEF officeLevel);
    }
}
