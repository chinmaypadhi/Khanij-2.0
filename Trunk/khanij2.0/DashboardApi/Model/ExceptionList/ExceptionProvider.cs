// ***********************************************************************
//  Class Name               : ExceptionProvider
//  Desciption               : Exception Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 04 Feb 2022
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using DashboardApi.Factory;
using DashboardApi.Repository;
using DashboardEF;

namespace DashboardApi.Model.ExceptionList
{
    public class ExceptionProvider: RepositoryBase,IExceptionProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public ExceptionProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Bind Error list details
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
                var paramList = new
                {
                    Controller = objLogEntry.Controller,
                    Action = objLogEntry.Action,
                    ReturnType = objLogEntry.ReturnType,
                    ErrorMessage = objLogEntry.ErrorMessage,
                    StackTrace = objLogEntry.StackTrace,
                    UserId = objLogEntry.UserID,
                    UserLoginID = objLogEntry.UserLoginID
                };
                var result = Connection.Execute("ReportErrorLog", paramList, commandType: System.Data.CommandType.StoredProcedure);
                return "1";
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get user list details
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public UserLoginSession getuserDetail(LoginEF model)
        {
            UserLoginSession objUserLoginSession = new UserLoginSession();
            try
            {
                var paramList = new
                {
                    UserId = model.UserID,
                    UserName = model.UserName,
                    Check = "1",
                };
                var result = Connection.Query<UserLoginSession>("uspUserdata", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objUserLoginSession = result.FirstOrDefault();
                }
                return objUserLoginSession;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objUserLoginSession = null;
            }
        }
        /// <summary>
        /// Get Menu list details
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            string result = "";
            List<MenuEF> objListMenuEF = new List<MenuEF>();
            List<childMenu> objListchildMenu;
            try
            {
                var paramList = new
                {
                    UserID = objmenuonput.UserID,
                    MineralId = objmenuonput.MineralId,
                    MineralName = objmenuonput.MineralName,
                    MMenuId = objmenuonput.MMenuId
                };
                IDataReader dr = Connection.ExecuteReader("GetUserWiseMenuDataAfterLogin_New_backup", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                string menu = "";
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dro in ds.Tables[0].Rows)
                    {
                        MenuEF objMenuEF = new MenuEF();
                        objMenuEF.MenuId = int.Parse(dro["MenuId"].ToString());
                        objMenuEF.MenuName = dro["MenuName"].ToString();
                        objMenuEF.ParentId = dro["ParentId"].ToString();
                        objMenuEF.Controller = dro["Controller"].ToString();
                        objMenuEF.url = dro["url"].ToString();
                        objMenuEF.Area = dro["Area"].ToString();
                        objMenuEF.ActionName = dro["ActionName"].ToString();
                        objMenuEF.IsView = dro["IsView"].ToString();
                        objMenuEF.IsAdd = dro["IsAdd"].ToString();
                        objMenuEF.IsEdit = dro["IsEdit"].ToString();
                        objMenuEF.IsDelete = dro["IsDelete"].ToString();
                        objMenuEF.DisplaySrNo = int.Parse(dro["DisplaySrNo"].ToString());
                        objMenuEF.CssClass = dro["CssClass"].ToString();
                        objMenuEF.MenuLevel = dro["MenuLevel"].ToString();
                        objMenuEF.ParentMenuName = dro["ParentMenuName"].ToString();
                        objMenuEF.GifIcon = dro["GifIcon"].ToString();
                        objMenuEF.LinkPath = dro["LinkPath"].ToString();
                        objMenuEF.SvgPath = dro["SvgPath"].ToString();
                        objMenuEF.divclass = dro["divclass"].ToString();
                        objListchildMenu = new List<childMenu>();
                        foreach (DataRow dro1 in ds.Tables[1].Rows)
                        {
                            if (dro1["ParentId"].ToString() == objMenuEF.MenuId.ToString())
                            {
                                childMenu objchildMenu = new childMenu();
                                objchildMenu.MenuId = int.Parse(dro1["MenuId"].ToString());
                                objchildMenu.MenuName = dro1["MenuName"].ToString();
                                objchildMenu.ParentId = int.Parse(dro1["ParentId"].ToString());
                                objchildMenu.Controller = dro1["Controller"].ToString();
                                objchildMenu.url = dro1["url"].ToString();
                                objchildMenu.Area = dro1["Area"].ToString();
                                objchildMenu.ActionName = dro1["ActionName"].ToString();
                                objchildMenu.IsView = dro1["IsView"].ToString();
                                objchildMenu.IsAdd = dro1["IsAdd"].ToString();
                                objchildMenu.IsEdit = dro1["IsEdit"].ToString();
                                objchildMenu.IsDelete = dro1["IsDelete"].ToString();
                                objchildMenu.DisplaySrNo = dro1["DisplaySrNo"].ToString();
                                objchildMenu.CssClass = dro1["CssClass"].ToString();
                                objchildMenu.MenuLevel = dro1["MenuLevel"].ToString();
                                objchildMenu.ParentMenuName = dro1["ParentMenuName"].ToString();
                                objchildMenu.GifIcon = dro1["GifIcon"].ToString();
                                objListchildMenu.Add(objchildMenu);
                            }
                        }
                        objMenuEF.childMenuList = objListchildMenu;

                        objListMenuEF.Add(objMenuEF);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objListMenuEF;
        }
        /// <summary>
        /// Method Convert datareader to dataset
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
    }
}
