// ***********************************************************************
//  Class Name               : ExceptionProvider
//  Desciption               : Exception
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2021
// ***********************************************************************
using IntegrationApp.Models.Utility;
using IntegrationEF;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationApp.Model.ExceptionList
{
    public class ExceptionProvider:IExceptionProvider
    { 
        IHttpWebClients _objIHttpWebClients;
        public ExceptionProvider(IHttpWebClients objIHttpWebClients)
        { 
            _objIHttpWebClients = objIHttpWebClients;
        }

        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
                string s = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("ExceptionData/AddException", JsonConvert.SerializeObject(objLogEntry)));
                return s;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }

        public UserLoginSession LoginUser(LoginEF ObjloginEF)
        {
            UserLoginSession objUserLoginSession = new UserLoginSession();
            try
            {

                objUserLoginSession = JsonConvert.DeserializeObject<UserLoginSession>(_objIHttpWebClients.PostRequest("ExceptionData/getuserDetail", JsonConvert.SerializeObject(ObjloginEF)));
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

        public List<MenuEF> MenuList(menuonput objmenuonput)
        {
            List<MenuEF> objList = new List<MenuEF>();
            try
            {
                objList = JsonConvert.DeserializeObject<List<MenuEF>>(_objIHttpWebClients.PostRequest("ExceptionData/MenuList", JsonConvert.SerializeObject(objmenuonput)));

                return objList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
