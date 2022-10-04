// ***********************************************************************
//  Class Name               : DepartmentProvider
//  Description              : Add,View,Edit,Update,Delete Department details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;

namespace MasterApi.Model.Department
{
    public class DepartmentProvider : RepositoryBase, IDepartmentProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="objICompanyProvider"></param>
        public DepartmentProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Add 
        public MessageEF AddDepartment(RoleTypeModel objRoleTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                
                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@roleTypeName", objRoleTypeModel.RoleTypeName);
                p.Add("@UserTypeId", objRoleTypeModel.UserTypeId);
                p.Add("@roleTypeId", 0);
                p.Add("@userId", objRoleTypeModel.CreatedBy);
                p.Add("@UserloginId", objRoleTypeModel.CreatedBy);
                p.Add("@IsActive", objRoleTypeModel.IsActive==null?true: objRoleTypeModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRoleTypeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteDepartment(RoleTypeModel roleTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            { 
                object[] objArray = new object[] {
                        "@roleTypeId",roleTypeModel.RoleTypeId,
                        "@operation",3,
                        "@userId",roleTypeModel.CreatedBy,
                        "@userLoginId",roleTypeModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspRoleTypeMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Edit
        public RoleTypeModel EditDepartment(RoleTypeModel roleTypeModel)
        {
            //RoleTypeModel objroleTypeModel = new RoleTypeModel();


            try
            {
                
                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@roleTypeId", roleTypeModel.RoleTypeId);

                var result = Connection.Query<RoleTypeModel>("uspRoleTypeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    roleTypeModel = result.FirstOrDefault();
                }

                return roleTypeModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                roleTypeModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateDespartment(RoleTypeModel roleTypeModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {


                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@roleTypeName", roleTypeModel.RoleTypeName);
                p.Add("@UserTypeId", roleTypeModel.UserTypeId);
                p.Add("@roleTypeId", roleTypeModel.RoleTypeId);
                p.Add("@userId", roleTypeModel.CreatedBy);
                p.Add("@UserloginId", roleTypeModel.CreatedBy);
                p.Add("@IsActive", roleTypeModel.IsActive==null?true : roleTypeModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRoleTypeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// View Department details in view
        /// </summary>
        /// <param name="roleTypeModel"></param>
        /// <returns></returns>
        #region View
        public List<RoleTypeModel> ViewDepartment(RoleTypeModel roleTypeModel)
        {
            List<RoleTypeModel> listRoleTypeModel = new List<RoleTypeModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);

                var result = Connection.Query<RoleTypeModel>("uspRoleTypeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listRoleTypeModel = result.ToList();
                }

                return listRoleTypeModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listRoleTypeModel = null;
            }
        }
        #endregion
    }
}
