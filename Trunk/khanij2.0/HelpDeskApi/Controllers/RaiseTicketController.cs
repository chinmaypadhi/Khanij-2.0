// ***********************************************************************
//  Controller  Name         : RaiseTicketController.cs
//  Desciption               : Used to Add,view,Take Action Raise Ticket 
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HelpDeskEF;
using HelpDeskApi.Model.Ticket;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Data;

namespace HelpDeskApi.Controllers
{
    [Route("api/{controller}/{action}")]
    [ApiController]
    [Authorize]
    public class RaiseTicketController : Controller
    {
        public ITicketProvider _objITicketProvider;
        public RaiseTicketController(ITicketProvider objICompanyProvider)
        {
            _objITicketProvider = objICompanyProvider;
        }
        /// <summary>
        /// Added by suroj on 3-mar-2021 to save Raiseticket 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF Add(RaiseTicket objCompanyMaster)
        {
            return _objITicketProvider.Add(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 3-mar-2021 to fetch userdetails 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public RaiseTicket FetchUserDetails(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.FetchUserDetails(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 18-mar-2021 to Bind state
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> StateBind(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.StateBind(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 13-mar-2021 to Bind userlist aginast district
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> DBind(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.DistrictBind(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to Bind Module
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> ModuleBind(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.ModuleBind(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 23-mar-2021 to fetch complain details
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> ComplainDetails(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.FetchCompalindetails(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 08-apr-2021 to Bind userlist popup
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetpopupDetails(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetpopupDetails(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to edit ticketdetails in Helpdesk login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RaiseTicket EditDetails(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.EditDetails(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind District data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetDistrictDataForUser(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetDistrictDataForUser(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind FMS Userlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetFMSUsersList(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetFMSUsersList(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to update the ticketby Authority user
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public int Update(RaiseTicket objCompanyMaster)
        {
            return _objITicketProvider.Update(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 13-apr-2021 to close ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public MessageEF CloseTicket(RaiseTicket objCompanyMaster)
        {
            return _objITicketProvider.CloseTicket(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to severity of ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<BackendModel> GetSeverity(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.GetSeverity(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        [HttpPost]
        public List<BackendModel> GetForwardedTo(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.GetForwardedTo(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        [HttpPost]
        public List<BackendModel> GetForwardedbyId(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.GetForwardedbyId(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to takeaction particular record
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public int TakeAction(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.TakeAction(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 1-apr-2021 to pull ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public int PullTicket(RaiseTicket objCompanyMaster)
        {
            return _objITicketProvider.PullTicket(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 3-apr-2021 to fetch details aginast ticketNo
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public BackendModel FetchTicketNo(BackendModel objPaymentTypeMaster)
        {
            return _objITicketProvider.FetchTicketNo(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to fetch backend Query Execution data
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public string FetchQuerydtls(string query, BackendModel objPaymentTypemaster)
        {
            return _objITicketProvider.FetchQuerydtls(query, objPaymentTypemaster);
        }
        [HttpPost]
        public int Queryinsert(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.Queryinsert(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 6-apr-2021 to Insert/Update Query Backend Query
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        [HttpPost]
        public int InsertExecution(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.InsertExecution(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 9-apr-2021 to fetch userdetails aginast usercode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetUserDetailsByUserCode(RaiseTicket objCompanyMaster)
        {
            return _objITicketProvider.GetUserDetailsByUserCode(objCompanyMaster);
        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Category Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetCategoryMaster(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetCategoryMaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Item Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetItemMaster(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetItemMaster(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj 16-apr-2021 to get modulewise report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> getModuleWisedata(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.getModuleWisedata(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get issuelogsummary report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<IssueLogsummaryModel> getIssueLogsummary(IssueLogsummaryModel objPaymentTypeMaster)
        {
            return _objITicketProvider.getIssueLogsummary(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 21-apr-2021 to get districtwise data
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> getDistrictWisedata(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.getDistrictWisedata(objPaymentTypeMaster);
        }
        /// <summary>
        /// ADDED BY SUROJ ON 18-mar-2021 TO VIEW LOCATIONWISEDETAILS REPORT
        /// </summary>
        /// <param name="Did"></param>
        /// <param name="type"></param>
        /// <param name="Dname"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> getDistrictWiseDetailsdata(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.getDistrictWiseDetailsdata(objPaymentTypeMaster);
        }
        /// <summary>
        /// ADDED BY SUROJ ON 19-mar-2021 TO VIEW ISSUE REPORT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> getdata(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.getdata(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 25-apr-2021 to getmultiple issue summary table report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public TotalIssueLogModel GetIssuesSummaryTables(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.GetIssuesSummaryTables(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 to bind district agnaist userid
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<BackendModel> GetStateDistrictList(BackendModel objPaymentTypeMaster)
        {
            return _objITicketProvider.GetStateDistrictList(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 22-apr-2021 to get backend data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public BackendModel GetDataBackend(BackendModel objPaymentTypeMaster)
        {
            return _objITicketProvider.GetDataBackend(objPaymentTypeMaster);
        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 for DGM Approval 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        [HttpPost]
        public int DgmApproval(BackendModel objCompanyMaster)
        {
            return _objITicketProvider.DgmApproval(objCompanyMaster);
        }
        /// <summary>
        /// //Added by suroj on 10-aug-2021 to get compainer details against ticketid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public RaiseTicket Fetchuserdetailshistory(RaiseTicket objPaymentTypeMaster)
        {
            return _objITicketProvider.Fetchuserdetailshistory(objPaymentTypeMaster);
        }
        #region Added by Lingaraj Dalai
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerName against District,UserType
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetUserByDistrictAndRoleType(RaiseTicket objRaiseTicket)
        {
            return _objITicketProvider.GetUserByDistrictAndRoleType(objRaiseTicket);
        }
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerDetails against ApplicantName
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> GetUserDetails(RaiseTicket objRaiseTicket)
        {
            return _objITicketProvider.GetUserDetails(objRaiseTicket);
        }
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 To View Detail Report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        [HttpPost]
        public List<RaiseTicket> getDetaildata(RaiseTicket objRaiseTicket)
        {
            return _objITicketProvider.getDetaildata(objRaiseTicket);
        }
        #endregion
    }
}
