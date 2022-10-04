using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApi.Repository;
using MasterEF;

namespace MasterApi.Model.UserInformationLicensee
{
    public interface IUserInformationLicenseeProvider: IDisposable, IRepository
    {
        #region IBM Details
        /// <summary>
        /// To Get IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task <LicenseeResult> GetLicenseeIBMDetail(IBMDetails objLicensee);
        /// <summary>
        /// To Insert New IBM Details of Licensee
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
        /// To Approve IBM Details of Licensee By Authority
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
        /// To View IBM Details for Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewIBMDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// To Compare IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<IBMDetails> CompareIBMDetails(IBMDetails objLicensee);
        IBMDetails ViewIBMDetails(IBMDetails objLicensee);
        /// <summary>
        /// To bind IBM Log History details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        Task<List<IBMDetails>> GetIBMLogDetails(IBMDetails iBMDetails);
        #endregion
        #region CTO Details
        /// <summary>
        /// To Get CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        Task <LicenseeResult> GetLicenseeCTODetail(CTODetails cTODetails);
        /// <summary>
        /// To Add New CTO Details of Licensee
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
        /// To Compare CTO Details of Licensee
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
        List<ViewLicenseeDetailsAuthority> ViewCTODetailsAuthority(ViewLicenseeDetailsAuthority objLicensee);
        #endregion
        #region CTE Details
        /// <summary>
        /// To Get CTE Details of Licesnee
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
        /// To Bind CTE Log Details in View
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        Task<List<CTEDetails>> GetCTELogDetails(CTEDetails cTEDetails);
        /// <summary>
        /// To delete CTE Details
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        MessageEF DeleteCTEDetail(CTEDetails cTEDetails);
        /// <summary>
        /// To View CTE Details for Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewCTEDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee);
        #endregion
        #region Grant Details
        /// <summary>
        /// To Get Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Add New Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF NewGrantOrderDetail(GrantDetails objLicensee);
        /// <summary>
        /// To update Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF UpdateGrantOrderDetail(GrantDetails objLicensee);
        /// <summary>
        /// To Approve Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF ApproveGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Reject Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF RejectGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To View Grarnt Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewGrantDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee);
        /// <summary>
        /// To Compare Grant Order Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<GrantDetails> CompareGrantOrderDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Bind Grant Order Log Details in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<List<GrantDetails>> GetGrantLogDetails(GrantDetails objLicensee);
        /// <summary>
        /// To Delete Grant Order Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF DeleteGrantOrderDetail(GrantDetails objLicensee);
        #endregion
        #region EC Details
        /// <summary>
        /// To Get Mineral Name
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        Task<List<ECDetails>> GetMineralNames(ECDetails eCDetails);
        /// <summary>
        /// To Get EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetECDetails(ECDetails objLicensee);
        /// <summary>
        /// To Add New EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF NewECDetail(ECDetails objLicensee);
        /// <summary>
        /// To Update EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF UpdateECDetail(ECDetails objLicensee);
        /// <summary>
        /// To Approve EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF ApproveECDetails(ECDetails objLicensee);
        /// <summary>
        /// To Reject EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF RejectECDetails(ECDetails objLicensee);
        /// <summary>
        /// To View EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewECDetailsAuthority(ECDetails eCDetails);
        /// <summary>
        /// To Compare EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        List<ECDetails> CompareECDetails(ECDetails objLicensee);
        /// <summary>
        /// To Bind EC Details Log in View
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        Task<List<ECDetails>> GetECLogDetails(ECDetails eCDetails);
        /// <summary>
        /// To Delete EC Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        MessageEF DeleteECDetail(ECDetails objLicensee);
        #endregion
        #region Area Details
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetStateList(AreaDetails objLeaseAreaModel);
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetDistrictList(AreaDetails objLeaseAreaModel);
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetTehsilList(AreaDetails objLeaseAreaModel);
        /// <summary>
        /// Bind Village List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetVillageList(AreaDetails objLeaseAreaModel);
        /// <summary>
        /// To Bind Land Type List
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        Task<List<AreaDetails>> GetLandTypeList(AreaDetails areaDetails);
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
        List<ViewLicenseeDetailsAuthority> ViewAreaDetailsAuthority(AreaDetails areaDetails);
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
        #region Applicatin Details

