// ***********************************************************************
//  Class Name               : AccessPermission
//  Description              : Access Permission details
//  Created By               : Kumar Jeevanjyoti
//  Created On               : 20 oct 2021
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

namespace MasterApi.Model.AccessPermission
{
    public class AccessPermission: RepositoryBase, IAccessPermission
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public AccessPermission(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Get view
        /// </summary>
        /// <param name="objUserRightsEF"></param>
        /// <returns></returns>
        public List<UserRightsEF> getview(UserRightsEF objUserRightsEF)
        {
            List<UserRightsEF> ListUserRightsEF = new List<UserRightsEF>();
            try
            {
                var paramList = new
                {
                    UserID = objUserRightsEF.UserId,
                    Check= objUserRightsEF.Check
                };
                var result = Connection.Query<UserRightsEF>("GetUserRightsNew", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListUserRightsEF = result.ToList();
                }

                
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ListUserRightsEF;
        }

        /// <summary>
        /// Get Tree view
        /// </summary>
        /// <param name="objTreeMenu"></param>
        /// <returns></returns>
        public List<TreeMenu> getTreeValue(TreeMenu objTreeMenu)
        {
            List<TreeMenu> objListTreeMenu = new List<TreeMenu>();
            try
            {
                var paramList = new
                {
                    UserID = objTreeMenu.userid                   
                };
                var result = Connection.Query<TreeMenu>("uspRoleMenuTreeGenration_Backup", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    objListTreeMenu = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;

                
            }
            return objListTreeMenu;
        }

        /// <summary>
        /// Fill dropdown
        /// </summary>
        /// <param name="objBindfild"></param>
        /// <returns></returns>
        public List<Bindfild> FilldropDown(Bindfild objBindfild)
        {
            List<Bindfild> objListBindfild = new List<Bindfild>();
            try
            {
                var paramList = new
                {
                    CheckSatus = objBindfild.CheckSatus,
                    Paramiterid=objBindfild.Paramiterid
                };
                var result = Connection.Query<Bindfild>("USP_GetRoleTypeList", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    objListBindfild = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;


            }
            return objListBindfild;
        }

        /// <summary>
        /// Bind User Type details in view
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        public List<userRights> BindUserTypeData(userRights objuserRights)
        {
            List<userRights> objListuserRights = new List<userRights>();
            try
            {
                var paramList = new
                {
                    Check = objuserRights.Check,
                    UserTypeId= objuserRights.UserTypeId,
                    UserID= objuserRights.UserID

                };
                var result = Connection.Query<userRights>("GetUserRightsNew", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                objListuserRights = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;


            }
            return objListuserRights;
        }

        /// <summary>
        /// Bind User Data
        /// </summary>
        /// <param name="objuserRights"></param>
        /// <returns></returns>
        public List<userRights> BindUseridData(userRights objuserRights)
        {
            List<userRights> objListuserRights = new List<userRights>();
            try
            {
                var paramList = new
                {
                    chkstatus = objuserRights.Check,                 
                    Userid = objuserRights.UserID

                };
                var result = Connection.Query<userRights>("UspgetRightsByUseridNew", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    objListuserRights = result.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;


            }
            return objListuserRights;
        }

        /// <summary>
        /// Add User Type details
        /// </summary>
        /// <param name="objAcessUserTypeEF"></param>
        /// <returns></returns>
        public MessageEF AddUserType(AcessUserTypeEF objAcessUserTypeEF)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("status","A");
                p.Add("Usertypeid", objAcessUserTypeEF.UserTypeid);
                p.Add("Createdby", 1);
                p.Add("menuid", string.Join(",", objAcessUserTypeEF.Menuid.ToArray()));
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);                
                Connection.Query<int>("uspUserTypeRightsNew_Backup", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

                }
                else
                {
                    objMessage.Satus = "2";
                }
                return objMessage;


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
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("status", "A");
                p.Add("Userid", objAcessUserTypeEF.Userid);
                p.Add("Createdby", 1);
                p.Add("menuid", string.Join(",", objAcessUserTypeEF.Menuid.ToArray()));
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspUserIDRightsNew_Backup", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");
                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else if (response == "2")
                {
                    objMessage.Satus = "3";

                }
                else
                {
                    objMessage.Satus = "2";
                }
                return objMessage;


            }
            catch (Exception ex)
            {

                throw ex;
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
                var paramList = new
                {
                    status = "E",
                    Userid = objAcessUserIdEf.Userid

                };
                var result = Connection.Query<AcessUserIdEf>("uspUserIDRightsNew_Backup", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    objAcessUserIdEf = result.FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;


            }
            return objAcessUserIdEf;
        }

    }
}
