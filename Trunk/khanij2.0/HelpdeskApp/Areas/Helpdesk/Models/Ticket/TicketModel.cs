// ***********************************************************************
//  Model Name               : TicketModel.cs
//  Desciption               : Used to Add,view,Take Action Raise Ticket 
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using HelpdeskApp.Models.Utility;
using HelpDeskEF;
using Newtonsoft.Json;

namespace HelpdeskApp.Areas.Helpdesk.Models.Ticket
{

    public class TicketModel:ITicketModel
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public TicketModel(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Added by suroj on 3-mar-2021 to save Raiseticket 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public MessageEF Add(RaiseTicket objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RaiseTicket/Add", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 3-mar-2021 to fetch userdetails 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public RaiseTicket FetchDetails(RaiseTicket objPaymentTypemaster)
        {
            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<RaiseTicket>(_objIHttpWebClients.PostRequest("RaiseTicket/FetchUserDetails", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 18-mar-2021 to Bind state
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> BindState(RaiseTicket objPaymentTypemaster)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/StateBind", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 13-mar-2021 to Bind userlist aginast district
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> DBind(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/DBind", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to Bind Module
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> ModuleBind(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/ModuleBind", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 23-mar-2021 to fetch complain details
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> FetchComplain(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/ComplainDetails", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 08-apr-2021 to Bind userlist popup
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetpopupDetails(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetpopupDetails", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to edit ticketdetails in Helpdesk login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RaiseTicket EditDetails(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objTicket = JsonConvert.DeserializeObject<RaiseTicket>(_objIHttpWebClients.PostRequest("RaiseTicket/EditDetails", JsonConvert.SerializeObject(objTicket)));
                return objTicket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind District data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetDistrictDataForUser(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetDistrictDataForUser", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind FMS Userlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetFMSUsersList(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetFMSUsersList", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to update the ticketby Authority user
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int Update(RaiseTicket objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/Update", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return respponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 13-apr-2021 to close ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public MessageEF CloseTicket(RaiseTicket objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("RaiseTicket/CloseTicket", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to severity of ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public List<BackendModel> GetSeverity(BackendModel objTicket)
        {
            List<BackendModel> objticket = new List<BackendModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<BackendModel>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetSeverity", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        public List<BackendModel> GetForwardedTo(BackendModel objTicket)
        {
            List<BackendModel> objticket = new List<BackendModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<BackendModel>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetForwardedTo", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        public List<BackendModel> GetForwardedbyId(BackendModel objTicket)
        {
            List<BackendModel> objticket = new List<BackendModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<BackendModel>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetForwardedbyId", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to takeaction particular record
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int TakeAction(BackendModel objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/TakeAction", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return respponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 1-apr-2021 to pull ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int PullTicket(RaiseTicket objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/PullTicket", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return respponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 3-apr-2021 to fetch details aginast ticketNo
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public BackendModel FetchTicketNo(BackendModel objPaymentTypemaster)
        {
            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<BackendModel>(_objIHttpWebClients.PostRequest("RaiseTicket/FetchTicketNo", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to fetch backend Query Execution data
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public string FetchQuerydtls(string query, BackendModel objPaymentTypemaster)
        {
            try
            {

                query = _objIHttpWebClients.PostRequest("RaiseTicket/FetchQuerydtls", JsonConvert.SerializeObject(objPaymentTypemaster)).ToString();
                return query;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public int Queryinsert(BackendModel objPaymentTypemaster)
        {
            
            try
            {

                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/Queryinsert", JsonConvert.SerializeObject(objPaymentTypemaster)));


                return respponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 6-apr-2021 to Insert/Update Query Backend Query
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public int InsertExecution(BackendModel objPaymentTypemaster)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                int respponse = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/InsertExecution", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return respponse;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 9-apr-2021 to fetch userdetails aginast usercode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserDetailsByUserCode(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetUserDetailsByUserCode", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Category Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetCategoryMaster(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetCategoryMaster", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Item Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetItemMaster(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetItemMaster", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj 16-apr-2021 to get modulewise report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getModuleWisedata(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/getModuleWisedata", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get issuelogsummary report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<IssueLogsummaryModel> getIssueLogsummary(IssueLogsummaryModel objTicket)
        {
            List<IssueLogsummaryModel> objticket = new List<IssueLogsummaryModel>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<IssueLogsummaryModel>>(_objIHttpWebClients.PostRequest("RaiseTicket/getIssueLogsummary", JsonConvert.SerializeObject(objTicket)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by suroj on 21-apr-2021 to get districtwise data
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getDistrictWisedata(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/getDistrictWisedata", JsonConvert.SerializeObject(objTicket)));
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

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
        public List<RaiseTicket> getDistrictWiseDetailsdata(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/getDistrictWiseDetailsdata", JsonConvert.SerializeObject(objTicket)));
               
                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// ADDED BY SUROJ ON 19-mar-2021 TO VIEW ISSUE REPORT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        public List<RaiseTicket> getdata(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/getdata", JsonConvert.SerializeObject(objTicket)));
                //objticket =List<RaiseTicket>(HelpdeskApp.Areas.Helpdesk.Models.Utility.HttpWebClients.PostRequest("RaiseTicket/getDistrictWiseDetailsdata", objTicket));


                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 25-apr-2021 to getmultiple issue summary table report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public TotalIssueLogModel GetIssuesSummaryTables(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            TotalIssueLogModel objtotal = new TotalIssueLogModel();
            try
            {

                objtotal = JsonConvert.DeserializeObject<TotalIssueLogModel>(_objIHttpWebClients.PostRequest("RaiseTicket/GetIssuesSummaryTables", JsonConvert.SerializeObject(objTicket)));
                //objticket =List<RaiseTicket>(HelpdeskApp.Areas.Helpdesk.Models.Utility.HttpWebClients.PostRequest("RaiseTicket/getDistrictWiseDetailsdata", objTicket));


                return objtotal;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 to bind district agnaist userid
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<BackendModel> GetStateDistrictList(BackendModel objTicket)
        {
            List<BackendModel> objticket = new List<BackendModel>();
            try
            {

                objticket = JsonConvert.DeserializeObject<List<BackendModel>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetStateDistrictList", JsonConvert.SerializeObject(objTicket)));
                //objticket =List<RaiseTicket>(HelpdeskApp.Areas.Helpdesk.Models.Utility.HttpWebClients.PostRequest("RaiseTicket/getDistrictWiseDetailsdata", objTicket));


                return objticket;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 22-apr-2021 to get backend data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BackendModel GetDataBackend(BackendModel objPaymentTypemaster)
        {
            try
            {

                objPaymentTypemaster = JsonConvert.DeserializeObject<BackendModel>(_objIHttpWebClients.PostRequest("RaiseTicket/GetDataBackend", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return objPaymentTypemaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 for DGM Approval 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int DgmApproval(BackendModel objPaymentTypemaster)
        {
            int response;
            try
            {


                response = JsonConvert.DeserializeObject<int>(_objIHttpWebClients.PostRequest("RaiseTicket/DgmApproval", JsonConvert.SerializeObject(objPaymentTypemaster)));
                return response;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// //Added by suroj on 10-aug-2021 to get compainer details against ticketid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RaiseTicket Fetchuserdetailshistory(RaiseTicket objPaymentTypeMaster)
        {
            try
            {

                objPaymentTypeMaster = JsonConvert.DeserializeObject<RaiseTicket>(_objIHttpWebClients.PostRequest("RaiseTicket/Fetchuserdetailshistory", JsonConvert.SerializeObject(objPaymentTypeMaster)));
                return objPaymentTypeMaster;

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        #region Added on 17-Mar-2022 by Lingaraj Dalai
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerName against District,UserType
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserByDistrictAndRoleType(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetUserByDistrictAndRoleType", JsonConvert.SerializeObject(objTicket)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerDetails against ApplicantName
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserDetails(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/GetUserDetails", JsonConvert.SerializeObject(objTicket)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 To View Detail Report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getDetaildata(RaiseTicket objTicket)
        {
            List<RaiseTicket> objticket = new List<RaiseTicket>();
            try
            {
                objticket = JsonConvert.DeserializeObject<List<RaiseTicket>>(_objIHttpWebClients.PostRequest("RaiseTicket/getDetaildata", JsonConvert.SerializeObject(objTicket)));
                return objticket;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
