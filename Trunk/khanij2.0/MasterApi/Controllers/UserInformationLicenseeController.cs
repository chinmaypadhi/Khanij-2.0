using MasterApi.Model.UserInformationLicensee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Microsoft.AspNetCore.Authorization;

namespace MasterApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    //[Authorize]
    public class UserInformationLicenseeController : Controller
    {
        public IUserInformationLicenseeProvider _objIUserInformationLicenseeProvider;
        public UserInformationLicenseeController (IUserInformationLicenseeProvider objIUserInformationLicenseeProvider)
        {
            _objIUserInformationLicenseeProvider = objIUserInformationLicenseeProvider;
        }
        #region IBMDetails
        /// <summary>
        ///  To Bind the IBM Details Data in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeIBMDetail(IBMDetails objLicensee)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeIBMDetail(objLicensee);
        }
        /// <summary>
        /// To Insert new IBM Details 
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF NewLicenseeIBMDetail(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.NewLicenseeIBMDetail(objLicensee);
        }
        /// <summary>
        /// To update IBM Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateLicenseeIBMDetail(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.UpdateLicenseeIBMDetail(objLicensee);
        }
        /// <summary>
        /// To Delete IBM Details 
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteLicenseeIBMDetail(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.DeleteLicenseeIBMDetail(objLicensee);
        }
        /// <summary>
        /// To Approve IBM Details 
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveLicenseeIBMDetails(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ApproveLicenseeIBMDetails(objLicensee);
        }
        /// <summary>
        /// To Reject IBM Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectLicenseeIBMDetails(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.RejectLicenseeIBMDetails(objLicensee);
        }
        /// <summary>
        /// To View IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewIBMDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewIBMDetailsAuthority(objLicensee);
        }
        /// <summary>
        /// To Compare IBM Deatils
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<IBMDetails> CompareIBMDetails(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.CompareIBMDetails(objLicensee);
        }
        public IBMDetails ViewIBMDetails(IBMDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewIBMDetails(objLicensee);
        }
        /// <summary>
        /// To bind IBM Log History details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<IBMDetails>>> GetIBMLogDetails(IBMDetails iBMDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetIBMLogDetails(iBMDetails);
        }
        #endregion
        #region CTE Details
        /// <summary>
        /// To Bind Consent To Establish Details to View For a Perticular Licensee
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeCTEDetail(CTEDetails cTEDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeCTEDetail(cTEDetails);
        }
        /// <summary>
        /// To insert a New CTE Details 
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF NewLicenseeCTEDetail(CTEDetails cTEDetails)
        {
            return _objIUserInformationLicenseeProvider.NewLicenseeCTEDetail(cTEDetails);
        }
        /// <summary>
        /// To Update CTE Details 
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateLicenseeCTEDetail(CTEDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.UpdateLicenseeCTEDetail(objLicensee);
        }
        /// <summary>
        /// To Approve CTE Details 
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveLicenseeCTEDetails(CTEDetails cTEDetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveLicenseeCTEDetails(cTEDetails);
        }
        /// <summary>
        /// To Reject CTE Details
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectLicenseeCTEDetails(CTEDetails cTEDetails)
        {
            return _objIUserInformationLicenseeProvider.RejectLicenseeCTEDetails(cTEDetails);
        }
        /// <summary>
        /// To Compare CTE Deatils of Licensee
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CTEDetails> CompareCTEDetails(CTEDetails cTEDetails)
        {
            return _objIUserInformationLicenseeProvider.CompareCTEDetails(cTEDetails);
        }
        /// <summary>
        /// To Bind CTE Log Details in View
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<CTEDetails>>> GetCTELogDetails(CTEDetails cTEDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetCTELogDetails(cTEDetails);
        }
        /// <summary>
        /// To Delete CTE Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteCTEDetail(CTEDetails cTEDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteCTEDetail(cTEDetails);
        }
        /// <summary>
        /// To View CTE Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewCTEDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewCTEDetailsAuthority(objLicensee);
        }
        #endregion
        #region CTO Details
        /// <summary>
        /// To Bind the Consent To Operate Details Data in View
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeCTODetail(CTODetails cTODetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeCTODetail(cTODetails);
        }
        /// <summary>
        /// To Insert new CTO Details 
        /// </summary>
        /// <param name="cTEDetails"></param>
        /// <returns>MessageEF</returns>
        public MessageEF NewLicenseeCTODetail(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.NewLicenseeCTODetail(cTODetails);
        }
        /// <summary>
        /// To Update CTO Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateLicenseeCTODetail(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.UpdateLicenseeCTODetail(cTODetails);
        }
        /// <summary>
        /// To Approve CTO Details by Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveLicenseeCTODetails(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveLicenseeCTODetails(cTODetails);
        }
        /// <summary>
        /// To Reject CTO Details
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectLicenseeCTODetails(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.RejectLicenseeCTODetails(cTODetails);
        }
        /// <summary>
        /// To Compare CTO Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<CTODetails> CompareCTODetails(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.CompareCTODetails(cTODetails);
        }
        /// <summary>
        /// To Bind CTO Details Log History
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<CTODetails>>> GetCTOLogDetails(CTODetails cTODetails)
        {
            return await _objIUserInformationLicenseeProvider.GetCTOLogDetails(cTODetails);
        }
        /// <summary>
        /// TO Delete CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF DeleteCTODetail(CTODetails cTODetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteCTODetail(cTODetails);
        }
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewCTODetailsAuthority(ViewLicenseeDetailsAuthority objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewCTODetailsAuthority(objLicensee);
        }
        #endregion
        #region Grant Order Details
        /// <summary>
        /// To Bind the Grant Order Details Data in View
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LicenseeResult> GetGrantOrderDetails(GrantDetails objLicensee)
        {
            return await _objIUserInformationLicenseeProvider.GetGrantOrderDetails(objLicensee);
        }
        /// <summary>
        /// To Insert new Grant Order Deatils
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF NewGrantOrderDetail(GrantDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.NewGrantOrderDetail(objLicensee);
        }
        /// <summary>
        /// To Update Grant Order Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateGrantOrderDetail(GrantDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.UpdateGrantOrderDetail(objLicensee);
        }
        /// <summary>
        /// To Approve Grant Order Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveGrantOrderDetails(GrantDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ApproveGrantOrderDetails(objLicensee);
        }
        /// <summary>
        /// To Reject Grant Order Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectGrantOrderDetails(GrantDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.RejectGrantOrderDetails(objLicensee);
        }
        /// <summary>
        /// To Compare Grant Order Details
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<GrantDetails> CompareGrantOrderDetails(GrantDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.CompareGrantOrderDetails(objLicensee);
        }
        /// <summary>
        /// To View all Requests of Grant Order Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewGrantDetailsAuthority(ViewLicenseeDetailsAuthority objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewGrantDetailsAuthority(objLicensee);
        }
        /// <summary>
        /// To Delete Grant Order Details
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteGrantOrderDetail(GrantDetails grantDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteGrantOrderDetail(grantDetails);
        }
        /// <summary>
        /// To Bind Log History of Grand Order Detaisl in View
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<GrantDetails>>> GetGrantLogDetails(GrantDetails grantDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetGrantLogDetails(grantDetails);
        }

        #endregion
        #region EC Details
        /// <summary>
        /// To Bind Mineral Dropdown
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<List<ECDetails>> GetMineralNames(ECDetails objLicensee)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralNames(objLicensee);
        }
        /// <summary>
        /// To Get EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<LicenseeResult> GetECDetails(ECDetails objLicensee)
        {
            return await _objIUserInformationLicenseeProvider.GetECDetails(objLicensee);
        }

        /// <summary>
        /// To Add New EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF NewECDetail(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.NewECDetail(objLicensee);
        }
        /// <summary>
        /// To Update EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateECDetail(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.UpdateECDetail(objLicensee);
        }
        /// <summary>
        /// To Approve EC Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveECDetails(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ApproveECDetails(objLicensee);
        }
        /// <summary>
        /// To Reject EC Details of Licenee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectECDetails(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.RejectECDetails(objLicensee);
        }
        /// <summary>
        /// To Compare EC Details of Licenee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ECDetails> CompareECDetails(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.CompareECDetails(objLicensee);
        }
        /// <summary>
        /// To View EC Profile Requests to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewECDetailsAuthority(ECDetails objLicensee)
        {
            return _objIUserInformationLicenseeProvider.ViewECDetailsAuthority(objLicensee);
        }
        /// <summary>
        /// To Delete EC Detaild of Licensee 
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteECDetail(ECDetails eCDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteECDetail(eCDetails);
        }
        /// <summary>
        /// To Bind EC Log History of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<ECDetails>>> GetECLogDetails(ECDetails eCDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetECLogDetails(eCDetails);
        }
        #endregion
        #region Area Details
        /// <summary>
        /// Bind State List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetStateList(AreaDetails viewAreaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetStateList(viewAreaDetails);
        }
        /// <summary>
        /// Bind District List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetDistrictList(AreaDetails viewAreaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetDistrictList(viewAreaDetails);
        }
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetTehsilList(AreaDetails viewAreaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetTehsilList(viewAreaDetails);
        }
        /// <summary>
        /// Bind Village List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetVillageList(AreaDetails viewAreaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetVillageList(viewAreaDetails);
        }
        /// <summary>
        /// To Bind Land Type Details
        /// </summary>
        /// <param name="viewAreaDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetLandTypeList(AreaDetails viewAreaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLandTypeList(viewAreaDetails);
        }
        [HttpPost]
        public async Task<LicenseeResult> GetAreaDetails(AreaDetails areaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetAreaDetails(areaDetails);
        }
        [HttpPost]
        public MessageEF NewAreaetail(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.NewAreaetail(areaDetails);
        }
        [HttpPost]
        public MessageEF UpdateAreaDetail(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.UpdateAreaDetail(areaDetails);
        }
        [HttpPost]
        public MessageEF ApproveAreaDetails(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveAreaDetails(areaDetails);
        }
        [HttpPost]
        public MessageEF RejectAreaDetails(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.RejectAreaDetails(areaDetails);
        }
        [HttpPost]
        public List<AreaDetails> CompareAreaDetails(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.CompareAreaDetails(areaDetails);
        }
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewAreaDetailsAuthority(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.ViewAreaDetailsAuthority(areaDetails);
        }
        [HttpPost]
        public async Task<ActionResult<List<AreaDetails>>> GetAreaDetailsLogDetails(AreaDetails areaDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetAreaDetailsLogDetails(areaDetails);
        }
        [HttpPost]
        public MessageEF DeleteAreaDetails(AreaDetails areaDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteAreaDetails(areaDetails);
        }
        #endregion
        #region Licensee Office Details
        public async Task<ActionResult<List<LicenseeDetails>>> GetAssociationListDetails(LicenseeDetails licenseeDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetAssociationListDetails(licenseeDetails);
        }
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public MessageEF NewLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.NewLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.UpdateLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public MessageEF DeleteLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public MessageEF RejectLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.RejectLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public List<LicenseeDetails> CompareLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.CompareLicenseeOfficeDetails(licenseeDetails);
        }
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.ViewLicenseeOfficeDetailsAuthority(licenseeDetails);
        }
        [HttpPost]
        public async Task<ActionResult<List<LicenseeDetails>>> GetLicenseeOfficeLogDetails(LicenseeDetails licenseeDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeOfficeLogDetails(licenseeDetails);
        }

        #endregion
        #region Application Details
        [HttpPost]
        public async Task<LicenseeResult> GetMineralUnitTypes(ApplicationDetails applicationDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralUnit(applicationDetails);
        }
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeType(ApplicationDetails applicationDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeType(applicationDetails);
        }
        [HttpPost]
        public async Task<LicenseeResult> GetLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public MessageEF NewLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.NewLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public MessageEF UpdateLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.UpdateLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public MessageEF DeleteLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public MessageEF ApproveLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public MessageEF RejectLicenseeApplicationDetails(ApplicationDetails licenseeDetails)
        {
            return _objIUserInformationLicenseeProvider.RejectLicenseeApplicationDetails(licenseeDetails);
        }
        [HttpPost]
        public List<ApplicationDetails> CompareLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.CompareLicenseeApplicationDetails(applicationDetails);
        }
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeApplicationDetailsAuthority(ApplicationDetails applicationDetails)
        {
            return _objIUserInformationLicenseeProvider.ViewLicenseeApplicationDetailsAuthority(applicationDetails);
        }
        [HttpPost]
        public async Task<ActionResult<List<ApplicationDetails>>> GetLicenseeApplicationLogDetails(ApplicationDetails applicationDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeApplicationLogDetails(applicationDetails);
        }
        #endregion
        #region Mineral Information
        #region Binddropdowns
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralCategoryDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralCategoryDetails(mineralDetails);
        }
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralNameDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralNameDetails(mineralDetails);
        }
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralFormDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralFormDetails(mineralDetails);
        }
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralGradeDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralGradeDetails(mineralDetails);
        }
        #endregion
        /// To bind Licensee Mineral Information details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MineralDetails>> GetMineralInformationDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralInformationDetails(mineralDetails);
        }
        /// <summary>
        /// To bind Mineral Information Log History details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralInformationLogDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralInformationLogDetails(mineralDetails);
        }
        /// <summary>
        /// To bind Mineral Information Compare details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<List<MineralDetails>>> GetMineralInformationCompareDetails(MineralDetails mineralDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralInformationCompareDetails(mineralDetails);
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Licensee Mineral Information details
        /// </summary>
        /// <param name="objLesseeMineralInformationModel"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF UpdateMineralInformationDetails(MineralDetails mineralDetails)
        {
            return _objIUserInformationLicenseeProvider.UpdateMineralInformationDetails(mineralDetails);
        }
        /// <summary>
        /// To Approve Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF ApproveMineralInformationDetails(MineralDetails mineralDetails)
        {
            return _objIUserInformationLicenseeProvider.ApproveMineralInformationDetails(mineralDetails);
        }
        /// <summary>
        /// To Reject Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF RejectMineralInformationDetails(MineralDetails mineralDetails)
        {
            return _objIUserInformationLicenseeProvider.RejectMineralInformationDetails(mineralDetails);
        }
        /// <summary>
        /// To Delete Licensee Mineral Information details 
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF DeleteMineralInformationDetails(MineralDetails mineralDetails)
        {
            return _objIUserInformationLicenseeProvider.DeleteMineralInformationDetails(mineralDetails);
        }
        /// <summary>
        /// To View Mineral Profile Requests to Authority
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        [HttpPost]
        public List<ViewLicenseeDetailsAuthority> ViewLicenseeMineralDetailsAuthority(MineralDetails mineralDetails)
        {
            return _objIUserInformationLicenseeProvider.ViewLicenseeMineralDetailsAuthority(mineralDetails);
        }

        #endregion
        #region Licenee Profile
        [HttpPost]
        public async Task<ActionResult<ViewIBMProfile>> GetIBMProfile(ViewIBMProfile viewIBMProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetIBMProfile(viewIBMProfile);
        }
        [HttpPost]
        public async Task<ActionResult<ProfileCount>> GetProfileCount(ProfileCount profileCount)
        {
            return await _objIUserInformationLicenseeProvider.GetProfileCount(profileCount);
        }
        [HttpPost]
        public async Task<ActionResult<CTEProfile>> GetCTEProfile(CTEProfile cTEProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetCTEProfile(cTEProfile);
        }
        [HttpPost]
        public async Task<ActionResult<CTOProfile>> GetCTOProfile(CTOProfile cTOProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetCTOProfile(cTOProfile);
        }
        [HttpPost]
        public async Task<ActionResult<GrantProfile>> GetGrantProfile(GrantProfile grantProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetGrantProfile(grantProfile);
        }
        [HttpPost]
        public async Task<ActionResult<ECProfile>> GetECProfile(ECProfile eCProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetECProfile(eCProfile);
        }
        [HttpPost]
        public async Task<AreaProfile> GetAreaProfile(AreaProfile areaProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetAreaProfile(areaProfile);
        }
        public async Task<ApplicationProfile> GetApplicationProfile(ApplicationProfile applicationProfile)
        {
            return await _objIUserInformationLicenseeProvider.GetApplicationProfile(applicationProfile);
        }
        public async Task<LicenseeDetails> GetOfficeProfile(LicenseeDetails licenseeDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetOfficeProfile(licenseeDetails);
        }
        public async Task<MineralProfile> GetMineralProfile(MineralProfile licenseeDetails)
        {
            return await _objIUserInformationLicenseeProvider.GetMineralProfile(licenseeDetails);
        }
        #endregion
        #region Individual Profile Count For DD
        [HttpPost]
        public async Task<ActionResult<DDProfileCount>> GetDDProfileCount(DDProfileCount dDProfileCount)
        {
            return await _objIUserInformationLicenseeProvider.GetDDProfileCount(dDProfileCount);
        }
        [HttpPost]
        public async Task<ActionResult<List<DDProfileCount>>> GetLicenseeUserList(DDProfileCount dDProfileCount)
        {
            return await _objIUserInformationLicenseeProvider.GetLicenseeUserList(dDProfileCount);
        }
        #endregion
    }
}
