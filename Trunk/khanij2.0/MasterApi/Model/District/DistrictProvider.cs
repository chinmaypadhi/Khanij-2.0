// ***********************************************************************
//  Class Name               : DistrictProvider
//  Description              : Add,View,Edit,Update,Delete District details
//  Created By               : Akshaya Dalei
//  Created On               : 01 Feb 2021
// ***********************************************************************
using Dapper;
using MasterApi.Factory;
using MasterApi.Repository;
using MasterEF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MasterApi.Model.District
{
    public class DistrictProvider : RepositoryBase,IDistrictProvider
    {
        /// <summary>
        /// Constructor declaration
        /// </summary>
        /// <param name="districtProvider"></param>
        public DistrictProvider(IConnectionFactory connectionFactory):base(connectionFactory)
        {

        }
        /// <summary>
        /// Add District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Add
        public MessageEF AddDistrict(DistrictModel districtModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 1);
                p.Add("@DistrictID",0);
                p.Add("@DistrictName", districtModel.DistrictName);
                p.Add("@DistrictCode", districtModel.DistrictCode);
                p.Add("@RegionalID", districtModel.RegionalID);
                p.Add("@StateID", districtModel.StateID);
                p.Add("@userId", districtModel.CreatedBy);
                p.Add("@UserLoginID", districtModel.CreatedBy);
                p.Add("@IsActive", districtModel.IsActive == null ? true : districtModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspDistrictMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// <summary>
        /// Delete District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Delete
        public MessageEF DeleteDistrict(DistrictModel districtModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {
                object[] objArray = new object[] {
                        "@DistrictID",districtModel.DistrictID,
                        "@operation",3,
                        "@userId",districtModel.CreatedBy,
                        "@UserLoginID",districtModel.CreatedBy
            };
                DynamicParameters _param = new DynamicParameters();
                _param = objArray.ToDynamicParameters("result");
                var result = Connection.Query<string>("uspDistrictMasterOperation", _param, commandType: System.Data.CommandType.StoredProcedure);
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
        /// <summary>
        /// Edit District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Edit
        public DistrictModel EditDistrict(DistrictModel districtModel)
        {
            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation", 4);
                param.Add("@DistrictID", districtModel.DistrictID);

                var result = Connection.Query<DistrictModel>("uspDistrictMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    districtModel = result.FirstOrDefault();
                }

                return districtModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                districtModel = null;
            }
        }
        #endregion
        /// <summary>
        /// Update District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region Update
        public MessageEF UpdateDistrict(DistrictModel districtModel)
        {
            MessageEF objMessage = new MessageEF();
            try
            {

                var p = new DynamicParameters();
                p.Add("@operation", 2);
                p.Add("@DistrictID", districtModel.DistrictID);
                p.Add("@DistrictName", districtModel.DistrictName);
                p.Add("@DistrictCode", districtModel.DistrictCode);
                p.Add("@RegionalID", districtModel.RegionalID);
                p.Add("@StateID", districtModel.StateID);
                p.Add("@userId", districtModel.CreatedBy);
                p.Add("@UserLoginID", districtModel.CreatedBy);
                p.Add("@IsActive", districtModel.IsActive == null ? true : districtModel.IsActive);
                p.Add("result", dbType: DbType.Int32, direction: ParameterDirection.Output);
                Connection.Query<int>("uspDistrictMasterOperation", p, commandType: CommandType.StoredProcedure);
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
        /// <summary>
        /// View District details in view
        /// </summary>
        /// <param name="districtModel"></param>
        /// <returns></returns>
        #region View
        public List<DistrictModel> ViewDistrict(DistrictModel districtModel)
        {
            List<DistrictModel> listDistrictModel = new List<DistrictModel>();


            try
            {

                DynamicParameters param = new DynamicParameters();
                param.Add("@operation",4);
                param.Add("@RegionalID", districtModel.RegionalID);
                var result = Connection.Query<DistrictModel>("uspDistrictMasterOperation", param, commandType: System.Data.CommandType.StoredProcedure);

                if (result.Count() > 0)
                {

                    listDistrictModel = result.ToList();
                }

                return listDistrictModel;



            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {

                listDistrictModel = null;
            }
        }
        #endregion
    }
}
