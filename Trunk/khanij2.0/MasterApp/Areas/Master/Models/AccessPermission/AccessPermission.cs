using MasterEF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.AccessPermission
{
    public class AccessPermission: IAccessPermission
    {
        /// <summary>
        /// Global Object & variable declaration
        /// </summary>
        public readonly IOptions<KeyList> _objKeyList;
        IHttpWebClients _objIHttpWebClients;
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objKeyList"></param>
        /// <param name="objIHttpWebClients"></param>
        public AccessPermission(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        /// <summary>
        /// Bind view
        /// </summary>
        /// <param name="objUserRightsEF"></param>
        /// <returns></returns>
        public List<UserRightsEF> getview(UserRightsEF objUserRightsEF)
        {
            try
            {
                List<UserRightsEF> objlistUserRightsEF = new List<UserRightsEF>();
                objlistUserRightsEF = JsonConvert.DeserializeObject<List<UserRightsEF>>(_objIHttpWebClients.PostRequest("AccessPermission/getview", JsonConvert.SerializeObject(objUserRightsEF)));
                return objlistUserRightsEF;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Bid Tree value
        /// </summary>
        /// <param name="objTreeMenu"></param>
        /// <returns></returns>
        public List<TreeMenu> getTreeValue(TreeMenu objTreeMenu)
        {
            try
            {
                List<TreeMenu> objListTreeMenu = new List<TreeMenu>();
                objListTreeMenu = JsonConvert.DeserializeObject<List<TreeMenu>>(_objIHttpWebClients.PostRequest("AccessPermission/getTreeValue", JsonConvert.SerializeObject(objTreeMenu)));
                return objListTreeMenu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Fill dropdown
        /// </summary>
        /// <param name="objBindfild"></param>
        /// <returns></returns>
        public List<Bindfild> FilldropDown(Bindfild objBindfild)
        {
            try
            {
                List<Bindfild> objListTreeMenu = new List<Bindfild>();
                objListTreeMenu = JsonConvert.DeserializeObject<List<Bindfild>>(_objIHttpWebClients.PostRequest("AccessPermission/FilldropDown", JsonConvert.SerializeObject(objBindfild)));
                return objListTreeMenu;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind UserTypeData
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        public List<userRights> BindUserTypeData(userRights objuserRights)
        {
            try
            {
                List<userRights> objListuserRights = new List<userRights>();
                objListuserRights = JsonConvert.DeserializeObject<List<userRights>>(_objIHttpWebClients.PostRequest("AccessPermission/BindUserTypeData", JsonConvert.SerializeObject(objuserRights)));
                return objListuserRights;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Add UserTypedata
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        public MessageEF AddUserType(AcessUserTypeEF objAcessUserTypeEF)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AccessPermission/AddUserType", JsonConvert.SerializeObject(objAcessUserTypeEF)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Bind Userid data
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        public List<userRights> BindUseridData(userRights objuserRights)
        {
            try
            {
                List<userRights> objListuserRights = new List<userRights>();
                objListuserRights = JsonConvert.DeserializeObject<List<userRights>>(_objIHttpWebClients.PostRequest("AccessPermission/BindUseridData", JsonConvert.SerializeObject(objuserRights)));
                return objListuserRights;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Add User Id
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        public MessageEF AddUserId(AcessUserIdEf objAcessUserTypeEF)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("AccessPermission/AddUserId", JsonConvert.SerializeObject(objAcessUserTypeEF)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        /// <summary>
        /// Edit User Id
        /// </summary>
        /// <param name="objAcessUserIdEf"></param>
        /// <returns></returns>
        public AcessUserIdEf EditUserId(AcessUserIdEf objAcessUserIdEf)
        {
            try
            {

                objAcessUserIdEf = JsonConvert.DeserializeObject<AcessUserIdEf>(_objIHttpWebClients.PostRequest("AccessPermission/EditUserId", JsonConvert.SerializeObject(objAcessUserIdEf)));
                return objAcessUserIdEf;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
