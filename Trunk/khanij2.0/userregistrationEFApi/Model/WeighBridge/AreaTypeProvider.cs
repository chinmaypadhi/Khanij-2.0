using Dapper;
using MasterApi.Factory;
using userregistrationEFApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using userregistrationEF;

namespace userregistrationEFApi.Model.WeighBridge
{
    public class AreaTypeProvider : RepositoryBase,IAreaTypeProvider
    {
        public AreaTypeProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<AreaDetails>> GetLandTypeList(AreaDetails objLeaseAreaModel)
        {
            List<AreaDetails> ObjStateList = new List<AreaDetails>();
            try
            {
                var paramList = new
                {
                    Chk = "LandType",
                };
                DynamicParameters param = new DynamicParameters();
                var Output = await Connection.QueryAsync<AreaDetails>("Usp_GetStateDistrictMaster", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (Output.Count() > 0)
                {
                    ObjStateList = Output.ToList();
                }
                return ObjStateList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
    }
}
