using Dapper;
using EpassApi.Factory;
using EpassApi.Repository;
using EpassEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EpassApi.Model.CaseOfIrregularity
{
    public class CaseOfIrregularityProvider: RepositoryBase, ICaseOfIrregularityProvider
    {

        public CaseOfIrregularityProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {
           
        }

        public async  Task<List<CheckPostIrrgModel>> ExcessMineralForCheckPost(CheckPostIrrgModel checkPostIrrgModel)
        {
            List<CheckPostIrrgModel> lstcheckPostIrrgModels =new List<CheckPostIrrgModel>();

            try
            {

                var param = new DynamicParameters();
                param.Add("Check", 2);
                param.Add("UserID", checkPostIrrgModel.UserId);
                var result = await Connection.QueryAsync<CheckPostIrrgModel>("GetExcessMineralQtyForCheckPost", param, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstcheckPostIrrgModels = result.ToList();
                }
                return lstcheckPostIrrgModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CheckPostIrrgModel>> GetDetailsFromTP(CheckPostIrrgModel checkPostIrrgModel)
        {
            List<CheckPostIrrgModel> lstcheckPostIrrgModels = new List<CheckPostIrrgModel>();

            try
            {

                var param = new DynamicParameters();
                param.Add("TransitPassNo", checkPostIrrgModel.TransitPassNo);
                param.Add("UserID", checkPostIrrgModel.UserId);
                var result = await Connection.QueryAsync<CheckPostIrrgModel>("uspGetAllEPass", param, commandType: CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    lstcheckPostIrrgModels = result.ToList();
                }
                return lstcheckPostIrrgModels;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
