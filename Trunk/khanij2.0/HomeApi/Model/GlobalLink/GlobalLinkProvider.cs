// ***********************************************************************
//  Class Name               : GlobalLinkProvider
//  Desciption               : Add Global link in Website Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Nov 2021
// ***********************************************************************
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.GlobalLink
{
    public class GlobalLinkProvider: RepositoryBase, IGlobalLinkProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public GlobalLinkProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Global Link Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public MessageEF AddGlobalLink(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_TOPMENU_ID", objAddGlobalLinkModel.VCH_TOPMENU_ID);
                p.Add("P_VCH_MAINMENU_ID", objAddGlobalLinkModel.VCH_MAINMENU_ID);
                p.Add("P_VCH_FOOTERMENU_ID", objAddGlobalLinkModel.VCH_FOOTERMENU_ID);
                p.Add("P_INT_USER_ID", objAddGlobalLinkModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("P_VCH_ACTION", "INSERT");
                Connection.Query<int>("[USP_WEB_GLINK_MASTER]", p, commandType: CommandType.StoredProcedure);
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
        /// Bind Website Top Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public async Task<AddGlobalLinkModel> TopMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            AddGlobalLinkModel objaddGlobalLinkModel = new AddGlobalLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "TOPMENU",
                };
                var result = await Connection.QueryAsync<AddGlobalLinkModel>("USP_WEB_GLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGlobalLinkModel = result.FirstOrDefault();
                }
                return objaddGlobalLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Main Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public async Task<AddGlobalLinkModel> MainMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            AddGlobalLinkModel objaddGlobalLinkModel = new AddGlobalLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "MAINMENU",
                };
                var result = await Connection.QueryAsync<AddGlobalLinkModel>("USP_WEB_GLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGlobalLinkModel = result.FirstOrDefault();
                }
                return objaddGlobalLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Footer Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public async Task<AddGlobalLinkModel> FooterMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            AddGlobalLinkModel objaddGlobalLinkModel = new AddGlobalLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "FOOTERMENU",
                };
                var result = await Connection.QueryAsync<AddGlobalLinkModel>("USP_WEB_GLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGlobalLinkModel = result.FirstOrDefault();
                }
                return objaddGlobalLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Get Website Global Link Sequence count Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public async Task<List<AddGlobalLinkModel>> GetPageList(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            List<AddGlobalLinkModel> objaddGlobalLinkModellist = new List<AddGlobalLinkModel>();
            try
            {
                var paramList = new
                {
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddGlobalLinkModel>("USP_GET_PAGELIST_DETAILS", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGlobalLinkModellist = result.ToList();
                }
                return objaddGlobalLinkModellist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Menu Details 
        /// </summary>
        /// <param name="objAddGlobalLinkModel"></param>
        /// <returns></returns>
        public async Task<AddGlobalLinkModel> WebsiteMenu(AddGlobalLinkModel objAddGlobalLinkModel)
        {
            AddGlobalLinkModel objaddGlobalLinkModel = new AddGlobalLinkModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEACTIVE",
                };
                var result = await Connection.QueryAsync<AddGlobalLinkModel>("USP_WEB_GLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddGlobalLinkModel = result.FirstOrDefault();
                }
                return objaddGlobalLinkModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Bind Website Child Menu Details 
        /// </summary>
        /// <param name="objAddPageModel"></param>
        /// <returns></returns>
        public async Task<List<AddPageModel>> WebsiteChildMenu(AddPageModel objAddPageModel)
        {
            List<AddPageModel> objAddPageModellist = new List<AddPageModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = objAddPageModel.VCH_ACTION,
                };
                var result = await Connection.QueryAsync<AddPageModel>("USP_WEB_GLINK_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objAddPageModellist = result.ToList();
                }
                return objAddPageModellist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
