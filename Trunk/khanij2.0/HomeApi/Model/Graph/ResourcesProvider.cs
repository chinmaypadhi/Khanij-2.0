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
    public class ResourcesProvider : RepositoryBase, IResourcesProvider
    {
        public ResourcesProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        public MessageEF Edit(EditResourcesModel objmodel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("Totalcoal_india", objmodel.Totalcoal_India);
                p.Add("Totalironore_india", objmodel.TotalLimestone_Chattisgarh);
                p.Add("Totallimestone_india", objmodel.TotalLimestone_India);
                p.Add("Totalbauxite_india", objmodel.TotalBauxite_India);
                p.Add("Totalcoal_chattishgarh", objmodel.Totalcoal_Chattisgarh);
                p.Add("Totalironore_chattishgarh", objmodel.TotalIronore_Chattisgarh);
                p.Add("Totallimestone_chattisgarh", objmodel.TotalLimestone_Chattisgarh);
                p.Add("Totalbauxite_chattisgarh", objmodel.TotalBauxite_Chattisgarh);
                p.Add("Updated_By", objmodel.Updated_By);
                p.Add("P_INT_RESULT", dbType: DbType.Int32, direction: ParameterDirection.Output);
                p.Add("ACTION", "UPDATE");
                Connection.Query<int>("[GraphMineralsAvail]", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("P_INT_RESULT");
                objMessage.Satus = newID.ToString();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }

        public async Task<ViewResourcesModel> View(ViewResourcesModel objmodel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", "");
                p.Add("Totalcoal_india", "");
                p.Add("Totalironore_india", "");
                p.Add("Totallimestone_india", "");
                p.Add("Totalbauxite_india", "");
                p.Add("Totalcoal_chattishgarh", "");
                p.Add("Totalironore_chattishgarh", "");
                p.Add("Totallimestone_chattisgarh", "");
                p.Add("Totalbauxite_chattisgarh", "");
                p.Add("Updated_By", "");
                p.Add("ACTION", "VIEW");
                var result = await Connection.QuerySingleAsync<ViewResourcesModel>("[GraphMineralsAvail]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<EditResourcesModel> ViewByID(ViewResourcesModel objmodel)
        {
            try
            {
                var p = new DynamicParameters();
                p.Add("ID", objmodel.ID);
                p.Add("Totalcoal_india", "");
                p.Add("Totalironore_india", "");
                p.Add("Totallimestone_india", "");
                p.Add("Totalbauxite_india", "");
                p.Add("Totalcoal_chattishgarh", "");
                p.Add("Totalironore_chattishgarh", "");
                p.Add("Totallimestone_chattisgarh", "");
                p.Add("Totalbauxite_chattisgarh", "");
                p.Add("Updated_By", "");
                p.Add("ACTION", "VIEWBYID");
                var result = await Connection.QuerySingleAsync<EditResourcesModel>("[GraphMineralsAvail]", p, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
