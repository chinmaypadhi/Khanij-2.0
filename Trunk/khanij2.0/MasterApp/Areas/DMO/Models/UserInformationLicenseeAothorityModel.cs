using MasterApp.Models.Utility;
using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApp.Areas.DMO.Models
{
    public class UserInformationLicenseeAothorityModel : IUserInformationLicenseeAothorityModel
    {
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public UserInformationLicenseeAothorityModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// View Profile Requests of IBM Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewIBMDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewIBMDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of Grant Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewGrantDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewGrantDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of EC Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewECDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewECDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of CTE Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewCTEDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewCTEDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of CTO Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewCTODetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewCTODetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of Area Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewAreaDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewAreaDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of Office Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewOfficeDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewLicenseeOfficeDetails", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Profile Requests of Application Details to Authority
        /// </summary>
        /// <param name="objLicensee"></param>
        /// <returns></returns>
        public List<ViewLicenseeDetailsAuthority> ViewApplicationDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewLicenseeApplicationDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ViewLicenseeDetailsAuthority> ViewMineralDetailsLiecnsees(ViewLicenseeDetailsAuthority objLicensee)
        {
            try
            {
                List<ViewLicenseeDetailsAuthority> objLicensees = new List<ViewLicenseeDetailsAuthority>();
                objLicensees = JsonConvert.DeserializeObject<List<ViewLicenseeDetailsAuthority>>(_objIHttpWebClients.PostRequest("UserInformationLicensee/ViewLicenseeMineralDetailsAuthority", JsonConvert.SerializeObject(objLicensee)));
                return objLicensees;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Individual Profile Count For DD
        public DDProfileCount GetDDProfileCount(DDProfileCount dDProfileCount)
        {
            try
            {
                return JsonConvert.DeserializeObject<DDProfileCount>(_objIHttpWebClients.PostRequest("UserInformationLicensee/GetDDProfileCount", JsonConvert.SerializeObject(dDProfileCount)));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<DDProfileCount>> GetLisenseeUserList(DDProfileCount dDProfileCount)
        {
            try
            {
                List<DDProfileCount> objarealist = new List<DDProfileCount>();
                objarealist = JsonConvert.DeserializeObject<List<DDProfileCount>>(await _objIHttpWebClients.AwaitPostRequest("UserInformationLicensee/GetLicenseeUserList", JsonConvert.SerializeObject(dDProfileCount)));
                return objarealist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
