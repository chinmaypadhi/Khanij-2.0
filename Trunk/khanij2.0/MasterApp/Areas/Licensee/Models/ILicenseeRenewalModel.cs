using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Models
{
    public interface ILicenseeRenewalModel
    {
        List<LicenseApplication> GetDistrictListForm4(LicenseApplication licenseApplication);
        List<LicenseApplication> GetLicenseeType(LicenseApplication licenseApplication);
        List<LicenseApplication> GetMineralTypeList(LicenseApplication licenseApplication);
        List<LicenseApplication> GetDistrictList(LicenseApplication licenseApplication);
        List<LicenseApplication> GetApplicantTypeForForm4(LicenseApplication licenseApplication);
        List<LicenseApplication> GetCompanyList(LicenseApplication licenseApplication);
        List<LicenseApplication> GetMineralNameFromMineralType(LicenseApplication licenseApplication);
        List<LicenseApplication> GetMineralNatureListFromMineralIdList(LicenseApplication licenseApplication);
        List<LicenseApplication> GetMineralGradeListFromMineralIdList(LicenseApplication licenseApplication);
        List<LicenseApplication> GetTehsilListByDistrictID(LicenseApplication licenseApplication);
        List<LicenseApplication> GetvillageFromTehsilID(LicenseApplication licenseApplication);
    }
}