        //#region Binddropdowns
        ///// <summary>
        ///// To bind Mineral Category details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //Task<List<ApplicationDetails>> GetMineralCategoryDetails(ApplicationDetails applicationDetails);
        ///// <summary>
        ///// To bind Mineral Name details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //Task<List<ApplicationDetails>> GetMineralNameDetails(ApplicationDetails applicationDetails);
        ///// <summary>
        ///// To bind Mineral Form details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //Task<List<ApplicationDetails>> GetMineralFormDetails(ApplicationDetails applicationDetails);
        ///// <summary>
        ///// To bind Mineral Grade details in view
        ///// </summary>
        ///// <param name="objLesseeMineralInformationModel"></param>
        ///// <returns></returns>
        //Task<List<ApplicationDetails>> GetMineralGradeDetails(ApplicationDetails applicationDetails);
        //#endregion
        Task<LicenseeResult> GetMineralUnit(ApplicationDetails applicationDetails);
        Task<LicenseeResult> GetLicenseeType(ApplicationDetails applicationDetails);
        Task<LicenseeResult> GetLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF NewLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF UpdateLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF DeleteLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF ApproveLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        MessageEF RejectLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        List<ViewLicenseeDetailsAuthority> ViewLicenseeApplicationDetailsAuthority(ApplicationDetails applicationDetails);
        List<ApplicationDetails> CompareLicenseeApplicationDetails(ApplicationDetails applicationDetails);
        Task<List<ApplicationDetails>> GetLicenseeApplicationLogDetails(ApplicationDetails applicationDetails);
        #endregion
        #region Licensee Details
        /// <summary>
        /// 
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        Task<List<LicenseeDetails>> GetAssociationListDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Get Licensee Office Details
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        Task<LicenseeResult> GetLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Insert New Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        MessageEF NewLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Update Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        MessageEF UpdateLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// TO Delete Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        MessageEF DeleteLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Approve Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        MessageEF ApproveLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Reject Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        MessageEF RejectLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        List<ViewLicenseeDetailsAuthority> ViewLicenseeOfficeDetailsAuthority(LicenseeDetails LicenseeDetails);
        /// <summary>
        /// To Compare Office Details of Licensee
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        List<LicenseeDetails> CompareLicenseeOfficeDetails(LicenseeDetails licenseeDetails);
        /// <summary>
        /// To Bind Log Details of Office Details
        /// </summary>
        /// <param name="licenseeDetails"></param>
        /// <returns></returns>
        Task<List<LicenseeDetails>> GetLicenseeOfficeLogDetails(LicenseeDetails licenseeDetails);

        #endregion
        #region Mineral Information
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
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralNameDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralFormDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralGradeDetails(MineralDetails mineralDetails);
        #endregion
        /// <summary>
        /// To bind Lessee Mineral Information details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<MineralDetails> GetMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralInformationLogDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        Task<List<MineralDetails>> GetMineralInformationCompareDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Save/Update,ForwardToDD Licensee Mineral Information details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF UpdateMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Approve Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF ApproveMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Reject Licenee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF RejectMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// To Delete Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        MessageEF DeleteMineralInformationDetails(MineralDetails mineralDetails);
        /// <summary>
        /// View Mineral Details For Authority
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        List<ViewLicenseeDetailsAuthority> ViewLicenseeMineralDetailsAuthority(MineralDetails mineralDetails);
        #endregion
        #region Licesnee Profile Details
        Task<ViewIBMProfile> GetIBMProfile(ViewIBMProfile viewIBMProfile);
        Task<ProfileCount> GetProfileCount(ProfileCount profileCount);
        Task<CTEProfile> GetCTEProfile(CTEProfile cTEProfile);
        Task<CTOProfile> GetCTOProfile(CTOProfile cTOProfile);
        Task<GrantProfile> GetGrantProfile(GrantProfile grantProfile);
        Task<ECProfile> GetECProfile(ECProfile eCProfile);
        Task<AreaProfile> GetAreaProfile(AreaProfile areaProfile);
        Task<ApplicationProfile> GetApplicationProfile(ApplicationProfile applicationProfile);
        Task<LicenseeDetails> GetOfficeProfile(LicenseeDetails licenseeDetails);
        Task<MineralProfile> GetMineralProfile(MineralProfile mineralDetails);
        #endregion
        #region Individual Profile Count For DD
        Task<DDProfileCount> GetDDProfileCount(DDProfileCount dDProfileCount);
        Task <List<DDProfileCount>> GetLicenseeUserList(DDProfileCount dDProfileCount);
        #endregion
    }
}
    