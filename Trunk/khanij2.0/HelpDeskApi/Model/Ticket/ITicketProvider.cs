// ***********************************************************************
//  Model Name               : ITicketProvider.cs
//  Desciption               : Used to Add,view,Take Action Raise Ticket 
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpDeskApi.Repository;
using HelpDeskEF;
using System.Data;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace HelpDeskApi.Model.Ticket
{
    
        public interface ITicketProvider : IDisposable, IRepository
        {
        /// <summary>
        /// Added by suroj on 3-mar-2021 to save Raiseticket 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        MessageEF Add(RaiseTicket objCompanyMaster);
        /// <summary>
        /// Added by suroj on 3-mar-2021 to fetch userdetails 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        RaiseTicket FetchUserDetails(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 18-mar-2021 to Bind state
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> StateBind(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 13-mar-2021 to Bind userlist aginast district
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> DistrictBind(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 21-mar-2021 to Bind Module
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> ModuleBind(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 23-mar-2021 to fetch complain details
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> FetchCompalindetails(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 08-apr-2021 to Bind userlist popup
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> GetpopupDetails(RaiseTicket objRaiseTicket);

        /// <summary>
        /// Added by suroj on 5-apr-2021 to edit ticketdetails in Helpdesk login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RaiseTicket EditDetails(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind District data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<RaiseTicket> GetDistrictDataForUser(RaiseTicket objticket);
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind FMS Userlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<RaiseTicket> GetFMSUsersList(RaiseTicket objticket);
        /// <summary>
        /// Added by suroj on 11-apr-2021 to update the ticketby Authority user
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        int Update(RaiseTicket objCompanyMaster);
        /// <summary>
        /// Added by suroj on 13-apr-2021 to close ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        MessageEF CloseTicket(RaiseTicket objCompanyMaster);
        /// <summary>
        /// Added by suroj on 15-apr-2021 to severity of ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        List<BackendModel> GetSeverity(BackendModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        List<BackendModel> GetForwardedTo(BackendModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        List<BackendModel> GetForwardedbyId(BackendModel objRaiseTicket);

        /// <summary>
        /// Added by suroj on 21-mar-2021 to takeaction particular record
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        int TakeAction(BackendModel objCompanyMaster);
        /// <summary>
        /// Added by suroj on 1-apr-2021 to pull ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        int PullTicket(RaiseTicket objCompanyMaster);
        /// <summary>
        /// Added by suroj on 3-apr-2021 to fetch details aginast ticketNo
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        BackendModel FetchTicketNo(BackendModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 5-apr-2021 to fetch backend Query Execution data
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        string FetchQuerydtls(string Query, BackendModel objPaymentTypemaster);

        int Queryinsert(BackendModel backendModel);
        /// <summary>
        /// Added by suroj on 6-apr-2021 to Insert/Update Query Backend Query
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        int InsertExecution(BackendModel backendModel);
        /// <summary>
        /// Added by suroj on 9-apr-2021 to fetch userdetails aginast usercode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        List<RaiseTicket> GetUserDetailsByUserCode(RaiseTicket model);
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Category Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> GetCategoryMaster(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Item Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> GetItemMaster(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj 16-apr-2021 to get modulewise report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> getModuleWisedata(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get issuelogsummary report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<IssueLogsummaryModel> getIssueLogsummary(IssueLogsummaryModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 21-apr-2021 to get districtwise data
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> getDistrictWisedata(RaiseTicket objRaiseTicket);
        /// <summary>
        /// ADDED BY SUROJ ON 18-mar-2021 TO VIEW LOCATIONWISEDETAILS REPORT
        /// </summary>
        /// <param name="Did"></param>
        /// <param name="type"></param>
        /// <param name="Dname"></param>
        /// <param name="Fromdate"></param>
        /// <param name="Todate"></param>
        /// <returns></returns>
        List<RaiseTicket> getDistrictWiseDetailsdata(RaiseTicket objRaiseTicket);
        /// <summary>
        /// ADDED BY SUROJ ON 19-mar-2021 TO VIEW ISSUE REPORT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        List<RaiseTicket> getdata(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 25-apr-2021 to getmultiple issue summary table report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>

        TotalIssueLogModel GetIssuesSummaryTables(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by suroj on 23-apr-2021 to bind district agnaist userid
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<BackendModel> GetStateDistrictList(BackendModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 22-apr-2021 to get backend data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        BackendModel GetDataBackend(BackendModel objRaiseTicket);
        /// <summary>
        /// Added by suroj on 23-apr-2021 for DGM Approval 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        int DgmApproval(BackendModel objbackend);
        /// <summary>
        /// //Added by suroj on 10-aug-2021 to get compainer details against ticketid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        RaiseTicket Fetchuserdetailshistory(RaiseTicket model);

        #region Added by Lingaraj Dalai
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerName against District,UserType
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> GetUserByDistrictAndRoleType(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerDetails against ApplicantName
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> GetUserDetails(RaiseTicket objRaiseTicket);
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 To View Detail Report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        List<RaiseTicket> getDetaildata(RaiseTicket objRaiseTicket);
        #endregion
    }

}
