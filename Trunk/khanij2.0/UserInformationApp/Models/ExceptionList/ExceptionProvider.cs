

using UserInformationEF;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserInformationApp.Model.ExceptionList
{
    public class ExceptionProvider:IExceptionProvider
    {
        
        public string ErrorList(LogEntry objLogEntry)
        {
            try
            {
              string   s = JsonConvert.DeserializeObject<string>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("ExceptionData/AddException", ""));
                return s;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
        //public UserLoginSession getuserDetail(LoginEF objLogEntry)
        //{
        //    UserLoginSession objlogin = new UserLoginSession();
        //    try
        //    {
        //        objlogin = JsonConvert.DeserializeObject<UserLoginSession>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("ExceptionData/getuserDetail", JsonConvert.SerializeObject(objLogEntry)));
        //        return objlogin;
        //    }
        //    catch (System.Exception ex)
        //    {

        //        throw ex;
        //    }
        //}
        public UserLoginSession LoginUser(LoginEF ObjloginEF)
        {
            UserLoginSession objUserLoginSession = new UserLoginSession();
            try
            {

                objUserLoginSession = JsonConvert.DeserializeObject<UserLoginSession>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("ExceptionData/getuserDetail", JsonConvert.SerializeObject(ObjloginEF)));
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
                objlist = JsonConvert.DeserializeObject<List<MenuEF>>(UserInformationApp.Models.Utility.HttpWebClients.PostRequest("ExceptionData/MenuList", JsonConvert.SerializeObject(objLogEntry)));
                return objlist;
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }
    }
}
