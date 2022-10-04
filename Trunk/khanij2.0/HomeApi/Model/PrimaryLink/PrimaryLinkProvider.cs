// ***********************************************************************
//  Class Name               : PrimaryLinkProvider
//  Desciption               : Add Primary link in Website Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 2 Nov 2021
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeEF;
using Dapper;
using HomeApi.Factory;
using System.Data;
using HomeApi.Repository;

namespace HomeApi.Model.PrimaryLink
{
    public class PrimaryLinkProvider : RepositoryBase, IPrimaryLinkProvider
    {
        /// <summary>
        /// Constructor initilisation
        /// </summary>
        /// <param name="connectionFactory"></param>
        public PrimaryLinkProvider(IConnectionFactory connectionFactory) :base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add Primary link
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public MessageEF AddPrimarylLink(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ABOUT_US_ID", addPrimaryLinkModel.VCH_ABOUTUS_ID);
                p.Add("P_VCH_REGISTRATION_ID", addPrimaryLinkModel.VCH_REGISTRATION_ID);
                p.Add("P_VCH_STATISTICAL_REPORT_ID", addPrimaryLinkModel.VCH_STATISTICAL_REPORT_ID);
                p.Add("P_INT_USER_ID", addPrimaryLinkModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("P_VCH_ACTION", "INSERT");
                Connection.Query<int>("[USP_WEB_PLINK_MASTER]", p, commandType: CommandType.StoredProcedure);
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
        /// To Bind About Us List
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<AddPrimaryLinkModel> AboutUs(AddPrimaryLinkModel  addPrimaryLinkModel)
        {
            AddPrimaryLinkModel objaddPrimaryLinkModel = new AddPrimaryLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "ABOUTUS",
                };
                var result = await Connection.QueryAsync<AddPrimaryLinkModel>("USP_WEB_PLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddPrimaryLinkModel = result.FirstOrDefault();
                }
                return objaddPrimaryLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Registration Link Details
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<AddPrimaryLinkModel> Registrations(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            AddPrimaryLinkModel objaddPrimaryLinkModel = new AddPrimaryLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "REGISTRATION",
                };
                var result = await Connection.QueryAsync<AddPrimaryLinkModel>("USP_WEB_PLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddPrimaryLinkModel = result.FirstOrDefault();
                }
                return objaddPrimaryLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Statistical Report List
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<AddPrimaryLinkModel> StatisticalReports(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            AddPrimaryLinkModel objaddPrimaryLinkModel = new AddPrimaryLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "STATISTICALREPORT",
                };
                var result = await Connection.QueryAsync<AddPrimaryLinkModel>("USP_WEB_PLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddPrimaryLinkModel = result.FirstOrDefault();
                }
                return objaddPrimaryLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Get Page List
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<List<AddPrimaryLinkModel>> GetPageList(AddPrimaryLinkModel  addPrimaryLinkModel)
        {
            List<AddPrimaryLinkModel> objPagelist = new List<AddPrimaryLinkModel>();
            try
            {
                var paramList = new
                {
                };
                //DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddPrimaryLinkModel>("USP_GET_PAGELIST_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objPagelist = result.ToList();
                }
                return objPagelist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Bind Global Link Lists in dropdown
        /// </summary>
        /// <param name="addPrimaryLinkModel"></param>
        /// <returns></returns>
        public async Task<List<AddPrimaryLinkModel>> GetGlobalLinkList(AddPrimaryLinkModel addPrimaryLinkModel)
        {
            List<AddPrimaryLinkModel> objGlobalLinkList = new List<AddPrimaryLinkModel>();
            try
            {
                var parameters = new 
                {
                    P_VCH_ACTION = "MAINMENU",
                };
                
                var result = await Connection.QueryAsync<AddPrimaryLinkModel>("USP_WEB_PLINK_MASTER", parameters, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objGlobalLinkList = result.ToList();
                }
                return objGlobalLinkList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
