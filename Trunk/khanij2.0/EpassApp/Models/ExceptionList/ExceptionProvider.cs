


using EpassEF;
using EpassApp.Models.Utility;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApp.Model.ExceptionList
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
              string   s = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("ExceptionData/AddException", JsonConvert.SerializeObject(objLogEntry)));
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
        public List<MenuEF> MenuList(menuonput objLogEntry)
        {
            List<MenuEF> objlist = new List<MenuEF>();
            try
            {
                objlist = JsonConvert.DeserializeObject<List<MenuEF>>(_objIHttpWebClients.PostRequest("ExceptionData/MenuList", JsonConvert.SerializeObject(objLogEntry)));
                return objlist;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
