// ***********************************************************************
//  Interface Name           : IBannerProvider
//  Desciption               : Add,View,Edit,Update,Delete Website Banner Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 22 Oct 2021
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


namespace HomeApi.Model.Banner
{
    public class BannerProvider: RepositoryBase, IBannerProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public BannerProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public MessageEF AddBanner(AddBannerModel objAddBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_BANNER_NAME", objAddBannerModel.VCH_BANNER_NAME);
                p.Add("P_VCH_DESCRIPTION", objAddBannerModel.VCH_DESCRIPTION);
                p.Add("P_VCH_BANNER_URL", objAddBannerModel.VCH_BANNER_URL);
                p.Add("P_VCH_DESKTOP_DOCUMENT", objAddBannerModel.VCH_DESKTOP_DOCUMENT);
                p.Add("P_VCH_MOBILE_DOCUMENT", objAddBannerModel.VCH_MOBILE_DOCUMENT);
                p.Add("P_INT_SEQUENCE", objAddBannerModel.INT_SEQUENCE);
                p.Add("P_INT_USER_ID", objAddBannerModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddBannerModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<List<ViewBannerModel>> ViewBanner(ViewBannerModel objViewBannerModel)
        {
            List<ViewBannerModel> ListNotification = new List<ViewBannerModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewBannerModel>("USP_WEB_BANNER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Banner Archive Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<List<ViewBannerModel>> ViewBannerArchive(ViewBannerModel objViewBannerModel)
        {
            List<ViewBannerModel> ListBanner = new List<ViewBannerModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECTARCHIVE",
                };
                var result = await Connection.QueryAsync<ViewBannerModel>("USP_WEB_BANNER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListBanner = result.ToList();
                }
                return ListBanner;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Edit Website Banner Details
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public AddBannerModel EditBanner(AddBannerModel objAddBannerModel)
        {
            AddBannerModel objaddBannerModel = new AddBannerModel();
            try
            {
                var paramList = new
                {
                    P_INT_BANNER_ID = objAddBannerModel.INT_BANNER_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddBannerModel>("USP_WEB_BANNER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddBannerModel = result.FirstOrDefault();
                }
                return objaddBannerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Archive Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> ArchiveBanner(ViewBannerModel objViewBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ARCHIVE");
                p.Add("P_INT_BANNER_ID", objViewBannerModel.INT_BANNER_ID);
                p.Add("P_INT_USER_ID", objViewBannerModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Delete Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF DeleteBanner(ViewBannerModel objViewBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_BANNER_ID", objViewBannerModel.INT_BANNER_ID);
                p.Add("P_INT_USER_ID", objViewBannerModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website Banner Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public MessageEF UpdateBanner(AddBannerModel objAddBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_BANNER_ID", objAddBannerModel.INT_BANNER_ID);
                p.Add("P_VCH_BANNER_NAME", objAddBannerModel.VCH_BANNER_NAME);
                p.Add("P_VCH_DESCRIPTION", objAddBannerModel.VCH_DESCRIPTION);
                p.Add("P_VCH_BANNER_URL", objAddBannerModel.VCH_BANNER_URL);
                p.Add("P_VCH_DESKTOP_DOCUMENT", objAddBannerModel.VCH_DESKTOP_DOCUMENT);
                p.Add("P_VCH_MOBILE_DOCUMENT", objAddBannerModel.VCH_MOBILE_DOCUMENT);
                p.Add("P_INT_SEQUENCE", objAddBannerModel.INT_SEQUENCE);
                p.Add("P_INT_USER_ID", objAddBannerModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddBannerModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website Banner Status Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public MessageEF UpdateStatus(AddBannerModel objAddBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_BANNER_ID", objAddBannerModel.INT_BANNER_ID);
                p.Add("P_BIT_STATUS", objAddBannerModel.BIT_STATUS);
                p.Add("P_INT_USER_ID", objAddBannerModel.INT_CREATED_BY);
                p.Add("P_VCH_ACTION", "UPDATESTATUS");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Publish Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> PublishBanner(ViewBannerModel objViewBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "PUBLISH");
                p.Add("P_INT_BANNER_ID", objViewBannerModel.INT_BANNER_ID);
                p.Add("P_INT_USER_ID", objViewBannerModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Unpublish Website Baner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> UnpublishBanner(ViewBannerModel objViewBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "UNPUBLISH");
                p.Add("P_INT_BANNER_ID", objViewBannerModel.INT_BANNER_ID);
                p.Add("P_INT_USER_ID", objViewBannerModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Active Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<MessageEF> Active(ViewBannerModel objViewBannerModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "ACTIVE");
                p.Add("P_INT_BANNER_ID", objViewBannerModel.INT_BANNER_ID);
                p.Add("P_INT_USER_ID", objViewBannerModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                await Connection.QueryAsync<int>("USP_WEB_BANNER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Get Website Banner Sequence count Details 
        /// </summary>
        /// <param name="objAddBannerModel"></param>
        /// <returns></returns>
        public async Task<AddBannerModel> GetSequence(AddBannerModel objAddBannerModel)
        {
            AddBannerModel objaddBannerModel = new AddBannerModel();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SEQUENCE",
                };
                DynamicParameters param = new DynamicParameters();
                var result = await Connection.QueryAsync<AddBannerModel>("USP_WEB_BANNER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddBannerModel = result.FirstOrDefault();
                }
                return objaddBannerModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Select Website Banner Details 
        /// </summary>
        /// <param name="objViewBannerModel"></param>
        /// <returns></returns>
        public async Task<List<ViewBannerModel>> ViewWebsiteBanner(ViewBannerModel objViewBannerModel)
        {
            List<ViewBannerModel> ListNotification = new List<ViewBannerModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITE",
                };
                var result = await Connection.QueryAsync<ViewBannerModel>("USP_WEB_BANNER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ListNotification = result.ToList();
                }
                return ListNotification;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
