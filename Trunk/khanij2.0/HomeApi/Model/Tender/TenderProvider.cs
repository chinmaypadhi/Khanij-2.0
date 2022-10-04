// ***********************************************************************
//  Class Name               : TenderProvider
//  Desciption               : Add,Select,Update,Delete Website Tender Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 11 Oct 2021
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

namespace HomeApi.Model.Tender
{
    public class TenderProvider: RepositoryBase, ITenderProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public TenderProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Add Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF AddTender(AddTenderModel objAddTenderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_TENDER_NO", objAddTenderModel.VCH_TENDER_NO);
                p.Add("P_DTM_TENDER_OPEN_DATE", objAddTenderModel.DTM_TENDER_OPEN_DATE);
                p.Add("P_DTM_TENDER_OPEN_TIME", objAddTenderModel.DTM_TENDER_OPEN_TIME);
                p.Add("P_DTM_TENDER_CLOSE_DATE", objAddTenderModel.DTM_TENDER_CLOSE_DATE);
                p.Add("P_DTM_TENDER_CLOSE_TIME", objAddTenderModel.DTM_TENDER_CLOSE_TIME);
                p.Add("P_VCH_DOCUMENT", objAddTenderModel.VCH_DOCUMENT);
                p.Add("P_VCH_TENDER_SUB", objAddTenderModel.VCH_SUBJECT);
                p.Add("P_INT_USER_ID", objAddTenderModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddTenderModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "INSERT");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TENDER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTenderModel>> ViewTender(ViewTenderModel objViewTenderModel)
        {
            List<ViewTenderModel> ListNotification = new List<ViewTenderModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "SELECT",
                };
                var result = await Connection.QueryAsync<ViewTenderModel>("USP_WEB_TENDER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Edit Website Tender Details
        /// </summary>
        /// <param name="objViewNotificationModel"></param>
        /// <returns></returns>
        public AddTenderModel EditTender(AddTenderModel objAddTenderModel)
        {
            AddTenderModel objaddTenderModel = new AddTenderModel();
            try
            {
                var paramList = new
                {
                    P_INT_TENDER_ID = objAddTenderModel.INT_TENDER_ID,
                    P_VCH_ACTION = "IDSELECT",
                };
                var result = Connection.Query<AddTenderModel>("USP_WEB_TENDER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objaddTenderModel = result.FirstOrDefault();
                }
                return objaddTenderModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Delete Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF DeleteTender(ViewTenderModel objAddTenderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_ACTION", "DELETE");
                p.Add("P_INT_TENDER_ID", objAddTenderModel.INT_TENDER_ID);
                p.Add("P_INT_USER_ID", objAddTenderModel.INT_CREATED_BY);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TENDER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Update Website Tender Details 
        /// </summary>
        /// <param name="objAddTenderModel"></param>
        /// <returns></returns>
        public MessageEF UpdateTender(AddTenderModel objAddTenderModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("P_INT_TENDER_ID", objAddTenderModel.INT_TENDER_ID);
                p.Add("P_VCH_TENDER_NO", objAddTenderModel.VCH_TENDER_NO);
                p.Add("P_DTM_TENDER_OPEN_DATE", objAddTenderModel.DTM_TENDER_OPEN_DATE);
                p.Add("P_DTM_TENDER_OPEN_TIME", objAddTenderModel.DTM_TENDER_OPEN_TIME);
                p.Add("P_DTM_TENDER_CLOSE_DATE", objAddTenderModel.DTM_TENDER_CLOSE_DATE);
                p.Add("P_DTM_TENDER_CLOSE_TIME", objAddTenderModel.DTM_TENDER_CLOSE_TIME);
                p.Add("P_VCH_DOCUMENT", objAddTenderModel.VCH_DOCUMENT);
                p.Add("P_VCH_TENDER_SUB", objAddTenderModel.VCH_SUBJECT);
                p.Add("P_INT_USER_ID", objAddTenderModel.INT_CREATED_BY);
                p.Add("P_BIT_STATUS", objAddTenderModel.BIT_STATUS);
                p.Add("P_VCH_ACTION", "UPDATE");
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("USP_WEB_TENDER_MASTER", p, commandType: CommandType.StoredProcedure);
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
        /// Select Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTenderModel>> ViewWebsiteTenderActive(ViewTenderModel objViewTenderModel)
        {
            List<ViewTenderModel> ListNotification = new List<ViewTenderModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEACTIVE",
                    P_VCH_TENDER_NO = objViewTenderModel.VCH_TENDER_NO,
                    P_DTM_FROM_DATE = objViewTenderModel.DTM_FROM_DATE,
                    P_DTM_TO_DATE = objViewTenderModel.DTM_TO_DATE
                };
                var result = await Connection.QueryAsync<ViewTenderModel>("USP_WEB_TENDER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Select Archive Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTenderModel>> ViewWebsiteTenderArchive(ViewTenderModel objViewTenderModel)
        {
            List<ViewTenderModel> ListNotification = new List<ViewTenderModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "WEBSITEARCHIVE",
                    P_VCH_TENDER_NO = objViewTenderModel.VCH_TENDER_NO,
                    P_DTM_FROM_DATE = objViewTenderModel.DTM_FROM_DATE,
                    P_DTM_TO_DATE = objViewTenderModel.DTM_TO_DATE
                };
                var result = await Connection.QueryAsync<ViewTenderModel>("USP_WEB_TENDER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
        /// Select Top Active Website Tender Details 
        /// </summary>
        /// <param name="objViewTenderModel"></param>
        /// <returns></returns>
        public async Task<List<ViewTenderModel>> ViewTopWebsiteTender(ViewTenderModel objViewTenderModel)
        {
            List<ViewTenderModel> ListNotification = new List<ViewTenderModel>();
            try
            {
                var paramList = new
                {
                    P_VCH_ACTION = "TOPWEBSITEACTIVE",
                };
                var result = await Connection.QueryAsync<ViewTenderModel>("USP_WEB_TENDER_MASTER", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
