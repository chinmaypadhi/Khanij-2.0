// ***********************************************************************
//  Class Name               : ExceptionProvider
//  Desciption               : Exception details class 
//  Created By               : Lingaraj Dalai
//  Created On               : 28 Sept 2021
// ***********************************************************************
using StarratingEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StarratingApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace StarratingApp.Model.ExceptionList
{
    public class ExceptionProvider : IExceptionProvider
    {
        /// <summary>
        /// Global Object & Variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public ExceptionProvider(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind Errorlist details
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
        /// Get LoginUser details in view
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
        /// Get Menulist details in view
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
