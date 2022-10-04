
using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Master.Models.LicenseeType
{
    public interface ILicenseeTypeModel
    {
        MessageEF Add(LicenseeTypeMaster objLicenseeType);
        MessageEF Update(LicenseeTypeMaster objLicenseeType);
        List<LicenseeTypeMaster> View(LicenseeTypeMaster objLicenseeType);
        MessageEF Delete(LicenseeTypeMaster objLicenseeType);
        LicenseeTypeMaster Edit(LicenseeTypeMaster objLicenseeType);
    }
}
