// ***********************************************************************
//  Model Name               : TicketProvider.cs
//  Desciption               : Used to Add,view,Take Action Raise Ticket 
//  Created By               : Suroj Kumar Pradhan
//  Created On               : 5-feb-2021
// ***********************************************************************
using Dapper;
using HelpDeskApi.Factory;
using HelpDeskApi.Repository;
using HelpDeskEF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HelpDeskApi.Model.Ticket
{
    public class TicketProvider : RepositoryBase, ITicketProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TicketProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Added by suroj on 3-mar-2021 to save Raiseticket 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public MessageEF Add(RaiseTicket objraiseticket)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@onbehalfof", objraiseticket.OnBehalfOfName);
                p.Add("@Check", objraiseticket.Action);
                p.Add("@state", objraiseticket.StateName);
                p.Add("@district", objraiseticket.DistrictName);
                p.Add("@complainername", objraiseticket.ComplainerName);
                p.Add("@complainermobileno", objraiseticket.ComplainerMobileNumber);
                p.Add("@complaineremail", objraiseticket.ComplainerEmailID);
                p.Add("@username", objraiseticket.ComplainerUserName);
                p.Add("@categoryid", objraiseticket.CategoryID);
                p.Add("@itemid", objraiseticket.ItemID);
                if (objraiseticket.OtherThanHelpdesk_ModuleID != null)
                {
                    p.Add("@moduleid", objraiseticket.OtherThanHelpdesk_ModuleID);
                }
                else
                {
                    p.Add("@moduleid", objraiseticket.ModuleID);
                }
                if (objraiseticket.Document != null)
                {
                    DataTable _dt = new DataTable("MultipleFileUpload");
                    _dt = (DataTable)objraiseticket.Document;
                    if (_dt.Rows.Count > 0)
                    {
                        p.Add("@MultipleFile", _dt, DbType.Object);
                    }
                }
                p.Add("@priorityid", objraiseticket.PriorityID);
                p.Add("@description", objraiseticket.ProblemDescription);
                p.Add("@onbehalfofid", objraiseticket.OnBehalfOfId);
                p.Add("@ticketid", objraiseticket.TicketID);
                p.Add("@userid", objraiseticket.Userid);
                p.Add("@userloginid", objraiseticket.Userid);
                p.Add("@HelpDesk_id", objraiseticket.Userid);
                if (objraiseticket.Action == "Helpdesk_UpdateRemarks")
                { p.Add("@HelpDesk_Remarks", objraiseticket.Remark); }
                else
                {
                    p.Add("@HelpDesk_Remarks", objraiseticket.Closeremark);
                }
                p.Add("@TicketId", objraiseticket.TicketID);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                objMessage.Satus = result.First();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Added by suroj on 05-mar-2021 to fetch userlist
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public RaiseTicket FetchUserDetails(RaiseTicket objRaiseTicket)
        {
            RaiseTicket objraise = new RaiseTicket();
            try
            {
                var paramList = new
                {
                    Userid = objRaiseTicket.Userid, //objRaiseTicket.User,
                    Check = "FetchDetailsID",
                };
                var result = Connection.Query<RaiseTicket>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objraise = result.FirstOrDefault();
                }
                else
                {
                    objraise = null;
                }
                return objraise;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
            }
        }
        /// <summary>
        /// Added by suroj on 18-mar-2021 to Bind state
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> StateBind(RaiseTicket objPaymentTypemaste)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    Check = objPaymentTypemaste.Action,
                };
                var result = Connection.Query<RaiseTicket>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 13-mar-2021 to Bind userlist aginast district
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetDistrictDataForUser(RaiseTicket objPaymentTypemaste)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                };
                var result = Connection.Query<RaiseTicket>("GetDistrictDataForUser", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 16-mar-2021 to Bind district
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> DistrictBind(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    P_INT_STATEID = objRaiseTicket.StateID,
                    Check = objRaiseTicket.Action,
                };
                var result = Connection.Query<RaiseTicket>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to Bind Module
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> ModuleBind(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    Check = objRaiseTicket.Action
                };
                var result = Connection.Query<RaiseTicket>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 23-mar-2021 to fetch complain details
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> FetchCompalindetails(RaiseTicket model)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    Check = model.Action,
                    UserID = model.Userid,
                    FromDate = model.fromdate,
                    ToDate = model.todate,
                };
                var result = Connection.ExecuteReader("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new RaiseTicket();
                    model.SrNo = Convert.ToString(dt.Rows[i]["SrNo"]);
                    if (!(dt.Rows[i]["TicketId"] is DBNull))
                        model.TicketID = Convert.ToInt64(dt.Rows[i]["TicketId"]);
                    model.TicketNumber = Convert.ToString(dt.Rows[i]["TicketNo"]);
                    model.OnBehalfOfName = Convert.ToString(dt.Rows[i]["OnBehalfOf"]);
                    model.StateName = Convert.ToString(dt.Rows[i]["State"]);
                    model.DistrictName = Convert.ToString(dt.Rows[i]["District"]);
                    model.ComplainerName = Convert.ToString(dt.Rows[i]["ComplainerName"]);
                    model.ComplainerMobileNumber = Convert.ToString(dt.Rows[i]["ComplainerMobileNo"]);
                    model.ComplainerEmailID = Convert.ToString(dt.Rows[i]["ComplainerEmail"]);
                    model.ComplainerUserName = Convert.ToString(dt.Rows[i]["UserName"]);
                    if (!(dt.Rows[i]["ModuleId"] is DBNull))
                        model.ModuleID = Convert.ToInt32(dt.Rows[i]["ModuleId"]);
                    model.ModuleName = Convert.ToString(dt.Rows[i]["ModuleName"]);
                    if (!(dt.Rows[i]["CategoryId"] is DBNull))
                        model.CategoryID = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                    model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    if (!(dt.Rows[i]["ItemId"] is DBNull))
                        model.ItemID = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                    model.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                    if (!(dt.Rows[i]["PriorityId"] is DBNull))
                        model.PriorityID = Convert.ToInt32(dt.Rows[i]["PriorityId"]);
                    model.PriorityName = Convert.ToString(dt.Rows[i]["PriorityName"]);
                    if (!(dt.Rows[i]["CriticalityId"] is DBNull))
                        model.CriticalityID = Convert.ToInt32(dt.Rows[i]["CriticalityId"]);
                    model.CriticalityName = Convert.ToString(dt.Rows[i]["CriticalityName"]);
                    model.ProblemDescription = Convert.ToString(dt.Rows[i]["Description"]);
                    model.TicketRaisedDateTime = Convert.ToString(dt.Rows[i]["CreatedOn"]);
                    model.Status_Details = Convert.ToString(dt.Rows[i]["Status_Detail"]);
                    model.Ticketstatus = Convert.ToString(dt.Rows[i]["Status"]);
                    model.SolutionDescription = Convert.ToString(dt.Rows[i]["SolutionDescription"]);
                    model.CloseDateTime = Convert.ToString(dt.Rows[i]["CloseDateTime"]);
                    model.DaysTimeTaken = Convert.ToString(dt.Rows[i]["CloseDaysTime"]);
                    model.DiffMinute = Convert.ToString(dt.Rows[i]["DiffMinute"]);
                    model.DiffMinuteForOSUFMS = Convert.ToString(dt.Rows[i]["DiffMinuteForOSUFMS"]);
                    if (!(dt.Rows[i]["IsBackendApprove"] is DBNull))
                        model.IsBackendApprove = Convert.ToInt32(dt.Rows[i]["IsBackendApprove"]);
                    objraise.Add(model);
                }
                return objraise;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objraise = null;
            }
        }
        /// <summary>
        /// Added by suroj on 08-apr-2021 to Bind userlist popup
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetpopupDetails(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    TicketId = objRaiseTicket.TicketID,
                    Userid = objRaiseTicket.Userid
                };
                var result = Connection.Query<RaiseTicket>("uspGetHelpdeskPopupInfo", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj to convert datareader to dataset
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to edit ticketdetails in Helpdesk login
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RaiseTicket EditDetails(RaiseTicket model)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    Check = model.Action,
                    UserID = model.Userid,
                    TicketId = model.TicketID
                };
                var result = Connection.ExecuteReader("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                {
                    model.SrNo = Convert.ToString(ds.Tables[0].Rows[0]["SrNo"]);
                    if (!(ds.Tables[0].Rows[0]["TicketId"] is DBNull))
                        model.TicketID = Convert.ToInt64(ds.Tables[0].Rows[0]["TicketId"]);
                    model.TicketNumber = Convert.ToString(ds.Tables[0].Rows[0]["TicketNo"]);
                    model.OnBehalfOfName = Convert.ToString(ds.Tables[0].Rows[0]["OnBehalfOf"]);
                    if (!(string.IsNullOrEmpty(model.OnBehalfOfName)) && model.OnBehalfOfName != "Non User")
                    {
                        model.OtherThenNonUser_StateName2 = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                        model.OtherThenNonUser_DistrictName2 = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                        model.OtherThenNonUser_ComplainerName2 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerName"]);
                        model.OtherThenNonUser_ComplainerUserName2 = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        model.OtherThenNonUser_ComplainerEmailID2 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerEmail"]);
                        model.OtherThenNonUser_ComplainerMobileNumber2 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerMobileNo"]);
                    }
                    else if (!(string.IsNullOrEmpty(model.OnBehalfOfName)))
                    {
                        model.NonUser_StateName1 = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                        model.NonUser_DistrictName1 = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                        model.NonUser_ComplainerName1 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerName"]);
                        model.NonUser_ComplainerUserName1 = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        model.NonUser_ComplainerEmailID1 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerEmail"]);
                        model.NonUser_ComplainerMobileNumber1 = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerMobileNo"]);
                    }
                    //else
                    //{
                    model.StateName = Convert.ToString(ds.Tables[0].Rows[0]["State"]);
                    model.DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["District"]);
                    model.ComplainerName = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerName"]);
                    model.ComplainerMobileNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerMobileNo"]);
                    model.ComplainerEmailID = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerEmail"]);
                    model.ComplainerUserName = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                    //}
                    if (!(ds.Tables[0].Rows[0]["ModuleId"] is DBNull))
                        model.ModuleID = Convert.ToInt32(ds.Tables[0].Rows[0]["ModuleId"]);
                    model.ModuleName = Convert.ToString(ds.Tables[0].Rows[0]["ModuleName"]);

                    if (!(ds.Tables[0].Rows[0]["CategoryId"] is DBNull))
                        model.CategoryID = Convert.ToInt32(ds.Tables[0].Rows[0]["CategoryId"]);
                    model.CategoryName = Convert.ToString(ds.Tables[0].Rows[0]["CategoryName"]);

                    if (!(ds.Tables[0].Rows[0]["ItemId"] is DBNull))
                        model.ItemID = Convert.ToInt32(ds.Tables[0].Rows[0]["ItemId"]);
                    model.ItemName = Convert.ToString(ds.Tables[0].Rows[0]["ItemName"]);

                    if (!(ds.Tables[0].Rows[0]["PriorityId"] is DBNull))
                        model.PriorityID = Convert.ToInt32(ds.Tables[0].Rows[0]["PriorityId"]);
                    model.PriorityName = Convert.ToString(ds.Tables[0].Rows[0]["PriorityName"]);

                    if (!(ds.Tables[0].Rows[0]["CriticalityId"] is DBNull))
                        model.CriticalityID = Convert.ToInt32(ds.Tables[0].Rows[0]["CriticalityId"]);
                    model.CriticalityName = Convert.ToString(ds.Tables[0].Rows[0]["CriticalityName"]);

                    model.ProblemDescription = Convert.ToString(ds.Tables[0].Rows[0]["Description"]);
                    model.TicketRaisedDateTime = Convert.ToString(ds.Tables[0].Rows[0]["CreatedOn"]);
                    model.Status_Details = Convert.ToString(ds.Tables[0].Rows[0]["Status_Detail"]);
                    model.Ticketstatus = Convert.ToString(ds.Tables[0].Rows[0]["Status"]);
                    model.SolutionDescription = Convert.ToString(ds.Tables[0].Rows[0]["SolutionDescription"]);
                    model.CloseDateTime = Convert.ToString(ds.Tables[0].Rows[0]["CloseDateTime"]);
                    model.DaysTimeTaken = Convert.ToString(ds.Tables[0].Rows[0]["CloseDaysTime"]);
                    if (ds != null && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {

                            var empList = ds.Tables[2].AsEnumerable()
                            .Select(dataRow => new Filedetail
                            {
                                FileName = dataRow.Field<string>("FileName"),
                                FilePath = "https://localhost:44361" + @" / HepldeskFile//" + Convert.ToString(ds.Tables[2].Rows[i]["FilePath"])
                            }).ToList();
                            model.attachments = empList;
                            //model.attachments = ds.Tables[2].Read<Filedetail>().ToList();
                            //Attachments a = new Attachments();
                            //a.FileName = Convert.ToString(ds.Tables[2].Rows[i]["FileName"]);
                            //a.FilePath = System.Configuration.ConfigurationManager.AppSettings["ServerPath"] + @"/Upload//" + Convert.ToString(ds.Tables[2].Rows[i]["FilePath"]);
                            //model.Attachment.Add(a);
                        }
                    }
                    //objraise.Add(model);
                }
                return model;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }


        }
        /// <summary>
        /// Added by suroj on 7-apr-2021 to bind FMS Userlist
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetFMSUsersList(RaiseTicket objPaymentTypemaste)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    Check = objPaymentTypemaste.Action,
                    UserTypeID = objPaymentTypemaste.intUsertypeid,
                    DistrictID = objPaymentTypemaste.DistrictID,
                };
                var result = Connection.Query<RaiseTicket>("uspGETHelpDeskUsersName", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to update the ticketby Authority user
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int Update(RaiseTicket objraiseticket)
        {
            int Response;
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                //p.Add("@onbehalfof", objraiseticket.OnBehalfOfName);
                p.Add("@ItemId", objraiseticket.ItemID);
                p.Add("@CategoryId", objraiseticket.CategoryID);
                if (objraiseticket.Fmuserid == 0)
                {
                    p.Add("@Check", "Helpdesk_Forword_To_Osu");
                    p.Add("@Forwarded_id", objraiseticket.Osuuserid);
                }
                else
                {
                    p.Add("@Check", "Helpdesk_Forword_To_Fms");
                    p.Add("@Forwarded_id", objraiseticket.Fmuserid);
                }
                if (objraiseticket.ModuleID == 0)
                {
                    //p.Add("@moduleid", objraiseticket.OtherThanHelpdesk_ModuleID);
                }
                else
                {
                    p.Add("@moduleid", objraiseticket.ModuleID);
                }

                //p.Add("@criticalityid", objraiseticket.CriticalityID);
                p.Add("@priorityid", objraiseticket.PriorityID);
                p.Add("@HelpDesk_id", objraiseticket.Userid);
                p.Add("@UserId", objraiseticket.Userid);
                p.Add("@UserLoginId", objraiseticket.Userid);
                p.Add("@HelpDesk_Remarks", objraiseticket.Remarks);
                p.Add("@TicketId", objraiseticket.TicketID);
                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                Response = p.Get<int>("Result");

                //if (response.ToString() == "1")
                //{
                //    objMessage.Satus = "1";

                //}
                //else
                //{
                //    objMessage.Satus = "2";
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Response;
        }
        /// <summary>
        /// Added by suroj on 13-apr-2021 to close ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public MessageEF CloseTicket(RaiseTicket objraiseticket)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@Check", objraiseticket.Action);
                if (objraiseticket.Document != null)
                {
                    DataTable _dt = new DataTable("MultipleFileUpload");
                    _dt = (DataTable)objraiseticket.Document;
                    if (_dt.Rows.Count > 0)
                    {
                        p.Add("@MultipleFile", _dt, DbType.Object);
                    }
                }
                p.Add("@userid", objraiseticket.Userid);
                p.Add("@userloginid", objraiseticket.Userid);
                p.Add("@HelpDesk_id", objraiseticket.Userid);
                if (objraiseticket.Action == "Helpdesk_ReOpen")
                {
                    p.Add("@HelpDesk_Remarks", objraiseticket.ReopenRemark);
                }
                else if (objraiseticket.Action == "Helpdesk_StatusUpdate_From_OsuFms")
                {
                    p.Add("@HelpDesk_Remarks", objraiseticket.UpdateRemark);
                }
                else
                {
                    p.Add("@HelpDesk_Remarks", objraiseticket.Closeremark);
                }
                p.Add("@TicketId", objraiseticket.TicketID);
                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                objMessage.Satus = response.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to severity of ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public List<BackendModel> GetSeverity(BackendModel objPaymentTypemaste)
        {
            List<BackendModel> ListPaymenttypeMaster = new List<BackendModel>();
            try
            {
                var paramList = new
                {
                    UserId = objPaymentTypemaste.userid,
                };
                var result = Connection.Query<BackendModel>("uspGetSeverity", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        public List<BackendModel> GetForwardedTo(BackendModel objPaymentTypemaste)
        {

            List<BackendModel> ListPaymenttypeMaster = new List<BackendModel>();


            try
            {
                var paramList = new
                {

                    UserId = objPaymentTypemaste.userid,

                };


                var result = Connection.Query<BackendModel>("upsGetHelpDeskFowardedTo", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPaymenttypeMaster = result.ToList();
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Added by suroj on 15-apr-2021 to load forward list user
        /// </summary>
        /// <param name="objPaymentTypemaste"></param>
        /// <returns></returns>
        public List<BackendModel> GetForwardedbyId(BackendModel objPaymentTypemaste)
        {

            List<BackendModel> ListPaymenttypeMaster = new List<BackendModel>();


            try
            {
                var paramList = new
                {

                    UserId = objPaymentTypemaste.userid,
                    ForwardedTo = objPaymentTypemaste.ForwardedTo,
                    Ticket_ID = objPaymentTypemaste.TicketID,
                    DistrictId = objPaymentTypemaste.DistrictId,

                };


                var result = Connection.Query<BackendModel>("upsGetHelpdeskForwader", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPaymenttypeMaster = result.ToList();
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Added by suroj on 21-mar-2021 to takeaction particular record
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int TakeAction(BackendModel objraiseticket)
        {
            int Response;
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@TicketId", objraiseticket.TicketID);
                p.Add("@SeverityId", objraiseticket.SeverityId);
                p.Add("@Check", objraiseticket.Action);
                if (objraiseticket.Document != null)
                {
                    DataTable _dt = new DataTable("MultipleFileUpload");
                    _dt = (DataTable)objraiseticket.Document;
                    if (_dt.Rows.Count > 0)
                    {
                        p.Add("@MultipleFile", _dt, DbType.Object);
                    }
                }
                p.Add("@ProblemType", objraiseticket.ProblemType);
                p.Add("@ForwardedTo", objraiseticket.UserType);
                p.Add("@Forwarded_id", objraiseticket.ForwardedId);
                p.Add("@Description", objraiseticket.ProblemDescription);
                p.Add("@UserId", objraiseticket.userid);

                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                Response = p.Get<int>("Result");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Response;
        }
        /// <summary>
        /// Added by suroj on 1-apr-2021 to pull ticket
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int PullTicket(RaiseTicket objraiseticket)
        {
            int Response;
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@TicketId", objraiseticket.TicketID);
                p.Add("@HelpDesk_id", objraiseticket.Userid);
                p.Add("@Check", objraiseticket.Action);
                p.Add("@HelpDesk_Remarks", objraiseticket.Remark);
                p.Add("@UserLoginId", objraiseticket.Userid);
                p.Add("@UserId", objraiseticket.Userid);

                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                Response = p.Get<int>("Result");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Response;
        }
        /// <summary>
        /// Added by suroj on 3-apr-2021 to fetch details aginast ticketNo
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public BackendModel FetchTicketNo(BackendModel objRaiseTicket)
        {
            BackendModel objraise = new BackendModel();
            try
            {
                var paramList = new
                {
                    Userid = objRaiseTicket.userid, //objRaiseTicket.User,
                    Check = objRaiseTicket.Action,
                    TicketId = objRaiseTicket.TicketID,

                };


                var result = Connection.Query<BackendModel>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objraise = result.FirstOrDefault();
                }
                else
                {
                    objraise = null;
                }
                return objraise;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }



        }
        /// <summary>
        /// Added by suroj on 5-apr-2021 to fetch backend Query Execution data
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public string FetchQuerydtls(string Query, BackendModel objPaymentTypemaster)
        {

            BackendModel objraise = new BackendModel();
            var dynamicDt = new List<dynamic>();

            try
            {

                //var result = Connection.Query<BackendModel>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var result = Connection.Query(objPaymentTypemaster.qry);

                var json = JsonSerializer.Serialize(result);

                return json;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }

        }
        public int Queryinsert(BackendModel objPaymentTypemaster)
        {

            BackendModel objraise = new BackendModel();
            var dynamicDt = new List<dynamic>();

            try
            {

                //var result = Connection.Query<BackendModel>("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var result = Connection.Execute(objPaymentTypemaster.qry);

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }

        }
        /// <summary>
        /// Added by suroj on 6-apr-2021 to Insert/Update Query Backend Query
        /// </summary>
        /// <param name="objPaymentTypemaster"></param>
        /// <returns></returns>
        public int InsertExecution(BackendModel objPaymentTypemaster)
        {
            int Response;
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@QueryID", 1);
                p.Add("@QueryText", objPaymentTypemaster.qry);
                p.Add("@QueryTypeID", objPaymentTypemaster.Qrytype);
                p.Add("@EntryDateTime", DateTime.Now);
                p.Add("@Mode", 1);
                p.Add("@UserId", objPaymentTypemaster.userid);
                p.Add("@Ticket_No", objPaymentTypemaster.TicketNo);
                p.Add("@OutID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("SP_CRUD_DBDev_QueryMaster", p, commandType: CommandType.StoredProcedure);
                Response = p.Get<int>("OutID");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Response;
        }
        /// <summary>
        /// Added by suroj on 9-apr-2021 to fetch userdetails aginast usercode
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserDetailsByUserCode(RaiseTicket model)
        {
            List<RaiseTicket> objraise = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    UserCode = model.FetchUserCode,
                    Check = "GetUserDetailsByUserCode",
                };
                var result = Connection.ExecuteReader("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    model = new RaiseTicket();
                    model.Userid = Convert.ToInt16(dt.Rows[i]["UserId"]);
                    model.ApplicantName = dt.Rows[i]["ApplicantName"].ToString();
                    model.FetchUserCode = Convert.ToString(dt.Rows[i]["UserCode"]);
                    model.StateName = Convert.ToString(dt.Rows[i]["StateName"]);
                    model.DistrictName = Convert.ToString(dt.Rows[i]["DistrictName"]);
                    model.ComplainerEmailID = Convert.ToString(dt.Rows[i]["EMailId"]);
                    model.ComplainerMobileNumber = Convert.ToString(dt.Rows[i]["MobileNo"]);
                    model.UserType = Convert.ToString(dt.Rows[i]["UserType"]);
                    objraise.Add(model);
                }
                return objraise;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                objraise = null;
            }


        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Category Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetCategoryMaster(RaiseTicket objRaiseTicket)
        {

            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();


            try
            {
                var paramList = new
                {

                    Check = "CategoryMasterNew",
                    UserId = objRaiseTicket.Userid,
                };


                var result = Connection.Query<RaiseTicket>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPaymenttypeMaster = result.ToList();
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Added by suroj on 11-apr-2021 to get Item Master
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetItemMaster(RaiseTicket objRaiseTicket)
        {

            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();


            try
            {
                var paramList = new
                {

                    Check = "ItemMasterNew",
                    UserId = objRaiseTicket.Userid,
                    CategoryID = objRaiseTicket.CategoryID,
                    ModuleID = objRaiseTicket.ModuleID,

                };


                var result = Connection.Query<RaiseTicket>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListPaymenttypeMaster = result.ToList();
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Added by suroj 16-apr-2021 to get modulewise report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getModuleWisedata(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,

                };
                var result = Connection.ExecuteReader("uspHELPDESK_MODULE_WISE_REPORT", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    RaiseTicket model = new RaiseTicket();

                    model.SrNo = Convert.ToString(i + 1);
                    model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    model.ModuleName = Convert.ToString(dt.Rows[i]["ModuleName"]);
                    model.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);

                    model.Logged = Convert.ToString(dt.Rows[i]["Logged"]);
                    model.Resolved_Issues_On_Same_Day = Convert.ToString(dt.Rows[i]["Resolved_Issues_On_Same_Day"]);
                    model.PreviousPendingIssue = Convert.ToString(dt.Rows[i]["PreviousPendingIssue"]);
                    model.PreviousPendingIssueSolved = Convert.ToString(dt.Rows[i]["PreviousPendingIssueSolved"]);
                    model.TotalIssueReSolved = Convert.ToString(dt.Rows[i]["TotalIssueReSolved"]);
                    model.TotalIssuePending = Convert.ToString(dt.Rows[i]["TotalIssuePending"]);
                    ListPaymenttypeMaster.Add(model);
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }



        }
        /// <summary>
        /// Added by suroj on 18-apr-2021 to get issuelogsummary report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<IssueLogsummaryModel> getIssueLogsummary(IssueLogsummaryModel objRaiseTicket)
        {
            List<IssueLogsummaryModel> ListPaymenttypeMaster = new List<IssueLogsummaryModel>();
            try
            {
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    IssueStatus = objRaiseTicket.IssueStatus,
                    FromDate = objRaiseTicket.FromDate,
                    ToDate = objRaiseTicket.ToDate,
                };
                var result = Connection.ExecuteReader("HelpdeskIssueReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    IssueLogsummaryModel model = new IssueLogsummaryModel();

                    model.SrNo = Convert.ToInt32(dt.Rows[i]["SrNo"]);
                    model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryName"]);
                    model.ModuleName = Convert.ToString(dt.Rows[i]["ModuleName"]);
                    model.ItemName = Convert.ToString(dt.Rows[i]["ItemName"]);
                    model.ItemId = Convert.ToInt32(dt.Rows[i]["ItemId"]);
                    model.LesseThan1 = Convert.ToInt32(dt.Rows[i]["<1"]);
                    model.LesseThan2 = Convert.ToInt32(dt.Rows[i]["<2"]);
                    model.LesseThan3 = Convert.ToInt32(dt.Rows[i]["<3"]);
                    model.LesseThan4 = Convert.ToInt32(dt.Rows[i]["<4"]);
                    model.LesseThan5 = Convert.ToInt32(dt.Rows[i]["<5"]);
                    model.GreaterThan5 = Convert.ToInt32(dt.Rows[i][">=5"]);
                    model.Total = Convert.ToInt32(dt.Rows[i]["Total"]);
                    model.FromDate = objRaiseTicket.FromDate;
                    model.ToDate = objRaiseTicket.ToDate;
                    ListPaymenttypeMaster.Add(model);
                }

                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 21-apr-2021 to get districtwise data
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getDistrictWisedata(RaiseTicket objRaiseTicket)
        {

            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();

            string fdate = objRaiseTicket.fromdate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.fromdate;
            string tdate = objRaiseTicket.todate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.todate;
            try
            {
                var paramList = new
                {


                    UserId = objRaiseTicket.Userid,


                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,

                };

                var result = Connection.ExecuteReader("uspHELPDESK_LOCATION_WISE_REPORT", paramList, commandType: System.Data.CommandType.StoredProcedure);


                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RaiseTicket model = new RaiseTicket();

                        model.SrNo = Convert.ToString(dt.Rows[i]["SrNo"]);

                        if (!(dt.Rows[i]["DistrictID"] is DBNull))
                            model.DistrictID = Convert.ToInt32(dt.Rows[i]["DistrictID"]);

                        model.DistrictName = Convert.ToString(dt.Rows[i]["District"]);
                        model.Logged = Convert.ToString(dt.Rows[i]["Logged"]);
                        model.Resolved_Issues_On_Same_Day = Convert.ToString(dt.Rows[i]["Resolved_Issues_On_Same_Day"]);
                        model.PreviousPendingIssue = Convert.ToString(dt.Rows[i]["PreviousPendingIssue"]);
                        model.PreviousPendingIssueSolved = Convert.ToString(dt.Rows[i]["PreviousPendingIssueSolved"]);
                        model.TotalIssueReSolved = Convert.ToString(dt.Rows[i]["TotalIssueReSolved"]);
                        model.TotalIssuePending = Convert.ToString(dt.Rows[i]["TotalIssuePending"]);
                        model.fromdate = fdate;
                        model.todate = tdate;

                        ListPaymenttypeMaster.Add(model);
                    }
                }

                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
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
        public List<RaiseTicket> getDistrictWiseDetailsdata(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    Type = objRaiseTicket.UserType,
                    DistrictID = objRaiseTicket.DistrictID,
                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,
                };
                var result = Connection.ExecuteReader("uspHelpdesk_TotalLocationWiseSummaryReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RaiseTicket model = new RaiseTicket();

                        model.SrNo = Convert.ToString(dt.Rows[i]["SrNo"]);
                        if (!(dt.Rows[i]["TicketId"] is DBNull))
                            model.TicketID = Convert.ToInt64(dt.Rows[i]["TicketId"]);

                        model.TicketNumber = Convert.ToString(dt.Rows[i]["TicketNo"]);
                        model.TicketOpenDate = Convert.ToString(dt.Rows[i]["TicketOpenTime"]);
                        model.StateName = Convert.ToString(dt.Rows[i]["State"]);
                        model.DistrictName = Convert.ToString(dt.Rows[i]["District"]);
                        model.ComplainerName = Convert.ToString(dt.Rows[i]["ComplainerName"]);
                        model.ComplainerMobileNumber = Convert.ToString(dt.Rows[i]["ComplainerMobileNo"]);
                        model.ComplainerEmailID = Convert.ToString(dt.Rows[i]["ComplainerEmail"]);
                        model.ComplainerUserName = Convert.ToString(dt.Rows[i]["UserName"]);
                        model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryDetails"]);
                        string replaceWith = "";
                        string removedBreaksdesc = Convert.ToString(dt.Rows[i]["Description"]).Trim().Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith).Replace("\t", replaceWith).Replace("@", replaceWith);
                        string removedBreaks = Convert.ToString(dt.Rows[i]["SoutionDescription"]).Replace("\r\n", replaceWith).Replace("\n", replaceWith).Replace("\r", replaceWith);
                        model.SolutionDescription = removedBreaks;
                        model.PriorityName = Convert.ToString(dt.Rows[i]["PriorityName"]);
                        model.Status_Details = Convert.ToString(dt.Rows[i]["Status_Detail"]);
                        model.CloseDateTime = Convert.ToString(dt.Rows[i]["CloseDateTime"]);
                        model.DaysTimeTaken = Convert.ToString(dt.Rows[i]["CloseDaysTime"]);
                        model.IssueReportedBy = Convert.ToString(dt.Rows[i]["IssueReportedBy"]);
                        model.designation = Convert.ToString(dt.Rows[i]["Designation"]);
                        model.delaytime = Convert.ToString(dt.Rows[i]["DelayTime"]);
                        ListPaymenttypeMaster.Add(model);
                    }
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// ADDED BY SUROJ ON 19-mar-2021 TO VIEW ISSUE REPORT
        /// </summary>
        /// <param name="id"></param>
        /// <param name="objRaise"></param>
        /// <returns></returns>
        public List<RaiseTicket> getdata(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            string fdate = objRaiseTicket.fromdate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.fromdate;
            string tdate = objRaiseTicket.todate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.todate;
            try
            {
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    Check = "GetIssueReport",
                    IssueStatus = objRaiseTicket.IssueStatus,
                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,
                };
                var result = Connection.ExecuteReader("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RaiseTicket model = new RaiseTicket();

                        model.SrNo = Convert.ToString(dt.Rows[i]["SrNo"]);
                        if (!(dt.Rows[i]["TicketId"] is DBNull))
                            model.TicketID = Convert.ToInt64(dt.Rows[i]["TicketId"]);
                        model.TicketNumber = Convert.ToString(dt.Rows[i]["TicketNo"]);
                        model.TicketOpenDate = Convert.ToString(dt.Rows[i]["TicketOpenTime"]);
                        model.StateName = Convert.ToString(dt.Rows[i]["State"]);
                        model.DistrictName = Convert.ToString(dt.Rows[i]["District"]);
                        model.ComplainerName = Convert.ToString(dt.Rows[i]["ComplainerName"]);
                        model.ComplainerMobileNumber = Convert.ToString(dt.Rows[i]["ComplainerMobileNo"]);
                        model.ComplainerEmailID = Convert.ToString(dt.Rows[i]["ComplainerEmail"]);
                        model.ComplainerUserName = Convert.ToString(dt.Rows[i]["UserName"]);
                        model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryDetails"]);
                        //model.ProblemDescription = Convert.ToString(dt.Rows[i]["Description"]);
                        model.SolutionDescription = Convert.ToString(dt.Rows[i]["SoutionDescription"]);
                        model.CriticalityName = Convert.ToString(dt.Rows[i]["CriticalityName"]);
                        model.PriorityName = Convert.ToString(dt.Rows[i]["PriorityName"]);
                        model.Status_Details = Convert.ToString(dt.Rows[i]["Status_Detail"]);
                        model.CloseDateTime = Convert.ToString(dt.Rows[i]["CloseDateTime"]);
                        model.DaysTimeTaken = Convert.ToString(dt.Rows[i]["CloseDaysTime"]);
                        model.IssueReportedBy = Convert.ToString(dt.Rows[i]["IssueReportedBy"]);
                        model.designation = Convert.ToString(dt.Rows[i]["Designation"]);
                        model.fromdate = fdate;
                        model.todate = tdate;
                        ListPaymenttypeMaster.Add(model);
                    }
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 25-apr-2021 to getmultiple issue summary table report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public TotalIssueLogModel GetIssuesSummaryTables(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            string fdate = objRaiseTicket.fromdate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.fromdate;
            string tdate = objRaiseTicket.todate == null ? DateTime.Now.ToString("dd/MM/yyyy") : objRaiseTicket.todate;
            try
            {
                TotalIssueLogModel model = new TotalIssueLogModel();
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,
                    IssueStatus = objRaiseTicket.IssueStatus
                };
                var result = Connection.ExecuteReader("uspHelpDeskIssueLogSummary", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds != null && ds.Tables[0] != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[0].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[0].Rows[i]["Total"]);
                            model.ISSUE_STATUS_SUMMARY.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[1].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[1].Rows[i]["Total"]);
                            model.SOFTWARE_ISSUES.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[2].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[2].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[2].Rows[i]["Total"]);
                            model.HARDWARE_ISSUES.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[3].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[3].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[3].Rows[i]["Total"]);
                            model.NETWORK_CALLS.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[4] != null && ds.Tables[4].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[4].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[4].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[4].Rows[i]["Total"]);
                            model.OTHERS.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[5].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[5].Rows[i]["Header"]);
                            childModel.Total = Convert.ToString(ds.Tables[5].Rows[i]["Total"]);
                            model.HDSSummary.Add(childModel);
                        }
                    }
                    if (ds != null && ds.Tables[6] != null && ds.Tables[6].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[6].Rows.Count; i++)
                        {
                            ChildModel childModel = new ChildModel();
                            childModel.Header = Convert.ToString(ds.Tables[6].Rows[i]["Header"]);
                            if (!(ds.Tables[6].Rows[i]["Total"] is DBNull))
                                childModel.Total = Convert.ToString(ds.Tables[6].Rows[i]["Total"]);
                            model.StatusSummary.Add(childModel);
                        }
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 to bind district agnaist userid
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<BackendModel> GetStateDistrictList(BackendModel objRaiseTicket)
        {

            List<BackendModel> ListPaymenttypeMaster = new List<BackendModel>();


            try
            {
                var paramList = new
                {

                };


                var result = Connection.ExecuteReader("GetDistrictDataForUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        BackendModel model = new BackendModel();
                        model.DistrictId = dt.Rows[i]["DistrictID"].ToString();
                        model.Districtname = dt.Rows[i]["DistrictName"].ToString();
                        ListPaymenttypeMaster.Add(model);
                    }
                }
                return ListPaymenttypeMaster;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListPaymenttypeMaster = null;
            }





        }
        /// <summary>
        /// Added by suroj on 22-apr-2021 to get backend data
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public BackendModel GetDataBackend(BackendModel model)
        {
            List<BackendModel> ListPaymenttypeMaster = new List<BackendModel>();
            try
            {
                var paramList = new
                {
                    UserId = model.userid,
                    TicketID = model.TicketID,
                    Check = "GetDataBackend",
                };
                var result = Connection.ExecuteReader("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (ds != null && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                        {
                            model.TicketHistory = ds.Tables[2];
                        }
                        if (!(ds.Tables[0].Rows[0]["SeverityId"] is DBNull))
                            model.SeverityId = Convert.ToInt32(ds.Tables[0].Rows[0]["SeverityId"]);
                        model.ProblemType = Convert.ToString(ds.Tables[0].Rows[0]["ProblemType"]);
                        model.ForwardedName = Convert.ToString(ds.Tables[0].Rows[0]["ApplicantName"]);
                        model.ProblemDescription = "Sir/Madam,";
                    }
                    if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            var empList = ds.Tables[1].AsEnumerable()
                            .Select(dataRow => new Filedetail
                            {
                                FileName = dataRow.Field<string>("FileName"),
                                FilePath = "https://localhost:44361" + @" / HepldeskFile//" + Convert.ToString(ds.Tables[1].Rows[i]["FilePath"])
                            }).ToList();
                            model.attachments = empList;
                        }
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by suroj on 23-apr-2021 for DGM Approval 
        /// </summary>
        /// <param name="objraiseticket"></param>
        /// <returns></returns>
        public int DgmApproval(BackendModel objraiseticket)
        {
            int Response;
            MessageEF objMessage = new MessageEF();
            try
            {
                string ForwardedTo = objraiseticket.ForwardedTo == null ? "" : objraiseticket.ForwardedTo;

                var p = new DynamicParameters();
                p.Add("@TicketId", objraiseticket.TicketID);
                p.Add("@Check", objraiseticket.Action);
                p.Add("@Description", objraiseticket.ProblemDescription);
                p.Add("@UserLoginId", objraiseticket.userid);
                p.Add("@UserId", objraiseticket.userid);
                p.Add("@BackendId", objraiseticket.ForwardedId);
                p.Add("@ForwardedTo", ForwardedTo);
                p.Add("@Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("usphelpdesk_raiseticket", p, commandType: CommandType.StoredProcedure);
                Response = p.Get<int>("Result");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return Response;
        }
        /// <summary>
        /// //Added by suroj on 10-aug-2021 to get compainer details against ticketid
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public RaiseTicket Fetchuserdetailshistory(RaiseTicket model)
        {
            try
            {
                var paramList = new
                {
                    TicketID = model.TicketID,
                    Check = "Fetchcompdtls",
                };
                var result = Connection.ExecuteReader("uspHelpDesk_RaiseTicket", paramList, commandType: System.Data.CommandType.StoredProcedure);
                var ds = ConvertDataReaderToDataSet(result);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (!(ds.Tables[0].Rows[0]["Ticketno"] is DBNull))
                            model.TicketNumber = Convert.ToString(ds.Tables[0].Rows[0]["Ticketno"]);
                        model.ComplainerName = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerName"]);
                        model.ComplainerMobileNumber = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerMobileNo"]);
                        model.ComplainerEmailID = Convert.ToString(ds.Tables[0].Rows[0]["ComplainerEmail"]);
                        model.DistrictName = Convert.ToString(ds.Tables[0].Rows[0]["DISTRICT"]);
                        model.PriorityName = Convert.ToString(ds.Tables[0].Rows[0]["PriorityName"]);
                        model.status = Convert.ToString(ds.Tables[0].Rows[0]["Status_Detail"]);
                        model.Createdon = Convert.ToString(ds.Tables[0].Rows[0]["createdon"]);
                    }
                    if (ds != null && ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                        {
                            var empList = ds.Tables[1].AsEnumerable()
                            .Select(dataRow => new Filedetail
                            {
                                FileName = dataRow.Field<string>("filename"),
                                FilePath = "https://localhost:44361" + @" / HepldeskFile//" + Convert.ToString(ds.Tables[1].Rows[i]["filepath"])
                            }).ToList();
                            model.attachments = empList;
                        }
                    }
                }
                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                model = null;
            }

        }
        #region Added by Lingaraj Dalai
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerName against District,UserType
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserByDistrictAndRoleType(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    DistrictName = objRaiseTicket.DistrictName,
                    UserType = objRaiseTicket.UserType,
                    Check = "GetUserDistrictAndRoleType",
                };
                var result = Connection.Query<RaiseTicket>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by Lingaraj on 17-mar-2022 to bind ComplainerDetails against ApplicantName
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> GetUserDetails(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> ListPaymenttypeMaster = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    ApplicantName = objRaiseTicket.ApplicantName,
                    Check = "GetComplainerDetails",
                };
                var result = Connection.Query<RaiseTicket>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListPaymenttypeMaster = result.ToList();
                }
                return ListPaymenttypeMaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ListPaymenttypeMaster = null;
            }
        }
        /// <summary>
        /// Added by Lingaraj on 25-mar-2022 To View Detail Report
        /// </summary>
        /// <param name="objRaiseTicket"></param>
        /// <returns></returns>
        public List<RaiseTicket> getDetaildata(RaiseTicket objRaiseTicket)
        {
            List<RaiseTicket> list = new List<RaiseTicket>();
            try
            {
                var paramList = new
                {
                    UserId = objRaiseTicket.Userid,
                    ItemId= objRaiseTicket.ItemID,
                    Days = objRaiseTicket.DaysTimeTaken,
                    FromDate = objRaiseTicket.fromdate,
                    ToDate = objRaiseTicket.todate,
                };
                var result = Connection.ExecuteReader("uspGetHelpdeskTicketDetailReport", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataTable dt = new DataTable();
                dt.Load(result);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        RaiseTicket model = new RaiseTicket();
                        model.SrNo = Convert.ToString(dt.Rows[i]["SrNo"]);
                        if (!(dt.Rows[i]["TicketId"] is DBNull))
                            model.TicketID = Convert.ToInt64(dt.Rows[i]["TicketId"]);
                        model.TicketNumber = Convert.ToString(dt.Rows[i]["TicketNo"]);
                        model.TicketOpenDate = Convert.ToString(dt.Rows[i]["TicketOpenTime"]);
                        model.StateName = Convert.ToString(dt.Rows[i]["State"]);
                        model.DistrictName = Convert.ToString(dt.Rows[i]["District"]);
                        model.ComplainerName = Convert.ToString(dt.Rows[i]["ComplainerName"]);
                        model.ComplainerMobileNumber = Convert.ToString(dt.Rows[i]["ComplainerMobileNo"]);
                        model.ComplainerEmailID = Convert.ToString(dt.Rows[i]["ComplainerEmail"]);
                        model.ComplainerUserName = Convert.ToString(dt.Rows[i]["UserName"]);
                        model.CategoryName = Convert.ToString(dt.Rows[i]["CategoryDetails"]);
                        model.ProblemDescription = Convert.ToString(dt.Rows[i]["Description"]);
                        model.SolutionDescription = Convert.ToString(dt.Rows[i]["SoutionDescription"]);
                        model.CriticalityName = Convert.ToString(dt.Rows[i]["CriticalityName"]);
                        model.PriorityName = Convert.ToString(dt.Rows[i]["PriorityName"]);
                        model.Status_Details = Convert.ToString(dt.Rows[i]["Status_Detail"]);
                        model.CloseDateTime = Convert.ToString(dt.Rows[i]["CloseDateTime"]);
                        model.DaysTimeTaken = Convert.ToString(dt.Rows[i]["CloseDaysTime"]);
                        model.IssueReportedBy = Convert.ToString(dt.Rows[i]["IssueReportedBy"]);
                        model.designation = Convert.ToString(dt.Rows[i]["Designation"]);
                        list.Add(model);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                list = null;
            }
        }
        #endregion
    }
}