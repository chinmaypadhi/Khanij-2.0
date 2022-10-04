using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using HomeEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HomeApi.Model.Graph
{
    public class RevenueProvider : RepositoryBase, IRevenueProvider
    {
        public RevenueProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }     
        public MessageEF Add(EditRevenueModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "0");
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("MineralName", objmodel.MineralName);
                p.Add("DMF", objmodel.DMF);
                p.Add("NMET", objmodel.NMET);
                p.Add("Royalty", objmodel.Royalty);
                p.Add("Updated_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "INSERT");
                Connection.Query<int>("[Graph_Revenue]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public MessageEF CheckRevenue(EditRevenueModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("MineralName", objmodel.MineralName);
                p.Add("DMF", objmodel.DMF);
                p.Add("NMET", objmodel.NMET);
                p.Add("Royalty", objmodel.Royalty);
                p.Add("Updated_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "CHECK");
                Connection.Query<int>("[Graph_Revenue]", p, commandType: CommandType.StoredProcedure);
                int i = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = i.ToString();
                return objMessage;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public MessageEF Edit(EditRevenueModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("MineralName", objmodel.MineralName);
                p.Add("DMF", objmodel.DMF);
                p.Add("NMET", objmodel.NMET);
                p.Add("Royalty", objmodel.Royalty);
                p.Add("Updated_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "UPDATE");
                Connection.Query<int>("[Graph_Revenue]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<List<ViewRevenueModel>> View(ViewRevenueModel objmodel)
        {
            List<ViewRevenueModel> objlist = new List<ViewRevenueModel>();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("FinancialYear", "");
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("MineralName", "");
                p.Add("DMF", "");
                p.Add("NMET", "");
                p.Add("Royalty", "");
                p.Add("Updated_By", "");
                p.Add("ACTION", "VIEWALL");
                var result = await Connection.QueryAsync<ViewRevenueModel>("[Graph_Revenue]", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objlist = result.ToList();
                }
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ViewRevenueModel>> ViewByFinancialYear(ViewRevenueModel objmodel)
        {
            List<ViewRevenueModel> objlist = new List<ViewRevenueModel>();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("MineralName", "");
                p.Add("DMF", "");
                p.Add("NMET", "");
                p.Add("Royalty", "");
                p.Add("Updated_By", "");
                p.Add("ACTION", "VIEW");
                var result = await Connection.QueryAsync<ViewRevenueModel>("[Graph_Revenue]", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    objlist = result.ToList();
                }
                return objlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EditRevenueModel> ViewByID(ViewRevenueModel objmodel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", "");
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("MineralName", "");
                p.Add("DMF", "");
                p.Add("NMET", "");
                p.Add("Royalty", "");
                p.Add("Updated_By", "");
                p.Add("ACTION", "VIEWBYID");
                var result = await Connection.QuerySingleAsync<EditRevenueModel>("[Graph_Revenue]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
