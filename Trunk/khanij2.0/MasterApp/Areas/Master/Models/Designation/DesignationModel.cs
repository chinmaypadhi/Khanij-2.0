using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasterEF;
using Newtonsoft.Json;
using MasterApp.Models.Utility;
using Microsoft.Extensions.Options;

namespace MasterApp.Areas.Master.Models.Designation
{
    public class DesignationModel : IDesignationModel
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
        public DesignationModel(IOptions<KeyList> objKeyList, IHttpWebClients objIHttpWebClients)
        {
            _objKeyList = objKeyList;
            _objIHttpWebClients = objIHttpWebClients;
        }
        #region Add
        /// <summary>
        /// Add Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        public MessageEF Add(RoleListModel roleListModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Designation/Add", JsonConvert.SerializeObject(roleListModel)));
                return objMessageEF;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        public MessageEF Delete(RoleListModel roleListModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Designation/Delete", JsonConvert.SerializeObject(roleListModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Edit
        /// <summary>
        /// Edit Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        public RoleListModel Edit(RoleListModel roleListModel)
        {
            try
            {
                roleListModel = JsonConvert.DeserializeObject<RoleListModel>(_objIHttpWebClients.PostRequest("Designation/Edit", JsonConvert.SerializeObject(roleListModel)));
                return roleListModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region Update
        /// <summary>
        /// Update Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        public MessageEF Update(RoleListModel roleListModel)
        {
            try
            {
                MessageEF objMessageEF = new MessageEF();
                objMessageEF = JsonConvert.DeserializeObject<MessageEF>(_objIHttpWebClients.PostRequest("Designation/Update", JsonConvert.SerializeObject(roleListModel)));
                return objMessageEF;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region View
        /// <summary>
        /// Bind Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        public List<RoleListModel> View(RoleListModel roleListModel)
        {
            try
            {
                List<RoleListModel> listRoleListModel = new List<RoleListModel>();
                listRoleListModel = JsonConvert.DeserializeObject<List<RoleListModel>>(_objIHttpWebClients.PostRequest("Designation/ViewDetails", JsonConvert.SerializeObject(roleListModel)));
                return listRoleListModel;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
