using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Department
{
    public class DepartmentMasterModel : IDepartmentMasterModel
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
        public DepartmentMasterModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        public MessageEF Add(RoleTypeModel roleTypeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Department/Add", JsonConvert.SerializeObject(roleTypeModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        public MessageEF Delete(RoleTypeModel roleTypeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Department/Delete", JsonConvert.SerializeObject(roleTypeModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        public RoleTypeModel Edit(RoleTypeModel roleTypeModel)
        {
            try
            {
                roleTypeModel = JsonConvert.DeserializeObject<RoleTypeModel>(_objIHttpWebClients.PostRequest("Department/Edit", JsonConvert.SerializeObject(roleTypeModel)));
                return roleTypeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        public MessageEF Update(RoleTypeModel roleTypeModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Department" +
                    "/Update", JsonConvert.SerializeObject(roleTypeModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        public List<RoleTypeModel> View(RoleTypeModel roleTypeModel)
        {
            try
            {
                List<RoleTypeModel> listRoleTypeModel = new List<RoleTypeModel>();
                listRoleTypeModel = JsonConvert.DeserializeObject<List<RoleTypeModel>>(_objIHttpWebClients.PostRequest("Department/ViewDetails", JsonConvert.SerializeObject(roleTypeModel)));
                return listRoleTypeModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
