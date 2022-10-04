using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.RailwayZone
{
    public class RailwayZoneProvider : RepositoryBase, IRailwayZoneProvider
    {
        public RailwayZoneProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddRailwayZone(RailwayZoneModel railwayZoneModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@RailwayZoneID", 0);
                p.Add("@RailwayZoneName", railwayZoneModel.RailwayZoneName); 
                p.Add("@StateID", railwayZoneModel.StateID);
                p.Add("@userId", railwayZoneModel.CreatedBy);
                p.Add("@UserLoginID", railwayZoneModel.CreatedBy);
                p.Add("@IsActive", railwayZoneModel.IsActive == null ? true : railwayZoneModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRailwayZoneeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public MessageEF DeleteRailwayZone(RailwayZoneModel railwayZoneModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@RailwayZoneID",railwayZoneModel.RailwayZoneID,
                        "@operation",3,
                        "@userId",railwayZoneModel.CreatedBy,
                        "@UserLoginID",railwayZoneModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspRailwayZoneeMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        public RailwayZoneModel EditRailwayZone(RailwayZoneModel railwayZoneModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@RailwayZoneID", railwayZoneModel.RailwayZoneID);

                var result = Connection.Query<RailwayZoneModel>("uspRailwayZoneeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    railwayZoneModel = result.FirstOrDefault();
                }

                return railwayZoneModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                railwayZoneModel = null;
            }
        }
        #endregion

        #region Update
        public MessageEF UpdateRailwayZoneModel(RailwayZoneModel railwayZoneModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@RailwayZoneID", railwayZoneModel.RailwayZoneID);
                p.Add("@RailwayZoneName", railwayZoneModel.RailwayZoneName);
                p.Add("@StateID", railwayZoneModel.StateID);
                p.Add("@userId", railwayZoneModel.CreatedBy);
                p.Add("@UserLoginID", railwayZoneModel.CreatedBy);
                p.Add("@IsActive", railwayZoneModel.IsActive == null ? true : railwayZoneModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRailwayZoneeMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public List<RailwayZoneModel> ViewRailwayZone(RailwayZoneModel railwayZoneModel)
        {
            List<RailwayZoneModel> listRailwayZoneModel = new List<RailwayZoneModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = Connection.Query<RailwayZoneModel>("uspRailwayZoneeMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listRailwayZoneModel = result.ToList();
                }

                return listRailwayZoneModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listRailwayZoneModel = null;
            }
        }
        #endregion
    }
}
