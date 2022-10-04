
// ***********************************************************************
//  Class Name               : ModuleProvider
//  Description              : Add,View,Edit,Update,Delete Module Master details
//  Created By               : Prakash Chandra Biswal
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

namespace MasterApi.Model.Module
{
    public class ModuleProvider : RepositoryBase, IModuleProvider
    {
        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="connectionFactory"></param>
        public ModuleProvider(IConnectionFactory connectionFactory): base(connectionFactory)
        {

        }
        /// <summary>
        /// To add a Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddModule(ModuleMasterModel moduleMasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_MODULE_NAME", moduleMasterModel.ModuleName);
                p.Add("P_INT_USER_ID", moduleMasterModel.UserID);
                p.Add("P_BIT_IS_ACTIVE", moduleMasterModel.IsActive);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_MODULE_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// To Delete a Module Name
        /// </summary>
        /// <param name="ModuleMasterModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteModule(ModuleMasterModel ModuleMasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_MODULE_ID", ModuleMasterModel.ModuleId);
                p.Add("P_INT_USER_ID", ModuleMasterModel.UserID);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<int>("USP_MODULE_MASTER", p, commandType: System.Data.CommandType.StoredProcedure);
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
        /// To Edit a Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public async Task<ModuleMasterModel> EditModule(ModuleMasterModel moduleMasterModel)
        {
            ModuleMasterModel objModulemaster = new ModuleMasterModel();
            try
            {
                var paramList = new
                {
                    P_INT_MODULE_ID = moduleMasterModel.ModuleId,
                    P_VCH_ACTION = "EDIT",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ModuleMasterModel>("USP_MODULE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objModulemaster = result.FirstOrDefault();
                }
                return objModulemaster;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Update Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateModule(ModuleMasterModel moduleMasterModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_MODULE_ID", moduleMasterModel.ModuleId);
                p.Add("P_VCH_MODULE_NAME", moduleMasterModel.ModuleName);
                p.Add("P_INT_USER_ID", moduleMasterModel.UserID);
                p.Add("P_BIT_IS_ACTIVE", moduleMasterModel.IsActive);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_MODULE_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// To View Module Name
        /// </summary>
        /// <param name="moduleMasterModel"></param>
        /// <returns></returns>

        public async Task<List<ModuleMasterModel>> ViewModule(ModuleMasterModel moduleMasterModel)
        {
            List<ModuleMasterModel> ModluleLists = new List<ModuleMasterModel>();
            try
            {
                var paramList = new
                {
                    P_INT_MODULE_ID = moduleMasterModel.ModuleId,
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ModuleMasterModel>("USP_MODULE_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {
                    ModluleLists = result.ToList();
                }
                return ModluleLists;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
