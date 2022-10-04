// ***********************************************************************
//  Class Name               : QbuilderProvider
//  Desciption               : Query builder 
//  Created By               : Lingaraj Dalai
//  Created On               : 30 Nov 2021
// ***********************************************************************
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;


namespace HomeApi.Model.Qbuilder
{
    public class QbuilderProvider: RepositoryBase, IQbuilderProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public QbuilderProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// Execute Query Details 
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        //public async Task<MessageEF> ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        //{
        //    MessageEF objMessage = new MessageEF();
        //    try
        //    {
        //        var p = new DynamicParameters();
        //        p.Add("P_VCH_UPWD", objQuerybuilderModel.VCH_UPWD);
        //        p.Add("P_VCH_QUERY_TEXT", objQuerybuilderModel.VCH_QUERY_TEXT);
        //        p.Add("P_VCH_QUERY_TYPE", objQuerybuilderModel.VCH_QUERY_TYPE);
        //        p.Add("P_INT_USERID", objQuerybuilderModel.INT_USERID);
        //        p.Add("P_INT_USER_LOGINID", objQuerybuilderModel.INT_USER_LOGINID);
        //        //IDataReader dr = await Connection.ExecuteReaderAsync("USP_QBUILDER", p, commandType: CommandType.StoredProcedure);
        //        //DataSet ds = ConvertDataReaderToDataSet(dr);
        //        //return ds;
        //        p.Add("P_INT_OUTPUT", dbType: DbType.Int32, direction: ParameterDirection.Output);
        //        await Connection.QueryAsync<int>("USP_QBUILDER", p, commandType: CommandType.StoredProcedure);
        //        int newID = p.Get<int>("P_INT_OUTPUT");
        //        string response = newID.ToString();
        //        objMessage.Satus = response;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    return objMessage;
        //}
        public async Task<DataSet> ExecuteQuery(QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("P_VCH_UPWD", objQuerybuilderModel.VCH_UPWD);
                p.Add("P_VCH_QUERY_TEXT", objQuerybuilderModel.VCH_QUERY_TEXT);
                p.Add("P_VCH_QUERY_TYPE", objQuerybuilderModel.VCH_QUERY_TYPE);
                p.Add("P_INT_USERID", objQuerybuilderModel.INT_USERID);
                p.Add("P_INT_USER_LOGINID", objQuerybuilderModel.INT_USER_LOGINID);
                IDataReader dr = await Connection.ExecuteReaderAsync("USP_QBUILDER", p, commandType: CommandType.StoredProcedure);
                DataSet ds = ConvertDataReaderToDataSet(dr);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Convert Dataset to Datareader
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataSet ConvertDataReaderToDataSet(IDataReader data)
        {
            DataSet ds = new DataSet();
            int i = 0;
            while (!data.IsClosed)
            {
                ds.Tables.Add("Table" + (i + 1));
                ds.EnforceConstraints = false;
                ds.Tables[i].Load(data);
                i++;
            }
            return ds;
        }
        /// <summary>
        /// Fetch query details
        /// </summary>
        /// <param name="Query"></param>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        public async Task<string> FetchQuerydtls(string Query, QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                var result = await Connection.QueryAsync(objQuerybuilderModel.VCH_QUERY_TEXT);
                var json = JsonSerializer.Serialize(result);
                return json;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// DML operations
        /// </summary>
        /// <param name="objQuerybuilderModel"></param>
        /// <returns></returns>
        public async Task<int> Queryinsert(QuerybuilderModel objQuerybuilderModel)
        {
            try
            {
                var result = await Connection.ExecuteAsync(objQuerybuilderModel.VCH_QUERY_TEXT);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
