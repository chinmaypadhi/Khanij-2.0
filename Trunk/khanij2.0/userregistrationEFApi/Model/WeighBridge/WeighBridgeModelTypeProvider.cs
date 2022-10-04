using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;
using MasterApi.Factory;
using userregistrationEFApi.Repository;
namespace userregistrationEFApi.Model.WeighBridge
{
    public class WeighBridgeModelTypeProvider : RepositoryBase, IWeighBrideModelTypeProvider
    {
        public WeighBridgeModelTypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<ViewWeighBridgeModelTypeModel>> ViewByMake(ViewWeighBridgeModelTypeModel objmodel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("@WeighBridgeMakeID", objmodel.WeighBridgeMakeID);
                p.Add("ACTION", "VIEWBYMAKE");
                var result = await Connection.QueryAsync<ViewWeighBridgeModelTypeModel>("[WeighBridgeModel1]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
