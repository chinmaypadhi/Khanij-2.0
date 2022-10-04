using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.ValidityExpired
{
    public class ValidityExpiredProvider : RepositoryBase, IValidityExpiredProvider
    {
        public ValidityExpiredProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        public async Task<List<ValidityExpiredEF>> GetValidityExpiredDetails(ValidityExpiredEF objUser)
        {
            List<ValidityExpiredEF> ObjUserTypeList = new List<ValidityExpiredEF>();
            try
            {
                var paramList = new
                {
                    UserId = objUser.UserID,
                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<ValidityExpiredEF>("uspGetLeaseWiseValidityExpiredDetails", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {

                    ObjUserTypeList = result.ToList();
                }

            }

            catch (Exception ex)
            {

                throw ex;
            }
            return ObjUserTypeList;

        }
    }
}
