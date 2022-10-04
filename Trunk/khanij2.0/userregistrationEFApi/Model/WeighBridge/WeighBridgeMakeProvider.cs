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
    public class WeighBridgeMakeProvider : RepositoryBase, IWeighBridgeMakeProvider
    {
        public WeighBridgeMakeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<ViewWeighBridgeMakeModel>> View()
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ACTION", "VIEWALL");
                var result = await Connection.QueryAsync<ViewWeighBridgeMakeModel>("[WeighBridgeMake1]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

    }
}
