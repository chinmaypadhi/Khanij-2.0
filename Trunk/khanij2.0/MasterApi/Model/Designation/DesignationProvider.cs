// ***********************************************************************
//  Class Name               : DesignationProvider
//  Description              : Add,View,Edit,Update,Delete Designation details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Designation
{
    public class DesignationProvider : RepositoryBase, IDesignationProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="designationProvider"></param>
        public DesignationProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {
                
        }
        /// <summary>
        /// Add Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddDesignation(RoleListModel roleListModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@operation",1);
                p.Add("@roleName", roleListModel.RoleName);
                p.Add("@RoleId",0);
                p.Add("@roleTypeId", roleListModel.RoleTypeId);
                p.Add("@userId", roleListModel.CreatedBy); 
               // p.Add("@IsActive", roleListModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRoleMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// Delete Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteDesignation(RoleListModel roleListModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@RoleId",roleListModel.RoleId,
                        "@operation",3
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspRoleMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("result");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// Edit Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Edit
        public RoleListModel EditDesignation(RoleListModel roleListModel)
        {
           


            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@operation",4);
                param.Add("@RoleId", roleListModel.RoleId);

                var result = Connection.Query<RoleListModel>("uspRoleMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    roleListModel = result.FirstOrDefault();
                }

                return roleListModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                roleListModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateDesignation(RoleListModel roleListModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@roleName", roleListModel.RoleName);
                p.Add("@RoleId", roleListModel.RoleId);
                p.Add("@roleTypeId", roleListModel.RoleTypeId);
                p.Add("@userId", roleListModel.CreatedBy);
               // p.Add("@UserloginId", roleListModel.CreatedBy);
                p.Add("@IsActive", roleListModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRoleMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion
        /// <summary>
        /// View Designation details in view
        /// </summary>
        /// <param name="roleListModel"></param>
        /// <returns></returns>
        #region View
        public List<RoleListModel> ViewDesignation(RoleListModel roleListModel)
        {
            List<RoleListModel> listRoleListModel = new List<RoleListModel>(); 
            try
            { 
                DynamicParameters param = new DynamicParameters();
                param.Add("@operation",4); 
                var result = Connection.Query<RoleListModel>("uspRoleMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure); 
                if (result.Count() > 0)
                { 
                    listRoleListModel = result.ToList();
                } 
                return listRoleListModel; 
            }
            catch (Exception ex)
            { 
                throw ex;
            }
            finally
            { 
                listRoleListModel = null;
            }
        }
        #endregion
    }
}
