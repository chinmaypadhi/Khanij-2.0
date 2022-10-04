// ***********************************************************************
// Assembly         : Khanij
// Author           : Kumar jeevan jyoti
// Created          : 28-dec-2020
//

// ***********************************************************************
// <copyright file="CommonExtension.cs" company="CSM technologies">
//     Copyright ©  2020
// </copyright>
// <summary></summary>
// ***********************************************************************
using Dapper;
using HomeApi.ExceptionHandlear;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;



namespace HomeApi.Model.Login
{
    [ServiceFilter(typeof(ExceptionFilterHandlear))]
    public class LoginProvider: RepositoryBase,ILoginProvider
    {
        public readonly IOptions<UserLoginSession> _objUserLoginSessiont;
        public LoginProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public UserLoginSession UserLogin(LoginEF model)
        {           
            UserLoginSession objUserLoginSession = new UserLoginSession();
            try
            {
                var paramList = new
                {
                    UserName = model.UserName,
                    Password = model.Password,
                    LoginUserType = model.UserType,
                    Check = "1",
                    RemoteIp = model.Remoteid,
                    LocalIp = model.Localip,
                    UserAgent = model.Browserinfo
                };


               

                

                var result = Connection.Query<UserLoginSession>("uspValidateUser", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    objUserLoginSession = result.FirstOrDefault();
                }

                return objUserLoginSession;



            }
            catch (Exception  ex)
            {

                throw ex;
            }
            finally
            {
                
                objUserLoginSession = null;
            }



        }
        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            string result="";
            List<MenuEF> objListMenuEF = new List<MenuEF>();
            List<childMenu> objListchildMenu;
            try
            {
                var paramList = new
                {
                    UserID = objmenuonput.UserID,
                    MineralId = objmenuonput.MineralId,
                    MineralName = objmenuonput.MineralName
                };
              IDataReader dr = Connection.ExecuteReader("GetUserWiseMenuDataAfterLogin_New", paramList, commandType: System.Data.CommandType.StoredProcedure);
                DataSet ds = new DataSet();
                ds = ConvertDataReaderToDataSet(dr);
                string menu = "";
                if(ds.Tables[0].Rows.Count>0)
                {
                    foreach(DataRow dro in ds.Tables[0].Rows)
                    {
                        MenuEF objMenuEF = new MenuEF();
                       objMenuEF.MenuId         = int.Parse(dro["MenuId"].ToString());
                       objMenuEF.MenuName       =dro["MenuName"].ToString();
                       objMenuEF.ParentId       =dro["ParentId"].ToString();
                       objMenuEF.Controller     =dro["Controller"].ToString();
                       objMenuEF.url            =dro["url"].ToString();
                       objMenuEF.Area           =dro["Area"].ToString();
                       objMenuEF.ActionName     =dro["ActionName"].ToString();
                       objMenuEF.IsView         =dro["IsView"].ToString();
                       objMenuEF.IsAdd          =dro["IsAdd"].ToString();
                       objMenuEF.IsEdit         =dro["IsEdit"].ToString();
                       objMenuEF.IsDelete       =dro["IsDelete"].ToString();
                       objMenuEF.DisplaySrNo =int.Parse(dro["DisplaySrNo"].ToString());
                       objMenuEF.CssClass       =dro["CssClass"].ToString();
                       objMenuEF.MenuLevel      =dro["MenuLevel"].ToString();
                       objMenuEF.ParentMenuName = dro["ParentMenuName"].ToString();
                        objListchildMenu = new List<childMenu>();
                        foreach (DataRow dro1 in ds.Tables[1].Rows)
                        {
                            if(dro1["ParentId"].ToString()== objMenuEF.MenuId.ToString ())
                            {
                                childMenu objchildMenu = new childMenu();
                                objchildMenu.MenuId         = int.Parse(dro1["MenuId"          ].ToString());
                                objchildMenu.MenuName       =dro1["MenuName"        ].ToString();
                                objchildMenu.ParentId       = int.Parse(dro1["ParentId"        ].ToString());
                                objchildMenu.Controller     =dro1["Controller"      ].ToString();
                                objchildMenu.url            =dro1["url"             ].ToString();
                                objchildMenu.Area           =dro1["Area"            ].ToString();
                                objchildMenu.ActionName     =dro1["ActionName"      ].ToString();
                                objchildMenu.IsView         =dro1["IsView"          ].ToString();
                                objchildMenu.IsAdd          =dro1["IsAdd"           ].ToString();
                                objchildMenu.IsEdit         =dro1["IsEdit"          ].ToString();
                                objchildMenu.IsDelete       =dro1["IsDelete"        ].ToString();
                                objchildMenu.DisplaySrNo    =dro1["DisplaySrNo"     ].ToString();
                                objchildMenu.CssClass       =dro1["CssClass"        ].ToString();
                                objchildMenu.MenuLevel      =dro1["MenuLevel"       ].ToString();
                                objchildMenu.ParentMenuName = dro1["ParentMenuName"].ToString();
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
