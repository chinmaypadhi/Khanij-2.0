



using EstablishmentApp.Models.Utility;
using EstablishmentEf;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstablishmentApp.Model.ExceptionList
{
    public class ExceptionProvider:IExceptionProvider
    {
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        public ExceptionProvider(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }



        //IHttpWebClients _objHttpWebClients;
        //public ExceptionProvider(IHttpWebClients objHttpWebClients)
        //{
        //    _objHttpWebClients = objHttpWebClients;
        //}
        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
                string s = JsonConvert.DeserializeObject<string>(_objIHttpWebClients.PostRequest("ExceptionData/AddException", JsonConvert.SerializeObject(objLogEntry)));
                //string   s = JsonConvert.DeserializeObject<string>(_objHttpWebClients.PostRequest("ExceptionData/AddException", objLogEntry));
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
                //objUserLoginSession = JsonConvert.DeserializeObject<UserLoginSession>(_objHttpWebClients.PostRequest("ExceptionData/getuserDetail", ObjloginEF));
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
                //objList = JsonConvert.DeserializeObject<List<MenuEF>>(_objHttpWebClients.PostRequest("ExceptionData/MenuList", objmenuonput));
                return objList;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
