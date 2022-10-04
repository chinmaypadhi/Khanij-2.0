// ***********************************************************************
//  Class Name               : MineralMapProvider
//  Desciption               : View Mineral Map Details 
//  Created By               : Lingaraj Dalai
//  Created On               : 14 April 2022
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

namespace HomeApi.Model.MineralMap
{
    public class MineralMapProvider: RepositoryBase, IMineralMapProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="connectionFactory"></param>
        public MineralMapProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }
        /// <summary>
        /// View Mineral Map Count details in view
        /// </summary>
        /// <param name="objMineralMapModel"></param>
        /// <returns></returns>
        public async Task<ViewMineralMapModel> ViewMineralMapCount(ViewMineralMapModel objMineralMapModel)
        {
            ViewMineralMapModel ObjMineralMapModel = new ViewMineralMapModel();
            try
            {
                var paramList = new
                {
                    Districtid = objMineralMapModel.DistrictID
                };
                var result = await Connection.QueryAsync<ViewMineralMapModel>("usp_Lessee_Licensee_Count", paramList, commandType: System.Data.CommandType.StoredProcedure);
                if (result.Count() > 0)
                {
                    ObjMineralMapModel = result.FirstOrDefault();
                }
                return ObjMineralMapModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
