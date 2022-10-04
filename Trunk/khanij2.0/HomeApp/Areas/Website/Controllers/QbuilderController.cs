// ***********************************************************************
//  Controller Name          : QbuilderController
//  Desciption               : Execute Query Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using Microsoft.AspNetCore.Mvc;
using HomeEF;
using HomeApp.Areas.Website.Models.Qbuilder;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Data.SqlClient;
using System.Data;
using HomeApp.Web;
using System.Collections.Generic;
using Nancy.Json;

namespace HomeApp.Areas.Website.Controllers
{
    [Area("Website")]
    public class QbuilderController : Controller
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        private readonly IHostingEnvironment hostingEnvironment;
        IQbuilderModel _objIQbuilderModel;
        MessageEF objobjmodel = new MessageEF();
        QuerybuilderModel objmodel = new QuerybuilderModel();
        DataSet dsQuery = new DataSet();
        string Query = string.Empty;
        string JSONresult = string.Empty;
        int result = 0;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objNotificationModel"></param>
        public QbuilderController(IQbuilderModel objIQbuilderModel, IHostingEnvironment hostingEnvironment)
        {
            _objIQbuilderModel = objIQbuilderModel;
            this.hostingEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// HTTP Get method
        /// </summary>
        /// <returns></returns>
        public IActionResult ExecuteQuery()
        {
            return View();
        }
        /// <summary>
        /// Execute Query
        /// </summary>
        /// <param name="qry"></param>
        /// <param name="qrytype"></param>
        /// <param name="Payid"></param>
        /// <returns></returns>
        public JsonResult GetData(string qry, string qrytype, string Payid)
        {
            try
            {
                UserLoginSession profile = HttpContext.Session.Get<UserLoginSession>(KeyHelper.UserKey);
                if (string.IsNullOrEmpty(qry) == false && !string.IsNullOrEmpty(Payid))
                {
                    #region oldcode
                    //try
                    //{
                    //    objmodel.VCH_UPWD = Payid;
                    //    objmodel.VCH_QUERY_TEXT = qry;
                    //    objmodel.VCH_QUERY_TYPE = qrytype;
                    //    objmodel.INT_USERID = profile.UserId;
                    //    objmodel.INT_USER_LOGINID = profile.UserLoginId;
                    //    ds = _objIQbuilderModel.ExecuteQuery(objmodel);
                    //    if (qry.ToUpper().Contains("DROP") || qry.ToUpper().Contains("TRUNCATE"))
                    //    {
                    //        JSONresult = "Restricted Command !!";
                    //    }
                    //    else if (ds.Tables.Count > 0)
                    //    {
                    //        #region View Query
                    //        if (qrytype == "Select")
                    //        {
                    //            for (int ftbl = 0; ftbl < ds.Tables.Count; ftbl++)
                    //            {
                    //                int cou = ds.Tables[ftbl].Columns.Count;
                    //                if (ds.Tables[ftbl].Columns.Count > 0)
                    //                {
                    //                    if (Convert.ToString(ds.Tables[ftbl].Columns[0].ColumnName) != "rowsAffected")
                    //                    {
                    //                        if (qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                        {
                    //                            //strtbl = strtbl + "<div id='tbl_" + ftbl + "' style='overflow-y: auto;overflow-x: scroll;margin-bottom:10px;'> <table class='table table-hover'  id='tbl_" + ftbl + "'>";
                    //                            strtbl = strtbl + "<div id='viewtable'> <table id='datatable' class='table table-sm table-bordered'>";
                    //                        }
                    //                        else
                    //                        {
                    //                            strtbl = strtbl + "<div id='viewtable'> <table id='datatable' class='table table-sm table-bordered'>";
                    //                        }
                    //                        strtbl = strtbl + "<thead>";
                    //                        strtbl = strtbl + "<tr>";
                    //                        if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                        {
                    //                            strtbl = strtbl + "<th>Sr.No.</th>";
                    //                        }
                    //                        for (int i = 0; i < ds.Tables[ftbl].Columns.Count; i++)
                    //                        {
                    //                            strtbl = strtbl + "<th>" + ds.Tables[ftbl].Columns[i].ColumnName.ToString() + "</th>";
                    //                        }
                    //                        strtbl = strtbl + "</tr>";
                    //                        strtbl = strtbl + "</thead>";
                    //                        strtbl = strtbl + "<tbody>";
                    //                        int inc = 1;
                    //                        foreach (DataRow row in ds.Tables[ftbl].Rows)
                    //                        {
                    //                            strtbl = strtbl + "<tr>";
                    //                            if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                            {
                    //                                strtbl = strtbl + "<td>" + inc++ + "</td>";
                    //                            }
                    //                            foreach (DataColumn column in ds.Tables[ftbl].Columns)
                    //                            {
                    //                                if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                                {
                    //                                    strtbl = strtbl + "<td>" + row[column].ToString() + "</td>";
                    //                                }
                    //                                else
                    //                                {
                    //                                    strtbl = strtbl + row[column].ToString();
                    //                                }
                    //                            }
                    //                            if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                            {
                    //                                strtbl = strtbl + "</tr>";
                    //                            }
                    //                        }
                    //                        if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                        {
                    //                            strtbl = strtbl + "</tbody>";
                    //                            strtbl = strtbl + "</table> </div>";
                    //                        }
                    //                    }
                    //                }
                    //                else
                    //                {
                    //                    if (qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                    {
                    //                        //strtbl = strtbl + "<div id='tbl_" + ftbl + "' style='overflow-y: auto;overflow-x: scroll;margin-bottom:10px;'> <table class='table table-hover'  id='tbl_" + ftbl + "'>";
                    //                        strtbl = strtbl + "<div id='viewtable'> <table id='datatable' class='table table-sm table-bordered'>";
                    //                    }
                    //                    else
                    //                    {
                    //                        strtbl = strtbl + "<div id='viewtable'> <table id='datatable' class='table table-sm table-bordered'>";
                    //                    }
                    //                    strtbl = strtbl + "<thead>";
                    //                    strtbl = strtbl + "<tr>";
                    //                    if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                    {
                    //                        strtbl = strtbl + "<th>Sr.No.</th>";
                    //                    }
                    //                    for (int i = 0; i < ds.Tables[ftbl].Columns.Count; i++)
                    //                    {
                    //                        strtbl = strtbl + "<th>" + ds.Tables[ftbl].Columns[i].ColumnName.ToString() + "</th>";
                    //                    }
                    //                    strtbl = strtbl + "</tr>";
                    //                    strtbl = strtbl + "</thead>";
                    //                    strtbl = strtbl + "<tbody>";
                    //                    strtbl = strtbl + "<tr>";
                    //                    if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                    {
                    //                        strtbl = strtbl + "</tr>";
                    //                    }
                    //                    if (!qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                    {
                    //                        strtbl = strtbl + "</tbody>";
                    //                        strtbl = strtbl + "</table> </div>";
                    //                    }
                    //                }
                    //            }
                    //            JSONresult = strtbl;
                    //        }
                    //        #endregion
                    //        #region Update,Delete Query
                    //        else if (qrytype == "Update")
                    //        {
                    //            string mRowUpdate = "0";
                    //            try
                    //            {
                    //                if (qry.ToUpper().Contains("SP_HELPTEXT"))
                    //                {
                    //                    mRowUpdate = ds.Tables[1].Rows[0][0].ToString();
                    //                }
                    //                else
                    //                {
                    //                    mRowUpdate = ds.Tables[0].Rows[0][0].ToString();
                    //                }
                    //                if (mRowUpdate == "-1")
                    //                {
                    //                    mRowUpdate = "0";
                    //                }
                    //                strtbl = "<b>" + mRowUpdate + " rows affected" + "</b>";
                    //                JSONresult = strtbl;
                    //            }
                    //            catch (Exception ex)
                    //            {
                    //                strtbl = "Row updated : false" + ex.ToString() + "<br/>" + ex.Message + "<br/>" + ex.Data;
                    //            }
                    //        }
                    //        #endregion
                    //    }
                    //    else
                    //    {
                    //        JSONresult = "Please enter Valid Password !!";
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    JSONresult = "<u><b>Message</b></u> : " + ex.Message + "</br>" + "</br>" + "<u><b>Exception</b></u> : " + ex.ToString() + "</br>" + "</br>" + "<u>Data</u> : " + ex.Data;
                    //}
                    //finally
                    //{
                    //    ds = null;
                    //}
                    #endregion
                    objmodel.VCH_UPWD = Payid;
                    objmodel.VCH_QUERY_TEXT = qry;
                    if (qry.ToUpper().Contains("ALTER PROCEDURE") || qry.ToUpper().Contains("CREATE PROCEDURE"))
                    {
                        qrytype = "1";
                    }
                    objmodel.VCH_QUERY_TYPE = qrytype;
                    objmodel.INT_USERID = profile.UserId;
                    objmodel.INT_USER_LOGINID = profile.UserLoginId;
                    dsQuery = _objIQbuilderModel.ExecuteQuery(objmodel);
                    Query = DataSetToJSONWithJavaScriptSerializer(dsQuery);
                    if (qrytype == "1")
                    {                       
                        if (dsQuery.Tables[0].Rows.Count > 0)
                        {
                            if (dsQuery.Tables[0].Rows[0][0].ToString() == "2")
                            {
                                Query = "2";
                            }
                        }
                        else if (qry.ToUpper().Contains("ALTER PROCEDURE") || qry.ToUpper().Contains("CREATE PROCEDURE"))
                        {
                            Query = "Executed Successfully";
                        }
                        else
                        {
                            Query = "No rows found!";
                        }
                        return Json(Query);
                    }
                    else
                    {
                        if (Query.Contains("2"))
                        {
                            result = 2;
                        }
                        else
                        {
                            result = _objIQbuilderModel.Queryinsert(objmodel);
                        }
                        return Json(result);
                    }
                }
                else
                {
                    JSONresult = "Please Enter Query !!";
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            finally
            {
                objmodel = null;
            }
            return Json(JSONresult);
        }
        /// <summary>
        /// Method to convert Dataset to Json string with Javascriptserializer
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public string DataSetToJSONWithJavaScriptSerializer(DataSet ds)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataTable table in ds.Tables)
            {
                foreach (DataRow row in table.Rows)
                {
                    childRow = new Dictionary<string, object>();
                    foreach (DataColumn col in table.Columns)
                    {
                        childRow.Add(col.ColumnName, row[col]);
                    }
                    parentRow.Add(childRow);
                }
            }
            return jsSerializer.Serialize(parentRow);
        }
    }
}
