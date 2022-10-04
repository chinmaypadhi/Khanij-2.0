// ***********************************************************************
//  Class Name               : ChangeStatusProvider
//  Description              : Add,View,Edit,Update,Delete Change Status details
//  Created By               : Lingaraj Dalai
//  Created On               : 29 Jan 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MasterApi.Model.ChangeStatus
{
    public class ChangeStatusProvider : RepositoryBase, IChangeStatusProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ChangeStatusProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Change Status details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public MessageEF AddChangeStatusmaster(ChangeStatusmaster objChangeStatusmaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("@RegionalId", objChangeStatusmaster.RegionalID);
                p.Add("@DistrictId", objChangeStatusmaster.DistrictID);
                p.Add("@UserType", objChangeStatusmaster.UserType);
                p.Add("@UserId", objChangeStatusmaster.UserId);
                p.Add("@NewStatusId", objChangeStatusmaster.ID);
                p.Add("@UserLoginId", objChangeStatusmaster.UserLoginId);
                p.Add("@CreatedBy", objChangeStatusmaster.UserId);
                p.Add("@Remarks", objChangeStatusmaster.Remarks);
                p.Add("@FileName", objChangeStatusmaster.Document_Name);
                p.Add("@FilePath", objChangeStatusmaster.Document_Path);
                p.Add("@chk", 1);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("StatusHistoryOperation", p, commandType: CommandType.StoredProcedure);
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
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Bind Division details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetDivisionList(ChangeStatusmaster objChangeStatusmaster)
        {
            List<ChangeStatusmaster> ObjDivisionList = new List<ChangeStatusmaster>();
            try
            {
                var paramList = new
                {

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ChangeStatusmaster>("spGetDivisionData", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjDivisionList = result.ToList();
                }

                return ObjDivisionList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind User Type list details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetUserTypeList(ChangeStatusmaster objChangeStatusmaster)
        {
            List<ChangeStatusmaster> ObjUserTypeList = new List<ChangeStatusmaster>();
            try
            {
                var paramList = new
                {

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ChangeStatusmaster>("uspGetLesseeLicenseeType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjUserTypeList = result.ToList();
                }

                return ObjUserTypeList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind District details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetDistrictList(ChangeStatusmaster objChangeStatusmaster)
        {
            List<ChangeStatusmaster> ObjDistrictList = new List<ChangeStatusmaster>();
            try
            {
                var paramList = new
                {
                    chk = "6",
                    RegionalID = objChangeStatusmaster.RegionalID
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ChangeStatusmaster>("StatusHistoryOperation", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjDistrictList = result.ToList();
                }

                return ObjDistrictList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind User Name List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetUserNameList(ChangeStatusmaster objChangeStatusmaster)
        {
            List<ChangeStatusmaster> ObjUserNameList = new List<ChangeStatusmaster>();
            try
            {
                var paramList = new
                {
                    DistirctId = objChangeStatusmaster.DistirctId,
                    RoleType = objChangeStatusmaster.RoleType
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ChangeStatusmaster>("uspGetUserByDistrictAndRoleType", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjUserNameList = result.ToList();
                }

                return ObjUserNameList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Change Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public List<ChangeStatusmaster> GetChangeStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            List<ChangeStatusmaster> ObjChangeStatusList = new List<ChangeStatusmaster>();
            try
            {
                var paramList = new
                {
                    UserType = objChangeStatusmaster.UserType
                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<ChangeStatusmaster>("uspGetStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ObjChangeStatusList = result.ToList();
                }

                return ObjChangeStatusList;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Bind Current Status List details in view
        /// </summary>
        /// <param name="objChangeStatusmaster"></param>
        /// <returns></returns>
        public ChangeStatusmaster GetCurrentStatusList(ChangeStatusmaster objChangeStatusmaster)
        {
            ChangeStatusmaster ObjChangeStatus = new ChangeStatusmaster();
            try
            {
                var paramList = new
                {
                    UserId = objChangeStatusmaster.UserId
                };
                DynamicParameters param = new DynamicParameters();

                var Output = Connection.Query<ChangeStatusmaster>("uspGetCurrentStatus", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (Output.Count() > 0)
                {
                    ObjChangeStatus = Output.FirstOrDefault();
                }
                return ObjChangeStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ObjChangeStatus = null;
            }
        }
    }
}
