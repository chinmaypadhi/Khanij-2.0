// ***********************************************************************
//  Class Name               : ExceptionProvider
//  Desciption               : Exception
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Dec 2021
// ***********************************************************************
using GeologyEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeologyApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace GeologyApp.Model.ExceptionList
{
    public class ExceptionProvider:IExceptionProvider
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objIHttpWebClients"></param>
        public ExceptionProvider(IHttpWebClients objIHttpWebClients)
        {
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Submit Error list details in view
        /// </summary>
        /// <param name="objLogEntry"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Login User details
        /// </summary>
        /// <param name="ObjloginEF"></param>
        /// <returns></returns>
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
        /// <summary>
        /// Bind Menu list details in view
        /// </summary>
        /// <param name="objmenuonput"></param>
        /// <returns></returns>
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
