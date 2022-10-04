using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

using PermitApi.Factory;
using PermitApi.Repository;
using PermitEF;

namespace PermitApi.Model.GradeUpdate
{
    public class UpgradeGrade : RepositoryBase, IUpgradeGrade
    {
        public UpgradeGrade(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public async Task<List<SampleGradeModel>> GetGradeDetails(SampleGradeModel objUser)
        {
            List<SampleGradeModel> ObjUserTypeList = new List<SampleGradeModel>();
            try
            {
                var paramList = new
                {
                    CreatedBy= objUser.CreatedBy,
                    Check =1

                };
                DynamicParameters param = new DynamicParameters();

                var result = await Connection.QueryAsync<SampleGradeModel>("uspSampleGrade_Master", paramList, commandType: System.Data.CommandType.StoredProcedure);
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
