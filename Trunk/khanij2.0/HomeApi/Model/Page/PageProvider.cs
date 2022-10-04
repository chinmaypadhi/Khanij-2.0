// ***********************************************************************
//  Class Name               : PageProvider
//  Desciption               : Add,Select,Update,Delete Website Page Details 
//  Created By               : Prakash Chandra Biswal
//  Created On               : 28 Oct 2021
// ***********************************************************************

using HomeApi.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using HomeApi.Repository;
using HomeEF;
using System.Data;

namespace HomeApi.Model.Page
{
    public class PageProvider : RepositoryBase, IPageProvider
    {
        /// <summary>
        /// Constructor Initialisation
        /// </summary>
        /// <param name="connectionFactory"></param>
        public PageProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// To Add Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public MessageEF AddPage(AddPageModel addPageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_PAGE_ID", addPageModel.INT_PAGE_ID);
                p.Add("P_VCH_PAGE_NAME", addPageModel.VCH_PAGE_NAME);
                p.Add("P_VCH_PAGE_NAME_ALIAS", addPageModel.VCH_PAGE_NAME_ALIAS);
                p.Add("P_VCH_PAGE_TITLE", addPageModel.VCH_PAGE_TITLE);
                p.Add("P_VCH_PAGE_SNIPPET", addPageModel.VCH_PAGE_SNIPPET);
                p.Add("P_VCH_META_TITLE", addPageModel.VCH_META_TITLE);
                p.Add("P_VCH_META_KEYWORD", addPageModel.VCH_META_KEYWORD);
                p.Add("P_VCH_META_DESCIPTION", addPageModel.VCH_META_DESCIPTION);
                p.Add("P_VCH_META_IMAGE_NAME", addPageModel.VCH_META_IMAGE_NAME);
                p.Add("P_VCH_FEATURE_IMAGE_NAME", addPageModel.VCH_FEATURE_IMAGE_NAME);
                p.Add("P_BIT_LINK_TYPE", addPageModel.BIT_LINK_TYPE);
                p.Add("P_VCH_URL", addPageModel.VCH_URL);
                p.Add("P_BIT_WINDOW_STATUS", addPageModel.BIT_WINDOW_STATUS);
                p.Add("P_INT_PAGE_TYPE", addPageModel.INT_PAGE_TYPE);
                p.Add("P_INT_PLUGIN_TYPE", addPageModel.INT_PLUGIN_TYPE);
                p.Add("P_VCH_PAGE_CONTENT", addPageModel.VCH_PAGE_CONTENT);
                p.Add("P_BIT_STATUS", addPageModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_WEB_PAGE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
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
        /// To View Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public async Task<List<ViewPageModel>> ViewPage(ViewPageModel viewPageModel)
        {
            List<ViewPageModel> PageList = new List<ViewPageModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewPageModel>("[USP_WEB_PAGE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    PageList = result.ToList();
                }
                return PageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To View Page in Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public async Task<List<ViewPageModel>> ViewPageOnArchive(ViewPageModel viewPageModel)
        {
            List<ViewPageModel> PageList = new List<ViewPageModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECTARCHIVE",
                };
                var result = await Connection.QueryAsync<ViewPageModel>("USP_WEB_PAGE", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    PageList = result.ToList();
                }
                return PageList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Archive Page 
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ArchivePage(ViewPageModel viewPageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ARCHIVE");
                p.Add("P_INT_PAGE_ID", viewPageModel.INT_PAGE_ID);
                p.Add("P_INT_USER_ID", viewPageModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_PAGE", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objMessage;
        }
        /// <summary>
        /// To Edit Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public AddPageModel EditPage(AddPageModel addPageModel)
        {
            AddPageModel objaddPage = new AddPageModel();
            try
            {
                var paramList = new
                {
                    P_INT_PAGE_ID = addPageModel.INT_PAGE_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddPageModel>("[USP_WEB_PAGE]", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddPage = result.FirstOrDefault();
                }
                return objaddPage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// To Delete Page Details
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public MessageEF DeletePage(ViewPageModel viewPageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_PAGE_ID", viewPageModel.INT_PAGE_ID);
                p.Add("P_INT_USER_ID", viewPageModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("[USP_WEB_PAGE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        /// <summary>
        /// To active page from Archive
        /// </summary>
        /// <param name="viewPageModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Active(ViewPageModel viewPageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "Active");
                p.Add("P_INT_PAGE_ID", viewPageModel.INT_PAGE_ID);
                p.Add("P_INT_USER_ID", viewPageModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("[USP_WEB_PAGE]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                string response = newID.ToString();
                objMessage.Satus = response;
            }
            catch (Exception)
            {
                throw;
            }
            return objMessage;
        }
        /// <summary>
        /// To Update Page Details
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public MessageEF UpdatePage(AddPageModel addPageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_PAGE_ID", addPageModel.INT_PAGE_ID);
                p.Add("P_VCH_PAGE_NAME", addPageModel.VCH_PAGE_NAME);
                p.Add("P_VCH_PAGE_NAME_ALIAS", addPageModel.VCH_PAGE_NAME_ALIAS);
                p.Add("P_VCH_PAGE_TITLE", addPageModel.VCH_PAGE_TITLE);
                p.Add("P_VCH_PAGE_SNIPPET", addPageModel.VCH_PAGE_SNIPPET);
                p.Add("P_VCH_META_TITLE", addPageModel.VCH_META_TITLE);
                p.Add("P_VCH_META_KEYWORD", addPageModel.VCH_META_KEYWORD);
                p.Add("P_VCH_META_DESCIPTION", addPageModel.VCH_META_DESCIPTION);
                p.Add("P_VCH_META_IMAGE_NAME", addPageModel.VCH_META_IMAGE_NAME);
                p.Add("P_VCH_FEATURE_IMAGE_NAME", addPageModel.VCH_FEATURE_IMAGE_NAME);
                p.Add("P_BIT_LINK_TYPE", addPageModel.BIT_LINK_TYPE);
                p.Add("P_VCH_URL", addPageModel.VCH_URL);
                p.Add("P_BIT_WINDOW_STATUS", addPageModel.BIT_WINDOW_STATUS);
                p.Add("P_INT_PAGE_TYPE", addPageModel.INT_PAGE_TYPE);
                p.Add("P_INT_PLUGIN_TYPE", addPageModel.INT_PLUGIN_TYPE);
                p.Add("P_VCH_PAGE_CONTENT", addPageModel.VCH_PAGE_CONTENT);
                p.Add("P_BIT_STATUS", addPageModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_PAGE", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
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
        /// To Get Plugin Types List
        /// </summary>
        /// <param name="addPageModel"></param>
        /// <returns></returns>
        public async Task<List<AddPageModel>> GetPluginTypeList(AddPageModel addPageModel)
        {
            List<AddPageModel> objpluginTypeList = new List<AddPageModel>();
            try
            {
                var paramlist = new
                {
                };
                DynamicParameters parameters = new DynamicParameters();
                var result = await Connection.QueryAsync<AddPageModel>("USP_GET_PLUGIN_TYPE", parameters, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objpluginTypeList = result.ToList();
                }
                return objpluginTypeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
