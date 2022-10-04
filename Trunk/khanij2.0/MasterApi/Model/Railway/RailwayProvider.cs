using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Railway
{
    public class RailwayProvider : RepositoryBase, IRailwayProvider
    {
        public RailwayProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddRailway(RailwayModel railwayModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@RailwayID", 0);
                p.Add("@RailwayName", railwayModel.RailwayName);
                p.Add("@RailwayZoneID", railwayModel.RailwayZoneID);
                p.Add("@RailwaySlidingName", railwayModel.RailwaySlidingName);
                p.Add("@RailwaySlidingType", railwayModel.RailwaySlidingType);
                p.Add("@RailwayAuthorityName", railwayModel.RailwayAuthorityName);
                p.Add("@Address", railwayModel.Address);
                p.Add("@ContactNo", railwayModel.ContactNo);
                p.Add("@MailID", railwayModel.MailID);
                p.Add("@userId", railwayModel.CreatedBy);
                p.Add("@UserLoginID", railwayModel.CreatedBy);
                p.Add("@IsActive", railwayModel.IsActive == null ? true : railwayModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRailwayMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public MessageEF DeleteRailway(RailwayModel railwayModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@RailwayID",railwayModel.RailwayID,
                        "@operation",3,
                        "@userId",railwayModel.CreatedBy,
                        "@UserLoginID",railwayModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspRailwayMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        public RailwayModel EditRailway(RailwayModel railwayModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@RailwayID", railwayModel.RailwayID);

                var result = Connection.Query<RailwayModel>("uspRailwayMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    railwayModel = result.FirstOrDefault();
                }

                return railwayModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                railwayModel = null;
            }
        }
        #endregion

        #region Update
        public MessageEF UpdateRailway(RailwayModel railwayModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@RailwayID", railwayModel.RailwayID);
                p.Add("@RailwayName", railwayModel.RailwayName);
                p.Add("@RailwayZoneID", railwayModel.RailwayZoneID);
                p.Add("@RailwaySlidingName", railwayModel.RailwaySlidingName);
                p.Add("@RailwaySlidingType", railwayModel.RailwaySlidingType);
                p.Add("@RailwayAuthorityName", railwayModel.RailwayAuthorityName);
                p.Add("@Address", railwayModel.Address);
                p.Add("@ContactNo", railwayModel.ContactNo);
                p.Add("@MailID", railwayModel.MailID);
                p.Add("@userId", railwayModel.CreatedBy);
                p.Add("@UserLoginID", railwayModel.CreatedBy);
                p.Add("@IsActive", railwayModel.IsActive == null ? true : railwayModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspRailwayMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public List<RailwayModel> ViewRailway(RailwayModel railwayModel)
        {
            List<RailwayModel> listRailwayModel = new List<RailwayModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                var result = Connection.Query<RailwayModel>("uspRailwayMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listRailwayModel = result.ToList();
                }

                return listRailwayModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listRailwayModel = null;
            }
        }
        #endregion
    }
}
