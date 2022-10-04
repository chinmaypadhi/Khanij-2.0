using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;

namespace MasterApp.Areas.Licensee.Models
{
    public class UserInformationLicenseeModel : IUserInformationLicenseeModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public UserInformationLicenseeModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region IBM Details
        /// <summary>
        /// To Get IBM Details of Licensee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetLicenseeIBMDetail(IBMDetails objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeIBMDetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Add New IBM Details of Licensee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeIBMDetail(IBMDetails objModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewLicenseeIBMDetail", JsonConvert.SerializeObject(objModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update IBM Details of Licensee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeIBMDetail(IBMDetails objModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateLicenseeIBMDetail", JsonConvert.SerializeObject(objModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete IBM Details of Licenee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteLicenseeIBMDetail(IBMDetails objModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteLicenseeIBMDetail", JsonConvert.SerializeObject(objModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Approve IBM Details of Licenee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeIBMDetails(IBMDetails objModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveLicenseeIBMDetails", JsonConvert.SerializeObject(objModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Reject IBM Details of Licenee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeIBMDetails(IBMDetails objModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectLicenseeIBMDetails", JsonConvert.SerializeObject(objModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Compare IBM Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<IBMDetails> CompareIBMDetails(IBMDetails objLicensee)
        {
            try
            {
                List<IBMDetails> objLicensees = new List<IBMDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<IBMDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareIBMDetails", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View IBM Details of Licensee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public IBMDetails ViewIBMDetails(IBMDetails objModel)
        {
            try
            {
                IBMDetails objLicensees = new IBMDetails();
                objLicensees = JsonConvert.DeserializeObject<IBMDetails>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewIBMDetails", JsonConvert.SerializeObject(objModel)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind IBM Log details in view
        /// </summary>
        /// <param name="objLesseeIBMDetailsModel"></param>
        /// <returns></returns>
        public async Task<List<IBMDetails>> GetIBMLogDetails(IBMDetails iBMDetails)
        {
            try
            {
                List<IBMDetails> objIBMlist = new List<IBMDetails>();
                objIBMlist = JsonConvert.DeserializeObject<List<IBMDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetIBMLogDetails", JsonConvert.SerializeObject(iBMDetails)));
                return objIBMlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region CTE Details
        /// <summary>
        /// To Get CTE Details of Licenee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task <LicenseeResult> GetLicenseeCTEDetail(CTEDetails objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeCTEDetail", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Add New CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeCTEDetail(CTEDetails objLicensee)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewLicenseeCTEDetail", JsonConvert.SerializeObject(objLicensee)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Update CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeCTEDetail(CTEDetails objLicensee)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateLicenseeCTEDetail", JsonConvert.SerializeObject(objLicensee)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Approve CET Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeCTEDetails(CTEDetails objLicensee)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveLicenseeCTEDetails", JsonConvert.SerializeObject(objLicensee)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Reject CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeCTEDetails(CTEDetails objLicensee)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectLicenseeCTEDetails", JsonConvert.SerializeObject(objLicensee)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Compare CTE Details of Licenee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<CTEDetails> CompareCTEDetails(CTEDetails objLicensee)
        {
            try
            {
                List<CTEDetails> objLicensees = new List<CTEDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<CTEDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareCTEDetails", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Get CTE Log Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public async Task<List<CTEDetails>> GetCTELogDetails(CTEDetails objLicensee)
        {
            try
            {
                List<CTEDetails> objCTElist = new List<CTEDetails>();
                objCTElist = JsonConvert.DeserializeObject<List<CTEDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetCTELogDetails", JsonConvert.SerializeObject(objLicensee)));
                return objCTElist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete CTE Details of Licensee
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public MessageEF DeleteCTEDetail(CTEDetails objLicensee)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteCTEDetail", JsonConvert.SerializeObject(objLicensee)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region CTO Details
        /// <summary>
        /// To Get CTO Details Of Licensee
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetLicenseeCTODetail(CTODetails cTODetails)
        {
            try
            {
                return  JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeCTODetail", JsonConvert.SerializeObject(cTODetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Insert New CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF NewLicenseeCTODetail(CTODetails cTODetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewLicenseeCTODetail", JsonConvert.SerializeObject(cTODetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF UpdateLicenseeCTODetail(CTODetails cTODetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateLicenseeCTODetail", JsonConvert.SerializeObject(cTODetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF ApproveLicenseeCTODetails(CTODetails cTODetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveLicenseeCTODetails", JsonConvert.SerializeObject(cTODetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Reject CTO Details of Licensee
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public MessageEF RejectLicenseeCTODetails(CTODetails cTODetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectLicenseeCTODetails", JsonConvert.SerializeObject(cTODetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Compare CTO Details Old Record With New One
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public List<CTODetails> CompareCTODetails(CTODetails cTODetails)
        {
            try
            {
                List<CTODetails> objLicensees = new List<CTODetails>();
                objLicensees = JsonConvert.DeserializeObject<List<CTODetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareCTODetails", JsonConvert.SerializeObject(cTODetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  To Bind CTO Log Details in View
        /// </summary>
        /// <param name="cTODetails"></param>
        /// <returns></returns>
        public async Task<List<CTODetails>> GetCTOLogDetails(CTODetails cTODetails)
        {
            try
            {
                List<CTODetails> objCTOlist = new List<CTODetails>();
                objCTOlist = JsonConvert.DeserializeObject<List<CTODetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetCTOLogDetails", JsonConvert.SerializeObject(cTODetails)));
                return objCTOlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete CTO Details
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public MessageEF DeleteCTODetail(CTODetails cTODetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteCTODetail", JsonConvert.SerializeObject(cTODetails)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw ;
            }
        }
        #endregion
        #region Grant Order Details
        /// <summary>
        /// To Bind the Grant Order Details Data in View
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetGrantOrderDetails(GrantDetails objModel)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetGrantOrderDetails", JsonConvert.SerializeObject(objModel)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Add New Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF NewGrantOrderDetail(GrantDetails grantDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewGrantOrderDetail", JsonConvert.SerializeObject(grantDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// To Update Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateGrantOrderDetail(GrantDetails grantDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateGrantOrderDetail", JsonConvert.SerializeObject(grantDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveGrantOrderDetails(GrantDetails grantDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveGrantOrderDetails", JsonConvert.SerializeObject(grantDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Reject Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF RejectGrantOrderDetails(GrantDetails grantDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectGrantOrderDetails", JsonConvert.SerializeObject(grantDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Compare Grant Order Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public List<GrantDetails> CompareGrantOrderDetails(GrantDetails grantDetails)
        {
            try
            {
                List<GrantDetails> objLicensees = new List<GrantDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<GrantDetails>>( _objIHttpWebClients.PostRequest("UserInformationLicensee/CompareGrantOrderDetails", JsonConvert.SerializeObject(grantDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Grant Order Details
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF DeleteGrantOrderDetail(GrantDetails grantDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteGrantOrderDetail", JsonConvert.SerializeObject(grantDetails)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<List<GrantDetails>> GetGrantLogDetails(GrantDetails grantDetails)
        {
            try
            {
                List<GrantDetails> objCTOlist = new List<GrantDetails>();
                objCTOlist = JsonConvert.DeserializeObject<List<GrantDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetGrantLogDetails", JsonConvert.SerializeObject(grantDetails)));
                return objCTOlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region EC Details
        public async Task<List<ECDetails>> GetMineralNames(ECDetails eCDetails)
        {
            try
            {
                List<ECDetails> objLicensees = new List<ECDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<ECDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralNames", JsonConvert.SerializeObject(eCDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the Envirnmental Clearance Details Data in View
        /// </summary>
        /// <param name="objModel"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetECDetails(ECDetails eCDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetECDetails", JsonConvert.SerializeObject(eCDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Add New EC Details of Lciensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public MessageEF NewECDetail(ECDetails eCDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewECDetail", JsonConvert.SerializeObject(eCDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateECDetail(ECDetails eCDetails )
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateECDetail", JsonConvert.SerializeObject(eCDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve EC Details of Lciensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveECDetails(ECDetails eCDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveECDetails", JsonConvert.SerializeObject(eCDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Reject EC Details of Licensee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public MessageEF RejectECDetails(ECDetails eCDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectECDetails", JsonConvert.SerializeObject(eCDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Compare EC Details of Licenee
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public List<ECDetails> CompareECDetails(ECDetails eCDetails )
        {
            try
            {
                List<ECDetails> objLicensees = new List<ECDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<ECDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareECDetails", JsonConvert.SerializeObject(eCDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind EC Log History in View
        /// </summary>
        /// <param name="eCDetails"></param>
        /// <returns></returns>
        public async Task<List<ECDetails>> GetECLogDetails(ECDetails eCDetails)
        {
            try
            {
                List<ECDetails> objCTOlist = new List<ECDetails>();
                objCTOlist = JsonConvert.DeserializeObject<List<ECDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetECLogDetails", JsonConvert.SerializeObject(eCDetails)));
                return objCTOlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete EC Details of Licensee
        /// </summary>
        /// <param name="grantDetails"></param>
        /// <returns></returns>
        public MessageEF DeleteECDetail(ECDetails eCDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteECDetail", JsonConvert.SerializeObject(eCDetails)));
                return objMessageEF;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
        #region Area Details
        /// <summary>
        /// To Bind the State Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetStateList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetStateList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind the District Details Data in View
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetDistrictList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetDistrictList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Tehsil List details in view
        /// </summary>
        /// <param name="objLeaseAreaModel"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetTehsilList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetTehsilList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///  Bind Village List details in view 
        /// </summary>
        /// <param name="viewAreaDetails"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetVillageList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetVillageList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Land Type Details
        /// </summary>
        /// <param name="viewAreaDetails"></param>
        /// <returns></returns>
        public async Task<List<AreaDetails>> GetLandTypeList(AreaDetails viewAreaDetails)
        {
            try
            {
                List<AreaDetails> objarealist = new List<AreaDetails>();
                objarealist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLandTypeList", JsonConvert.SerializeObject(viewAreaDetails)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// To Get Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> GetAreaDetails(AreaDetails areaDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetAreaDetails", JsonConvert.SerializeObject(areaDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Add Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF NewAreaetail(AreaDetails areaDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewAreaetail", JsonConvert.SerializeObject(areaDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateAreaDetail(AreaDetails areaDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateAreaDetail", JsonConvert.SerializeObject(areaDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteAreaDetails(AreaDetails areaDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteAreaDetails", JsonConvert.SerializeObject(areaDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// To Approve Area Details of Licensee
        /// </summary>
        /// <param name="areaDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveAreaDetails(AreaDetails areaDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveAreaDetails", JsonConvert.SerializeObject(areaDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF RejectAreaDetails(AreaDetails areaDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectAreaDetails", JsonConvert.SerializeObject(areaDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<AreaDetails> CompareAreaDetails(AreaDetails areaDetails)
        {
            try
            {
                List<AreaDetails> objLicensees = new List<AreaDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<AreaDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareAreaDetails", JsonConvert.SerializeObject(areaDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<AreaDetails>> GetAreaDetailsLogDetails(AreaDetails areaDetails)
        {
            try
            {
                List<AreaDetails> objIBMlist = new List<AreaDetails>();
                objIBMlist = JsonConvert.DeserializeObject<List<AreaDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetAreaDetailsLogDetails", JsonConvert.SerializeObject(areaDetails)));
                return objIBMlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Licensee Office Details
        public async Task<List<LicenseeDetails>> GetAssociationListDetails(LicenseeDetails licenseeDetails)
        {
            List<LicenseeDetails> objofficelist = new List<LicenseeDetails>();
            try
            {
                objofficelist = JsonConvert.DeserializeObject<List<LicenseeDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetAssociationListDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objofficelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<LicenseeResult> GetLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF NewLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF UpdateLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF ApproveLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF RejectLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LicenseeDetails> CompareLicenseeOfficeDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                List<LicenseeDetails> objLicensees = new List<LicenseeDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<LicenseeDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareLicenseeOfficeDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<LicenseeDetails> GetLicenseeOfficeLogDetails(LicenseeDetails licenseeDetails)
        {
            try
            {
                List<LicenseeDetails> objCTOlist = new List<LicenseeDetails>();
                objCTOlist = JsonConvert.DeserializeObject<List<LicenseeDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetLicenseeOfficeLogDetails", JsonConvert.SerializeObject(licenseeDetails)));
                return objCTOlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Application Details
        #region Binddropdowns

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationDetails"></param>
        /// <returns></returns>
        public async Task<LicenseeResult> MineralUnits(ApplicationDetails applicationDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralUnitTypes", JsonConvert.SerializeObject(applicationDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public async Task<LicenseeResult> GetLicenseeType(ApplicationDetails applicationDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeType", JsonConvert.SerializeObject(applicationDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        public async Task<LicenseeResult> GetLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeResult>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MessageEF NewLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/NewLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF UpdateLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF DeleteLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF ApproveLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MessageEF RejectLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objMessageEF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ApplicationDetails> CompareLicenseeApplicationDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                List<ApplicationDetails> objLicensees = new List<ApplicationDetails>();
                objLicensees = JsonConvert.DeserializeObject<List<ApplicationDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/CompareLicenseeApplicationDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ApplicationDetails> GetLicenseeApplicationLogDetails(ApplicationDetails applicationDetails)
        {
            try
            {
                List<ApplicationDetails> objCTOlist = new List<ApplicationDetails>();
                objCTOlist = JsonConvert.DeserializeObject<List<ApplicationDetails>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetLicenseeApplicationLogDetails", JsonConvert.SerializeObject(applicationDetails)));
                return objCTOlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Mineral Inforamtion
        #region Binddropdowns
        /// <summary>
        /// To bind Mineral Category details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralCategoryDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objmineralcategorylist = new List<MineralDetails>();
                objmineralcategorylist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralCategoryDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objmineralcategorylist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Name details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralNameDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objmineralnamelist = new List<MineralDetails>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralNameDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Form details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralFormDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objmineralnamelist = new List<MineralDetails>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralFormDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Grade details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralGradeDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objmineralnamelist = new List<MineralDetails>();
                objmineralnamelist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralGradeDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objmineralnamelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        /// <summary>
        /// To bind Licenese Mineral Information details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<MineralDetails> GetMineralInformationDetails(MineralDetails mineralDetails)
        {
            try
            {
                MineralDetails objmineralinformationlist = new MineralDetails();
                objmineralinformationlist = JsonConvert.DeserializeObject<MineralDetails>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralInformationDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objmineralinformationlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To bind Mineral Information Log details in view
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralInformationLogDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objgrantorderlist = new List<MineralDetails>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralInformationLogDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Save/Update,ForwardToDD Licensee Mineral Information details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF UpdateMineralInformationDetails(MineralDetails mineralDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/UpdateMineralInformationDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objMessageEF;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Licensee Mineral Information details by DD
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF DeleteMineralInformationDetails(MineralDetails mineralDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/DeleteMineralInformationDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objMessageEF;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Compare Mineral Information of Licensee Details
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public async Task<List<MineralDetails>> GetMineralInformationCompareDetails(MineralDetails mineralDetails)
        {
            try
            {
                List<MineralDetails> objgrantorderlist = new List<MineralDetails>();
                objgrantorderlist = JsonConvert.DeserializeObject<List<MineralDetails>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetMineralInformationCompareDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objgrantorderlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Approve Mineral Details of Licensee
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF ApproveMineralInformationDetails(MineralDetails mineralDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ApproveMineralInformationDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objMessageEF;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Reject Mineral Details of Licensee
        /// </summary>
        /// <param name="mineralDetails"></param>
        /// <returns></returns>
        public MessageEF RejectMineralInformationDetails(MineralDetails mineralDetails)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("UserInformationLicensee/RejectMineralInformationDetails", JsonConvert.SerializeObject(mineralDetails)));
                return objMessageEF;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region Licensee Profile
        public ViewIBMProfile GetIBMProfile(ViewIBMProfile viewIBMProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<ViewIBMProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetIBMProfile", JsonConvert.SerializeObject(viewIBMProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ProfileCount GetProfileCount(ProfileCount profileCount)
        {
            try
            {
                return JsonConvert.DeserializeObject<ProfileCount>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetProfileCount", JsonConvert.SerializeObject(profileCount)));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public CTEProfile GetCTEProfile(CTEProfile cTEProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<CTEProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetCTEProfile", JsonConvert.SerializeObject(cTEProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public CTOProfile GetCTOProfile(CTOProfile cTOProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<CTOProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetCTOProfile", JsonConvert.SerializeObject(cTOProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public GrantProfile GetGrantProfile(GrantProfile grantProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<GrantProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetGrantProfile", JsonConvert.SerializeObject(grantProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ECProfile GetECProfile(ECProfile eCProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<ECProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetECProfile", JsonConvert.SerializeObject(eCProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public AreaProfile GetAreaProfile(AreaProfile areaProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<AreaProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetAreaProfile", JsonConvert.SerializeObject(areaProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ApplicationProfile GetApplicationProfile(ApplicationProfile applicationProfile)
        {
            try
            {
                return JsonConvert.DeserializeObject<ApplicationProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetApplicationProfile", JsonConvert.SerializeObject(applicationProfile)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public LicenseeDetails GetOfficeProfile(LicenseeDetails licenseeDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<LicenseeDetails>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetOfficeProfile", JsonConvert.SerializeObject(licenseeDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public MineralProfile GetMineralProfile(MineralProfile mineralDetails)
        {
            try
            {
                return JsonConvert.DeserializeObject<MineralProfile>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetMineralProfile", JsonConvert.SerializeObject(mineralDetails)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
    }
}
