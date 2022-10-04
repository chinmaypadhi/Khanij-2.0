using MasterEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.Licensee.Models
{
    public interface IUserInformationLicenseeModel
    {
        #region IBM Details
        /// <summary>
        /// TO Get IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetLicenseeIBMDetail(IBMDetails objLicensee);
        /// <summary>
        /// To Add New IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF NewLicenseeIBMDetail(IBMDetails objLicensee);
        /// <summary>
        /// To Update IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF UpdateLicenseeIBMDetail(IBMDetails objLicensee);
        /// <summary>
        /// To Delete IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF DeleteLicenseeIBMDetail(IBMDetails objLicensee);
        /// <summary>
        /// To Approve IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF ApproveLicenseeIBMDetails(IBMDetails objLicensee);
        /// <summary>
        /// To Reject IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF RejectLicenseeIBMDetails(IBMDetails objLicensee);
        /// <summary>
        /// To Comapre IBM Details 
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<IBMDetails> CompareIBMDetails(IBMDetails objLicensee);
        IBMDetails ViewIBMDetails(IBMDetails objLicensee);
        /// <summary>
        /// To bind IBM Log details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        Task<List<IBMDetails>> GetIBMLogDetails(IBMDetails iBMDetails);
        #endregion
        #region CTE Details
        /// <summary>
        /// To Get CTE Details of Licenesee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetLicenseeCTEDetail(CTEDetails objLicensee);
        /// <summary>
        /// To Add New CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF NewLicenseeCTEDetail(CTEDetails objLicensee);
        /// <summary>
        /// To Update CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF UpdateLicenseeCTEDetail(CTEDetails objLicensee);
        /// <summary>
        /// To Approve CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF ApproveLicenseeCTEDetails(CTEDetails objLicensee);
        /// <summary>
        /// To Reject CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF RejectLicenseeCTEDetails(CTEDetails objLicensee);
        /// <summary>
        /// To Compare CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<CTEDetails> CompareCTEDetails(CTEDetails objLicensee);
        /// <summary>
        /// To Bind CTE Log Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<List<CTEDetails>> GetCTELogDetails(CTEDetails objLicensee);
        /// <summary>
        /// To Delete CTE Details
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF DeleteCTEDetail(CTEDetails objLicensee);
        #endregion
        #region CTO Details
        /// <summary>
        /// To Get CTO Details Of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetLicenseeCTODetail(CTODetails cTODetails);
        /// <summary>
        /// To Insert New CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF NewLicenseeCTODetail(CTODetails cTODetails);
        /// <summary>
        /// To Update CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF UpdateLicenseeCTODetail(CTODetails cTODetails);
        /// <summary>
        /// To Approve CTO Details of Licensee 
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF ApproveLicenseeCTODetails(CTODetails cTODetails);
        /// <summary>
        /// To Reject CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF RejectLicenseeCTODetails(CTODetails cTODetails);
        /// <summary>
        /// To Compare CTO Details Old Record With New One
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        List<CTODetails> CompareCTODetails(CTODetails cTODetails);
        /// <summary>
        /// To Bind CTO Log Details in View
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        Task<List<CTODetails>> GetCTOLogDetails(CTODetails cTODetails);
        /// <summary>
        /// To Delete CTO Details
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        MessageEF DeleteCTODetail(CTODetails cTODetails);
        #endregion
        #region Grant Order Details
        /// <summary>
        /// To Bind the Grant Order Details Data in View
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetGrantOrderDetails(GrantDetails grantDetails);
        /// <summary>
        /// To Add New Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        MessageEF NewGrantOrderDetail(GrantDetails grantDetails);
        /// <summary>
        /// To Update Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        MessageEF UpdateGrantOrderDetail(GrantDetails grantDetails);
        /// <summary>
        /// To Approve Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF ApproveGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Reject Grant Order Details of Licenee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF RejectGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Compare Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<GrantDetails> CompareGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Delete Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF DeleteGrantOrderDetail(GrantDetails objLicensee);
        /// <summary>
        /// To Get Log Deatails of Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<List<GrantDetails>> GetGrantLogDetails(GrantDetails objLicensee);
        #endregion
        #region EC Details
        /// <summary>
        /// To Get Mineral Names
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        Task<List<ECDetails>> GetMineralNames(ECDetails eCDetails);
        /// <summary>
        /// To Bind the EC Details Data in View
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetECDetails(ECDetails eCDetails);
        /// <summary>
        /// To Add New EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        MessageEF NewECDetail(ECDetails eCDetails);
        /// <summary>
        /// To Update EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        MessageEF UpdateECDetail(ECDetails eCDetails);
        /// <summary>
        /// To Approve Ec Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        MessageEF ApproveECDetails(ECDetails eCDetails);
        /// <summary>
        /// To Reject EC Details of Licesnee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        MessageEF RejectECDetails(ECDetails eCDetails);
        /// <summary>
        /// To Compare EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        List<ECDetails> CompareECDetails(ECDetails eCDetails);
        /// <summary>
        /// To Bind EC Log History in View 
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        Task<List<ECDetails>> GetECLogDetails(ECDetails eCDetails);
        /// <summary>
        /// To Delete EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF DeleteECDetail(ECDetails objLicensee);
        #endregion
        #region Area Details
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetStateList(AreaDetails viewAreaDetails);
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetDistrictList(AreaDetails viewAreaDetails);
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetTehsilList(AreaDetails objLeaseAreaModel);
        /// <summary>
        ///  Bind Village List details in view 
        /// </summary>
        /// <param name="viewAreaDetails"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetVillageList(AreaDetails viewAreaDetails);
        /// <summary>
        /// To Bind Land Type Details
        /// </summary>
        /// <param name="viewAreaDetails"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetLandTypeList(AreaDetails viewAreaDetails);

        /// To Get Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetAreaDetails(AreaDetails areaDetails);
        /// <summary>
        /// To Add Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        MessageEF NewAreaetail(AreaDetails areaDetails);
        /// <summary>
        /// To Update Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        MessageEF UpdateAreaDetail(AreaDetails areaDetails);
        /// <summary>
        /// To Approve Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        MessageEF ApproveAreaDetails(AreaDetails areaDetails);
        /// <summary>
        /// To Reject Area Deatils of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        MessageEF RejectAreaDetails(AreaDetails areaDetails);
        /// <summary>
        /// To View Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        //List<ViewLicenseeDetailsAuthority> ViewAreaDetailsAuthority(AreaDetails areaDetails);
        /// <summary>
        /// To Comapre Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        List<AreaDetails> CompareAreaDetails(AreaDetails areaDetails);
        /// <summary>
        /// To Bind Area Details Log in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetAreaDetailsLogDetails(AreaDetails objLicensee);
        MessageEF DeleteAreaDetails(AreaDetails areaDetails);

        #endregion
        #region Licensee Office Details
        Task<List<LicenseeDetails>> GetAssociationListDetails(LicenseeDetails licenseeDetails);
        Task<LicenseeResult> GetLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        MessageEF NewLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        MessageEF UpdateLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        MessageEF DeleteLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        MessageEF ApproveLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        MessageEF RejectLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        List<LicenseeDetails> CompareLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        List<LicenseeDetails> GetLicenseeOfficeLogDetails(LicenseeDetails licenseeDetails);
        #endregion
        #region Application Deatails
        #region Binddropdowns

        /// <summary>
        /// To Bind Mineral Unit 
        /// </summary>
        /// <param name="applicationDetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> MineralUnits(ApplicationDetails applicationDetails);
        Task<LicenseeResult> GetLicenseeType(ApplicationDetails applicationDetails);
        #endregion
        Task<LicenseeResult> GetLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF NewLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF UpdateLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF DeleteLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF ApproveLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF RejectLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        //List<ViewLicenseeDetailsAuthority> ViewLicenseeApplicationDetailsAuthority(ApplicationDetails applicationDetails);
        List<ApplicationDetails> CompareLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        List<ApplicationDetails> GetLicenseeApplicationLogDetails(ApplicationDetails applicationDetails);
        #endregion
        #region Minearal Inforamtion
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralCategoryDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralNameDetails(MineralDetails  mineralDetails);
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralFormDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralGradeDetails(MineralDetails mineralDetails);
        #endregion
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<MineralDetails> GetMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Information Log details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralInformationLogDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Save/Update,ForwardToDD Licensee Mineral Information details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF UpdateMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Delete Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF DeleteMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Compare Mineral Information of Licensee Details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralInformationCompareDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Approve Mineral Details of Licensee
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF ApproveMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Reject Mineral Details of Licensee
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF RejectMineralInformationDetails(MineralDetails mineralDetails);
        #endregion
        #region Licensee Profile
        ViewIBMProfile GetIBMProfile(ViewIBMProfile viewIBMProfile);
        ProfileCount GetProfileCount(ProfileCount profileCount);
        CTEProfile GetCTEProfile(CTEProfile cTEProfile);
        CTOProfile GetCTOProfile(CTOProfile cTOProfile);
        GrantProfile GetGrantProfile(GrantProfile grantProfile);
        ECProfile GetECProfile(ECProfile eCProfile);
        AreaProfile GetAreaProfile(AreaProfile areaProfile);
        ApplicationProfile GetApplicationProfile(ApplicationProfile applicationProfile);
        LicenseeDetails GetOfficeProfile(LicenseeDetails licenseeDetails);
        MineralProfile GetMineralProfile(MineralProfile mineralDetails);
        #endregion
        
    }
}
