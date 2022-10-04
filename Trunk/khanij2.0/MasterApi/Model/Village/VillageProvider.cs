using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Village
{
    public class VillageProvider : RepositoryBase, IVillageProvider
    {
        public VillageProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddVillage(VillageModel villageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@VillageID",0);
                p.Add("@VillageName", villageModel.VillageName);
                p.Add("@VillageCode", villageModel.VillageName);
                p.Add("@TehsilID", villageModel.TehsilID); 
                p.Add("@DistrictID", villageModel.DistrictID);
                p.Add("@RegionalID", villageModel.RegionalID);
                p.Add("@StateID", villageModel.StateID);
                p.Add("@userId", villageModel.CreatedBy);
                p.Add("@UserLoginID", villageModel.CreatedBy);
                p.Add("@IsActive", villageModel.IsActive == null ? true : villageModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspVillageMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Delete
        public MessageEF DeleteVillage(VillageModel villageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@VillageID",villageModel.VillageID,
                        "@operation",3,
                        "@userId",villageModel.CreatedBy,
                        "@UserLoginID",villageModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspVillageMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
                string response = _param.Get<string>("result");
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region Edit
        public VillageModel EditVillage(VillageModel villageModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@VillageID", villageModel.VillageID);

                var result = Connection.Query<VillageModel>("uspVillageMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    villageModel = result.FirstOrDefault();
                }

                return villageModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                villageModel = null;
            }
        }
        #endregion

        #region Update
        public MessageEF UpdateVillage(VillageModel villageModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@VillageID", villageModel.VillageID);
                p.Add("@VillageName", villageModel.VillageName);
                p.Add("@VillageCode", villageModel.VillageName);
                p.Add("@TehsilID", villageModel.TehsilID);
                p.Add("@DistrictID", villageModel.DistrictID);
                p.Add("@RegionalID", villageModel.RegionalID);
                p.Add("@StateID", villageModel.StateID);
                p.Add("@userId", villageModel.CreatedBy);
                p.Add("@UserLoginID", villageModel.CreatedBy);
                p.Add("@IsActive", villageModel.IsActive == null ? true : villageModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspVillageMasterOperation", p, commandType: CommandType.StoredProcedure);
                int newID = p.Get<int>("result");



                string response = newID.ToString();
                if (response == "1")
                {
                    objMessage.Satus = "1";

                }
                else
                {
                    objMessage.Satus = "2";
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return objMessage;
        }
        #endregion

        #region View
        public List<VillageModel> ViewVillage(VillageModel villageModel)
        {
            List<VillageModel> listVillageModel = new List<VillageModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = Connection.Query<VillageModel>("uspVillageMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listVillageModel = result.ToList();
                }

                return listVillageModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listVillageModel = null;
            }
        }
        #endregion
    }
}
