// ***********************************************************************
//  Class Name               : LeaseTypeProvider
//  Description              : Add,View,Edit,Update,Delete LeaseType details
//  Created By               : Lingaraj Dalai
//  Created On               : 08 Jan 2021
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

namespace MasterApi.Model.LeaseType
{
    public class LeaseTypeProvider: RepositoryBase, ILeaseTypeProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public LeaseTypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF AddLeaseType(LeaseTypeMaster objLeaseType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LeaseTypeName", objLeaseType.LeaseTypeName);
                p.Add("LeaseTypeCode", objLeaseType.LeaseTypeCode);
                p.Add("CreatedBy", objLeaseType.CreatedBy);
                p.Add("IsActive", objLeaseType.IsActive);
                p.Add("UserLoginId", objLeaseType.UserLoginId);
                p.Add("Chk", 1);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LEASETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
                if (response.ToString() == "1")
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
        /// <summary>
        /// View LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public List<LeaseTypeMaster> ViewLeaseType(LeaseTypeMaster objLeaseType)
        {
            List<LeaseTypeMaster> ListLeaseType = new List<LeaseTypeMaster>();
            try
            {
                var paramList = new
                {
                    LeaseTypeName = objLeaseType.LeaseTypeName,
                    LeaseTypeCode = objLeaseType.LeaseTypeCode,
                    Chk = "5",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<LeaseTypeMaster>("USP_LEASETYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    ListLeaseType = result.ToList();
                }

                return ListLeaseType;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                ListLeaseType = null;
            }



        }
        /// <summary>
        /// Edit LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public LeaseTypeMaster EditLeaseType(LeaseTypeMaster objLeaseType)
        {
            LeaseTypeMaster LobjLeaseType = new LeaseTypeMaster();
            try
            {
                var paramList = new
                {
                    LeaseTypeID = objLeaseType.LeaseTypeId,
                    Chk = "2",

                };
                DynamicParameters param = new DynamicParameters();

                var result = Connection.Query<LeaseTypeMaster>("USP_LEASETYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    LobjLeaseType = result.FirstOrDefault();
                }

                return LobjLeaseType;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                LobjLeaseType = null;
            }
        }
        /// <summary>
        /// Update LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF UpdateLeaseType(LeaseTypeMaster objLeaseType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LeaseTypeName", objLeaseType.LeaseTypeName);
                p.Add("LeaseTypeCode", objLeaseType.LeaseTypeCode);
                p.Add("LeaseTypeID", objLeaseType.LeaseTypeId);
                p.Add("CreatedBy", objLeaseType.CreatedBy);
                p.Add("IsActive", objLeaseType.IsActive);
                p.Add("UserLoginId", objLeaseType.UserLoginId);
                p.Add("Chk", 3);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LEASETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");


                if (response.ToString() == "1")
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
        /// <summary>
        /// Delete LeaseType details in view
        /// </summary>
        /// <param name="objLeaseType"></param>
        /// <returns></returns>
        public MessageEF DeleteLeaseType(LeaseTypeMaster objLeaseType)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("LeaseTypeID", objLeaseType.LeaseTypeId);
                p.Add("CreatedBy", objLeaseType.CreatedBy);
                p.Add("UserLoginId", objLeaseType.UserLoginId);
                p.Add("Chk", 4);
                p.Add("Result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = Connection.Query<string>("USP_LEASETYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int response = p.Get<int>("Result");
               
                if (response.ToString() == "1")
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
    }
}
