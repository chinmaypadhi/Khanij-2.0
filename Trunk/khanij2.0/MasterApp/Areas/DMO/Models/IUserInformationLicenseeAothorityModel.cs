using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.DMO.Models
{
    public interface IUserInformationLicenseeAothorityModel
    {
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewIBMDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// View Profile Requests of Grant Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewGrantDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// View Profile Requests of EC Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewECDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// View Profile Requests of CTE Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewCTEDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// View Profile Requests of CTO Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewCTODetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        List<ViewLicenseeDetailsAuthority> ViewAreaDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        List<ViewLicenseeDetailsAuthority> ViewOfficeDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        List<ViewLicenseeDetailsAuthority> ViewApplicationDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);
        List<ViewLicenseeDetailsAuthority> ViewMineralDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee);

        #region Individual Profile Count For DD
        DDProfileCount GetDDProfileCount(DDProfileCount dDProfileCount);
        Task<List<DDProfileCount>> GetLisenseeUserList(DDProfileCount dDProfileCount);
        #endregion
    }
}
