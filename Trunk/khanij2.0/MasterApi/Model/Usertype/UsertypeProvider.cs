// ***********************************************************************
//  Class Name               : UsertypeProvider
//  Description              : Add,View,Edit,Update,Delete Usertype Master details
//  Created By               : Lingaraj Dalai
//  Created On               : 25 Dec 2021
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

namespace MasterApi.Model.Usertype
{
    public class UsertypeProvider: RepositoryBase, IUsertypeProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public UsertypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddUsertypemaster(UsertypeMaster objUsertypeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_USERTYPE_NAME", objUsertypeMaster.Usertype);
                p.Add("P_INT_USER_ID", objUsertypeMaster.UserID);
                p.Add("P_BIT_ACTIVE", objUsertypeMaster.IsActive);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_USERTYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Edit Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public async Task<List<UsertypeMaster>> ViewUsertypeMaster(UsertypeMaster objUsertypeMaster)
        {
            List<UsertypeMaster> ListChecklistmaster = new List<UsertypeMaster>();
            try
            {
                var paramList = new
                {
                    P_INT_USERTYPE_ID = objUsertypeMaster.UsertypeId,
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<UsertypeMaster>("USP_USERTYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ListChecklistmaster = result.ToList();
                }
                return ListChecklistmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// View Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public async Task<UsertypeMaster> EditUsertypeMaster(UsertypeMaster objUsertypeMaster)
        {
            UsertypeMaster LobjChecklistmaster = new UsertypeMaster();
            try
            {
                var paramList = new
                {
                    P_INT_USERTYPE_ID = objUsertypeMaster.UsertypeId,
                    P_VCH_ACTION = "SELECT",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<UsertypeMaster>("USP_USERTYPE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    LobjChecklistmaster = result.FirstOrDefault();
                }
                return LobjChecklistmaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteUsertypeMaster(UsertypeMaster objUsertypeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_USERTYPE_ID", objUsertypeMaster.UsertypeId);
                p.Add("P_INT_USER_ID", objUsertypeMaster.UserID);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<int>("USP_USERTYPE_MASTER", p, commandType: System.Data.CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// Update Usertype details in view
        /// </summary>
        /// <param name="objUsertypeMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateUsertypeMaster(UsertypeMaster objUsertypeMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_USERTYPE_ID", objUsertypeMaster.UsertypeId);
                p.Add("P_VCH_USERTYPE_NAME", objUsertypeMaster.Usertype);
                p.Add("P_INT_USER_ID", objUsertypeMaster.UserID);
                p.Add("P_BIT_ACTIVE", objUsertypeMaster.IsActive);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_USERTYPE_MASTER", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
    }
}
