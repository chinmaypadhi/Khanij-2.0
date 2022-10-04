// ***********************************************************************
//  Class Name               : ChecklistProvider
//  Description              : Add,View,Edit,Update,Delete Checklist Master details
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

namespace MasterApi.Model.Checklist
{
    public class ChecklistProvider: RepositoryBase, IChecklistProvider
    {
        /// <summary>
        /// Global Object and Variable Declaration
        /// </summary>
        public ChecklistProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> AddChecklistmaster(ChecklistMaster objChecklistMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_MODULE_ID", objChecklistMaster.ModuleID);
                p.Add("P_VCH_CHECKLIST_DESCRIPTION", objChecklistMaster.CheckListDescription);
                p.Add("P_INT_USER_ID", objChecklistMaster.UserID);
                p.Add("P_BIT_ACTIVE", objChecklistMaster.IsActive);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_CHECKLIST_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Edit Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<List<ChecklistMaster>> ViewChecklistMaster(ChecklistMaster objChecklistMaster)
        {
            List<ChecklistMaster> ListChecklistmaster = new List<ChecklistMaster>();
            try
            {
                var paramList = new
                {
                    P_INT_CHECKLIST_ID = objChecklistMaster.ChecklistId,
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ChecklistMaster>("USP_CHECKLIST_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);

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
        /// View Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<ChecklistMaster> EditChecklistMaster(ChecklistMaster objChecklistMaster)
        {
            ChecklistMaster LobjChecklistmaster = new ChecklistMaster();
            try
            {
                var paramList = new
                {
                    P_INT_CHECKLIST_ID = objChecklistMaster.ChecklistId,
                    P_VCH_ACTION = "SELECT",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ChecklistMaster>("USP_CHECKLIST_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Delete Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> DeleteChecklistMaster(ChecklistMaster objChecklistMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_CHECKLIST_ID", objChecklistMaster.ChecklistId);
                p.Add("P_INT_USER_ID", objChecklistMaster.UserID);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await Connection.QueryAsync<int>("USP_CHECKLIST_MASTER", p, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Update Checklist details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<MessageEF> UpdateChecklistMaster(ChecklistMaster objChecklistMaster)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_CHECKLIST_ID", objChecklistMaster.ChecklistId);
                p.Add("P_INT_MODULE_ID", objChecklistMaster.ModuleID);
                p.Add("P_VCH_CHECKLIST_DESCRIPTION", objChecklistMaster.CheckListDescription);
                p.Add("P_INT_USER_ID", objChecklistMaster.UserID);
                p.Add("P_BIT_ACTIVE", objChecklistMaster.IsActive);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_CHECKLIST_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Bind Module List Details in view
        /// </summary>
        /// <param name="objChecklistMaster"></param>
        /// <returns></returns>
        public async Task<List<ChecklistMaster>> GetModuleList(ChecklistMaster objChecklistMaster)
        {
            List<ChecklistMaster> ObjModuleList = new List<ChecklistMaster>();
            try
            {
                var paramList = new
                {
                    Check = "GetAllModuleNew"
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<ChecklistMaster>("uspHelpdeskDropDown", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjModuleList = result.ToList();
                }
                return ObjModuleList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
