using HomeEF;
using Dapper;
using HomeApi.Factory;
using HomeApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace HomeApi.Model.Graph
{
    public class ProductionProvider : RepositoryBase, IProductionProvider
    {
        public ProductionProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public MessageEF Add(EditProductionModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("Mineral", objmodel.Mineral);
                p.Add("Production", objmodel.Production);
                p.Add("Despatch", objmodel.Despatch);
                p.Add("Update_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "INSERT");
                Connection.Query<int>("[GraphProductionandDespatch]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public MessageEF CheckProduction(EditProductionModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("Mineral", objmodel.Mineral);
                p.Add("Production", objmodel.Production);
                p.Add("Despatch", objmodel.Despatch);
                p.Add("Update_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "CHECK");
                Connection.Query<int>("[GraphProductionandDespatch]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public MessageEF Edit(EditProductionModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", objmodel.MineralCategoryID);
                p.Add("MineralID", objmodel.MineralID);
                p.Add("Mineral", objmodel.Mineral);
                p.Add("Production", objmodel.Production);
                p.Add("Despatch", objmodel.Despatch);
                p.Add("Update_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "UPDATE");
                Connection.Query<int>("[GraphProductionandDespatch]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<List<ViewProductionModel>> View(ViewProductionModel objmodel)
        {
            List<ViewProductionModel> viewproductionlist = new List<ViewProductionModel>();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("FinancialYear", "");
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("Mineral", "");
                p.Add("Production", "");
                p.Add("Despatch", "");
                p.Add("Update_By", "");
                p.Add("ACTION", "VIEWALL");
                var result = await Connection.QueryAsync<ViewProductionModel>("[GraphProductionandDespatch]", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    viewproductionlist = result.ToList();
                }
                return viewproductionlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ViewProductionModel>> ViewByFinancialYear(ViewProductionModel objmodel)
        {
            List<ViewProductionModel> viewproductionlist = new List<ViewProductionModel>();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("FinancialYear", objmodel.FinancialYear);
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("Mineral", "");
                p.Add("Production", "");
                p.Add("Despatch", "");
                p.Add("Update_By", "");
                p.Add("ACTION", "VIEW");
                var result = await Connection.QueryAsync<ViewProductionModel>("[GraphProductionandDespatch]", p, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    viewproductionlist = result.ToList();
                }
                return viewproductionlist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EditProductionModel> ViewByID(ViewProductionModel objmodel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("FinancialYear", "");
                p.Add("MineralCategoryID", "");
                p.Add("MineralID", "");
                p.Add("Mineral", "");
                p.Add("Production", "");
                p.Add("Despatch", "");
                p.Add("Update_By", "");
                p.Add("ACTION", "VIEWBYID");
                var result = await Connection.QuerySingleAsync<EditProductionModel>("[GraphProductionandDespatch]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
