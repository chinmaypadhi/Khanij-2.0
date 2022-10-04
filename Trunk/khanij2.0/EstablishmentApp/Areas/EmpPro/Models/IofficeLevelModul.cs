using EstablishmentEf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Areas.EmpPro.Models
{
   public interface IofficeLevelModul
    {
        MessageEF AddUpdateDelete(officeLevelEF officeLevel);
        List<officeLevelEF> GetOfficeLevel(officeLevelEF officeLevel);
        officeLevelEF EditOfficeLevel(officeLevelEF officeLevel);
    }
}
