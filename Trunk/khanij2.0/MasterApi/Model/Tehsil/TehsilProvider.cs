using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.Tehsil
{
    public class TehsilProvider : RepositoryBase, ITehsilProvider
    {
        public TehsilProvider(IConnectionFactory connectionFactory) : base(connectionFactory)
        {

        }

        #region Add
        public MessageEF AddTehsil(TehsilModel tehsilModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@TehsilID",0);
                p.Add("@TehsilName", tehsilModel.TehsilName);
                p.Add("@TehsilCode", tehsilModel.TehsilCode);
                p.Add("@DistrictID", tehsilModel.DistrictID); 
                p.Add("@RegionalID", tehsilModel.RegionalID);
                p.Add("@StateID", tehsilModel.StateID);
                p.Add("@userId", tehsilModel.CreatedBy);
                p.Add("@UserLoginID", tehsilModel.CreatedBy);
                p.Add("@IsActive", tehsilModel.IsActive == null ? true : tehsilModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspTehsilMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public MessageEF DeleteTehsil(TehsilModel tehsilModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@TehsilID",tehsilModel.TehsilID,
                        "@operation",3,
                        "@userId",tehsilModel.CreatedBy,
                        "@UserLoginID",tehsilModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspTehsilMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        public TehsilModel EditTehsil(TehsilModel tehsilModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@TehsilID", tehsilModel.TehsilID);

                var result = Connection.Query<TehsilModel>("uspTehsilMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    tehsilModel = result.FirstOrDefault();
                }

                return tehsilModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                tehsilModel = null;
            }
        }
        #endregion

        #region Update
        public MessageEF UpdateTehsil(TehsilModel tehsilModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation",2);
                p.Add("@TehsilID", tehsilModel.TehsilID);
                p.Add("@TehsilName", tehsilModel.TehsilName);
                p.Add("@TehsilCode", tehsilModel.TehsilCode);
                p.Add("@DistrictID", tehsilModel.DistrictID);
                p.Add("@RegionalID", tehsilModel.RegionalID);
                p.Add("@StateID", tehsilModel.StateID);
                p.Add("@userId", tehsilModel.CreatedBy);
                p.Add("@UserLoginID", tehsilModel.CreatedBy);
                p.Add("@IsActive", tehsilModel.IsActive == null ? true : tehsilModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspTehsilMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        public List<TehsilModel> ViewTehsil(TehsilModel tehsilModel)
        {
            List<TehsilModel> listTehsilModel = new List<TehsilModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@DistrictID",tehsilModel.DistrictID);
                var result = Connection.Query<TehsilModel>("uspTehsilMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listTehsilModel = result.ToList();
                }

                return listTehsilModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listTehsilModel = null;
            }
        }
        #endregion
    }
}
